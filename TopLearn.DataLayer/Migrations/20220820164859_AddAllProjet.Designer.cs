﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopLearn.DataLayer.Context;

namespace TopLearn.DataLayer.Migrations
{
    [DbContext(typeof(TopLearnContext))]
    [Migration("20220820164859_AddAllProjet")]
    partial class AddAllProjet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CoursePrice")
                        .HasColumnType("int");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DemoFileName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SubGroup")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.HasIndex("GroupId");

                    b.HasIndex("LevelId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubGroup");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseEpisode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EpisodeTime")
                        .HasColumnType("time");

                    b.Property<string>("EpisodeTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.HasKey("EpisodeId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEpisodes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LevelTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("LevelId");

                    b.ToTable("CourseLevels");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("StatusTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("StatusId");

                    b.ToTable("CourseStatuses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentID");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Wallet.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WalletTypeTypeId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletTypeTypeId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Wallet.WalletType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TypeId");

                    b.ToTable("WalletTypes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", "CourseGroup")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseLevel", "CourseLevel")
                        .WithMany("Courses")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseStatus", "CourseStatus")
                        .WithMany("Courses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", "Group")
                        .WithMany("SubGroup")
                        .HasForeignKey("SubGroup");

                    b.HasOne("TopLearn.DataLayer.Entities.User.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseGroup");

                    b.Navigation("CourseLevel");

                    b.Navigation("CourseStatus");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseEpisode", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.Course", "Course")
                        .WithMany("CourseEpisodes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", null)
                        .WithMany("CourseGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermission", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Wallet.Wallet", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.User.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.User.Wallet.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("WalletTypeTypeId");

                    b.Navigation("User");

                    b.Navigation("WalletType");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.Navigation("CourseEpisodes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.Navigation("CourseGroups");

                    b.Navigation("Courses");

                    b.Navigation("SubGroup");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseLevel", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseStatus", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.User", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("UserRoles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Wallet.WalletType", b =>
                {
                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
