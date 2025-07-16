using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Restaurant_app.Models
{
    public partial class DBRestaurant : DbContext
    {
        public DBRestaurant()
            : base("name=DBRestaurant")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryExecutive> DeliveryExecutives { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<KOT> KOTs { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<OrganizationInfo> OrganizationInfoes { get; set; }
        public virtual DbSet<PaymentStatu> PaymentStatus { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TableArea> TableAreas { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TimeZone> TimeZones { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .HasMany(e => e.TableAreas)
                .WithRequired(e => e.Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Areas)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.DeliveryExecutives)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.KOTs)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.MenuItems)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.TableAreas)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryExecutive>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.DeliveryExecutive)
                .HasForeignKey(e => e.AssignExecutiveId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.KOTs)
                .WithRequired(e => e.MenuItem)
                .HasForeignKey(e => e.MenuItemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuItem>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.MenuItem)
                .HasForeignKey(e => e.MenuItemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuItems)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.KOTs)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.SGST)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.CGST)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Areas)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Branches)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.DeliveryExecutives)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.KOTs)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.MenuItems)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrganizationInfo>()
                .HasMany(e => e.TableAreas)
                .WithRequired(e => e.OrganizationInfo)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Reservation>()
            //    .HasOptional(e => e.Reservation1)
            //    .WithRequired(e => e.Reservation2);
        }
    }
}
