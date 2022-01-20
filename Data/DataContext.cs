using marcore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// 

namespace marcore.api.Data
{
    public class DataContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Like>()
                .HasKey(k => new { k.LikerId, k.LikeeId });

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Photo>().HasQueryFilter(p => p.IsApproved);
        }
        public DbSet<VsoftCustomer> VsoftCustomers { get; set; }
        public DbSet<VsoftContract> VsoftContracts { get; set; }
        public DbSet<VsoftTelebibContract> VsoftTelebibContracts { get; set; }
        public DbSet<VsoftCustomerInvoice> VsoftCustomerInvoices { get; set; }
        public DbSet<VsoftSupplier> VsoftSuppliers { get; set; }
        public DbSet<VsoftSupplierInvoice> VsoftSupplierInvoices { get; set; }

        public DbSet<VsoftLedgerAccount> VsoftLedgerAccounts { get; set; }
        public DbSet<VsoftLedger> VsoftLedgers { get; set; }
        public DbSet<VsoftYearSetting> VsoftYearSettings { get; set; }
        public DbSet<VsoftProduct> VsoftProducts { get; set; }
        public DbSet<VsoftMailform> VsoftMailforms { get; set; }

        /* public DbSet<VsoftProductGroup> VsoftProductGroups { get; set; }                
        public DbSet<VsoftCorrespondence> VsoftCorrespondences { get; set; }        
        public DbSet<VsoftMiscellaneous> VsoftMiscellaneouses { get; set; }
        public DbSet<VsoftTelebib> VsoftTelebibs { get; set; } */

        public DbSet<TbQualifier> TbQualifiers { get; set; }
        public DbSet<TbValeur> TbValeurs { get; set; }
        // public DbSet<VsoftKboEnterprise> VsoftKboEnterprises { get; set; }
        public DbSet<VsoftKboCode> VsoftKboCodes { get; set; }
    }
}
