﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wallet.Services.Transactions.Infrastructure;

namespace Wallet.Services.Transactions.Migrations
{
    [DbContext(typeof(TransactionsDbContext))]
    partial class TransactionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.EntityFrameworkHiLoSequence", "'EntityFrameworkHiLoSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountId");

                    b.Property<string>("AccountTitle")
                        .IsRequired();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CurrencyCode");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("CurrencyTitle");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("FromAccount");

                    b.Property<string>("Notes");

                    b.Property<int?>("ToAccount");

                    b.Property<int>("TransactionCategoryId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<int>("TypeId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TransactionCategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.TransactionCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "EntityFrameworkHiLoSequence")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TransactionType");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TransactionCategories");
                });

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.TransactionTag", b =>
                {
                    b.Property<Guid>("TransactionId");

                    b.Property<string>("Tag");

                    b.HasKey("TransactionId", "Tag");

                    b.ToTable("TransactionTags");
                });

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.Transaction", b =>
                {
                    b.HasOne("Wallet.Services.Transactions.Domain.Models.TransactionCategory", "TransactionCategory")
                        .WithMany()
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Wallet.Services.Transactions.Domain.Models.TransactionTag", b =>
                {
                    b.HasOne("Wallet.Services.Transactions.Domain.Models.Transaction")
                        .WithMany("TransactionTags")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
