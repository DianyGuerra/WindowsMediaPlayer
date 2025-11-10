using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Dsp; // para FFT(Transformadas de fourier) - extrae el espectro de frecuencia

namespace Windows_Media_Player___Proyecto_Unidad_1
{
    internal class AudioAnalyzer
    {
        private WasapiLoopbackCapture capture;
        private const int fftSize = 1024;
        private readonly Complex[] complexBuffer = new Complex[fftSize];
        private readonly float[] sampleBuffer = new float[fftSize];
        private int sampleIndex = 0;

        public float Amplitude { get; private set; }
        public float[] FrequencyBands { get; private set; } = new float[32];

        public bool IsRunning { get; private set; }

        public void Start()
        {
            if (IsRunning) return;

            capture = new WasapiLoopbackCapture();
            capture.DataAvailable += OnDataAvailable;
            capture.StartRecording();
            IsRunning = true;
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            int bytesPerSample = capture.WaveFormat.BitsPerSample / 8;
            int sampleCount = e.BytesRecorded / bytesPerSample;
            float sum = 0f;

            for (int i = 0; i < sampleCount; i++)
            {
                float sample = BitConverter.ToInt16(e.Buffer, i * bytesPerSample) / 32768f;

                // RMS
                sum += sample * sample;

                // FFT buffer
                sampleBuffer[sampleIndex] = sample;
                complexBuffer[sampleIndex].X = sample;
                complexBuffer[sampleIndex].Y = 0;

                sampleIndex++;
                if (sampleIndex >= fftSize)
                {
                    // Calcular FFT
                    FastFourierTransform.FFT(true, (int)Math.Log(fftSize, 2.0), complexBuffer);
                    ComputeFrequencyBands();
                    sampleIndex = 0;
                }
            }

            float amp = (float)Math.Sqrt(sum / sampleCount);

            // 🔹 Amplificar un poco los valores medios y bajos
            amp *= 1.4f; // puedes probar 1.5f – 2.5f

            // 🔹 Aplicar una ligera curva logarítmica para que los cambios sean más notorios
            Amplitude = (float)Math.Log10(1 + amp * 9f);

            // 🔹 Limitar por seguridad (evita valores mayores a 1)
            if (Amplitude > 1f) Amplitude = 1f;

        }

        private void ComputeFrequencyBands()
        {
            // 32 bandas de frecuencia promediadas
            for (int i = 0; i < FrequencyBands.Length; i++)
            {
                int start = (int)(i * (fftSize / 2) / FrequencyBands.Length);
                int end = (int)((i + 1) * (fftSize / 2) / FrequencyBands.Length);

                float avg = 0f;
                for (int j = start; j < end; j++)
                {
                    avg += (float)Math.Sqrt(complexBuffer[j].X * complexBuffer[j].X + complexBuffer[j].Y * complexBuffer[j].Y);
                }
                FrequencyBands[i] = avg / (end - start);
            }
        }

        public void Stop()
        {
            if (!IsRunning) return;

            capture.StopRecording();
            capture.Dispose();
            capture = null;
            IsRunning = false;
        }
    }

}



