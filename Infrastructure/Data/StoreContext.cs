using System.Linq;
using System.Reflection;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //Doing this in production is not ideal
            //this is done bcz decimal in not supported in sqllite,if you are using sqlserver ignore this
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    /*
                    //For SQLLite
                    //Enable these 2 comment parts for datetime problem

                    var dateTimeProperties=entityType.clrType.GetProperties().Where(p=>p.propertyTpes==typeof(DateTimeOffset));

                    */
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();

                    }

                    /*
                     foreach (var property in dateTimeProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion(new DateTimeOffsetToBinaryConverter());

                    }
                    */
                   




                }
            }



        }

    }
}