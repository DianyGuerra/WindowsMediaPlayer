using System.Drawing;
using System.Windows.Forms;

namespace AudioVisualizationTest
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuración del formulario
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(1000, 700);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Visualizaciones de Animación";

            // Panel de controles
            Panel controlPanel = new Panel
            {
                BackColor = Color.FromArgb(40, 40, 40),
                Dock = DockStyle.Top,
                Height = 50
            };

            // Botones
            btnStart = new Button
            {
                Text = "Iniciar",
                Location = new Point(10, 10),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnStop = new Button
            {
                Text = "Detener",
                Location = new Point(100, 10),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSwitch = new Button
            {
                Text = "Cambiar",
                Location = new Point(190, 10),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnMode = new Button
            {
                Text = "Modo Beat",
                Location = new Point(280, 10),
                Size = new Size(80, 30),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // ComboBox
            comboVisualizations = new ComboBox
            {
                Location = new Point(370, 10),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboVisualizations.Items.AddRange(new object[] { "Ondas Sinusoidales", "Partículas Orbitantes" });
            comboVisualizations.SelectedIndex = 0;

            // Label de estado
            statusLabel = new Label
            {
                Text = "Listo - Presiona Iniciar",
                ForeColor = Color.White,
                Location = new Point(530, 15),
                Size = new Size(300, 20),
                Font = new Font("Arial", 10)
            };

            // Agregar controles al panel
            controlPanel.Controls.AddRange(new Control[]
            {
                btnStart, btnStop, btnSwitch, btnMode,
                comboVisualizations, statusLabel
            });

            this.Controls.Add(controlPanel);

            // CONECTAR EVENTOS - ESTO ES IMPORTANTE
            btnStart.Click += new System.EventHandler(this.btnStart_Click);
            btnStop.Click += new System.EventHandler(this.btnStop_Click);
            btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            btnMode.Click += new System.EventHandler(this.btnMode_Click);
            comboVisualizations.SelectedIndexChanged += new System.EventHandler(this.comboVisualizations_SelectedIndexChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);

            this.ResumeLayout(false);
        }

        #endregion
    }
}