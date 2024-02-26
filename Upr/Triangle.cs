
namespace Upr_1
{
    public class Triangle<T>
    {
        // getInstance

        // constructor

        // if the sum of two nubers is greater than the third

        private T sideA;
        private T sideB;
        private T sideC;

        public Triangle(T sideA, T sideB, T sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public static bool GetInstance(T sideA, T sideB, T sideC, out Triangle<T>? triangle)
        {
            
            if (typeof(T) != typeof(float) && typeof(T) != typeof(int))
            {
                triangle = null;
                return false;
            }

            double a = Convert.ToDouble(sideA);
            double b = Convert.ToDouble(sideB);
            double c = Convert.ToDouble(sideC);
            
            if (a + b > c && a + c > b && b + c > a)
            {
                triangle = new Triangle<T>(sideA, sideB, sideC);
                Console.WriteLine("Triangle created");
                return true;
            }
            else
            {
                triangle = null;
                Console.WriteLine("NOT A VALID TRIANGLE");
                return false;
            }
        }
    }
}
