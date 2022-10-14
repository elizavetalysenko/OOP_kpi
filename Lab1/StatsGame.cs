namespace Lab1
{
    public class StatsGame
    {
        public enum ResultGame
        {
            Win,
            Lose
        }
        public ResultGame Result { get; }
        public string OpponentName { get; }
        public int IdGame { get; }
        public int Rating { get; }

        public StatsGame(int idGame, string opponentName, ResultGame resultGame, int rating)
        {
            IdGame = idGame;
            OpponentName = opponentName;
            Result = resultGame;
            Rating = rating;
        }
    }
}