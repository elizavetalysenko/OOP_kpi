namespace Lab1
{
    public class StatsResultGame
    {
        public enum ResultGame
        {
            Win,
            Lose
        }
        public ResultGame Result { get; }
        public GameAccount Opponent { get; }
        public int IdGame { get; }
        public int Rating { get; }
        public int RatingOperation { get; }

        public StatsResultGame(int idGame, GameAccount opponent, ResultGame resultGame, int rating, int ratingOperation)
        {
            IdGame = idGame;
            Opponent = opponent;
            Result = resultGame;
            Rating = rating;
            RatingOperation = ratingOperation;
        }
    }
}