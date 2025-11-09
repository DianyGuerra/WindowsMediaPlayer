using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace AudioVisualizationTest
{
    public partial class MainForm : Form
    {
        private WaveVisualization waveViz;
        private ParticleSystem particleSystem;
        private bool showWaves = true;

        private Thread animationThread;
        private bool isRunning;
        private Bitmap buffer;
        private Graphics bufferGraphics;

        private Label statusLabel;
        private Button btnStart, btnStop, btnSwitch, btnMode;
        private ComboBox comboVisualizations;

        private bool useBeatMode = false;

        public MainForm()
        {
            InitializeComponent();
            InitializeVisualizations();
        }

        private void InitializeVisualizations()
        {
            waveViz = new WaveVisualization();
            particleSystem = new ParticleSystem();
            UpdateBuffer();
        }

        private void UpdateBuffer()
        {
            buffer?.Dispose();
            bufferGraphics?.Dispose();
            buffer = new Bitmap(Math.Max(1, ClientSize.Width), Math.Max(1, ClientSize.Height));
            bufferGraphics = Graphics.FromImage(buffer);
        }

        // MÉTODOS DE EVENTO CON NOMBRES CORRECTOS
        private void btnStart_Click(object sender, EventArgs e)
        {
            StartAnimation();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAnimation();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            SwitchVisualization();
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            ToggleMode();
        }

        private void comboVisualizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboVisualizations_SelectedIndexChanged(sender, e);
        }

        private void StartAnimation()
        {
            if (isRunning) return;

            isRunning = true;
            statusLabel.Text = $"Ejecutando: {(showWaves ? "Ondas" : "Partículas")}";

            animationThread = new Thread(AnimationLoop);
            animationThread.IsBackground = true;
            animationThread.Start();

            Console.WriteLine("Animación INICIADA"); // Para debug
        }

        private void StopAnimation()
        {
            isRunning = false;
            animationThread?.Join(1000);
            statusLabel.Text = "Detenido";
            this.Invalidate();

            Console.WriteLine("Animación DETENIDA"); // Para debug
        }

        private void SwitchVisualization()
        {
            showWaves = !showWaves;
            comboVisualizations.SelectedIndex = showWaves ? 0 : 1;
            statusLabel.Text = $"Ejecutando: {(showWaves ? "Ondas" : "Partículas")}";

            Console.WriteLine($"Cambiado a: {(showWaves ? "Ondas" : "Partículas")}"); // Para debug
        }

        private void ToggleMode()
        {
            useBeatMode = !useBeatMode;
            btnMode.Text = useBeatMode ? "Modo Suave" : "Modo Beat";
            statusLabel.Text = useBeatMode ? "Modo Beat Activado" : "Modo Suave Activado";
        }

        private void ComboVisualizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            showWaves = (comboVisualizations.SelectedIndex == 0);
            if (isRunning)
            {
                statusLabel.Text = $"Ejecutando: {(showWaves ? "Ondas" : "Partículas")}";
            }
        }

        private void AnimationLoop()
        {
            Console.WriteLine("Hilo de animación iniciado"); // Para debug

            while (isRunning)
            {
                try
                {
                    // Generar datos de audio
                    float[] audioData = useBeatMode ?
                        AudioDataSimulator.GenerateBeatData() :
                        AudioDataSimulator.GenerateAudioData();

                    // Actualizar visualización actual
                    if (showWaves)
                        waveViz.Update(audioData, ClientSize.Width, ClientSize.Height);
                    else
                        particleSystem.Update(audioData, ClientSize.Width, ClientSize.Height);

                    // Redibujar
                    this.Invoke(new Action(() => this.Invalidate()));

                    Thread.Sleep(16); // ~60 FPS
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en animación: {ex.Message}");
                }
            }

            Console.WriteLine("Hilo de animación terminado"); // Para debug
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (buffer == null) return;

            try
            {
                // Limpiar buffer
                bufferGraphics.Clear(Color.Black);

                // Renderizar visualización actual
                if (showWaves)
                    waveViz.Render(bufferGraphics, ClientSize.Width, ClientSize.Height);
                else
                    particleSystem.Render(bufferGraphics, ClientSize.Width, ClientSize.Height);

                // Dibujar información
                DrawInfoPanel(bufferGraphics);

                // Copiar buffer a pantalla
                e.Graphics.DrawImage(buffer, 0, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en Paint: {ex.Message}");
            }
        }

        private void DrawInfoPanel(Graphics g)
        {
            string info = $"{(showWaves ? "Ondas Sinusoidales" : "Partículas Orbitantes")} | " +
                         $"{(useBeatMode ? "Modo Beat" : "Modo Suave")} | " +
                         $"Tamaño: {ClientSize.Width}x{ClientSize.Height}";

            using (Brush textBrush = new SolidBrush(Color.White))
            using (Font infoFont = new Font("Arial", 10))
            {
                g.DrawString(info, infoFont, textBrush, 10, ClientSize.Height - 30);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdateBuffer();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAnimation();
            bufferGraphics?.Dispose();
            buffer?.Dispose();
        }
    }
}