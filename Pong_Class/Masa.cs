using System;

namespace Pong_Class
{
    internal class Masa
    {
        public int Genislik { get; set; }
        public int Yukseklik { get; set; }

        public Masa(int genislik = 70, int yukseklik = 20)
        {
            Genislik = genislik;
            Yukseklik = yukseklik;
        }

        public void MasaCiz()
        {
            for (int i = 1; i <= Genislik; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }

            for (int i = 1; i <= Genislik; i++)
            {
                Console.SetCursorPosition(i, Yukseklik + 1);
                Console.Write("-");
            }

            for (int i = 1; i <= Yukseklik; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }

            for (int i = 1; i <= Yukseklik; i++)
            {
                Console.SetCursorPosition(Genislik + 1, i);
                Console.Write("|");
            }

            Console.SetCursorPosition(0, 0);
            Console.Write("*");
            Console.SetCursorPosition(0, Yukseklik + 1);
            Console.Write("*");
            Console.SetCursorPosition(Genislik + 1, 0);
            Console.Write("*");
            Console.SetCursorPosition(Genislik + 1, Yukseklik + 1);
            Console.Write("*");
        }
    }
}