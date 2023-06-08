﻿// <auto-generated />
using Games.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Games.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230608090537_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Games.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Games.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gameId")
                        .HasColumnType("int");

                    b.Property<string>("review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("gameId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Games.Models.Review", b =>
                {
                    b.HasOne("Games.Models.Game", "Games")
                        .WithMany()
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
