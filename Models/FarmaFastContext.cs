using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FarmaFast.Models;

public partial class FarmaFastContext : DbContext
{
    public FarmaFastContext()
    {
    }

    public FarmaFastContext(DbContextOptions<FarmaFastContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<EstadoProducto> EstadoProductos { get; set; }

    public virtual DbSet<EstadoProveedor> EstadoProveedors { get; set; }

    public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }

    public virtual DbSet<EstiloProducto> EstiloProductos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    public virtual DbSet<Vigencia> Vigencia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IddetalleVenta).HasName("PK__detalle___7CFD2ACAD7877F9F");

            entity.ToTable("detalle_venta");

            entity.Property(e => e.IddetalleVenta).HasColumnName("iddetalleVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.ObProducto).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_v__idpro__6A30C649");

            entity.HasOne(d => d.ObVenta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_v__idven__693CA210");
        });

        modelBuilder.Entity<EstadoProducto>(entity =>
        {
            entity.HasKey(e => e.IdestadoProducto).HasName("PK__estado_p__89983936B4181576");

            entity.ToTable("estado_producto");

            entity.Property(e => e.IdestadoProducto).HasColumnName("idestadoProducto");
            entity.Property(e => e.EstadoProducto1)
                .IsUnicode(false)
                .HasColumnName("estadoProducto");
        });

        modelBuilder.Entity<EstadoProveedor>(entity =>
        {
            entity.HasKey(e => e.IdestadoProveedor).HasName("PK__estado_p__B42260C58EFE1B15");

            entity.ToTable("estado_proveedor");

            entity.Property(e => e.IdestadoProveedor).HasColumnName("idestadoProveedor");
            entity.Property(e => e.EstadoProveedor1)
                .IsUnicode(false)
                .HasColumnName("estadoProveedor");
        });

        modelBuilder.Entity<EstadoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdestadoUsuario).HasName("PK__estado_u__080C08B67D13774A");

            entity.ToTable("estado_usuario");

            entity.Property(e => e.IdestadoUsuario).HasColumnName("idestadoUsuario");
            entity.Property(e => e.EstadoUsuario1)
                .IsUnicode(false)
                .HasColumnName("estadoUsuario");
        });

        modelBuilder.Entity<EstiloProducto>(entity =>
        {
            entity.HasKey(e => e.Idestilo).HasName("PK__estilo_p__AE4CFABAD7423D42");

            entity.ToTable("estilo_producto");

            entity.Property(e => e.Idestilo).HasColumnName("idestilo");
            entity.Property(e => e.EstiloProducto1)
                .IsUnicode(false)
                .HasColumnName("estiloProducto");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.Idmarca).HasName("PK__marca__6D3757B28C4B69F4");

            entity.ToTable("marca");

            entity.Property(e => e.Idmarca).HasColumnName("idmarca");
            entity.Property(e => e.Idestilo).HasColumnName("idestilo");
            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Idvigencia).HasColumnName("idvigencia");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.ObEstilo).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.Idestilo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__marca__idestilo__5AEE82B9");

            entity.HasOne(d => d.ObProveedor).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.Idproveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__marca__idproveed__75A278F5");

            entity.HasOne(d => d.ObVigencia).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.Idvigencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__marca__idvigenci__59FA5E80");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3CD54CD0C9");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdestadoProducto).HasColumnName("idestadoProducto");
            entity.Property(e => e.Idmarca).HasColumnName("idmarca");
            entity.Property(e => e.IdtipoProducto).HasColumnName("idtipoProducto");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.ObEstadoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdestadoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__idesta__6383C8BA");

            entity.HasOne(d => d.ObMarca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idmarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__idmarc__619B8048");

            entity.HasOne(d => d.ObTipoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdtipoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__idtipo__628FA481");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("PK__proveedo__2DCD485DA0FB8B85");

            entity.ToTable("proveedor");

            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Celular)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dui)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.IdestadoProveedor).HasColumnName("idestadoProveedor");

            entity.HasOne(d => d.ObEstadoProveedor).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.IdestadoProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__proveedor__idest__534D60F1");
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.IdtipoProducto).HasName("PK__tipo_pro__6BDCB6D699F2D9D8");

            entity.ToTable("tipo_producto");

            entity.Property(e => e.IdtipoProducto).HasColumnName("idtipoProducto");
            entity.Property(e => e.TipoProducto1)
                .IsUnicode(false)
                .HasColumnName("tipoProducto");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdtipoUsuario).HasName("PK__tipo_usu__743B669E9876972A");

            entity.ToTable("tipo_usuario");

            entity.Property(e => e.IdtipoUsuario).HasColumnName("idtipoUsuario");
            entity.Property(e => e.TipoUsuario1)
                .IsUnicode(false)
                .HasColumnName("tipoUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__usuarios__080A974300F4AA99");

            entity.ToTable("usuarios");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Celular)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Contrasena)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Dui)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.IdestadoUsuario).HasColumnName("idestadoUsuario");
            entity.Property(e => e.IdtipoUsuario).HasColumnName("idtipoUsuario");
            entity.Property(e => e.Nombres)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.HasOne(d => d.ObEstadoUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdestadoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__idesta__4D94879B");

            entity.HasOne(d => d.ObTipoUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdtipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuarios__idtipo__4E88ABD4");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__venta__F82D1AFB33EA16DF");

            entity.ToTable("venta");

            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Cliente)
                .IsUnicode(false)
                .HasColumnName("cliente");
            entity.Property(e => e.Codigoventa)
                .IsUnicode(false)
                .HasColumnName("codigoventa");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.ObUsuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__idusuario__66603565");
        });

        modelBuilder.Entity<Vigencia>(entity =>
        {
            entity.HasKey(e => e.Idvigencia).HasName("PK__vigencia__F5B6880F18204253");

            entity.ToTable("vigencia");

            entity.Property(e => e.Idvigencia).HasColumnName("idvigencia");
            entity.Property(e => e.EstadoVigencia)
                .IsUnicode(false)
                .HasColumnName("estadoVigencia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
