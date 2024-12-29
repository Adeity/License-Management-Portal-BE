using System;
using System.Collections.Generic;
using DP_BE_LicensePortal.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DP_BE_LicensePortal.Context;

public partial class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
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

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=reseller;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.ToTable("AddressType", "reseller");

            entity.HasIndex(e => e.Name, "UQ_AddressType_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.ToTable("ContactType", "reseller");

            entity.HasIndex(e => e.Name, "UQ_ContactType_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country", "reseller");

            entity.HasIndex(e => e.Name, "UQ_Country_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice", "reseller");

            entity.HasIndex(e => e.InvoiceTypeId, "IX_Invoice_InvoiceType");

            entity.HasIndex(e => e.OrganizationAccountId, "IX_Invoice_OrganizationAccount");

            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.InvoiceType).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.InvoiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_InvoiceType");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.OrganizationAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoice_OrganizationAccount");
        });

        modelBuilder.Entity<InvoiceType>(entity =>
        {
            entity.ToTable("InvoiceType", "reseller");

            entity.HasIndex(e => e.Name, "UQ_InvoiceType_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrganizationAccount>(entity =>
        {
            entity.ToTable("OrganizationAccount", "reseller");

            entity.HasIndex(e => e.AccountId, "IX_OrganizationAccount_Account");

            entity.HasIndex(e => e.OrganizationTypeId, "IX_OrganizationAccount_OrganizationType");

            entity.HasIndex(e => e.ParentOrganizationId, "IX_OrganizationAccount_ParentOrganizationId");

            entity.HasIndex(e => new { e.Name, e.ParentOrganizationId }, "UQ_OrganizationAccount_Name").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .HasColumnName("AccountID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(256)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.OrganizationAccounts)
                .HasForeignKey(d => d.OrganizationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAccount_OrganizationType");

            entity.HasOne(d => d.ParentOrganization).WithMany(p => p.InverseParentOrganization)
                .HasForeignKey(d => d.ParentOrganizationId)
                .HasConstraintName("FK_OrganizationAccount_OrganizationAccount");
        });

        modelBuilder.Entity<OrganizationAddress>(entity =>
        {
            entity.ToTable("OrganizationAddress", "reseller");

            entity.HasIndex(e => e.AddressTypeId, "IX_OrganizationAddress_AddressType");

            entity.HasIndex(e => e.CountryId, "IX_OrganizationAddress_Country");

            entity.HasIndex(e => e.OrganizationAccountId, "IX_OrganizationAddress_OrganizationAccount");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Address2).HasMaxLength(250);
            entity.Property(e => e.Address3).HasMaxLength(250);
            entity.Property(e => e.City).HasMaxLength(250);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(250);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.AddressType).WithMany(p => p.OrganizationAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAddress_AddressType");

            entity.HasOne(d => d.Country).WithMany(p => p.OrganizationAddresses)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAddress_Country");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.OrganizationAddresses)
                .HasForeignKey(d => d.OrganizationAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAddress_OrganizationAccount");
        });

        modelBuilder.Entity<OrganizationContact>(entity =>
        {
            entity.ToTable("OrganizationContact", "reseller");

            entity.HasIndex(e => e.ContactTypeId, "IX_OrganizationContact_ContactType");

            entity.HasIndex(e => e.OrganizationAccountId, "IX_OrganizationContact_OrganizationAccount");

            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ContactType).WithMany(p => p.OrganizationContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_ContactType");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.OrganizationContacts)
                .HasForeignKey(d => d.OrganizationAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_OrganizationAccount");

            entity.HasOne(d => d.OrganizationRole).WithMany(p => p.OrganizationContacts)
                .HasForeignKey(d => d.OrganizationRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationContact_OrganizationRole");

            entity.HasOne(d => d.User).WithMany(p => p.OrganizationContacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrganizationContact_User");
        });

        modelBuilder.Entity<OrganizationPackageDetail>(entity =>
        {
            entity.ToTable("OrganizationPackageDetails", "reseller");

            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.OrganizationAccount).WithMany(p => p.OrganizationPackageDetails)
                .HasForeignKey(d => d.OrganizationAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationPackageDetails_OrganizationAccount");

            entity.HasOne(d => d.PackageDetails).WithMany(p => p.OrganizationPackageDetails)
                .HasForeignKey(d => d.PackageDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationPackageDetails_PackageDetails");
        });

        modelBuilder.Entity<OrganizationRole>(entity =>
        {
            entity.ToTable("OrganizationRole", "reseller");

            entity.HasIndex(e => e.Name, "UQ_OrganizationRole_Name").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrganizationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrganizationStatus");

            entity.ToTable("OrganizationType", "reseller");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<PackageDetail>(entity =>
        {
            entity.ToTable("PackageDetails", "reseller", tb => tb.HasComment("License package details."));

            entity.Property(e => e.Id)
                .HasComment("Primary Key")
                .HasColumnName("ID");
            entity.Property(e => e.Advanced)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.Current)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.Engineering)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.Flags)
                .HasDefaultValue(0)
                .HasComment("Encoded flags");
            entity.Property(e => e.Hybrid)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.Legacy)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.LegacyPlus)
                .HasDefaultValue(false)
                .HasComment("Product class");
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .HasComment("License file prefix \"PRO\",\"ENG\"");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasComment("Package name\n\"ServiceRanger Professional\"");
            entity.Property(e => e.ProductNumber)
                .HasMaxLength(50)
                .HasComment("Package \"PRO-TRNHEV-001\"");
            entity.Property(e => e.RoleKeyId)
                .HasDefaultValue(-1)
                .HasComment("Base data role key id 5-PRO;222-ENG..");
            entity.Property(e => e.Subscription).HasComment("Number of months");
            entity.Property(e => e.Title).HasComment("Package description");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Last changed date")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SerialNumberDetail>(entity =>
        {
            entity.ToTable("SerialNumberDetails", "reseller", tb => tb.HasComment("License details."));

            entity.HasIndex(e => e.SerialNumber, "IX_SerialNumberDetails_SerialNumber").IsUnique();

            entity.Property(e => e.Id)
                .HasComment("Primary Key")
                .HasColumnName("ID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Account")
                .HasColumnName("AccountID");
            entity.Property(e => e.ExpirationDate)
                .HasComment("License expiration date")
                .HasColumnType("datetime");
            entity.Property(e => e.IsTemp).HasComment("Is temporary license");
            entity.Property(e => e.IsValid).HasComment("Is valid license");
            entity.Property(e => e.LatestModificationDate)
                .HasComment("Last time license modification where made.")
                .HasColumnType("datetime");
            entity.Property(e => e.Prefix)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("License prefix \"PRO\",\"RFM\"");
            entity.Property(e => e.ProductNumber)
                .HasMaxLength(50)
                .HasComment("Product number \"PRO-RFM-003\"");
            entity.Property(e => e.ResellerAccount)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ResellerCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.ResellerInvoice)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ResellerInvoiceLastRenew)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("License number\n\"RFM-QYF5S0-TVA7K-JG3YA-J32P7-3KNN7-D7KV0\"");
            entity.Property(e => e.SerialNumberRequestLogId)
                .HasComment("Request log")
                .HasColumnName("SerialNumberRequestLogID");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Last changed date")
                .HasColumnType("datetime");

            entity.HasOne(d => d.SerialNumberRequestLog).WithMany(p => p.SerialNumberDetails)
                .HasForeignKey(d => d.SerialNumberRequestLogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SerialNumberDetails_SerialNumberRequestLogID");
        });

        modelBuilder.Entity<SerialNumberRequestLog>(entity =>
        {
            entity.ToTable("SerialNumberRequestLog", "reseller", tb => tb.HasComment("License generation request log."));

            entity.Property(e => e.Id)
                .HasComment("Primary Key")
                .HasColumnName("ID");
            entity.Property(e => e.OrderdDate)
                .HasComment("Request date")
                .HasColumnType("datetime");
            entity.Property(e => e.RequestedSn)
                .HasComment("How many serial numbers got requested (1)")
                .HasColumnName("RequestedSN");
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("Last changed date")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("user", "reseller");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E6164FD488E09").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.WindowsUserName)
                .HasMaxLength(255)
                .HasColumnName("WindowsUserName");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("PasswordHash");
            entity.Property(e => e.IsSmart).HasColumnName("isSmart");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
