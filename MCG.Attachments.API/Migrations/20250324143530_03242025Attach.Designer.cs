﻿// <auto-generated />
using System;
using MSG.Attachment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCG.Attachments.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250324143530_03242025Attach")]
    partial class _03242025Attach
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MCG.Attachments.API.Models.Domain.DocumentsType", b =>
                {
                    b.Property<int>("DocumentKey")
                        .HasColumnType("int");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentKey");

                    b.ToTable("DocumentsType");

                    b.HasData(
                        new
                        {
                            DocumentKey = 0,
                            DocumentName = "MRI"
                        });
                });

            modelBuilder.Entity("MCG.Attachments.API.Models.Domain.FileTypes", b =>
                {
                    b.Property<int>("FileKey")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileKey");

                    b.ToTable("FileTypes");

                    b.HasData(
                        new
                        {
                            FileKey = 0,
                            FileName = "PDF"
                        });
                });

            modelBuilder.Entity("MCG.Attachments.API.Models.Domain.PatientAttachments", b =>
                {
                    b.Property<int>("AttachmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUploaded")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocType")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("AttachmentID");

                    b.ToTable("PatientAttachments");

                    b.HasData(
                        new
                        {
                            AttachmentID = 1,
                            CreatedBy = 1,
                            DateUploaded = new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DocType = 0,
                            FileName = "MRI_03082025_1048.PDF",
                            FilePath = "E:\\MCG\\API\\MCG.API\\Files",
                            FileType = 0,
                            PatientID = 1000
                        },
                        new
                        {
                            AttachmentID = 2,
                            CreatedBy = 1,
                            DateUploaded = new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DocType = 1,
                            FileName = "CAT_03082025_1040.PDF",
                            FilePath = "E:\\MCG\\API\\MCG.API\\Files",
                            FileType = 0,
                            PatientID = 1001
                        },
                        new
                        {
                            AttachmentID = 3,
                            CreatedBy = 1,
                            DateUploaded = new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DocType = 1,
                            FileName = "CAT_03082025_1040.PDF",
                            FilePath = "E:\\MCG\\API\\MCG.API\\Files",
                            FileType = 2,
                            PatientID = 1001
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
