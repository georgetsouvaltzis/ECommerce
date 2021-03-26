namespace ECommerce.Domain.DomainHelpers
{
    public class ScreenResolution
    {
        public ScreenResolution(int width, int height)
        {
            Width = width;
            Height = height;
            
        }

        public int Width { get; }
        public int Height { get; }
        
    }
}
