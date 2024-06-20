using Backend.Donation.Domain.Model.Aggregates;
using Backend.Donation.Domain.Model.Enitities;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;


namespace Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
         builder.Entity<Ong>().ToTable("Ongs");
        builder.Entity<Ong>().HasKey(e => e.Id);
        builder.Entity<Ong>().Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Entity<Ong>().Property(e => e.Name).IsRequired();
        builder.Entity<Ong>().Property(e => e.Type).IsRequired();
        builder.Entity<Ong>().Property(e => e.AboutUs).IsRequired();
        builder.Entity<Ong>().Property(e => e.MissionVision).IsRequired();
        builder.Entity<Ong>().Property(e => e.SupportForm).IsRequired();
        builder.Entity<Ong>().Property(e => e.Address).IsRequired();
        builder.Entity<Ong>().Property(e => e.Email).IsRequired();
        builder.Entity<Ong>().Property(e => e.Number).IsRequired();
        builder.Entity<Ong>().Property(e => e.UrlLogo).IsRequired();
        builder.Entity<Ong>().Property(e => e.UrlWebSite).IsRequired();
        
        //Category
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(e => e.Id);
        builder.Entity<Category>().Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(e => e.Name).IsRequired();
        
        //Relationships category and ong
        
        builder.Entity<Ong>()
            .HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        //Projects
        builder.Entity<Project>().ToTable("Projects");
        builder.Entity<Project>().HasKey(e => e.Id);
        builder.Entity<Project>().Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Entity<Project>().Property(e => e.Name).IsRequired();
        builder.Entity<Project>().Property(e => e.Description).IsRequired();
        
        //Social Network
        builder.Entity<SocialNetwork>().ToTable("SocialNetworks");
        builder.Entity<SocialNetwork>().HasKey(e => e.Id);
        builder.Entity<SocialNetwork>().Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Entity<SocialNetwork>().Property(e => e.Name).IsRequired();
        builder.Entity<SocialNetwork>().Property(e => e.Url).IsRequired();
        builder.Entity<SocialNetwork>().Property(e => e.Icon).IsRequired();
        
        //Account Number
        builder.Entity<AccountNumber>().ToTable("AccountNumbers");
        builder.Entity<AccountNumber>().HasKey(e => e.Id);
        builder.Entity<AccountNumber>().Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Entity<AccountNumber>().Property(e => e.Name).IsRequired();
        builder.Entity<AccountNumber>().Property(e => e.Number).IsRequired();
        builder.Entity<AccountNumber>().Property(e => e.CCI).IsRequired();
        
        //relationship ong and all, if my ong have a listt or icollection of projects, socialnetworks, accountnumbers
        builder.Entity<Ong>()
            .HasMany(e => e.Projects)
            .WithOne()
            .HasForeignKey(e => e.OngId)
            .HasPrincipalKey(t => t.Id);
        
        builder.Entity<Ong>()
            .HasMany(e => e.SocialNetworks)
            .WithOne()
            .HasForeignKey(e => e.OngId)
            .HasPrincipalKey(t => t.Id);
        
        builder.Entity<Ong>()
            .HasMany(e => e.AccountNumbers)
            .WithOne()
            .HasForeignKey(e => e.OngId)
            .HasPrincipalKey(t => t.Id);
        
        
        

        
       
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}