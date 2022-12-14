// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TwitterClone.MSSQL.EFConexts;

#nullable disable

namespace TwitterClone.MSSQL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TwitterClone.Business.Models.TweetModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("RootTweetId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserModelId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RootTweetId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("TwitterClone.Business.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TwitterClone.Business.Models.TweetModel", b =>
                {
                    b.HasOne("TwitterClone.Business.Models.TweetModel", "RootTweet")
                        .WithMany("Tweets")
                        .HasForeignKey("RootTweetId");

                    b.HasOne("TwitterClone.Business.Models.UserModel", null)
                        .WithMany("Tweets")
                        .HasForeignKey("UserModelId");

                    b.Navigation("RootTweet");
                });

            modelBuilder.Entity("TwitterClone.Business.Models.TweetModel", b =>
                {
                    b.Navigation("Tweets");
                });

            modelBuilder.Entity("TwitterClone.Business.Models.UserModel", b =>
                {
                    b.Navigation("Tweets");
                });
#pragma warning restore 612, 618
        }
    }
}
