using System;

namespace Lab1
{
    public class Game
    {
        private static int _idSeed = 32000;
        private static Random _random = new Random();

        public int Id { get; }
        public GameAccount Winner { get; }
        public GameAccount Loser { get; }
        public int RatingGame { get; }

        private Game(GameAccount winner, GameAccount loser, int rating)
        {
            CheckRating(rating);
            Winner = winner;
            Loser = loser;
            RatingGame = rating;
            Id = _idSeed++;
        }

        private void CheckRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating played must be positive");
            }
        }

        public static Game StartGame(GameAccount firstPlayer, GameAccount secondPlayer, int rating)
        {
            Game game;
            if (_random.Next(0, 2) == 0)
            {
                game = new Game(firstPlayer, secondPlayer, rating);
            }
            else
            {
                game = new Game(secondPlayer, firstPlayer, rating);
            }

            game.Winner.WinGame(game);
            game.Loser.LoseGame(game);

            return game;
        }
    }
}