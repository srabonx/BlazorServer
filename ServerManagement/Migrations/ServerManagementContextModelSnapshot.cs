﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerManagement.Components.Database;

#nullable disable

namespace ServerManagement.Migrations
{
    [DbContext(typeof(ServerManagementContext))]
    partial class ServerManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServerManagement.Components.Models.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServerId"));

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("ServerCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServerId");

                    b.ToTable("Servers");

                    b.HasData(
                        new
                        {
                            ServerId = 1,
                            IsOnline = true,
                            ServerCity = "Toronto",
                            ServerName = "Server1"
                        },
                        new
                        {
                            ServerId = 2,
                            IsOnline = true,
                            ServerCity = "Toronto",
                            ServerName = "Server2"
                        },
                        new
                        {
                            ServerId = 3,
                            IsOnline = true,
                            ServerCity = "Toronto",
                            ServerName = "Server3"
                        },
                        new
                        {
                            ServerId = 4,
                            IsOnline = false,
                            ServerCity = "Montreal",
                            ServerName = "Server4"
                        },
                        new
                        {
                            ServerId = 5,
                            IsOnline = true,
                            ServerCity = "Montreal",
                            ServerName = "Server5"
                        },
                        new
                        {
                            ServerId = 6,
                            IsOnline = true,
                            ServerCity = "Montreal",
                            ServerName = "Server6"
                        },
                        new
                        {
                            ServerId = 7,
                            IsOnline = true,
                            ServerCity = "Halifax",
                            ServerName = "Server7"
                        },
                        new
                        {
                            ServerId = 8,
                            IsOnline = true,
                            ServerCity = "Halifax",
                            ServerName = "Server8"
                        },
                        new
                        {
                            ServerId = 9,
                            IsOnline = true,
                            ServerCity = "Halifax",
                            ServerName = "Server9"
                        },
                        new
                        {
                            ServerId = 10,
                            IsOnline = false,
                            ServerCity = "Calgary",
                            ServerName = "Server10"
                        },
                        new
                        {
                            ServerId = 11,
                            IsOnline = true,
                            ServerCity = "Calgary",
                            ServerName = "Server11"
                        },
                        new
                        {
                            ServerId = 12,
                            IsOnline = true,
                            ServerCity = "Ottawa",
                            ServerName = "Server12"
                        },
                        new
                        {
                            ServerId = 13,
                            IsOnline = true,
                            ServerCity = "Ottawa",
                            ServerName = "Server13"
                        },
                        new
                        {
                            ServerId = 14,
                            IsOnline = true,
                            ServerCity = "Ottawa",
                            ServerName = "Server14"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
