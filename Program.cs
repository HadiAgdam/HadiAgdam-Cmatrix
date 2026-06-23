using System;
using System.Threading;

namespace ConsoleApplication1
{
     static class Program
    {

        public static void set(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public static int width = 100;
        public static int height = 50;

        static void Main(string[] args)
        {
            Console.WindowHeight = 55;
            Console.WindowWidth = 128;

            Console.CursorVisible = false;


            //Test1();
            //Boom.Do();

            Cmatrix.Do();
            Console.Read();
        }


        private static void Test1()
        {
            for (int i = 0; i < height; i++)
            {
                set(0, i, '*');
                set(width - 1, i, '*');
            }

            for (int i = 0; i < width; i++)
            {
                set(i, 0, '#');
                set(i, height - 1, '#');
            }

        }


    }
}
