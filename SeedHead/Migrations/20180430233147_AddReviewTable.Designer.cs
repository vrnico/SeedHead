using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SeedHead.Models;

namespace SeedHead.Migrations
{
    [DbContext(typeof(SeedHeadContext))]
    [Migration("20180430233147_AddReviewTable")]
    partial class AddReviewTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5");

            modelBuilder.Entity("SeedHead.Models.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("OfferId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("SeedHead.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Rating");

                    b.Property<int>("SeedId");

                    b.HasKey("ReviewId");

                    b.HasIndex("SeedId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SeedHead.Models.Seed", b =>
                {
                    b.Property<int>("SeedId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("OfferId");

                    b.HasKey("SeedId");

                    b.HasIndex("OfferId");

                    b.ToTable("Seeds");
                });

            modelBuilder.Entity("SeedHead.Models.Review", b =>
                {
                    b.HasOne("SeedHead.Models.Seed", "Seed")
                        .WithMany()
                        .HasForeignKey("SeedId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SeedHead.Models.Seed", b =>
                {
                    b.HasOne("SeedHead.Models.Offer", "Offer")
                        .WithMany("Seeds")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
