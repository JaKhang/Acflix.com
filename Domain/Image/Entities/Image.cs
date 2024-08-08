using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Image.ValueObjects;

namespace Domain.Image.Entities
{
    public class Image : Entity
    {
        public string Name { get; protected set; }
        private readonly List<Variant> _variants;

        public Image() : base(new())
        {
            _variants = [];
        }

        public Image(string name) : base(new())
        {
            this.Name = name;
            _variants = [];
        }

        public void AddVariants(string reference, Dimension dimension)
        {
            Variant variant = new(dimension, reference, Id);
            _variants.Add(variant);
        }

        public IReadOnlyList<Variant> Variants => _variants;


    }
}
