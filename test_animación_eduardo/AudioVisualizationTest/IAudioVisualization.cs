using System.Drawing;

namespace AudioVisualizationTest
{
    public interface IAudioVisualization
    {
        string Name { get; }
        void Initialize(int width, int height);
        void Update(float[] audioData, int width, int height);
        void Render(Graphics g, int width, int height);
        void Resize(int width, int height);
    }
}
