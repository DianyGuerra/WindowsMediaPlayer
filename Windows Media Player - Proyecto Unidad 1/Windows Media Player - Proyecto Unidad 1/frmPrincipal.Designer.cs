namespace Windows_Media_Player___Proyecto_Unidad_1
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelEfectos = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerBarras = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lstboxSongsList = new System.Windows.Forms.ListBox();
            this.lblSongsList = new System.Windows.Forms.Label();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.comboBoxEfectos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEfectos
            // 
            this.panelEfectos.BackColor = System.Drawing.Color.Black;
            this.panelEfectos.Location = new System.Drawing.Point(16, 15);
            this.panelEfectos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEfectos.Name = "panelEfectos";
            this.panelEfectos.Size = new System.Drawing.Size(947, 626);
            this.panelEfectos.TabIndex = 0;
            this.panelEfectos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEfectos_Paint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerBarras
            // 
            this.timerBarras.Enabled = true;
            this.timerBarras.Interval = 30;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1353, 706);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 91);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadFile.Image = global::Windows_Media_Player___Proyecto_Unidad_1.Properties.Resources.loadfile;
            this.btnLoadFile.Location = new System.Drawing.Point(972, 533);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(100, 91);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.UseVisualStyleBackColor = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // lstboxSongsList
            // 
            this.lstboxSongsList.BackColor = System.Drawing.Color.Silver;
            this.lstboxSongsList.Font = new System.Drawing.Font("Sitka Banner", 8.830188F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstboxSongsList.ForeColor = System.Drawing.Color.Blue;
            this.lstboxSongsList.FormattingEnabled = true;
            this.lstboxSongsList.HorizontalScrollbar = true;
            this.lstboxSongsList.ItemHeight = 21;
            this.lstboxSongsList.Location = new System.Drawing.Point(972, 57);
            this.lstboxSongsList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstboxSongsList.Name = "lstboxSongsList";
            this.lstboxSongsList.Size = new System.Drawing.Size(464, 445);
            this.lstboxSongsList.TabIndex = 5;
            this.lstboxSongsList.SelectedIndexChanged += new System.EventHandler(this.lstboxSongsList_SelectedIndexChanged);
            // 
            // lblSongsList
            // 
            this.lblSongsList.AutoSize = true;
            this.lblSongsList.Font = new System.Drawing.Font("Sitka Banner", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSongsList.Location = new System.Drawing.Point(972, 16);
            this.lblSongsList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSongsList.Name = "lblSongsList";
            this.lblSongsList.Size = new System.Drawing.Size(179, 35);
            this.lblSongsList.TabIndex = 6;
            this.lblSongsList.Text = "Lista de canciones";
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Font = new System.Drawing.Font("Sitka Banner", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.Location = new System.Drawing.Point(1268, 533);
            this.btnUpdateList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(169, 64);
            this.btnUpdateList.TabIndex = 7;
            this.btnUpdateList.Text = "Actualizar Lista";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 527);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(710, 125);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // comboBoxEfectos
            // 
            this.comboBoxEfectos.FormattingEnabled = true;
            this.comboBoxEfectos.Location = new System.Drawing.Point(1110, 556);
            this.comboBoxEfectos.Name = "comboBoxEfectos";
            this.comboBoxEfectos.Size = new System.Drawing.Size(121, 24);
            this.comboBoxEfectos.TabIndex = 8;
            this.comboBoxEfectos.SelectedIndexChanged += new System.EventHandler(this.comboBoxEfectos_SelectedIndexChanged);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1453, 812);
            this.Controls.Add(this.comboBoxEfectos);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.lblSongsList);
            this.Controls.Add(this.lstboxSongsList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panelEfectos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Media Player";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelEfectos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timerBarras;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstboxSongsList;
        private System.Windows.Forms.Label lblSongsList;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.ComboBox comboBoxEfectos;
    }
}

