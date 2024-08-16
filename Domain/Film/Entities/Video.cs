using Domain.Base;

namespace Domain.Film.Entities;

public class Video : Entity
{
    public Video()
    {
    }

    public Video(long duration, int quality, bool precess, string reference)
    {
        Duration = duration;
        Quality = quality;
        Precess = precess;
        Reference = reference;
    }

    public long Duration { get; protected set; }
    public int Quality { get; protected set; }
    public bool Precess { get; protected set; }
    public string Reference { get; protected set; }
}