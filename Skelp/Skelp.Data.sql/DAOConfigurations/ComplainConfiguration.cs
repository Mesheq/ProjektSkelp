using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.DAOConfigurations
{
    //Klasa konfiguracyjna encji Category
    //należy zaimplementować (generyczny) interfejs IEntityTypeConfiguration i jako parametr przekazać 
    public partial class  ComplainConfiguration: IEntityTypeConfiguration<Complain>
    {
        public void Configure(EntityTypeBuilder<Complain> builder)
        {
            builder.Property(c => c.Description).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.Complains)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Order)
                .WithMany(x => x.Complains)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OrderId);
            builder.ToTable("Complain");
        }
    }

}