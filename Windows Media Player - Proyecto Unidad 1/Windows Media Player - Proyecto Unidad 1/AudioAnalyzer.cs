using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Dsp; // para FFT(Transformadas de fourier) - extrae el espectro de frecuencias

namespace Windows_Media_Player___Proyecto_Unidad_1
{
    internal class AudioAnalyzer
    {
        private AudioFileReader reader;
        private Thread analyzeThread;
        private bool isRunning = false;

        public bool IsPaused { get; set; } = false;
        public float[] FrequencyBands { get; private set; } // valores para las barras

        public AudioAnalyzer()
        {
            FrequencyBands = new float[30]; // 16 barras por defecto
        }

        public void Start(string filePath)
        {
            Stop(); // por si ya había un análisis previo

            reader = new AudioFileReader(filePath);
            isRunning = true;

            analyzeThread = new Thread(() =>
            {
                int fftLength = 1024; // tamaño de FFT, potencia de 2
                Complex[] fftBuffer = new Complex[fftLength];
                float[] sampleBuffer = new float[fftLength];

                while (isRunning && reader != null)
                {
                    if (IsPaused)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    int read = reader.Read(sampleBuffer, 0, fftLength);
                    if (read == 0) break;

                    // Copiar las muestras al buffer FFT
                    for (int i = 0; i < fftLength; i++)
                    {
                        fftBuffer[i].X = (float)(sampleBuffer[i] * FastFourierTransform.HammingWindow(i, fftLength));
                        fftBuffer[i].Y = 0;
                    }

                    // Aplicar FFT
                    FastFourierTransform.FFT(true, (int)Math.Log(fftLength, 2.0), fftBuffer);

                    // Calcular magnitud por banda
                    int bands = FrequencyBands.Length;
                    for (int b = 0; b < bands; b++)
                    {
                        int start = (int)(Math.Pow(2, b * (10.0 / bands)));
                        int end = Math.Min((int)(Math.Pow(2, (b + 1) * (10.0 / bands))), fftLength / 2);

                        float sum = 0;
                        for (int i = start; i < end; i++)
                        {
                            float mag = (float)Math.Sqrt(fftBuffer[i].X * fftBuffer[i].X + fftBuffer[i].Y * fftBuffer[i].Y);
                            sum += mag;
                        }

                        FrequencyBands[b] = sum / (end - start + 1);
                    }

                    Thread.Sleep(4);
                }
            });

            analyzeThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
            reader?.Dispose();
            analyzeThread?.Join();
        }

        public void SyncPosition(double seconds)
        {
            if (reader != null)
            {
                try
                {
                    reader.CurrentTime = TimeSpan.FromSeconds(seconds);
                }
                catch { /* Ignorar errores si se intenta saltar fuera del rango */ }
            }
        }

    }


}
