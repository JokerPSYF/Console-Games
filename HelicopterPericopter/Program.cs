using System;
using System.Text;
using System.Threading;


namespace HelicopterPericopter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int count = 0;
            while (true)
            {
                Thread.Sleep(100);
                Console.Clear();
                string a = @"===============^ ==    --    ";
                string b = @" -    --    == ^================";
                if (count % 2 == 0)
                {
                    count++;
                    Console.WriteLine(@" ===============^ ==    --    -");
                   // Console.Write($"\r{a}", b);
                    Console.WriteLine(@"                ^              ");
                    Console.WriteLine(@" ''|        /--|||----------\");
                    Console.WriteLine(@"==<0>=======|      [ 0 ][ 0 ]\");
                    Console.WriteLine(@"   |/       \     ===   W  ===\");
                    Console.WriteLine(@"             \________________/");
                    Console.WriteLine(@"                ||       ||    ");
                    Console.WriteLine(@"             /----------------\");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    count++;     //     -    --    ==^================
                    Console.WriteLine(@"  -    --    == ^================");
                    Console.WriteLine(@"                ^              ");
                    Console.WriteLine(@" ''|/       /--|||----------\");
                    Console.WriteLine(@"==<0>=======|      [ 0 ][ 0 ]\");
                    Console.WriteLine(@"   |        \     ===   W  ===\");
                    Console.WriteLine(@"             \________________/");
                    Console.WriteLine(@"                ||       ||    ");
                    Console.WriteLine(@"             /----------------\");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            for (int i = 0; i < 5; ++i)
            {
                Console.Write("\r{0}%   ", i);
            }
        }
    }
}
