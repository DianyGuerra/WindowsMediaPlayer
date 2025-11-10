using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using Windows_Media_Player___Proyecto_Unidad_1.Visualizer;

namespace Windows_Media_Player___Proyecto_Unidad_1
{
    internal class EfectoSol : EfectoVisual
    {
        private float radioSuavizado = 0f; // efecto glow del círculo
        private float velocidad = 0f;  // velocidad de crecimiento del sol
        private float amortiguacion = 0.7f;  //sensibilidad del movimiento (mayor = más sensible)
        private float elasticidad = 0.35f;   // factor de elasticidad del círculo (menor = más elástico)
        private float baseRadio = 50f;  // tamaño base del sol
        private Random rnd = new Random();
        private float faseColor = 0f;

        public EfectoSol()
        {
            Nombre = "Sol pulsante";
        }

        public override void Dibujar(Graphics g, Rectangle area, float intensidad)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(8, 10, 20)); // Fondo más profundo

            float cx = area.Width / 2f;    //Calculamos el centro del área de dibujo
            float cy = area.Height / 2f;

            // Movimiento elástico con intensidad
            float radioObjetivo = baseRadio + intensidad * 90f;
            float desplazamiento = radioObjetivo - radioSuavizado;
            velocidad += desplazamiento * elasticidad;
            velocidad *= (1 - amortiguacion);
            radioSuavizado += velocidad;

            // Color dinámico del sol
            faseColor += 0.02f + intensidad * 0.04f;
            Color colorBase = ColorFromHSV((faseColor * 80) % 360, 0.9, 1.0);

            // Halo exterior suave
            float haloRadio = radioSuavizado * 1.6f;
            using (GraphicsPath haloPath = new GraphicsPath())
            {
                haloPath.AddEllipse(cx - haloRadio, cy - haloRadio, haloRadio * 2, haloRadio * 2);
                using (PathGradientBrush haloBrush = new PathGradientBrush(haloPath))
                {
                    haloBrush.CenterColor = Color.FromArgb(80, colorBase);
                    haloBrush.SurroundColors = new[] { Color.FromArgb(0, colorBase) };
                    g.FillEllipse(haloBrush, cx - haloRadio, cy - haloRadio, haloRadio * 2, haloRadio * 2);
                }
            }

            // Círculo central brillante
            using (GraphicsPath corePath = new GraphicsPath())
            {
                corePath.AddEllipse(cx - radioSuavizado, cy - radioSuavizado, radioSuavizado * 2, radioSuavizado * 2);
                using (PathGradientBrush coreBrush = new PathGradientBrush(corePath))
                {
                    coreBrush.CenterColor = Color.FromArgb(220, colorBase);
                    coreBrush.SurroundColors = new[] { Color.FromArgb(40, colorBase) };
                    g.FillEllipse(coreBrush, cx - radioSuavizado, cy - radioSuavizado, radioSuavizado * 2, radioSuavizado * 2);
                }
            }

            // Rayos dinámicos
            int barras = 125;  // Numero de barras
            float anguloPaso = 360f / barras;  // Angulo de distribución de barras
            float maxLongitud = 60f;  //altura máxima de las barras

            for (int i = 0; i < barras; i++)
            {
                double ang = i * anguloPaso * Math.PI / 180.0;

                float variacion = (float)Math.Sin((faseColor * 2) + i * 0.3f) * 0.5f + 0.5f;
                float longitud = intensidad * maxLongitud * (0.7f + variacion * 0.6f);
                float grosor = 1.5f + variacion * 2.5f;

                float x1 = cx + (float)Math.Cos(ang) * radioSuavizado;
                float y1 = cy + (float)Math.Sin(ang) * radioSuavizado;
                float x2 = cx + (float)Math.Cos(ang) * (radioSuavizado + longitud);
                float y2 = cy + (float)Math.Sin(ang) * (radioSuavizado + longitud);

                Color rayoColor = ColorFromHSV(((faseColor * 90) + i * 6) % 360, 0.8, 1.0);
                using (Pen pen = new Pen(Color.FromArgb(180, rayoColor), grosor))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    g.DrawLine(pen, x1, y1, x2, y2);
                }

                
            }

            // === Brillo central adicional (pequeño núcleo luminoso) ===
            float coreGlow = radioSuavizado * 0.3f;
            using (GraphicsPath coreGlowPath = new GraphicsPath())
            {
                coreGlowPath.AddEllipse(cx - coreGlow, cy - coreGlow, coreGlow * 2, coreGlow * 2);
                using (PathGradientBrush glowBrush = new PathGradientBrush(coreGlowPath))
                {
                    glowBrush.CenterColor = Color.FromArgb(255, Color.White);
                    glowBrush.SurroundColors = new[] { Color.FromArgb(0, Color.White) };
                    g.FillEllipse(glowBrush, cx - coreGlow, cy - coreGlow, coreGlow * 2, coreGlow * 2);
                }
            }
           
        }

        // Conversión HSV → RGB (compatible con C# 7.3)
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

