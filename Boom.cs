using System;
using System.Threading;


namespace ConsoleApplication1
{
    static class Boom
    {

        static void set(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
        {
            try
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(x, y);
                Console.Write(c);
            }catch(Exception ex)
            {

            }
        }



        private static int delay = 300;


        public static void boom(int x, int y)
        {
            set(x, y - 1, '*', ConsoleColor.Red);
            set(x, y + 1, '*', ConsoleColor.Red);

            set(x - 1, y, '*', ConsoleColor.Red);
            set(x + 1, y, '*', ConsoleColor.Red);

            Thread.Sleep(delay);

            set(x, y - 1, ' ', ConsoleColor.Red);
            set(x, y + 1, ' ', ConsoleColor.Red);

            set(x - 1, y, ' ', ConsoleColor.Red);
            set(x + 1, y, ' ', ConsoleColor.Red);



            set(x - 1, y - 1, '*', ConsoleColor.Red);
            set(x + 1, y - 1, '*', ConsoleColor.Red);

            set(x - 1, y + 1, '*', ConsoleColor.Red);
            set(x + 1, y + 1, '*', ConsoleColor.Red);

            Thread.Sleep(delay);

            set(x - 1, y - 1, ' ', ConsoleColor.Red);
            set(x + 1, y - 1, ' ', ConsoleColor.Red);

            set(x - 1, y + 1, ' ', ConsoleColor.Red);
            set(x + 1, y + 1, ' ', ConsoleColor.Red);

        }

        private static void Test2Thread1()
        {
            int x = 30;
            int y = 40;
            while (true)
            {
                set(x, y, '-', ConsoleColor.White);
                for (int i = x - 10; i <= x; i++)
                {
                    set(i, y, '-', ConsoleColor.Red);
                    Thread.Sleep(100);
                    set(i, y, ' ', ConsoleColor.Red);
                }


                set(x, y, '*', ConsoleColor.Red);
                Thread.Sleep(300);
                set(x, y, ' ', ConsoleColor.Red);
                boom(x, y);
            }
        }

        public static void Do()
        {
            Thread tr = new Thread(new ThreadStart(Test2Thread1));
            tr.Start();
        }
    }
}
