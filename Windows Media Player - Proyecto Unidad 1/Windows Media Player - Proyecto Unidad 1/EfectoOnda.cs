using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizer
{
    internal class EfectoOnda : EfectoVisual
    {
        private PointF[] wavePoints;
        private PointF[] wavePoints2;
        private float tiempo = 0;
        private const float VELOCIDAD_ONDA = 0.08f;
        private const float ESCALA_AMPLITUD = 60f;

        public EfectoOnda()
        {
            Nombre = "Onda";
        }

        public override void Dibujar(Graphics g, Rectangle area, float intensidad)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(10, 10, 25));

            int width = area.Width;
            int height = area.Height;

            if (wavePoints == null || wavePoints.Length != width)
                InicializarOnda(width, height);

            tiempo += VELOCIDAD_ONDA;

            for (int x = 0; x < width; x++)
            {
                float normalizedX = (x / (float)width) * (float)(4 * Math.PI);

                // Amplitudes de frecuencia
                float bass = intensidad * ESCALA_AMPLITUD;
                float mid = intensidad * ESCALA_AMPLITUD * 0.7f;
                float high = intensidad * ESCALA_AMPLITUD * 0.4f;

                // Ondas principales
                float wave1 = bass * (float)Math.Sin(1.5f * normalizedX + tiempo);
                float wave2 = mid * (float)Math.Sin(3.0f * normalizedX + tiempo * 1.3f);
                float wave3 = high * (float)Math.Sin(6.0f * normalizedX + tiempo * 1.7f);

                float y = (height / 2) + wave1 + wave2 + wave3;
                wavePoints[x] = new PointF(x, y);

                // Ondas secundarias
                float wave4 = bass * 0.5f * (float)Math.Sin(2.0f * normalizedX + tiempo * 0.7f);
                float wave5 = mid * 0.3f * (float)Math.Sin(4.0f * normalizedX + tiempo * 1.1f);
                float y2 = (height / 2) + wave4 + wave5;
                wavePoints2[x] = new PointF(x, y2);
            }

            // Efecto de fondo tenue
            using (SolidBrush fondo = new SolidBrush(Color.FromArgb(30, 0, 0, 30)))
                g.FillRectangle(fondo, area);

            // Onda secundaria
            using (Pen secondaryPen = new Pen(Color.FromArgb(100, Color.MediumVioletRed), 2))
            {
                for (int i = 0; i < wavePoints2.Length - 1; i++)
                    g.DrawLine(secondaryPen, wavePoints2[i], wavePoints2[i + 1]);
            }

            // Onda principal con brillo y color dinámico
            Color baseColor = ColorFromHSV((tiempo * 40) % 360, 0.8, 1.0);
            using (Pen glowPen = new Pen(Color.FromArgb(60, baseColor), 6))
            using (Pen mainPen = new Pen(baseColor, 3))
            {
                for (int i = 0; i < wavePoints.Length - 1; i += 2)
                    g.DrawLine(glowPen, wavePoints[i], wavePoints[i + 1]);

                for (int i = 0; i < wavePoints.Length - 1; i++)
                    g.DrawLine(mainPen, wavePoints[i], wavePoints[i + 1]);
            }

            // Puntos brillantes decorativos
            using (Brush punto = new SolidBrush(Color.FromArgb(200, Color.Yellow)))
            {
                for (int i = 0; i < wavePoints.Length; i += 20)
                    g.FillEllipse(punto, wavePoints[i].X - 2, wavePoints[i].Y - 2, 4, 4);
            }
        }

        private void InicializarOnda(int width, int height)
        {
            wavePoints = new PointF[width];
            wavePoints2 = new PointF[width];
            for (int i = 0; i < width; i++)
            {
                wavePoints[i] = new PointF(i, height / 2);
                wavePoints2[i] = new PointF(i, height / 2);
            }
        }

        // Conversión HSV → RGB (para color dinámico tipo arcoíris)
        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            hue = (hue % 360 + 360) % 360;
            int hi = (int)Math.Floor(hue / 60.0) % 6;
            double f = hue / 60.0 - Math.Floor(hue / 60.0);

            double vD = value * 255.0;
            int v = (int)Math.Round(vD);
            int p = (int)Math.Round(vD * (1.0 - saturation));
            int q = (int)Math.Round(vD * (1.0 - f * saturation));
            int t = (int)Math.Round(vD * (1.0 - (1.0 - f) * saturation));

            switch (hi)
            {
                case 0: return Color.FromArgb(255, v, t, p);
                case 1: return Color.FromArgb(255, q, v, p);
                case 2: return Color.FromArgb(255, p, v, t);
                case 3: return Color.FromArgb(255, p, q, v);
                case 4: return Color.FromArgb(255, t, p, v);
                default: return Color.FromArgb(255, v, p, q);
            }
        }
    }
}

