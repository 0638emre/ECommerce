using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce.Persistance.Contexts
{
    //public class ECommerceAPIDbContext : DbContext projemize identity kurduğumuz için aşağıdaki dbcontext üzerinden devam ediyoruz bunun sebebi identity classlarını da görsün db set olarak
    public class ECommerceAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        //burada IdentityDbContext ile Identity bussiness işlerini yapacak olan repositoryi de yazmış oluyoruz. Ayrıca bir repository yazmaya gerek kalmamaktadır. Çünkü bu asp.net.core.identity içerinde zaten yazılmıştır.
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<CompletedOrder> CompletedOrders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                            .HasKey(b => b.Id);

            builder.Entity<Order>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();

            builder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<Order>(b => b.Id);

            builder.Entity<Order>()
                .HasOne(o => o.CompletedOrder)
                .WithOne(c => c.Order)
                .HasForeignKey<CompletedOrder>(c => c.OrderId);


            base.OnModelCreating(builder); //bu tarz IdentityDbContext ile implement edilen contextlerde bu gerekir
        }

        //bu aşağıdaki metot ile bir ezme işlemi kullanıyoruz. Burada bir interceptor koyuyoruz ki her db işleminde biz createddate ve updated date kolonlarına  manuel istek atmayalım. buradaki override metot save fonksiyonunu ezsin ve bunu otomatikmen gerçeleştirsin. burada repositoryde async ise async bir metot yazmaktayız
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            //bundan sonra her savechanges tetiklendiğinde burası devreye girecek. changetracker entityler üzerinde yapılan değişiklik ya da yen eklenen verileri yakalayan propertydir
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in datas)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.Now
                    //burada delete operasyonu gerçekleştiğinde silinmiş bir verinin de bu swicthden geçeceğini bildiğimiz için yaptık
                };
            }
                
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
