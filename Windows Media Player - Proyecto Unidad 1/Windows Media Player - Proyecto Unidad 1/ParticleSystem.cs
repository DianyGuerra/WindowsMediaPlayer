using System;
using System.Drawing;

namespace AudioVisualizationTest
{
    public class ParticleSystem
    {
        private Particle[] particles;
        private Random random = new Random();
        private const int PARTICLE_COUNT = 150;
        private PointF center;
        private float baseRadius;

        public class Particle
        {
            public float Angle { get; set; }
            public float Radius { get; set; }
            public float BaseRadius { get; set; }
            public float Speed { get; set; }
            public Color Color { get; set; }
            public float Size { get; set; }
            public float Opacity { get; set; }
        }

        public void Update(float[] audioData, int width, int height)
        {
            if (particles == null)
            {
                InitializeParticles(width, height);
            }

            float bassIntensity = audioData != null && audioData.Length > 0 ? audioData[0] : 0.1f;
            float midIntensity = audioData != null && audioData.Length > 2 ? audioData[2] : 0.1f;
            float radiusVariation = bassIntensity * baseRadius * 0.6f;

            for (int i = 0; i < particles.Length; i++)
            {
                var particle = particles[i];

                particle.Angle += particle.Speed * (1 + bassIntensity * 0.5f);
                if (particle.Angle > 2 * Math.PI)
                    particle.Angle -= (float)(2 * Math.PI);

                float phase = (i % 4) * 0.5f;
                float audioEffect = radiusVariation * (float)Math.Sin(particle.Angle * 2 + phase);
                particle.Radius = particle.BaseRadius + audioEffect;

                particle.Size = 1 + (float)Math.Abs(Math.Sin(particle.Angle * 3)) * 4 * bassIntensity;
                particle.Opacity = 120 + (int)(midIntensity * 135);
            }
        }

        private void InitializeParticles(int width, int height)
        {
            center = new PointF(width / 2, height / 2);
            baseRadius = Math.Min(width, height) * 0.2f;

            particles = new Particle[PARTICLE_COUNT];

            for (int i = 0; i < PARTICLE_COUNT; i++)
            {
                particles[i] = new Particle
                {
                    Angle = (float)(random.NextDouble() * 2 * Math.PI),
                    BaseRadius = baseRadius * (0.7f + (float)random.NextDouble() * 0.6f),
                    Radius = baseRadius,
                    Speed = 0.008f + (float)random.NextDouble() * 0.02f,
                    Size = 1 + random.Next(4),
                    Opacity = 120 + random.Next(135)
                };

                float hue = (i / (float)PARTICLE_COUNT) * 360f;
                particles[i].Color = ColorFromHue(hue);
            }
        }

        private Color ColorFromHue(float hue)
        {
            int r, g, b;
            float h = hue / 60f;
            int i = (int)Math.Floor(h);
            float f = h - i;
            float q = 1 - f;

            switch (i % 6)
            {
                case 0: r = 255; g = (int)(f * 255); b = 0; break;
                case 1: r = (int)(q * 255); g = 255; b = 0; break;
                case 2: r = 0; g = 255; b = (int)(f * 255); break;
                case 3: r = 0; g = (int)(q * 255); b = 255; break;
                case 4: r = (int)(f * 255); g = 0; b = 255; break;
                default: r = 255; g = 0; b = (int)(q * 255); break;
            }

            return Color.FromArgb(200, r, g, b);
        }

        public void Render(Graphics g, int width, int height)
        {
            if (particles == null) return;

            // Círculos guía
            for (int i = 1; i <= 3; i++)
            {
                float radius = baseRadius * i * 0.3f;
                using (Pen circlePen = new Pen(Color.FromArgb(30, Color.White), 1))
                {
                    g.DrawEllipse(circlePen,
                        center.X - radius, center.Y - radius,
                        radius * 2, radius * 2);
                }
            }

            // Partículas
            foreach (var particle in particles)
            {
                float x = center.X + particle.Radius * (float)Math.Cos(particle.Angle);
                float y = center.Y + particle.Radius * (float)Math.Sin(particle.Angle);

                using (Brush particleBrush = new SolidBrush(Color.FromArgb(
                    (int)particle.Opacity, particle.Color)))
                {
                    g.FillEllipse(particleBrush,
                        x - particle.Size, y - particle.Size,
                        particle.Size * 2, particle.Size * 2);
                }
            }

            // Centro
            using (Brush centerBrush = new SolidBrush(Color.FromArgb(150, Color.White)))
            {
                g.FillEllipse(centerBrush, center.X - 3, center.Y - 3, 6, 6);
            }
        }
    }
}