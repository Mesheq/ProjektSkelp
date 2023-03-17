using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.DAOConfigurations
{
    public class SellerConfiguration: IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.Property(c => c.Nip).IsRequired();
            builder.Property(c => c.Regon).IsRequired();
            builder.Property(c => c.SellerName).IsRequired();
            builder.Property(c => c.CompanyAdress).IsRequired();
            
          
            builder.ToTable("Seller");
        }
    }

}