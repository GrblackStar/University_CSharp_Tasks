
namespace Upr_1
{
    public class Rectangle : Shape, IEllipse
    {
        float sideA = 0;
        float sideB = 0;
        public override float Area()
        {
            return sideA * sideB;
        }

        public override float Circumference()
        {
            return (sideA + sideB) * 2;
        }

        public bool isEllipse()
        {
            return false;
        }
    }
}
