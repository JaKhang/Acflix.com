using Domain.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Converter
{
    public class IDConverter : ValueConverter<ID, Guid>
    {
        public IDConverter(): base(v => v.Value, v => new ID(v))
        { 
        }

 
    }
}
