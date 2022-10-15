using System.Globalization;

namespace Konsol.Helpers
{
    public static class CConsole
    {
        public static void WriteLine(int value, ConsoleColor color)
        {
            Write(value.ToString(CultureInfo.CurrentCulture), color);
        }
        public static void WriteLine(decimal value, ConsoleColor color)
        {
            Write(value.ToString(CultureInfo.CurrentCulture), color);
        }
        public static void WriteLine(double value, ConsoleColor color)
        {
            Write(value.ToString(CultureInfo.CurrentCulture), color);
        }

        public static void WriteLine(string value, ConsoleColor color, params object[] values)
        {
            Write(value, color, values);
        }

        private static void Write(string value, ConsoleColor color)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(value);

            Console.ForegroundColor = temp;
        }

        private static void Write(string value, ConsoleColor color, params object[] values)
        {
            var temp = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(value, values);

            Console.ForegroundColor = temp;
        }
    }
}
