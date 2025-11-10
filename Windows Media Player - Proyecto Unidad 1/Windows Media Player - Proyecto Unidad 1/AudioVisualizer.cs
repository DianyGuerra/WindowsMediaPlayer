using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Esta clase se encarga de administrar los efectos que se mostrarán en el panel de efectos
using System.Drawing;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizer
{
    internal class AudioVisualizer
    {
        private List<EfectoVisual> efectos;
        private EfectoVisual efectoActual;
        private Random rnd = new Random();

        public AudioVisualizer()
        {
            efectos = new List<EfectoVisual>()
            {
                new EfectoBarras(),
                new EfectoSol(),
                new EfectoParticulas(),
                new EfectoOnda()
            };

            efectoActual = efectos[0];
        }

        public List<EfectoVisual> ObtenerEfectos() => efectos;
        public void CambiarEfecto(int index) => efectoActual = efectos[index];
        public void EfectoAleatorio() => efectoActual = efectos[rnd.Next(efectos.Count)];

        public void Dibujar(Graphics g, Rectangle area, float intensidad)
        {
            efectoActual.Dibujar(g, area, intensidad);
        }

        public string NombreEfectoActual => efectoActual.Nombre;
    }
}
