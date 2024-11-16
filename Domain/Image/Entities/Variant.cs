using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Image.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Domain.Image.Entities
{
    public class Variant : Entity
    {
        public Variant() : base(new())
        {
        }

        public Variant(Dimension dimension, string reference, Id imageId) : base(new())
        {
            Dimension = dimension;
            Reference = reference;
            ImageId = imageId;
        }

       
        public Dimension Dimension { get; protected set; }
        public string Reference { get; protected set; }
        public Id ImageId { get; protected set; }



    }
}
