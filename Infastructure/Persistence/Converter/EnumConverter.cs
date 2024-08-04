using Domain.Base;
using Domain.Film.ObjectValues;
using Domain.User.ObjectValue;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Persistence.Converter
{


    public class QualityConverter : ValueConverter<Quality, int>
    {
        public QualityConverter() : base(e => e.Id, id => Quality.FromId(id)) { }
  
    }

    public class FilmStatusConverter : ValueConverter<FilmStatus, int>
    {
        public FilmStatusConverter() : base(e => e.Id, id => FilmStatus.FromId(id)) { }

    }

    public class GenreConverter : ValueConverter<Genre, int>
    {
        public GenreConverter() : base(e => e.Id, id => Genre.FromId(id)) { }

    }

    public class RoleConverter : ValueConverter<Role, int>
    {
        public RoleConverter() : base(e => e.Id, id => Role.FromId(id)) { }

    }

    public class UserProviderConverter : ValueConverter<UserProvider, int>
    {
        public UserProviderConverter() : base(e => e.Id, id => UserProvider.FromId(id)) { }

    }

}
