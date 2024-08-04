using Domain.Base;
using Domain.Image.ValueObjects;

namespace Domain.Image.Entities
{
    public class Image : Entity
    {
        public string name;
        private readonly List<Varient> _varients;

        public Image() : base(new())
        {
            _varients = [];
        }

        public Image(string name) : base(new())
        {
            this.name = name;
            _varients = [];
        }

        public void AddVarients(string reference, Dimension dimension)
        {
            Varient varient = new(dimension, reference, Id);
            _varients.Add(varient);
        }

        public IReadOnlyList<Varient> Varients => _varients;


    }
}
