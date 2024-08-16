using Domain.Exceptions;
using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Series : Film
    {
        private readonly List<Episode> _episodes = [];
        public IReadOnlyList<Episode> Episodes => _episodes;
        public int TotalEpisode { get; protected set; }
        public int LastEpisode { get; protected set; }
        public DateTime? LastReleasedEpisodeAt { get; protected set; }


        public void AddEpisode(string name, string label, Video video)
        {
            if (Status == FilmStatus.COMPLETED) throw new BusinessException("Series film cant not add episode because film is completed !");
            int index = Episodes.Count + 1;
            Episode episode = new(name, index, video, label , Id);
            LastEpisode = index;
            LastReleasedEpisodeAt = new DateTime();
            _episodes.Add(episode);
        }




    }
}
