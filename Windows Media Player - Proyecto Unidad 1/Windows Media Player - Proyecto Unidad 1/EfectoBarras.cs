using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizer
{
    internal class EfectoBarras : EfectoVisual
    {
        private readonly int numBarras = 48;
        private readonly float[] valoresSuavizados;
        private readonly float[] valoresObjetivo;
        private readonly Random rnd = new Random();
        private float faseColor = 0;

        public EfectoBarras()
        {
            Nombre = "Barras";
            valoresSuavizados = new float[numBarras];
            valoresObjetivo = new float[numBarras];
        }

        public override void Dibujar(Graphics g, Rectangle area, float intensidad)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(10, 10, 20));

            faseColor += 0.03f; // hace que el color se mueva lentamente
            float anchoBarra = (float)area.Width / numBarras;

            for (int i = 0; i < numBarras; i++)
            {
                // Valor objetivo aleatorio en función de la intensidad actual
                float valor = (float)(intensidad * (0.3 + rnd.NextDouble() * 0.7));

                // Suavizar el movimiento (interpolación lineal)
                valoresSuavizados[i] += (valor - valoresSuavizados[i]) * 0.15f;
                valoresObjetivo[i] = Math.Max(valoresObjetivo[i] - 0.02f, valoresSuavizados[i]);

                // Altura de la barra
                float altura = valoresObjetivo[i] * area.Height;
                float x = i * anchoBarra;

                // Evitar crear barras con dimensiones inválidas
                if (altura > 1 && anchoBarra > 1)
                {
                    RectangleF rect = new RectangleF(x, area.Height - altura, anchoBarra - 2, altura);

                    if (rect.Width > 0 && rect.Height > 0)
                    {
                        // Colores dinámicos tipo arcoíris desplazado
                        Color baseColor = ColorFromHSV((i * 10 + faseColor * 40) % 360, 0.8, 1.0);

                        // Gradiente vertical
                        using (LinearGradientBrush gradiente = new LinearGradientBrush(
                            rect,
                            Color.FromArgb(200, baseColor),
                            Color.FromArgb(20, baseColor),
                            LinearGradientMode.Vertical))
                        {
                            // Efecto de sombra
                            using (SolidBrush sombra = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
                                g.FillRectangle(sombra, x + 2, area.Height - altura + 4, anchoBarra - 2, altura);

                            // Dibuja la barra
                            g.FillRectangle(gradiente, rect);
                        }

                        // Reflejo superior suave
                        using (Pen reflejo = new Pen(Color.FromArgb(80, Color.White), 1))
                            g.DrawLine(reflejo, x, area.Height - altura, x + anchoBarra - 2, area.Height - altura);
                    }
                }
            }
        }

        // Conversión HSV → RGB para crear colores cambiantes tipo arcoíris
        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            // Normalizar hue a 0..360
            hue = (hue % 360 + 360) % 360;
            int hi = (int)Math.Floor(hue / 60.0) % 6;
            double f = hue / 60.0 - Math.Floor(hue / 60.0);

            // Convertir value (0..1) a 0..255
            double vD = value * 255.0;
            int v = (int)Math.Round(vD);
            int p = (int)Math.Round(vD * (1.0 - saturation));
            int q = (int)Math.Round(vD * (1.0 - f * saturation));
            int t = (int)Math.Round(vD * (1.0 - (1.0 - f) * saturation));

            switch (hi)
            {
                case 0:
                    return Color.FromArgb(255, v, t, p);
                case 1:
                    return Color.FromArgb(255, q, v, p);
                case 2:
                    return Color.FromArgb(255, p, v, t);
                case 3:
                    return Color.FromArgb(255, p, q, v);
                case 4:
                    return Color.FromArgb(255, t, p, v);
                default:
                    return Color.FromArgb(255, v, p, q);
            }
        }

    }
}
