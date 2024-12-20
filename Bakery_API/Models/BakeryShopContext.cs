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

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<GroupProduct> GroupProducts { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACER;Database=BakeryShop;User Id=nhutanh;Password=nhutanh02042004@;TrustServerCertificate=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Colors__70A64FDD54ED9BFD");

            entity.Property(e => e.ColorId).HasColumnName("colorId");
            entity.Property(e => e.HexCode)
                .HasMaxLength(7)
                .HasColumnName("hexCode");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.HasOne(d => d.Product).WithMany(p => p.Colors)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colors__productI__47DBAE45");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Deliveri__CDC3A0B257FC84DE");

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
            entity.HasKey(e => e.GroupProductId).HasName("PK__GroupPro__61C823762726C37B");

            entity.Property(e => e.GroupProductId).HasColumnName("groupProductId");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__336E9B557491F071");

            entity.Property(e => e.ImageId).HasColumnName("imageId");
            entity.Property(e => e.ColorId).HasColumnName("colorId");
            entity.Property(e => e.Image1).HasColumnName("image");

            entity.HasOne(d => d.Color).WithMany(p => p.Images)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Images__colorId__4D94879B");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Membersh__86AA3B17A4F87C67");

            entity.ToTable("Membership");

            entity.Property(e => e.MembershipId).HasColumnName("membershipId");
            entity.Property(e => e.Endow)
                .HasMaxLength(255)
                .HasColumnName("endow");
            entity.Property(e => e.PointsRequired).HasColumnName("pointsRequired");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__0809335DEFD17B53");

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
                .HasConstraintName("FK__Orders__delivery__59FA5E80");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__paymentI__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__userId__5812160E");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__A0D9EFC6EFE31DB7");

            entity.Property(e => e.PaymentId).HasColumnName("paymentId");
            entity.Property(e => e.MethodPayment)
                .HasMaxLength(255)
                .HasColumnName("methodPayment");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D16AB45FBA40");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.GroupProductId).HasColumnName("groupProductID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");

            entity.HasOne(d => d.GroupProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.GroupProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__groupP__44FF419A");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__produc__440B1D61");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__A944253BE326CB70");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategoryId");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__2ECD6E04D760974E");

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
            entity.HasKey(e => e.ShoppingCartItemId).HasName("PK__Shopping__1CF034B4BBC41EF3");

            entity.Property(e => e.ShoppingCartItemId).HasColumnName("shoppingCartItemId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__order__5DCAEF64");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__produ__5CD6CB2B");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Sizes__55B1E557D727EED4");

            entity.Property(e => e.SizeId).HasColumnName("sizeId");
            entity.Property(e => e.ColorId).HasColumnName("colorId");
            entity.Property(e => e.Size1)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Color).WithMany(p => p.Sizes)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sizes__colorId__4AB81AF0");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Statuses__36257A185B29232C");

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
                .HasConstraintName("FK__Statuses__orderI__60A75C0F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFFE1AE9D79");

            entity.HasIndex(e => e.Gmail, "UQ__Users__493D0C0A65599A6D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Gmail)
                .HasMaxLength(255)
                .HasColumnName("gmail");
            entity.Property(e => e.MembershipId).HasColumnName("membershipId");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Point)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("point");
            entity.Property(e => e.RememberMeToken)
                .HasMaxLength(255)
                .HasColumnName("remember_me_token");
            entity.Property(e => e.Gender)
            .HasColumnName("gender")
            .HasColumnType("tinyint")
            .IsRequired();

            entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();
          

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("user")
                .HasColumnName("role");

            entity.HasOne(d => d.Membership).WithMany(p => p.Users)
                .HasForeignKey(d => d.MembershipId)
                .HasConstraintName("FK__Users__membershi__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
