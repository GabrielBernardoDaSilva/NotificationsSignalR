// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210810201349_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("API.Models.ChartData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<short>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Charts");
                });
#pragma warning restore 612, 618
        }
    }
}
