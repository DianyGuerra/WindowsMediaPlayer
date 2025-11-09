using System;

namespace AudioVisualizationTest
{
    public static class AudioDataSimulator
    {
        private static Random random = new Random();
        private static float timeAccumulator = 0;

        public static float[] GenerateAudioData(int bands = 8)
        {
            timeAccumulator += 0.1f;
            float[] data = new float[bands];

            for (int i = 0; i < bands; i++)
            {
                // Combinación de patrones sinusoidales y ruido
                float sinePattern = (float)Math.Abs(Math.Sin(timeAccumulator * (i + 1) * 0.3f));
                float noise = (float)random.NextDouble() * 0.4f;
                float pulse = (float)Math.Max(0, Math.Sin(timeAccumulator * 2 - i * 0.5f)) * 0.3f;

                data[i] = Clamp(sinePattern * 0.6f + noise * 0.3f + pulse, 0.1f, 1.0f);
            }

            return data;
        }

        public static float[] GenerateBeatData(int bands = 8)
        {
            timeAccumulator += 0.05f;
            float[] data = new float[bands];

            // Simular patrones de música electrónica
            float kick = (float)Math.Max(0, Math.Sin(timeAccumulator * 4)) * 0.8f;
            float snare = (float)Math.Max(0, Math.Sin(timeAccumulator * 2 - 0.5f)) * 0.6f;
            float hihat = (float)(random.NextDouble() * 0.4f + 0.1f);

            data[0] = kick;  // Bajos (kick)
            data[1] = kick * 0.7f;
            data[2] = snare; // Medios (snare)
            data[3] = snare * 0.5f;
            data[4] = hihat; // Agudos (hihat)
            data[5] = hihat * 0.8f;
            data[6] = hihat * 0.6f;
            data[7] = hihat * 0.4f;

            return data;
        }

        // Método auxiliar para clamping
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
