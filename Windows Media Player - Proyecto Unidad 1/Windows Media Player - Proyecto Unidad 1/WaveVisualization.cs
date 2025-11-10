using System;
using System.Drawing;

namespace AudioVisualizationTest
{
    public class WaveVisualization
    {
        private PointF[] wavePoints;
        private PointF[] wavePoints2;
        private float timeCounter = 0;
        private const float WAVE_SPEED = 0.08f;
        private const float AMPLITUDE_SCALE = 60f;

        public void Update(float[] audioData, int width, int height)
        {
            if (wavePoints == null || wavePoints.Length != width)
            {
                InitializeWave(width, height);
            }

            timeCounter += WAVE_SPEED;

            for (int x = 0; x < width; x++)
            {
                float normalizedX = (x / (float)width) * (float)(4 * Math.PI);

                float bassAmplitude = audioData[0] * AMPLITUDE_SCALE;
                float midAmplitude = audioData[2] * AMPLITUDE_SCALE * 0.7f;
                float highAmplitude = audioData[6] * AMPLITUDE_SCALE * 0.4f;

                float wave1 = bassAmplitude * (float)Math.Sin(1.5f * normalizedX + timeCounter);
                float wave2 = midAmplitude * (float)Math.Sin(3.0f * normalizedX + timeCounter * 1.3f);
                float wave3 = highAmplitude * (float)Math.Sin(6.0f * normalizedX + timeCounter * 1.7f);

                float y = (height / 2) + wave1 + wave2 + wave3;
                wavePoints[x] = new PointF(x, y);

                // Segunda onda complementaria
                float wave4 = bassAmplitude * 0.5f * (float)Math.Sin(2.0f * normalizedX + timeCounter * 0.7f);
                float wave5 = midAmplitude * 0.3f * (float)Math.Sin(4.0f * normalizedX + timeCounter * 1.1f);
                float y2 = (height / 2) + wave4 + wave5;
                wavePoints2[x] = new PointF(x, y2);
            }
        }

        private void InitializeWave(int width, int height)
        {
            wavePoints = new PointF[width];
            wavePoints2 = new PointF[width];
            for (int i = 0; i < width; i++)
            {
                wavePoints[i] = new PointF(i, height / 2);
                wavePoints2[i] = new PointF(i, height / 2);
            }
        }

        public void Render(Graphics g, int width, int height)
        {
            if (wavePoints == null || wavePoints.Length < 2) return;

            // Onda secundaria
            using (Pen secondaryPen = new Pen(Color.FromArgb(100, Color.Magenta), 2))
            {
                for (int i = 0; i < wavePoints2.Length - 1; i++)
                {
                    g.DrawLine(secondaryPen, wavePoints2[i], wavePoints2[i + 1]);
                }
            }

            // Onda principal
            using (Pen primaryPen = new Pen(Color.Cyan, 3))
            using (Pen glowPen = new Pen(Color.FromArgb(80, Color.Cyan), 6))
            {
                for (int i = 0; i < wavePoints.Length - 1; i += 2)
                {
                    g.DrawLine(glowPen, wavePoints[i], wavePoints[i + 1]);
                }

                for (int i = 0; i < wavePoints.Length - 1; i++)
                {
                    g.DrawLine(primaryPen, wavePoints[i], wavePoints[i + 1]);
                }
            }

            // Puntos destacados
            using (Brush pointBrush = new SolidBrush(Color.Yellow))
            {
                for (int i = 0; i < wavePoints.Length; i += 15)
                {
                    g.FillEllipse(pointBrush, wavePoints[i].X - 2, wavePoints[i].Y - 2, 4, 4);
                }
            }
        }
    }
}