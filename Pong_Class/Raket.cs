using System;

namespace Pong_Class
{
    internal class Raket
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Uzunluk { get; set; }
        private int MasaYuksekligi { get; set; }

        public Raket(int x, int masa_yukseligi)
        {
            MasaYuksekligi = masa_yukseligi;
            Uzunluk = MasaYuksekligi / 3;
            X = x;
            Y = MasaYuksekligi / 2;
        }

        public void Yukari()
        {
            if (Y - 1 - Uzunluk / 2 != 0)
            {
                Console.SetCursorPosition(X, Y + Uzunluk / 2 - 1);
                Console.Write("\0");
                Y--;
                RaketCiz();
            }
        }

        public void Asagi()
        {
            if (Y + 1 + Uzunluk / 2 != MasaYuksekligi + 2)
            {
                Console.SetCursorPosition(X, Y - Uzunluk / 2);
                Console.Write("\0");
                Y++;
                RaketCiz();
            }
        }

        public void RaketCiz()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = Y - Uzunluk / 2; i < Y + Uzunluk / 2; i++)
            {
                Console.SetCursorPosition(X, i);
                Console.Write("|");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}