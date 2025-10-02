namespace Checkmate.Utils
{
    public static class EnumUtils
    {
        public static List<T> GetFlags<T>(this T input) where T : Enum
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .Where(value => input.HasFlag(value) && !Convert.ToInt64(value).Equals(0))
                       .ToList();
        }
    }
}
