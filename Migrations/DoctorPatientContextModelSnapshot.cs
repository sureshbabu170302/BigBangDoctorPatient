﻿// <auto-generated />
using System;
using BigBangDoctorPatient.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigBangDoctorPatient.Migrations
{
    [DbContext(typeof(DoctorPatientContext))]
    partial class DoctorPatientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointment", b =>
                {
                    b.Property<int>("Appointment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Appointment_Id"));

                    b.Property<string>("Appointment_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Doctor_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Patient_Id")
                        .HasColumnType("int");

                    b.HasKey("Appointment_Id");

                    b.HasIndex("Doctor_Id");

                    b.HasIndex("Patient_Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Admin", b =>
                {
                    b.Property<int>("Admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_Id"));

                    b.Property<string>("Admin_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Admin_Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Doctor", b =>
                {
                    b.Property<int>("Doctor_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Doctor_Id"));

                    b.Property<string>("Doctor_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doctor_PhNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Doctor_Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Patient", b =>
                {
                    b.Property<int>("Patient_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_Id"));

                    b.Property<string>("Disease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doctor_Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patient_PhNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_Id");

                    b.HasIndex("Doctor_Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Appointment", b =>
                {
                    b.HasOne("BigBangDoctorPatient.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("Doctor_Id");

                    b.HasOne("BigBangDoctorPatient.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("Patient_Id");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Patient", b =>
                {
                    b.HasOne("BigBangDoctorPatient.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("Doctor_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("BigBangDoctorPatient.Models.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
