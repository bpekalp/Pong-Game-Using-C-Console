using Pong_Class;
using System;

namespace Pong_Game
{
    internal class Program
    {
        private static void Main(string[] args)

        {
            ConsoleKeyInfo secim;
            ConsoleKey secimKey;

            do
            {
                Pong pong = new Pong();
                pong.Calistir();
                pong.Bitir();
                Console.Clear();
                Console.WriteLine("Tekrar oynamak için enter'a basın.");
                secim = Console.ReadKey();
                secimKey = secim.Key;
            } while (secimKey == ConsoleKey.Enter);
        }
    }
}