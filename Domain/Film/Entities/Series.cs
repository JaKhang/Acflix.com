using Domain.Film.ObjectValues;

namespace Domain.Film.Entities
{
    public class Series : Film
    {
        public readonly ISet<Episode> Episodes = new HashSet<Episode>();
        public bool IsComplated { get; set; }


        public void AddEpisode(string name, string label, Source source)
        {
            if (IsComplated) throw new BusinessException("Series film cant not add episode because film is completed !");
            int index = Episodes.Count + 1;
            Episode episode = new(name, index, source, label is not null ? label : index.ToString(), this.Id);
            Episodes.Add(episode);
        }




    }
}
