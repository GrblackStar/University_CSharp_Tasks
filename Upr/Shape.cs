
namespace Upr_1
{
    public abstract class Shape
    {
        public int colorNumber {  get; set; }
        private int _color;
        public int ShapeColor
        {
            get
            {
                /*switch (colorNumber)
                {
                    case Color.Red: return 0x00FF0000;
                    case Color.Green: return 0x0000FF00;
                    case Color.Blue: return 0x000000FF;
                    default: return 0x000000FF;
                }*/
                return _color;
            }
            set
            {
                switch (colorNumber)
                {
                    case 0x00FF0000: _color = 1; break;
                    case 0x0000FF00: _color = 2; break;
                    case 0x000000FF: _color = 3; break;
                    default: _color = 1; break;
                }
            }
        }
        public abstract float Area();
        public abstract float Circumference();

        static class Color
        {
            public const int Red = 1;
            public const int Green = 2;
            public const int Blue = 3;
        }
    }

    
}
