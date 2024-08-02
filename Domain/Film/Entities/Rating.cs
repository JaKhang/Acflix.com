using Domain.User.ObjectValue;
using Domain.Base;

namespace Domain.Film.Entities
{
    public class Rating : Entity
    {
        private static readonly int MAX_SCORE = 5;
        private static readonly int MIN_SCORE = 1;

        public Rating(int score, UserId userId) : base(new())
        {
            Score = score;
            UserId = userId;
        }

        public int Score { get; internal set; }

        public void SetScore(int Score)
        {
            if (Score < MIN_SCORE && Score > MAX_SCORE)
                throw new ArgumentException("Score value is beteewn " + MIN_SCORE + " and " + MAX_SCORE);

            this.Score = Score;

        }

        public void SetUserId(UserId UserId)
        {
            ArgumentNullException.ThrowIfNull(UserId);
            this.UserId = UserId;
        }
        public UserId UserId { get; internal set; }
    }
}
