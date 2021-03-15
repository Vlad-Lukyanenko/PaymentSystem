﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentSystem.SqlRepository;

namespace PaymentSystem.Api.Migrations
{
    [DbContext(typeof(PaymentSystemContext))]
    partial class PaymentSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountOfMoney")
                        .HasColumnType("float");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("BankAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87ab530a-aa4a-4fcb-a09d-436c03be080c"),
                            AmountOfMoney = 10000.0,
                            ClientId = new Guid("ef74f0f4-fcca-4751-a39e-4faae75f9123"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a41713c6-393e-4202-b490-62028bac8aed"),
                            AmountOfMoney = 20000.0,
                            ClientId = new Guid("16db1414-387c-40d1-89e3-05945c4661a1"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"),
                            AmountOfMoney = 20000.0,
                            ClientId = new Guid("c5a3b5dc-caa1-4b00-987b-b3acf0527397"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("5b5385b9-5157-4d4c-a883-1ea0c2bff1ed"),
                            AmountOfMoney = 30000.0,
                            ClientId = new Guid("28e1de8a-715a-4d50-8a08-2d86caca0bb4"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("54bf5559-3ded-4338-98f5-02d18509e7fd"),
                            AmountOfMoney = 40000.0,
                            ClientId = new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("52ef23aa-621f-4184-b88b-263f5f2e4b0f"),
                            AmountOfMoney = 50000.0,
                            ClientId = new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"),
                            AmountOfMoney = 60000.0,
                            ClientId = new Guid("1d8f8003-fd0e-42b5-9f7e-05b766de6340"),
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Cvc")
                        .HasColumnType("int")
                        .HasMaxLength(3);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c24145b-2b66-40b9-8057-a1c6c80e114f"),
                            BankAccountId = new Guid("87ab530a-aa4a-4fcb-a09d-436c03be080c"),
                            CardNumber = "1234789565897412",
                            ClientName = "Thor Odinson",
                            Cvc = 123,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c85e2b5d-e144-4076-af2d-9281ec0c6e98"),
                            BankAccountId = new Guid("a41713c6-393e-4202-b490-62028bac8aed"),
                            CardNumber = "5847632589562417",
                            ClientName = "Tony Stark",
                            Cvc = 734,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("19916e12-94c2-48bf-baa8-daabc5d43264"),
                            BankAccountId = new Guid("a41713c6-393e-4202-b490-62028bac8aed"),
                            CardNumber = "2569875896325698",
                            ClientName = "Tony Stark",
                            Cvc = 745,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9adbaebc-78e5-4cca-be0d-f05871f1a476"),
                            BankAccountId = new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"),
                            CardNumber = "3256874596325874",
                            ClientName = "Bruce Banner",
                            Cvc = 846,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("80b10d23-b9d4-415b-b247-2290c6752b93"),
                            BankAccountId = new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"),
                            CardNumber = "8745102356985478",
                            ClientName = "Bruce Banner",
                            Cvc = 137,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("b5fabe04-1620-4750-8601-df9c0d7dd2e3"),
                            BankAccountId = new Guid("5b5385b9-5157-4d4c-a883-1ea0c2bff1ed"),
                            CardNumber = "1023547895235687",
                            ClientName = "Wanda Maximoff",
                            Cvc = 128,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("42bd14da-8ebb-4344-9f07-8cd6bdb63675"),
                            BankAccountId = new Guid("54bf5559-3ded-4338-98f5-02d18509e7fd"),
                            CardNumber = "2014258785693258",
                            ClientName = "Victor Shade",
                            Cvc = 129,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("eddb3ea9-6306-4225-9f9a-520028104d71"),
                            BankAccountId = new Guid("52ef23aa-621f-4184-b88b-263f5f2e4b0f"),
                            CardNumber = "5024785695874253",
                            ClientName = "Victor Shade",
                            Cvc = 120,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8a486232-f9c5-4805-9858-862e4956f0d9"),
                            BankAccountId = new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"),
                            CardNumber = "3256985620147452",
                            ClientName = "Dane Whitman",
                            Cvc = 112,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("dd7f6807-04de-4190-81b4-914331a22cef"),
                            BankAccountId = new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"),
                            CardNumber = "3025485695874123",
                            ClientName = "Dane Whitman",
                            Cvc = 132,
                            ExpirationDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssueDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef74f0f4-fcca-4751-a39e-4faae75f9123"),
                            Address = "New York, Green Streen 13",
                            DateCreated = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1973, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Thor",
                            LastName = "Odinson",
                            PhoneNumber = "32568978568"
                        },
                        new
                        {
                            Id = new Guid("16db1414-387c-40d1-89e3-05945c4661a1"),
                            Address = "New York, Yellow Streen 11",
                            DateCreated = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1985, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Tony",
                            LastName = "Stark",
                            PhoneNumber = "36589875659"
                        },
                        new
                        {
                            Id = new Guid("c5a3b5dc-caa1-4b00-987b-b3acf0527397"),
                            Address = "New York, Brown Streen 10",
                            DateCreated = new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1974, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bruce",
                            LastName = "Banner",
                            PhoneNumber = "34587965865"
                        },
                        new
                        {
                            Id = new Guid("28e1de8a-715a-4d50-8a08-2d86caca0bb4"),
                            Address = "New York, Red Streen 15",
                            DateCreated = new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1980, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Wanda",
                            LastName = "Maximoff",
                            PhoneNumber = "32532547896"
                        },
                        new
                        {
                            Id = new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"),
                            Address = "New York, Black Streen 14",
                            DateCreated = new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1977, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Victor",
                            LastName = "Shade",
                            PhoneNumber = "32987563545"
                        },
                        new
                        {
                            Id = new Guid("1d8f8003-fd0e-42b5-9f7e-05b766de6340"),
                            Address = "New York, White Streen 12",
                            DateCreated = new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(1976, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Dane",
                            LastName = "Whitman",
                            PhoneNumber = "36548998566"
                        });
                });

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AmountOfMoney")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RecipientCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.BankAccount", b =>
                {
                    b.HasOne("PaymentSystem.SqlRepository.Models.Client", null)
                        .WithMany("BankAccounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaymentSystem.SqlRepository.Models.Card", b =>
                {
                    b.HasOne("PaymentSystem.SqlRepository.Models.BankAccount", null)
                        .WithMany("PaymentCards")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
