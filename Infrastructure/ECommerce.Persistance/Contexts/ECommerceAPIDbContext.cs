using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        //bu aşağıdaki metot ile bir ezme işlemi kullanıyoruz. Burada bir interceptor koyuyoruz ki her db işleminde biz createddate ve updated date kolonlarına  manuel istek atmayalım. buradaki override metot save fonksiyonunu ezsin ve bunu otomatikmen gerçeleştirsin. burada repositoryde async ise async bir metot yazmaktayız
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            //bundan sonra her savechanges tetiklendiğinde burası devreye girecek. changetracker entityler üzerinde yapılan değişiklik ya da yen eklenen verileri yakalayan propertydir
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => 
               item.Entity.UpdatedDate = DateTime.Now
                };
            }
                
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
