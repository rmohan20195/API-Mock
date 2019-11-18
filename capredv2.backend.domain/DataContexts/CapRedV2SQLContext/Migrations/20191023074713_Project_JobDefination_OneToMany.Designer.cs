﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using capredv2.backend.domain.DataContexts.CapRedV2SQLContext;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    [DbContext(typeof(CapRedV2Context))]
    [Migration("20191023074713_Project_JobDefination_OneToMany")]
    partial class Project_JobDefination_OneToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.CapRedV2User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool?>("IsActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinition", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<Guid>("ProjectId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("CoupaImporterJodDefinitions");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinitionDetail", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<Guid>("CsvInviteJobDefinitionId");

                    b.Property<string>("ErrorDescription");

                    b.Property<bool>("IsProcessed");

                    b.Property<bool?>("IsSuccessful");

                    b.Property<int>("LineNumber");

                    b.Property<string>("RawContent");

                    b.HasKey("Id");

                    b.HasIndex("CsvInviteJobDefinitionId");

                    b.ToTable("CoupaImporterJobDefinitionDetails");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.CapitalPlan", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("BusinessDriver");

                    b.Property<int>("BusinessPriority");

                    b.Property<bool>("BusinessRequirementsDone");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Group");

                    b.Property<string>("LeaseExpiry");

                    b.Property<bool>("PartOfPBASubmission");

                    b.Property<int>("Priority");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("RiskToBusinessByNotDoingIt");

                    b.Property<bool>("Rollover");

                    b.Property<int>("RolloverCategory");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("CapitalPlans");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.InvoiceHeader", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("AccountingTotalCurrency");

                    b.Property<string>("Billing");

                    b.Property<string>("Currency");

                    b.Property<DateTime?>("InvoiceDate");

                    b.Property<string>("InvoiceNumber");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("Status");

                    b.Property<string>("Supplier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("InvoiceHeaders");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.InvoiceLineItem", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<double?>("AccountingTotal");

                    b.Property<string>("Commodity");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("CurrentApprover");

                    b.Property<Guid>("InvoiceHeaderId");

                    b.Property<DateTime?>("LocalPaymentDate");

                    b.Property<double?>("POLineTotal");

                    b.Property<double?>("PONumber");

                    b.Property<string>("POShipToCity");

                    b.Property<string>("POShipToCountry");

                    b.Property<string>("POShipToName");

                    b.Property<string>("Paid");

                    b.Property<string>("PaymentNotes");

                    b.Property<string>("ProjectDescription");

                    b.Property<double?>("ReqLineNumber");

                    b.Property<double?>("ReqLineTotal");

                    b.Property<string>("ReqNumber");

                    b.Property<string>("RequestedBy");

                    b.Property<string>("TargetLocationCode");

                    b.Property<double?>("Total");

                    b.Property<double?>("TotalTax");

                    b.Property<string>("WorkflowCode");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceHeaderId");

                    b.ToTable("InvoiceLineItems");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.Project", b =>
                {
                    b.Property<Guid>("Id");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.ProjectInformation", b =>
                {
                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ActionsNextTwoWeeks");

                    b.Property<double>("ApprovedBudget");

                    b.Property<string>("AwardOfficeFurnitureContracts");

                    b.Property<string>("BauOrRe");

                    b.Property<string>("BudgetedOrUnbudgeted");

                    b.Property<string>("CapitalExpense");

                    b.Property<string>("CommenceInstallDesktopAndAVEquipment");

                    b.Property<string>("CommenceMoveIsAndUse");

                    b.Property<string>("CompleteProjectAnalysis");

                    b.Property<string>("Country");

                    b.Property<string>("CriticalityRationale");

                    b.Property<string>("CriticalityRationaleLevel2");

                    b.Property<int>("CurrentLeaseExpiryDate");

                    b.Property<int>("CurrentMileStonePercentComplete");

                    b.Property<string>("CurrentProjectPhase");

                    b.Property<string>("Department");

                    b.Property<string>("DesignBriefGatewayDocumentApproval");

                    b.Property<string>("DesignComplete");

                    b.Property<string>("EntityCode");

                    b.Property<string>("FacilityType");

                    b.Property<int>("FiscalYearEnd");

                    b.Property<string>("HandoverToFacilities");

                    b.Property<int>("HeadCount");

                    b.Property<string>("Highlights");

                    b.Property<bool>("InstallationComplete");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("LeaseExecution");

                    b.Property<string>("LeasedOrOwned");

                    b.Property<string>("Location");

                    b.Property<string>("LocationCode");

                    b.Property<int>("NewLeaseExpiryDate");

                    b.Property<DateTime>("OnboardingDate");

                    b.Property<string>("OnboardingDeckLink");

                    b.Property<string>("OnboardingStatus");

                    b.Property<int>("PercentComplete");

                    b.Property<bool>("ProjectComplete");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectName");

                    b.Property<string>("ProjectOwner");

                    b.Property<string>("ProjectSponsor");

                    b.Property<string>("ProjectStartReceiveBusinessRequest");

                    b.Property<string>("ProjectStatus");

                    b.Property<string>("ProjectType");

                    b.Property<string>("PurchaseCeAvTechCircuitsSecurityEquipment");

                    b.Property<string>("ReceiveCloseoutDocumentationAndFinalAccounts");

                    b.Property<string>("Region");

                    b.Property<string>("RequiredOrDiscretionary");

                    b.Property<string>("RisksAndIssues");

                    b.Property<bool>("Rollover");

                    b.Property<string>("Scope");

                    b.Property<string>("StartOnSite");

                    b.Property<string>("SubmitProjectRequestForAnalysis");

                    b.Property<string>("TechnologyRoomHandoverComplete");

                    b.Property<string>("TechnologyRoomMepCommissioningIST");

                    b.Property<string>("Top10Project");

                    b.Property<int>("UsableFloorArea");

                    b.HasKey("ProjectId");

                    b.ToTable("ProjectsInformation");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.PurchaseOrder", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Account");

                    b.Property<double>("AccountingTotal");

                    b.Property<string>("AccountingTotalCurrency");

                    b.Property<string>("Currency");

                    b.Property<string>("Item");

                    b.Property<DateTime>("OrderDate");

                    b.Property<double>("OrderTotal");

                    b.Property<Guid>("ProjectId");

                    b.Property<int>("PurchaseOrderNumber");

                    b.Property<string>("Supplier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.Requisition", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("Account");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Currency");

                    b.Property<string>("Item");

                    b.Property<double>("OrderTotal");

                    b.Property<Guid>("ProjectId");

                    b.Property<int>("PurchaseOrderNumber");

                    b.Property<double>("ReportingTotal");

                    b.Property<int>("RequisitionNumber");

                    b.Property<string>("Status");

                    b.Property<string>("Supplier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Requisitions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinition", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithMany("CoupaImporterJobDefinitions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinitionDetail", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinition", "CsvInviteJobDefinition")
                        .WithMany("CoupaImporterJobDefinitionDetails")
                        .HasForeignKey("CsvInviteJobDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.CapitalPlan", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithOne("CapitalPlan")
                        .HasForeignKey("capredv2.backend.domain.DatabaseEntities.Projects.CapitalPlan", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.InvoiceHeader", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithMany("InvoiceHeaders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.InvoiceLineItem", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.InvoiceHeader", "InvoiceHeader")
                        .WithMany("InvoiceLineItems")
                        .HasForeignKey("InvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.ProjectInformation", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithOne("ProjectInformation")
                        .HasForeignKey("capredv2.backend.domain.DatabaseEntities.Projects.ProjectInformation", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.PurchaseOrder", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capredv2.backend.domain.DatabaseEntities.Projects.Requisition", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.Projects.Project", "Project")
                        .WithMany("Requisitions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.CapRedV2User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.CapRedV2User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("capredv2.backend.domain.DatabaseEntities.CapRedV2User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("capredv2.backend.domain.DatabaseEntities.CapRedV2User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
