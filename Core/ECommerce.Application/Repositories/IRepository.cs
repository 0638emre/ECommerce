using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Sonradan not: baseentity zaten bir classtır. T hem class hem base entityden kısıtlanır.
        //burada Revrelsel repository interfacesini yazarken T olan entitynin çapını (genişliğini kısalttık.sen sdadece class olabilirsin dedik.)
        DbSet<T> Table { get; }

    }
}
