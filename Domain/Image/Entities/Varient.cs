using Domain.Base;
using Domain.Base.ValueObjects;
using Domain.Image.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Domain.Image.Entities
{
    public class Varient : Entity
    {
        public Varient() : base(new())
        {
        }

        public Varient(Dimension dimension, string reference, ID imageId) : base(new())
        {
            Dimension = dimension;
            Reference = reference;
            ImageId = imageId;
        }

       
        public Dimension Dimension { get; protected set; }
        public string Reference { get; protected set; }
        public ID ImageId { get; protected set; }



    }
}
