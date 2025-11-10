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
            this.panelVisualizer = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.lstboxSongsList = new System.Windows.Forms.ListBox();
            this.lblSongsList = new System.Windows.Forms.Label();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.timerVisualizer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelVisualizer
            // 
            this.panelVisualizer.BackColor = System.Drawing.Color.Black;
            this.panelVisualizer.Location = new System.Drawing.Point(12, 12);
            this.panelVisualizer.Name = "panelVisualizer";
            this.panelVisualizer.Size = new System.Drawing.Size(710, 509);
            this.panelVisualizer.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 527);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(710, 125);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1015, 574);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 74);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadFile.Image = global::Windows_Media_Player___Proyecto_Unidad_1.Properties.Resources.loadfile;
            this.btnLoadFile.Location = new System.Drawing.Point(729, 433);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 74);
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
            this.lstboxSongsList.ItemHeight = 19;
            this.lstboxSongsList.Location = new System.Drawing.Point(729, 46);
            this.lstboxSongsList.Name = "lstboxSongsList";
            this.lstboxSongsList.Size = new System.Drawing.Size(349, 365);
            this.lstboxSongsList.TabIndex = 5;
            this.lstboxSongsList.SelectedIndexChanged += new System.EventHandler(this.lstboxSongsList_SelectedIndexChanged);
            // 
            // lblSongsList
            // 
            this.lblSongsList.AutoSize = true;
            this.lblSongsList.Font = new System.Drawing.Font("Sitka Banner", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSongsList.Location = new System.Drawing.Point(729, 13);
            this.lblSongsList.Name = "lblSongsList";
            this.lblSongsList.Size = new System.Drawing.Size(159, 30);
            this.lblSongsList.TabIndex = 6;
            this.lblSongsList.Text = "Lista de canciones";
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Font = new System.Drawing.Font("Sitka Banner", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.Location = new System.Drawing.Point(951, 433);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(127, 52);
            this.btnUpdateList.TabIndex = 7;
            this.btnUpdateList.Text = "Actualizar Lista";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // timerVisualizer
            // 
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1090, 660);
            this.Controls.Add(this.btnUpdateList);
            this.Controls.Add(this.lblSongsList);
            this.Controls.Add(this.lstboxSongsList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.panelVisualizer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Media Player";
            this.TransparencyKey = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelVisualizer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lstboxSongsList;
        private System.Windows.Forms.Label lblSongsList;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.Timer timerVisualizer;
    }
}

