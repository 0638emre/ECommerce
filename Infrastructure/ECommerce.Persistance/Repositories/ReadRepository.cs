using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        //burada T koşullandırmasını BaseEntity ile işaretledik. çünkü MarkerPattern kullanıyoruz. Normalde orada 'class' yazması gerekirdi. Fakat baseEntity zaten bir class bu yüzden class olmasını da veriyoruz aslında. Aynı zamanda BaseEntitydeki fieldları da vermiş oluyoruz ki. getbyid gibi metotlarda id parametresini marker ile işaretleyebilelim. diğer türlü olmaz. çünkü her class da ya da her entity de id diye bir parametre olacak diye bir şey yok.
        private readonly ECommerceAPIDbContext _context;

        public ReadRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        //burada contextimiz T türünde bir nesne döndürür.

        public IQueryable<T> GetAll(bool tracking = true)
        {
            //eğer track edilmiyorsa boşuna maliyet oluşturmaması açısından bu şekilde bir if bloğu giriyoruz
            //asQuarayble dememiz gerekiyorsa aksi halde dbcontexten bu işlemi yapmamız gerekir.asqurayble a çeviriyoruz
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }
               
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {

            //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            //burada ReadRepository classındaki kısıtlanmış olan T entitysinin BaseEntitydeki id yi almış olmanın yani markerdesign patternin faydasını göryoruz NOT 2 burada find ve findasync de kullanılabilir.
            //fakat IQuerayble ile çalışıyorsak findasync metotdu yoktur. Bu yüzden marker desing patterni kullanırız.

            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = Table.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
    }
}
