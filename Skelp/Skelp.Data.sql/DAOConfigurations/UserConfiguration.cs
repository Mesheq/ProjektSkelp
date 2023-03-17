using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skelp.Data.Sql.DAO;

namespace Skelp.Data.Sql.DAOConfigurations
{
    public partial class UserConfiguration: IEntityTypeConfiguration<Data.Sql.DAO.User>
    {
        public void Configure(EntityTypeBuilder<Data.Sql.DAO.User> builder)
        {
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired();
            builder.Property(c => c.IsBannedUser).HasColumnType("tinyint(1)");
            builder.ToTable("User");
        }
    }

}