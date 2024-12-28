using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bakery_API.Models;

public partial class BakeryShopContext : DbContext
{
    public BakeryShopContext()
    {
    }

    public BakeryShopContext(DbContextOptions<BakeryShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<GroupProduct> GroupProducts { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TRIDUC;Initial Catalog=bakeryShop;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Deliveri__CDC3A0B2D874046E");

            entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");
            entity.Property(e => e.Fee)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fee");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GroupProduct>(entity =>
        {
            entity.HasKey(e => e.GroupProductId).HasName("PK__GroupPro__61C8237697D86E56");

            entity.Property(e => e.GroupProductId).HasColumnName("groupProductId");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Membersh__86AA3B17E160F072");

            entity.ToTable("Membership");

            entity.Property(e => e.MembershipId).HasColumnName("membershipId");
            entity.Property(e => e.Endow)
                .HasMaxLength(255)
                .HasColumnName("endow");
            entity.Property(e => e.PointsRequired).HasColumnName("pointsRequired");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809335D3D92C850");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(255)
                .HasColumnName("deliveryAddress");
            entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");
            entity.Property(e => e.OrderDate).HasColumnName("orderDate");
            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__delivery__4D94879B");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__paymentI__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userId__4BAC3F29");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__A0D9EFC6B00347E8");

            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.MethodPayment)
                .HasMaxLength(255)
                .HasColumnName("methodPayment");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D16AB6BABA80");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.GroupProductId).HasColumnName("groupProductID");
            entity.Property(e => e.Img).HasMaxLength(1000);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");

            entity.HasOne(d => d.GroupProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.GroupProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__groupP__4316F928");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__produc__4222D4EF");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__A944253B201A6C40");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__2ECD6E04E94D1C61");

            entity.Property(e => e.ReviewId).HasColumnName("reviewId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__product__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__userId__5070F446");
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.HasKey(e => e.ShoppingCartItemId).HasName("PK__Shopping__1CF034B4CDD726C7");

            entity.Property(e => e.ShoppingCartItemId).HasColumnName("shoppingCartItemId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__produ__5441852A");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Statuses__36257A18913CFFEC");

            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OrderId).HasColumnName("orderId");

            entity.HasOne(d => d.Order).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Statuses__orderI__571DF1D5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF18AD2614");

            entity.HasIndex(e => e.Gmail, "UQ__Users__493D0C0AD89702CE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Gmail)
                .HasMaxLength(255)
                .HasColumnName("gmail");
            entity.Property(e => e.MembershipId).HasColumnName("membershipId");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Point)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("point");
            entity.Property(e => e.RememberMeToken)
                .HasMaxLength(255)
                .HasColumnName("remember_me_token");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("user")
                .HasColumnName("role");

            entity.HasOne(d => d.Membership).WithMany(p => p.Users)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("FK__Users__membershi__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
