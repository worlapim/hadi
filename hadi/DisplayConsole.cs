
namespace hadi
{
    internal static class DisplayConsole
    {
        public static void WaitInput(string message, bool autoplay)
        {
            Print(message);
            if (autoplay)
            {
                Thread.Sleep(2000);
            }
            else
            {
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        public static int ReadIntFromConsole(string message)
        {
            bool success = false;
            int number = 0;
            while (!success)
            {
                Print(message);
                string? input = Console.ReadLine();
                if (Int32.TryParse(input, out number) && number > 0)
                {
                    success = true;
                }
                else
                {
                    Console.WriteLine($"Zadejte celé číslo větčí než 0. ");
                }
            }
            return number;
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }
    }
}
