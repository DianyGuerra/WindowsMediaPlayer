using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Media_Player___Proyecto_Unidad_1.Visualizations;



namespace Windows_Media_Player___Proyecto_Unidad_1
{
    public partial class frmPrincipal : Form
    {
        private List<ItemSong> songsList = new List<ItemSong>();  // Lista interna para almacenar las canciones
        AudioAnalyzer analyzer = new AudioAnalyzer();

        private BaseVisualizer currentVisualizer;



        public frmPrincipal()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.settings.autoStart = false; //No reproducir automáticamente

            LoadSongs(); // carga automática al iniciar la aplicación
            lstboxSongsList.SelectedIndexChanged += lstboxSongsList_SelectedIndexChanged;  // Suscribirse al evento de cambio de selección

            timerVisualizer.Interval = 30; // ~33 fps
            timerVisualizer.Tick += (s, e) => panelVisualizer.Invalidate();
            timerVisualizer.Start();

            currentVisualizer = new SunVisualizer(); // animación activa por defecto

            panelVisualizer.Paint += (s, e) =>
            {
                if (currentVisualizer != null && analyzer != null)
                    currentVisualizer.Draw(e.Graphics, analyzer, panelVisualizer.ClientRectangle);
            };

            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic,
            null, panelVisualizer, new object[] { true });

        }

        //Método que detecta el cambio de estado del reproductor
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            switch (axWindowsMediaPlayer1.playState)
            {
                case WMPLib.WMPPlayState.wmppsPlaying:// reproducir
                    analyzer.Start();
                    break;

                case WMPLib.WMPPlayState.wmppsPaused:// pausar
                    //analyzer.IsPaused = true;  // pausar análisis
                    break;

                case WMPLib.WMPPlayState.wmppsStopped:// detener
                    analyzer.Stop();   // detener captura
                    break;
            }
        }

        //Metodo para cargar un archivo de audio específico
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();  //Crear un nuevo cuadro de diálogo para abrir archivos
            ofd.Filter = "Archivos de audio|*.mp3;*.wav";  //Establecer el filtro para mostrar solo archivos de audio
            if (ofd.ShowDialog() == DialogResult.OK)  //Mostrar el cuadro de diálogo y verificar si se seleccionó un archivo
            {
                axWindowsMediaPlayer1.URL = ofd.FileName;  //Establecer la URL del reproductor al archivo seleccionado cuando el usuario haga clic en Aceptar
            }
            axWindowsMediaPlayer1.Ctlcontrols.play(); //Reproducir el archivo seleccionado
        }


        //Metodo que detecta el cambio de selección en la lista de canciones
        private void lstboxSongsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstboxSongsList.SelectedItem is ItemSong selectedSong)  //Verificamos que el elemento seleccionado sea de tipo ItemSong
            {
                for(int i = 0; i < axWindowsMediaPlayer1.currentPlaylist.count; i++)  //Iteramos sobre cada elemento de la lista de reproducción actual del reproductor
                {
                    var item = axWindowsMediaPlayer1.currentPlaylist.get_Item(i);  //Obtenemos el elemento en la posición i
                    if (item.sourceURL == selectedSong.Path)  //Comparamos la ruta del elemento con la ruta del objeto ItemSong seleccionado
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.playItem(item);  //Si coinciden ambas rutas reproducimos el elemento encontrado
                        break;
                    }
                }
            }
        }

        //Boton para actualizar la lista de canciones
        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            LoadSongs();  //Recargamos la lista de canciones
        }

        //Boton para salir de la aplicación
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Metodo para cargar las canciones desde la carpeta de música del usuario
        private void LoadSongs()
        {
            try
            {
                lstboxSongsList.Items.Clear(); //Limpiamos el control de la lista
                songsList.Clear(); // Limpiamos la lista de canciones interna

                string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic); //Obtenemos la ruta de la carpeta de música del usuario
                string[] songs = Directory.GetFiles(musicFolder, "*.*", SearchOption.TopDirectoryOnly)
                                          .Where(f => f.EndsWith(".mp3") || f.EndsWith(".wav"))
                                          .ToArray(); //Obtenemos todos los archivos de audio en la carpeta de música
                WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("MyPlaylist");  //Creamos una nueva lista de reproducción

                foreach (string song in songs) //Iteramos sobre cada archivo de audio encontrado en la carpeta de mmúsica del sistema
                {
                    var item = new ItemSong { Name = Path.GetFileNameWithoutExtension(song), Path = song }; //Creamos un nuevo objeto ItemSong con el nombre y la ruta del archivo
                    songsList.Add(item);  //Agregamos el objeto a la lista interna
                    lstboxSongsList.Items.Add(item);  //Agregamos el objeto al control de la lista para mostrarlo en la interfaz

                    WMPLib.IWMPMedia media = axWindowsMediaPlayer1.newMedia(song); //Creamos un nuevo objeto IWMPMedia para el archivo de audio
                    playlist.appendItem(media);  //Agregamos el objeto IWMPMedia a la lista de reproducción
                }

                axWindowsMediaPlayer1.currentPlaylist = playlist;  //Asignamos la lista de reproducción al reproductor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las canciones: " + ex.Message);
            }
        }

    }
}
