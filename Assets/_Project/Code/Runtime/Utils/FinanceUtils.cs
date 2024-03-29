namespace _Project.Code.Runtime.Utils
{
    public static class FinanceUtils
    {
        public static string PriceToText(int value)
        {
            if (value == 0)
                return "FREE";
            return $"{value}$";
        }
    }
}