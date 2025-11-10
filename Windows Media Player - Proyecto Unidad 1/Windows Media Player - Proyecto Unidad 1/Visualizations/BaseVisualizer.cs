using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizations
{
    internal abstract class BaseVisualizer
    {
        /// <summary>
        /// Dibuja la animación en el área indicada.
        /// </summary>
        public abstract void Draw(Graphics g, AudioAnalyzer analyzer, Rectangle area);
    }
}
