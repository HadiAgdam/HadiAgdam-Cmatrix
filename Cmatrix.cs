using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class Cmatrix
    {
        private static Random r = new Random();
        private static Random r1 = new Random();
        private static BlockingCollection<Position> queue = new BlockingCollection<Position>(new ConcurrentQueue<Position>());

        private static List<string> words = new List<string>()
        {
             "i++", "C#", "Android Developer", ".NET developer", "Visual Studio", "Batman",
            "Hacker", "Loading....", "Database", "Ronin", "Killer", "Hadi", "Hadi Agdam",
            "Kotlin", "Iran", "Moz", "Banana"
        };


        private static void set(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
        {
            queue.Add(new Position(x, y, c, color));
        }

        private static void applyChanges()
        {
            foreach (var p in queue.GetConsumingEnumerable())
            {
                Program.set(p.x, p.y, p.c, p.color);
            }
        }


        private static bool special(int x, int y)
        {
            List<Special> specials = new List<Special>()
            {
                new Special(55, 20, "Hadi Agdam", ConsoleColor.Red),
                //new Special(100, 45, "The King", ConsoleColor.Blue)
            };

            foreach (Special s in specials)
            {
                if (y == s.y)
                {
                    for (int i = 0; i < s.text.Length; i++)
                        if (s.x + i == x)
                        {
                            set(x, y, s.text[i], s.color);
                            return true;
                        }
                }
            }


            return false;
        }

        private static char getRandomChar()
        {
            // A -> Z : 65 -> 90
            // a -> z : 97 -> 122
            return (char)(r.Next(0, 2) == 1 ? r.Next(65, 91) : r.Next(97, 122));
        }



        private static void c(int x, int y)
        {
            List<Position> l = new List<Position>();
            int delay = 100;

            string text = words[r1.Next(0, words.Count)];

            for (int i = 0; i < text.Length; i++)
            {
                char c1 = text[i];
                if (!special(x, y + i)) set(x, y + i, text[i], ConsoleColor.White);
                if (i > 0 && !special(x, y + i - 1)) set(x, y + i - 1, text[i - 1], ConsoleColor.Green);
                l.Add(new Position(x, y + i, c1));
                Thread.Sleep(delay);
            }
            var last = l[l.Count - 1];
            set(x, last.y, last.c, ConsoleColor.Green);
            foreach (Position p in l)
            {
                if (!special(p.x, p.y))
                    set(p.x, p.y, p.c, ConsoleColor.DarkGray);
                
                Thread.Sleep(delay / 2);
            }
            Thread.Sleep((int)(delay * 2.5));
            foreach (Position p in l)
            {
                if (!special(p.x, p.y))
                    set(p.x, p.y, ' ', ConsoleColor.Black);
                Thread.Sleep(delay / 2);
            }

        }

        private static void t()
        {
            r = new Random();
            int x = r.Next(0, Program.width + 20);
            int y = r.Next(0, Program.height - 20);

            c(x, y);

        }


        public static void Do()
        {
            var renderThread = new Thread(applyChanges)
            {
                IsBackground = true
            };
            renderThread.Start();

            while (true)
            {
                Thread tr = new Thread(t);
                tr.Start();
                Thread.Sleep(5);
            }
        }


    }


    class Position
    {
        public int x, y;
        public char c;
        public ConsoleColor color;
        public Position(int x, int y, char c, ConsoleColor color = ConsoleColor.White)
        {
            this.x = x;
            this.y = y;
            this.c = c;
            this.color = color;
        }
    }

    class Special
    {
        public int x, y;
        public string text;
        public ConsoleColor color;

        public Special(int x, int y, string text, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.text = text;
            this.color = color;
        }
    }

}
