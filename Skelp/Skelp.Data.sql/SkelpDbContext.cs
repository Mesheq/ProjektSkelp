using Microsoft.EntityFrameworkCore;
using Skelp.Data.Sql.DAO;
using Skelp.Data.Sql.DAOConfigurations;

namespace Skelp.Data.Sql
{
    //Klasa odpowiadająca za konfigurację Entity Framework Core
    //Przy pomocy instancji klasy SkelpDbContext możliwe jest wykonywanie
    //wszystkich operacji na bazie danych od tworzenia bazy danych po zapytanie do bazy danych itd.
    public class SkelpDbContext : DbContext
    {
        public SkelpDbContext(DbContextOptions<SkelpDbContext> options) : base(options) {}
        
        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<Order> Order { get; set; }        
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }        
        public virtual DbSet<Product> Product { get; set; }        
        public virtual DbSet<Seller> Seller { get; set; }        
        public virtual DbSet<Complain> Complain { get; set; }        
               
        public virtual DbSet<DAO.User> User { get; set; }        
        
      

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new SellerConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductOrderConfiguration());
            builder.ApplyConfiguration(new ComplainConfiguration());
            
        }
        
        //Przykład konfiguracji modeli/encji w klasie DbContext (nie polecam)
        
//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.Entity<Category>(b =>
//            {
//                b.HasKey(c => (object) c.CategoryId);
//                b.Property(c => c.CategoryId);    
////                b.Property(c => c.CategoryId).HasMaxLength(254);    
//                b.ToTable("Category");
//            });
//
//            builder.Entity<Comment>(b =>
//            {
//                b.HasKey(c => (object) c.CommentId);
//                b.Property(c => c.CommentId); 
//                b.Property(c => c.ParentCommentId); 
//                b.Property(c => c.PostId); 
//                b.Property(c => c.UserId); 
//                b.HasOne(x => x.Post)
//                    .WithMany(x => x.Comments)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x=>x.PostId);
//                b.HasOne(x => x.User)
//                    .WithMany(x => x.Comments)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x=>x.UserId);
//                b.HasOne(x => x.ParentComment)
//                    .WithMany(x => x.SubComments)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x=>x.ParentCommentId);
//                b.ToTable("Comment");
//            });
//
//            builder.Entity<Media>(b =>
//            {
//                b.HasKey(c => (object) c.MediaId);
//                b.Property(c => c.MediaId); 
//                b.HasOne(x => x.Post)
//                    .WithMany(x => x.Medias)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.PostId);
//                b.ToTable("Media");
//            });
//            
//            builder.Entity<Post>(b =>
//            {
//                b.HasKey(c => (object) c.PostId);
//                b.Property(c => c.PostId); 
//                b.Property(c => c.UserId); 
//                b.HasOne(x => x.User)
//                    .WithMany(x => x.Posts)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.UserId);
//                b.ToTable("Post");
//            });
//                
//            builder.Entity<PostCategory>(b=>
//            {
//                b.HasKey(c => (object) c.PostCategoryId);
//                b.Property(c => c.PostCategoryId); 
//                b.Property(c => c.CategoryId); 
//                b.Property(c => c.PostId); 
//                b.HasOne(x => x.Post)
//                    .WithMany(x => x.PostCategories)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.PostId);
//                b.HasOne(x => x.Category)
//                    .WithMany(x => x.PostCategories)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.CategoryId);
//                b.ToTable("PostCategory");
//            });
//
//            builder.Entity<PostTag>(b =>
//            {
//                b.HasKey(c => (object) c.PostTagId);
//                b.Property(c => c.PostTagId);
//                b.Property(c => c.TagId);
//                b.Property(c => c.PostId);
//                b.HasOne(x => x.Post)
//                    .WithMany(x => x.PostTags)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.PostId);
//                b.HasOne(x => x.Tag)
//                    .WithMany(x => x.PostTags)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.TagId);
//                b.ToTable("PostTag");
//            });
//
//            builder.Entity<Preference>(b =>
//            {
//                b.HasKey(c => (object) c.PreferenceId);
//                b.Property(c => c.PreferenceId);
//                b.Property(c => c.PostId);
//                b.Property(c => c.UserId);
//                b.HasOne(x => x.Post)
//                    .WithMany(x => x.Preferences)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.PostId);
//                b.HasOne(x => x.User)
//                    .WithMany(x => x.Preferences)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.UserId);
//                b.ToTable("Preference");
//            });
//
//            builder.Entity<Tag>(b =>
//            {
//                b.HasKey(c => (object) c.TagId);
//                b.Property(c => c.TagId);
//                b.ToTable("Tag");
//            });
//
//            builder.Entity<User>(b =>
//            {
//                b.HasKey(c => (object) c.UserId);
//                b.Property(c => c.UserId);
//                b.ToTable("User");
//            });
//            
//            builder.Entity<UserRelation>(b =>
//            { 
//                b.HasKey(c => (object) c.UserRelationId);
//                b.Property(c => c.UserRelationId);
//                b.Property(c => c.RelatedUserId);
//                b.Property(c => c.RelatingUserId);
//                b.HasOne(x => x.RelatedUser)
//                    .WithMany(x => x.RelatingUsers)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.RelatedUserId);
//                b.HasOne(x => x.RelatingUser)
//                    .WithMany(x => x.RelatedUsers)
//                    .OnDelete(DeleteBehavior.Restrict)
//                    .HasForeignKey(x => x.RelatingUserId);
//                b.ToTable("UserRelation");
//            });
//        }

    }
}