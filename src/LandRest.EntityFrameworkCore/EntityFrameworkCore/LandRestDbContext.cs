using System;
using LandRest.Blogs;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace LandRest.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class LandRestDbContext :
        AbpDbContext<LandRestDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

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

        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }


        #region LlorachdevsDbSets
        
        public DbSet<Blog> DbBlogs { get; set; }
        public DbSet<BlogUser> BlogUsers { get; set; }
        public DbSet<BlogArticle> DbArticles { get; set; }

        public DbSet<BlogArticleComment> DbComments { get; set; }

        public DbSet<BlogVisit> DbVisits { get; set; }

        #endregion

        #endregion

        public LandRestDbContext(DbContextOptions<LandRestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();


            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LandRestConsts.DbTablePrefix + "YourEntities", LandRestConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<BlogUser>(entity =>
            {
                entity.ToTable("BlogUsers");
                entity.HasKey(e => e.Id)
                    .HasName("PK_Blog_User");
                entity.HasOne(e => e.Blog)
                    .WithMany(e => e.Users)
                    .HasForeignKey(e => e.Id);
                entity.HasMany(e => e.Articles)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId);
                entity.HasMany(e => e.Comments)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId);
                entity.Property(e => e.FirstName)
                    .IsRequired();
                entity.Property(e => e.FirstLastName)
                    .IsRequired();
                entity.Property(e => e.RoleId)
                    .IsRequired();
            });

            builder.Entity<BlogVisit>(entity =>
            {
                entity.ToTable("BlogVisits");
                entity.Property(e => e.VisitDate)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .IsRequired();
            });

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
            });

            builder.Entity<BlogArticle>(entity =>
            {
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
            });

            builder.Entity<BlogArticleComment>(entity =>
            {
                entity.ToTable("BlogArticleComments");
                entity.Property(e => e.Comment)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .IsRequired();
                entity.Property(e => e.Published)
                    .IsRequired();
                entity.Property(e => e.IpAddress)
                    .HasMaxLength(15);
            });
        }
    }
}