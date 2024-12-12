﻿// <auto-generated />
using System;
using GymManagementSystem.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241210070034_hbf")]
    partial class hbf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GymManagementSystem.Entities.AdminMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("AdminMessages");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.EmailTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("emailTypes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmailTemplates");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0);

                    b.Property<Guid>("ProgramId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("EnrolledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextDueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MemberId", "ProgramId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MemberStatus")
                        .HasColumnType("bit");

                    b.Property<string>("NicNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.MemberMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberMessages");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProgramPaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProgramPaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.ProgramImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("alternative")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramImages");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.ProgramPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("SubscriptionPaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("SubscriptionPaymentId");

                    b.ToTable("ProgramPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.RefundPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("RefundPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("ReviewMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SkippedPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndtDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProgramId");

                    b.ToTable("SkippedPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SubscribedProgram", b =>
                {
                    b.Property<Guid>("SubscribeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkoutProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubscribeId", "ProgramId");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("WorkoutProgramId");

                    b.ToTable("SubscribedPrograms");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsSpecialOffer")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SubscriptionPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentDate")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("UserCanPay")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.VisitorMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("VisitorMessages");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.WorkoutProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("WorkoutPrograms");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.AdminMessage", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Enrollment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("Enrollments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.WorkoutProgram", "Program")
                        .WithMany("Enrollments")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.Subscription", "Subscription")
                        .WithMany("Enrollments")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Program");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Member", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.User", "User")
                        .WithOne("Member")
                        .HasForeignKey("GymManagementSystem.Entities.Member", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.MemberMessage", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("MemberMessages")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Notification", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("Notifications")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Payment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("Payments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.ProgramPayment", "ProgramPayment")
                        .WithMany("Payments")
                        .HasForeignKey("ProgramPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("ProgramPayment");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.ProgramImages", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.WorkoutProgram", "Program")
                        .WithMany("Images")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.ProgramPayment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.WorkoutProgram", "Program")
                        .WithMany("ProgramPayments")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.SubscriptionPayment", "SubscriptionPayment")
                        .WithMany("ProgramPayments")
                        .HasForeignKey("SubscriptionPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Program");

                    b.Navigation("SubscriptionPayment");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.RefundPayment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Review", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("Reviews")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SkippedPayment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Member", "Member")
                        .WithMany("SkippedPayments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.WorkoutProgram", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SubscribedProgram", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Subscription", "Subscription")
                        .WithMany("SubscribedPrograms")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymManagementSystem.Entities.WorkoutProgram", "WorkoutProgram")
                        .WithMany("Subscriptions")
                        .HasForeignKey("WorkoutProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");

                    b.Navigation("WorkoutProgram");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SubscriptionPayment", b =>
                {
                    b.HasOne("GymManagementSystem.Entities.Subscription", "Subscription")
                        .WithMany("SubscriptionPayments")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Member", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("MemberMessages");

                    b.Navigation("Notifications");

                    b.Navigation("Payments");

                    b.Navigation("Reviews");

                    b.Navigation("SkippedPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.ProgramPayment", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.Subscription", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("SubscribedPrograms");

                    b.Navigation("SubscriptionPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.SubscriptionPayment", b =>
                {
                    b.Navigation("ProgramPayments");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.User", b =>
                {
                    b.Navigation("Member");
                });

            modelBuilder.Entity("GymManagementSystem.Entities.WorkoutProgram", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Images");

                    b.Navigation("ProgramPayments");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
