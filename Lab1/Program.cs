using System;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            var startRating = random.Next(100, 151);

            GameAccount danil = new GameAccount("Danil", startRating);
            GameAccount liza = new GameAccount("Liza", startRating);
            GameAccount bot = new GameAccount("Bot", startRating);

            Console.WriteLine($"\nPlayers: {danil.UserName}, {liza.UserName}, {bot.UserName}." +
                              $"\nThe starting rating of all players: {startRating}\n");

            for (int i = 0; i < 2; i++)
            {
                Game.StartGame(liza, danil, random.Next(10, 51));
                Game.StartGame(liza, bot, random.Next(10, 51));
                Game.StartGame(bot, danil, random.Next(10, 51));
            }

            Console.WriteLine(liza.GetStats() + "\n" + danil.GetStats() + "\n" + bot.GetStats());
        }
    }
}