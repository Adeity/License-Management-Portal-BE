using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using LicenseManagementPortal.Model.database;
using LicenseManagementPortal.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LicenseManagementPortal.Context;

public partial class MyDbContext : IdentityDbContext<User>
{
    private readonly IConfiguration _configuration;

    public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }

    public virtual DbSet<OrganizationAccount> OrganizationAccounts { get; set; }

    public virtual DbSet<OrganizationAddress> OrganizationAddresses { get; set; }

    public virtual DbSet<OrganizationContact> OrganizationContacts { get; set; }

    public virtual DbSet<OrganizationPackageDetail> OrganizationPackageDetails { get; set; }

    public virtual DbSet<OrganizationRole> OrganizationRoles { get; set; }

    public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }

    public virtual DbSet<PackageDetail> PackageDetails { get; set; }

    public virtual DbSet<SerialNumberDetail> SerialNumberDetails { get; set; }

    public virtual DbSet<SerialNumberRequestLog> SerialNumberRequestLogs { get; set; }

    public virtual DbSet<SubscriptionItem> SubscriptionItems { get; set; }
    public virtual DbSet<ActivationDetail> ActivationDetails { get; set; }
    public virtual DbSet<ActivationStatusLog> ActivationStatusLogs { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if (!optionsBuilder.IsConfigured)
        // {
            var connectionString = _configuration.GetConnectionString("MyDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        // }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var getDate = "(getdate())";
        var suserSname = "(suser_sname())";
        base.OnModelCreating(builder);
        builder.Entity<AddressType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<ContactType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.InvoiceType).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_InvoiceType");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_OrganizationAccount");
        });

        builder.Entity<InvoiceType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<OrganizationAccount>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.OrganizationAccounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAccount_OrganizationType");

            entity.HasOne(d => d.OrganizationAddress).WithOne(p => p.OrganizationAccount)
                .HasForeignKey<OrganizationAddress>(d => d.OrganizationAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAccount_OrganizationAddress");

            entity.HasOne(d => d.ParentOrganization).WithMany(p => p.InverseParentOrganization).HasConstraintName("FK_OrganizationAccount_OrganizationAccount");
        });

        builder.Entity<OrganizationAddress>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.AddressType).WithMany(p => p.OrganizationAddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAddress_AddressType");

            entity.HasOne(d => d.Country).WithMany(p => p.OrganizationAddresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAddress_Country");
        });

        builder.Entity<OrganizationContact>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.ContactType).WithMany(p => p.OrganizationContacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_ContactType");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.OrganizationContacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_OrganizationAccount");

            entity.HasOne(d => d.OrganizationRole).WithMany(p => p.OrganizationContacts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_OrganizationRole");

            entity.HasOne(d => d.LoginUser).WithOne(u => u.OrganizationContact)
                .HasConstraintName("FK_OrganizationContact_LoginUser");
        });

        builder.Entity<OrganizationPackageDetail>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.OrganizationPackageDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationPackageDetails_OrganizationAccount");

            entity.HasOne(d => d.PackageDetails).WithMany(p => p.OrganizationPackageDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationPackageDetails_PackageDetails");
        });

        builder.Entity<OrganizationRole>(entity =>
        {
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<OrganizationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrganizationStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<PackageDetail>(entity =>
        {
            entity.Property(e => e.Advanced).HasDefaultValue(false);
            entity.Property(e => e.Current).HasDefaultValue(false);
            entity.Property(e => e.Engineering).HasDefaultValue(false);
            entity.Property(e => e.Flags).HasDefaultValue(0);
            entity.Property(e => e.Hybrid).HasDefaultValue(false);
            entity.Property(e => e.Legacy).HasDefaultValue(false);
            entity.Property(e => e.LegacyPlus).HasDefaultValue(false);
            entity.Property(e => e.RoleKeyId).HasDefaultValue(-1);
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<SerialNumberDetail>(entity =>
        {
            entity.Property(e => e.ResellerAccount).HasDefaultValue("");
            entity.Property(e => e.ResellerCode).HasDefaultValue("");
            entity.Property(e => e.ResellerInvoice).HasDefaultValue("");
            entity.Property(e => e.ResellerInvoiceLastRenew).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.SerialNumberRequestLog).WithMany(p => p.SerialNumberDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SerialNumberDetails_SerialNumberRequestLogID");
        });

        builder.Entity<SerialNumberRequestLog>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);
        });

        builder.Entity<SubscriptionItem>(entity =>
        {
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.Invoice).WithMany(p => p.SubscriptionItems).HasConstraintName("FK_SubscriptionItem_Invoice");

            entity.HasOne(d => d.SerialNumberDetails).WithMany(p => p.SubscriptionItems).HasConstraintName("FK_SubscriptionItem_SerialNumberDetails");
        });

        builder.Entity<ActivationDetail>(entity =>
        {
            entity.Property(e => e.CustomerName).HasDefaultValue("");
            entity.Property(e => e.Organization).HasDefaultValue("");
            entity.Property(e => e.SystemName).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.SerialNumberDetails).WithMany(p => p.ActivationDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivationDetails_SerialNumberDetails");
        });

        builder.Entity<ActivationStatusLog>(entity =>
        {
            entity.Property(e => e.Reason).HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue("");
            entity.Property(e => e.UpdateDate).HasDefaultValueSql(getDate);
            entity.Property(e => e.UserID).HasDefaultValueSql(suserSname);

            entity.HasOne(d => d.SerialNumberDetail).WithMany(p => p.ActivationStatusLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivationStatusLogs_SerialNumberDetails");
        });
        builder.HasDefaultSchema("identity");
    }
}
