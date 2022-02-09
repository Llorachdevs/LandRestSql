using System;
using System.Linq;
using LandRest.Blogs;
using LandRest.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace LandRest.EntityFrameworkCore
{
    // [ReplaceDbContext(typeof(IIdentityDbContext))]
    // [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class LandRestDbContext :
        AbpDbContext<LandRestDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules
        
        // public DbSet<IdentityUser> Users { get; }
        // public DbSet<IdentityRole> Roles { get; }
        // public DbSet<IdentityClaimType> ClaimTypes { get; }
        // public DbSet<OrganizationUnit> OrganizationUnits { get; }
        // public DbSet<IdentitySecurityLog> SecurityLogs { get; }
        // public DbSet<IdentityLinkUser> LinkUsers { get; }
        // public DbSet<Tenant> Tenants { get; }
        // public DbSet<TenantConnectionString> TenantConnectionStrings { get; }
        
        #endregion

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        // #region LlorachdevsDbSets
        //
        // public DbSet<Blog> DbBlogs { get; set; }
        // public DbSet<AppUser> Users { get; set; }
        // public DbSet<BlogArticle> DbArticles { get; set; }
        //
        // public DbSet<BlogArticleComment> DbComments { get; set; }
        //
        // public DbSet<BlogVisit> DbVisits { get; set; }
        //
        // #endregion

        public LandRestDbContext(DbContextOptions<LandRestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /* Include modules to your migration db context */
            
            // builder.ConfigurePermissionManagement();
            // builder.ConfigureSettingManagement();
            // builder.ConfigureBackgroundJobs();
            // builder.ConfigureAuditLogging();
            // builder.ConfigureIdentity();
            // builder.ConfigureIdentityServer();
            // builder.ConfigureFeatureManagement();
            // builder.ConfigureTenantManagement();


            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LandRestConsts.DbTablePrefix + "YourEntities", LandRestConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users");
                entity.ConfigureByConvention();
                entity.ConfigureAbpUser();
                
                entity.HasOne(e => e.Blog)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.BlogId);
                entity.HasMany(e => e.Articles)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Comments)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId);
                entity.Property(e => e.Name)
                    .IsRequired();
                entity.Property(e => e.Surname)
                    .IsRequired();
                entity.Property(e => e.SecondName);
                entity.Property(e => e.SecondSurname);
                entity.Property(e => e.CvLink);
                entity.Property(e => e.SiteLink);
            });
            
            builder.Entity<BlogVisit>(entity =>
            {
                // entity.Ignore(e => e.ExtraProperties);
                entity.ToTable("BlogVisits");
                entity.Property(e => e.VisitDate)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .IsRequired();
                entity.ConfigureByConvention();
            });
            
            builder.Entity<Blog>(entity =>
            {
                // entity.Ignore(e => e.ExtraProperties);
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
                entity.ConfigureByConvention();
            });
            
            builder.Entity<BlogArticle>(entity =>
            {
                // entity.Ignore(e => e.ExtraProperties);
                entity.ToTable("BlogArticles");
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
            
            builder.Entity<BlogArticleComment>(entity =>
            {
                // entity.Ignore(e => e.ExtraProperties);
                entity.ToTable("BlogArticleComments");
                entity.Property(e => e.Comment)
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
}