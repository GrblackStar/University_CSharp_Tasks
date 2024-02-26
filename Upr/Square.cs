
namespace Upr_1
{
    public class Square : Rectangle
    {
        public float side;
        public override float Area()
        {
            return side * side;
        }

        public override float Circumference()
        {
            return side * 4;
        }

        public bool isEllipse()
        {
            return false;
        }

        public static float SquareArea(float squareSide)
        {
            return squareSide * squareSide;
        }

    }
}
