using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Media_Player___Proyecto_Unidad_1.Visualizations
{
    internal class SunVisualizer : BaseVisualizer
    {
        private float baseRadius = 50f;
        private int barCount = 100;
        private float smoothRadius = 200f; // radio suavizado
        private float velocity = 0.5f;       // velocidad del “rebote”
        private float damping = 0.15f;     // fricción (entre 0.1 y 0.3)
        private float stiffness = 0.50f;   // fuerza del resorte (entre 0.3 y 0.5)

        public override void Draw(Graphics g, AudioAnalyzer analyzer, Rectangle bounds)
        {
            if (analyzer == null) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Black);

            float centerX = bounds.Width / 2f;
            float centerY = bounds.Height / 2f;

            // 🎚️ Amplitud del audio → radio objetivo
            float targetRadius = baseRadius + analyzer.Amplitude * 100f;

            // 🧮 Interpolación elástica (resorte)
            float displacement = targetRadius - smoothRadius;
            velocity += displacement * stiffness;
            velocity *= (1 - damping);
            smoothRadius += velocity;

            // === Círculo central ===
            float circleX = centerX - smoothRadius;
            float circleY = centerY - smoothRadius;
            float circleDiameter = smoothRadius * 2;

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(200, 0, 180, 180)))
                g.FillEllipse(brush, circleX, circleY, circleDiameter, circleDiameter);


                // === Barras radiales ===
                float[] freqs = analyzer.FrequencyBands;
            if (freqs == null) return;

            int usableBars = Math.Min(barCount, freqs.Length);
            float angleStep = 360f / usableBars;

            for (int i = 0; i < usableBars; i++)
            {
                float angle = i * angleStep;
                double radians = angle * Math.PI / 180.0;

                float barHeight = freqs[i] * 2500f;
                barHeight = Math.Min(barHeight, 60f);

                float x1 = centerX + (float)Math.Cos(radians) * smoothRadius;
                float y1 = centerY + (float)Math.Sin(radians) * smoothRadius;
                float x2 = centerX + (float)Math.Cos(radians) * (smoothRadius + barHeight);
                float y2 = centerY + (float)Math.Sin(radians) * (smoothRadius + barHeight);

                using (Pen pen = new Pen(GetColorForFrequency(i, usableBars), 3))
                    g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        // === Helpers ===
        private Color GetColorForFrequency(int index, int total)
        {
            float hue = (float)index / total;
            return FromHSL(hue, 1f, 0.5f);
        }

        private Color FromHSL(float h, float s, float l)
        {
            h *= 360f;
            if (s == 0f) return Color.FromArgb((int)(l * 255), (int)(l * 255), (int)(l * 255));

            float q = l < 0.5f ? l * (1 + s) : l + s - (l * s);
            float p = 2 * l - q;
            float r = HueToRGB(p, q, h + 120);
            float g = HueToRGB(p, q, h);
            float b = HueToRGB(p, q, h - 120);
            return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private float HueToRGB(float p, float q, float h)
        {
            if (h < 0) h += 360;
            if (h > 360) h -= 360;
            if (h < 60) return p + (q - p) * h / 60;
            if (h < 180) return q;
            if (h < 240) return p + (q - p) * (240 - h) / 60;
            return p;
        }


    }
}

