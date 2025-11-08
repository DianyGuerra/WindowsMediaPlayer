using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Windows_Media_Player___Proyecto_Unidad_1
{
    public partial class frmPrincipal : Form
    {
        private string ruta;
        AudioAnalyzer analyzer = new AudioAnalyzer();

        Random rand = new Random();
        float[] amplitudes;
        int numBarras = 20;
        float[] barHeights;
        float[] barVelocities;


        public frmPrincipal()
        {
            ruta = "";
            InitializeComponent();
            /*this.DoubleBuffered = true;

            amplitudes = new float[numBarras];
            timerBarras.Start();
            this.panelBarras.Paint += new PaintEventHandler(panelBarras_Paint);
            this.timerBarras.Tick += new EventHandler(timerBarras_Tick);
            barHeights = new float[numBarras];
            barVelocities = new float[numBarras];*/

        }

        private void timerBarras_Tick(object sender, EventArgs e)
        {
            /*if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Sincronizar la posición de NAudio con WMP
                analyzer.SyncPosition(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);

                // Usar los datos de frecuencia
                float[] freqs = analyzer.FrequencyBands;
                int min = Math.Min(numBarras, freqs.Length);

                for (int i = 0; i < min; i++)
                {
                    // Nueva altura basada en frecuencia real (0–1)
                    float target = Math.Min(1f, freqs[i] * 6f);

                    // Si la barra sube (nuevo valor mayor), sube rápido
                    if (target > barHeights[i])
                    {
                        barVelocities[i] = (target - barHeights[i]) * 0.5f; // impulso
                    }
                    else
                    {
                        // Si baja, cae más lento
                        barVelocities[i] -= 0.015f; // gravedad visual
                    }

                    // Actualizar altura
                    barHeights[i] += barVelocities[i];

                    // Limitar entre 0 y 1
                    if (barHeights[i] < 0) barHeights[i] = 0;
                    if (barHeights[i] > 1) barHeights[i] = 1;

                    // Suavizado del impulso
                    barVelocities[i] *= 0.9f;
                }


                panelBarras.Invalidate();
            }*/
        }

        

        //Método que detecta el cambio de estado del reproductor
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (axWindowsMediaPlayer1.playState)
            {
                case WMPLib.WMPPlayState.wmppsPlaying:// reproducir
                    analyzer.IsPaused = false; // reanudar análisis
                    break;

                case WMPLib.WMPPlayState.wmppsPaused:// pausar
                    analyzer.IsPaused = true;  // pausar análisis
                    break;

                case WMPLib.WMPPlayState.wmppsStopped:// detener
                    analyzer.Stop();           // detener análisis
                    break;
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de audio|*.mp3;*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                axWindowsMediaPlayer1.URL = ruta;
            }
        }

    }
}
