namespace FunctionProvider.Math
{
    using SM = System.Math;

    public class Math
    {
        public static double Pi()
        {
            return SM.PI;
        }

        public static decimal RoundingToTwo(decimal numberToRound)
        {
            return SM.Round(numberToRound, 2);
        }
    }
}
