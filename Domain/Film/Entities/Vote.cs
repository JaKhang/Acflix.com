using Domain.User.ObjectValue;
using Domain.Base;
using Domain.Base.ValueObjects;

namespace Domain.Film.Entities
{
    public class Vote : Entity
    {
        private static readonly int MAX_SCORE = 5;
        private static readonly int MIN_SCORE = 1;

        public Vote(int score, ID userId, ID filmId) : base(new())
        {
            Score = score;
            UserId = userId;
            FilmId = filmId;
        }

        public Vote() : base(new ID())
        {

        }

        public int Score { get; internal set; }
        public ID FilmId { get; internal set; }
        public void SetScore(int Score)
        {
            if (Score < MIN_SCORE && Score > MAX_SCORE)
                throw new ArgumentException("Score value is beteewn " + MIN_SCORE + " and " + MAX_SCORE);

            this.Score = Score;

        }

        public void SetUserId(ID UserId)
        {
            ArgumentNullException.ThrowIfNull(UserId);
            this.UserId = UserId;
        }
        public ID UserId { get; internal set; }
    }
}
