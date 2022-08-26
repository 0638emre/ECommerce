using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T:BaseEntity
    {
        //Irepositorydeki T ye gönderilen T entitysi generic olarak burada da hem class olmalı hem de T nin gideceği yere göre karar verilmeli.

        //burada dönüş değeri queryable seçilmiştir . List -IEnubarabledir- de yazılabilir. fakat list in memory de tutar veriyi. qureayble ise direkt veritabanı sorgusuna ekler
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

        //buradaki tracking olan parametre bizim ef üzerindeki tracking mekanizmasını çalıştırıp çalıştırmaması için verilmiş bir paremetredir.
    }
}
