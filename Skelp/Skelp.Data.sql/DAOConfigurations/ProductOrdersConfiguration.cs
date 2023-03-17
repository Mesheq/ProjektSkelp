using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.DAOConfigurations
{
    public class ProductOrderConfiguration: IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
        
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ProductId);
            builder.ToTable("ProductOrder");
        }
    }

}