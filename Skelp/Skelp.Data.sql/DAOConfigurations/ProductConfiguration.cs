using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.DAOConfigurations
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.ProductName).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.ProductDescription).IsRequired();
            
            builder.HasOne(x => x.Seller)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.SellerId);
            builder.ToTable("Product");
        }
    }

}