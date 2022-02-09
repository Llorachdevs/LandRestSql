using System.Linq;
using LandRest.Articles;
using LandRest.Blogs;
using LandRest.Comments;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LandRest.EntityFrameworkCore;

public static class LandRestModelCreatingExtensions
{
    public static void ConfigureLandRestEntities(this ModelBuilder builder)
    {
         builder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blogs");
                entity.Property(e => e.SiteLink)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.HasIndex(e => e.SiteLink)
                    .IsUnique();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(b => b.Secret)
                    .HasMaxLength(150);
                entity.HasMany(e => e.Users)
                    .WithOne(e => e.Blog)
                    .HasForeignKey(e => e.BlogId);
                entity.ConfigureByConvention();
            });
            
            builder.Entity<Article>(entity =>
            {
                entity.ToTable("Articles");
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.UserEmail)
                    .IsRequired();
                entity.Property(e => e.ArticleLink)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.HasIndex(e => e.ArticleLink)
                    .IsUnique();
                entity.Property(ba => ba.Tittle)
                    .IsRequired();
                entity.HasMany(e => e.Comments)
                    .WithOne(e => e.Article)
                    .HasForeignKey(e => e.ArticleId);
                entity.ConfigureByConvention();
            });
            
            builder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comments");
                entity.Property(e => e.Text)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .IsRequired();
                entity.Property(e => e.Published)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .HasMaxLength(15);
                entity.ConfigureByConvention();
            });
            
            foreach (var foreignKey in builder.Model.GetEntityTypes()
                         .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
    }
}