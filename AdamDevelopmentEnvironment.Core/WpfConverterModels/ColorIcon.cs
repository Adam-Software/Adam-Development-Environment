using System.Windows.Media;

namespace AdamDevelopmentEnvironment.Core.WpfConverterModels
{
    public class ColorIcon
    {
        public ColorIcon(string iconColor, Geometry iconGeometry)
        {
            IconColor = iconColor;
            IconGeometry = iconGeometry;
        }

        public string IconColor { get; private set; }
        public Geometry IconGeometry { get; private set; }
    }
}
