using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewBTC.Areas.Invesment;
using NewBTC.Areas.Investment;

namespace NewBTC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<InvestmentPlan>? InvestmentPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });


            //modelBuilder.Ignore<SelectListItem>();
            //modelBuilder.Ignore<SelectListGroup>();
        //    modelBuilder
        //.Entity<PlanType>(
        //    eb =>
        //    {
        //        eb.HasNoKey();
        //        eb.ToView("Create");
        //        eb.Property(v => v.SelectedDuration).HasColumnName("Name");
        //    });

            modelBuilder.Entity<InvestmentP>()
      .Property(p => p.Amount)
      .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<InvestmentP>()
   .Property(p => p.MiniInvestment)
   .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<InvestmentP>()
   .Property(p => p.MaxInvestment)
   .HasColumnType("decimal(18,2)");
        }

        public DbSet<NewBTC.Areas.Investment.InvestmentP> InvestmentP { get; set; }
        public DbSet<NewBTC.Areas.Investment.Deposits> Deposits { get; set; }
        public DbSet<NewBTC.Areas.Investment.Withdraw> Withdraw { get; set; }
        public DbSet<NewBTC.Areas.Investment.Account> Account { get; set; }
    }

}