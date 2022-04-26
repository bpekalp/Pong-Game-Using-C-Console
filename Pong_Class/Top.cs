using System;
using System.Threading;

namespace Pong_Class
{
    internal class Top
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Yon { get; set; }
        private int DonusX { get; set; }
        private int DonusY { get; set; }
        private int MasaGenislik { get; set; }
        private int MasaYukseklik { get; set; }

        public int Skor1 = 0, Skor2 = 0;

        public Top(int x, int y, int masa_genislik = 70, int masa_yukseklik = 20)
        {
            X = x;
            Y = y;
            DonusX = 1;
            DonusY = -1;
            MasaGenislik = masa_genislik;
            MasaYukseklik = masa_yukseklik;
        }

        public void Carpma(Raket raket1, Raket raket2)
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("\0");

            if (Y <= 1 || Y >= MasaYukseklik)
            {
                DonusY *= -1;
            }

            if (X == 3 && (raket1.Y - (raket1.Uzunluk / 2)) <= Y && (raket1.Y + (raket1.Uzunluk / 2)) > Y)
            {
                DonusX *= -1;

                if (Y == raket1.Y)
                {
                    Yon = 0;
                }
                else if ((Y >= (raket1.Y - (raket1.Uzunluk / 2)) && Y < raket1.Y) || (Y > raket1.Y && Y < (raket1.Y + (raket1.Uzunluk / 2))))
                {
                    Yon = 1;
                }
            }
            else if (X == MasaGenislik - 3 && (raket2.Y - (raket2.Uzunluk / 2)) <= Y && (raket2.Y + (raket2.Uzunluk / 2)) > Y)
            {
                DonusX *= -1;

                if (Y == raket2.Y)
                {
                    Yon = 0;
                }
                else if ((Y >= (raket2.Y - (raket2.Uzunluk / 2)) && Y < raket2.Y) || (Y > raket2.Y && Y < (raket2.Y + (raket1.Uzunluk / 2))))
                {
                    Yon = 1;
                }
            }

            switch (Yon)
            {
                case 0:
                    X += DonusX;
                    break;

                case 1:
                    X += DonusX;
                    Y += DonusY;
                    break;
            }
        }

        public void TopCiz()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(X, Y);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SkorSayaci()
        {
            if (X == 1)
            {
                Thread.Sleep(500);
                Skor2++;
            }

            if (X == MasaGenislik - 1)
            {
                Thread.Sleep(500);
                Skor1++;
            }
        }
    }
}