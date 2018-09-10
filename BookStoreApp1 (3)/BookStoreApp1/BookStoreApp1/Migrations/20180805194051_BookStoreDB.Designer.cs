﻿// <auto-generated />
using BookStoreApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookStoreApp1.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20180805194051_BookStoreDB")]
    partial class BookStoreDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStoreApp1.Models.BookModel", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Desc");

                    b.Property<bool>("IsActive");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.ToTable("BookModel");
                });

            modelBuilder.Entity("BookStoreApp1.Models.UserModel", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Username");

                    b.HasKey("Userid");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}