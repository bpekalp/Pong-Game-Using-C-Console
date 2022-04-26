using System;
using System.Threading;

namespace Pong_Class
{
    public class Pong

    {
        private int Genislik, Yukseklik;
        private Masa masa;
        private Raket raket1, raket2;
        private Top top;
        private ConsoleKeyInfo keyInfo;
        private ConsoleKey consoleKey;

        public Pong(int genislik = 70, int yukseklik = 20)
        {
            Genislik = genislik;
            Yukseklik = yukseklik;
            masa = new Masa(genislik, yukseklik);
            top = new Top(Genislik / 2, Yukseklik / 2);
        }

        public void Hazirlik()
        {
            raket1 = new Raket(2, Yukseklik);
            raket2 = new Raket(Genislik - 1, Yukseklik);
            top.X = Genislik / 2;
            top.Y = Yukseklik / 2;
            top.Yon = 0;
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
        }

        private void Klavye()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }

        public void SkorYaz()
        {
            Console.SetCursorPosition(Genislik / 2 - 2, Yukseklik / 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{top.Skor1} - {top.Skor2}");
        }

        public void Calistir()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Soldaki oyuncu W ve S, sağdaki oyuncu yukarı ve aşağı yön tuşlarıyla oynayacaktır.");
            Console.WriteLine("Oyun bir oyuncu 7'ye ulaşınca bitecektir.");

            for (int i = 5; i >= 0; i--)
            {
                Console.Write("Oyun ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(i);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" saniye sonra başlayacaktır, iyi oyunlar!");
                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.White;

            while (top.Skor1 < 7 && top.Skor2 < 7)
            {
                Console.Clear();
                Hazirlik();

                while (top.X != 1 && top.X != Genislik - 1)
                {
                    Klavye();
                    switch (consoleKey)
                    {
                        case ConsoleKey.W:
                            raket1.Yukari();
                            break;

                        case ConsoleKey.S:
                            raket1.Asagi();
                            break;

                        case ConsoleKey.UpArrow:
                            raket2.Yukari();
                            break;

                        case ConsoleKey.DownArrow:
                            raket2.Asagi();
                            break;
                    }
                    consoleKey = ConsoleKey.G;
                    top.Carpma(raket1, raket2);
                    Console.Clear();
                    masa.MasaCiz();
                    this.SkorYaz();
                    raket1.RaketCiz();
                    raket2.RaketCiz();
                    top.TopCiz();
                    top.SkorSayaci();
                    Thread.Sleep(45);
                }
            }
        }

        public void Bitir()
        {
            Console.Clear();
            if (top.Skor1 > top.Skor2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. oyuncu kazandı!");
                Console.Write("Skor: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(top.Skor1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(top.Skor2);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("2. oyuncu kazandı!");
                Console.Write("Skor: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(top.Skor1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" - ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(top.Skor2);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}