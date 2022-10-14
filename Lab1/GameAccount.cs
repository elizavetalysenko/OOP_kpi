using System;
using System.Collections.Generic;

namespace Lab1
{
    public class GameAccount
    {
        public string UserName { get; }
        private int StartRating { get; }
        private readonly List<StatsGame> _statsGames = new List<StatsGame>();
        public int GamesCount => _statsGames.Count;
        public int CurrentRating
        {
            get
            {
                int rating = StartRating;
                foreach (var item in _statsGames)
                {
                    if (item.Result == StatsGame.ResultGame.Win)
                    {
                        rating += item.Rating;
                    }
                    else
                    {
                        if (rating - item.Rating < 1)
                        {
                            rating = 1;
                        }
                        else
                        {
                            rating -= item.Rating;
                        }
                    }
                }

                return rating;
            }
        }

        public GameAccount(string userName, int startRating)
        {
            UserName = userName;
            StartRating = startRating;
        }
        
        public void WinGame(int id, GameAccount opponent, int rating)
        {
            CheckRating(rating);
            _statsGames.Add(new StatsGame(id, opponent.UserName, StatsGame.ResultGame.Win, rating));
        }

        public void LoseGame(int id, GameAccount opponent, int rating)
        {
            CheckRating(rating);
            _statsGames.Add(new StatsGame(id, opponent.UserName, StatsGame.ResultGame.Lose, rating));
        }

        private void CheckRating(int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The rating played must be positive");
            }
        }

        public void GetStats()
        {
            Console.WriteLine($"Stats game {UserName}`s\nTotal games - {GamesCount}\nCurrent rating player - {CurrentRating}");
            Console.WriteLine("Game List:\nId Game\tOpponent name\tRating game\tResult game\tPost-game rating");
            int rating = StartRating;
            foreach (var item in _statsGames)
            {
                if (item.Result == StatsGame.ResultGame.Win)
                {
                    rating += item.Rating;
                }
                else
                {
                    if (rating - item.Rating < 1)
                    {
                        rating = 1;
                    }
                    else
                    {
                        rating -= item.Rating;
                    }
                }
                Console.WriteLine($"{item.IdGame}\t{item.OpponentName}\t\t{item.Rating}\t\t{item.Result}\t\t{rating}");
            }
            Console.WriteLine();
        }


    }
}