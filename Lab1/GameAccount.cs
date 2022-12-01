using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; }
        private int StartRating { get; }
        private readonly List<StatsResultGame> _statsGames = new List<StatsResultGame>();
        public int GamesCount => _statsGames.Count;

        public int CurrentRating
        {
            get
            {
                int rating = StartRating;
                foreach (var item in _statsGames)
                {
                    rating += item.RatingOperation;
                }

                return rating;
            }
        }

        public GameAccount(string userName, int startRating)
        {
            UserName = userName;
            StartRating = startRating;
        }

        public void WinGame(Game game)
        {
            _statsGames.Add(new StatsResultGame(game.Id, game.Loser, StatsResultGame.ResultGame.Win,
                game.RatingGame, game.RatingGame));
        }

        public void LoseGame(Game game)
        {
            _statsGames.Add(new StatsResultGame(game.Id, game.Winner, StatsResultGame.ResultGame.Lose,
                game.RatingGame, CheckLoserRating(game.RatingGame)));
        }

        private int CheckLoserRating(int rating)
        {
            if (CurrentRating - rating < 1)
            {
                return 1 - CurrentRating;
            }

            return -rating;
        }

        public string GetStats()
        {
            StringBuilder str =
                new StringBuilder(
                    $"Stats game {UserName}`s\nTotal games - {GamesCount}\nCurrent rating player - {CurrentRating}\n");
            str.AppendLine("Game List:\nId Game\tOpponent name\tRating game\tResult game\tRating Operation");
            foreach (var item in _statsGames)
            {
                if (item.Result == StatsResultGame.ResultGame.Win)
                {
                    str.AppendLine(
                        $"{item.IdGame}\t{item.Opponent.UserName}\t\t{item.Rating}\t\t{item.Result}\t\t+{item.RatingOperation}");
                }
                else
                {
                    str.AppendLine(
                        $"{item.IdGame}\t{item.Opponent.UserName}\t\t{item.Rating}\t\t{item.Result}\t\t{item.RatingOperation}");
                }
            }

            return str.AppendLine().ToString();
        }
    }
}