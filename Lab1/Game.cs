using System;

namespace Lab1
{
    public class Game
    {
        private static int _idSeed = 32000;

        private static readonly Random Random = new Random();

        public static void StartGame(GameAccount firstPlayer, GameAccount secondPlayer, int rating)
        {
            if (Random.Next(0, 2) == 0)
            {
                firstPlayer.WinGame(_idSeed, secondPlayer, rating);
                secondPlayer.LoseGame(_idSeed, firstPlayer, rating);
            }
            else
            {
                firstPlayer.LoseGame(_idSeed, secondPlayer, rating);
                secondPlayer.WinGame(_idSeed, firstPlayer, rating);
            }

            _idSeed++;
        }
    }
}