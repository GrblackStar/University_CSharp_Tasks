
namespace Upr_1
{
    public class Circle : Shape, IEllipse
    {
        float radius = 0;

        public override float Area()
        {
            return radius * radius * (float)Math.PI;
        }

        public override float Circumference()
        {
            return 2 * radius * (float)Math.PI;
        }

        public bool isEllipse()
        {
            return false;
        }
    }
}
