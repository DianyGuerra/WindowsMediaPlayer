using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizer
{
    internal abstract class EfectoVisual
    {
        public string Nombre { get; protected set; }

        // Método abstracto que cada efecto implementará
        public abstract void Dibujar(Graphics g, Rectangle area, float intensidad);
    }
}
