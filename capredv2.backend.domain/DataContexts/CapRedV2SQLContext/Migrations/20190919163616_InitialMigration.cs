using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapitalPlans",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Rollover = table.Column<bool>(nullable: false),
                    RolloverCategory = table.Column<int>(nullable: false),
                    PartOfPBASubmission = table.Column<bool>(nullable: false),
                    BusinessPriority = table.Column<int>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    BusinessDriver = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true),
                    LeaseExpiry = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RiskToBusinessByNotDoingIt = table.Column<string>(nullable: true),
                    BusinessRequirementsDone = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapitalPlans", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_CapitalPlans_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoupaImporterJodDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoupaImporterJodDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoupaImporterJodDefinitions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    PurchaseOrderNumber = table.Column<long>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: true),
                    ReceivedOrCreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    LocalPaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsInformation",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    Scope = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LocationCode = table.Column<string>(nullable: true),
                    EntityCode = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Top10Project = table.Column<string>(nullable: true),
                    ProjectStatus = table.Column<string>(nullable: true),
                    ProjectOwner = table.Column<string>(nullable: true),
                    ProjectSponsor = table.Column<string>(nullable: true),
                    BauOrRe = table.Column<string>(nullable: true),
                    FiscalYearEnd = table.Column<int>(nullable: false),
                    BudgetedOrUnbudgeted = table.Column<string>(nullable: true),
                    CurrentProjectPhase = table.Column<string>(nullable: true),
                    UsableFloorArea = table.Column<int>(nullable: false),
                    HeadCount = table.Column<int>(nullable: false),
                    LeasedOrOwned = table.Column<string>(nullable: true),
                    CapitalExpense = table.Column<string>(nullable: true),
                    FacilityType = table.Column<string>(nullable: true),
                    ProjectType = table.Column<string>(nullable: true),
                    CriticalityRationale = table.Column<string>(nullable: true),
                    CriticalityRationaleLevel2 = table.Column<string>(nullable: true),
                    RequiredOrDiscretionary = table.Column<string>(nullable: true),
                    CurrentLeaseExpiryDate = table.Column<int>(nullable: false),
                    NewLeaseExpiryDate = table.Column<int>(nullable: false),
                    OnboardingStatus = table.Column<string>(nullable: true),
                    OnboardingDate = table.Column<DateTime>(nullable: false),
                    OnboardingDeckLink = table.Column<string>(nullable: true),
                    Rollover = table.Column<bool>(nullable: false),
                    ApprovedBudget = table.Column<double>(nullable: false),
                    PercentComplete = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Highlights = table.Column<string>(nullable: true),
                    ActionsNextTwoWeeks = table.Column<string>(nullable: true),
                    RisksAndIssues = table.Column<string>(nullable: true),
                    ProjectStartReceiveBusinessRequest = table.Column<string>(nullable: true),
                    CompleteProjectAnalysis = table.Column<string>(nullable: true),
                    SubmitProjectRequestForAnalysis = table.Column<string>(nullable: true),
                    CurrentMileStonePercentComplete = table.Column<int>(nullable: false),
                    DesignBriefGatewayDocumentApproval = table.Column<string>(nullable: true),
                    LeaseExecution = table.Column<string>(nullable: true),
                    DesignComplete = table.Column<string>(nullable: true),
                    PurchaseCeAvTechCircuitsSecurityEquipment = table.Column<string>(nullable: true),
                    AwardOfficeFurnitureContracts = table.Column<string>(nullable: true),
                    StartOnSite = table.Column<string>(nullable: true),
                    TechnologyRoomMepCommissioningIST = table.Column<string>(nullable: true),
                    TechnologyRoomHandoverComplete = table.Column<string>(nullable: true),
                    CommenceInstallDesktopAndAVEquipment = table.Column<string>(nullable: true),
                    HandoverToFacilities = table.Column<string>(nullable: true),
                    CommenceMoveIsAndUse = table.Column<string>(nullable: true),
                    InstallationComplete = table.Column<bool>(nullable: false),
                    ReceiveCloseoutDocumentationAndFinalAccounts = table.Column<string>(nullable: true),
                    ProjectComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsInformation", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectsInformation_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    PurchaseOrderNumber = table.Column<int>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    AccountingTotal = table.Column<double>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    AccountingTotalCurrency = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => new { x.ProjectId, x.PurchaseOrderNumber });
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisitions",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    RequisitionNumber = table.Column<int>(nullable: false),
                    OrderTotal = table.Column<double>(nullable: false),
                    ReportingTotal = table.Column<double>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    PurchaseOrderNumber = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisitions", x => new { x.ProjectId, x.RequisitionNumber });
                    table.ForeignKey(
                        name: "FK_Requisitions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoupaImporterJobDefinitionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RawContent = table.Column<string>(nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: true),
                    ErrorDescription = table.Column<string>(nullable: true),
                    IsProcessed = table.Column<bool>(nullable: false),
                    LineNumber = table.Column<int>(nullable: false),
                    CsvInviteJobDefinitionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoupaImporterJobDefinitionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoupaImporterJobDefinitionDetails_CoupaImporterJodDefinitions_CsvInviteJobDefinitionId",
                        column: x => x.CsvInviteJobDefinitionId,
                        principalTable: "CoupaImporterJodDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJobDefinitionDetails_CsvInviteJobDefinitionId",
                table: "CoupaImporterJobDefinitionDetails",
                column: "CsvInviteJobDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoupaImporterJodDefinitions_ProjectId",
                table: "CoupaImporterJodDefinitions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectId",
                table: "Invoices",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CapitalPlans");

            migrationBuilder.DropTable(
                name: "CoupaImporterJobDefinitionDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "ProjectsInformation");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Requisitions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CoupaImporterJodDefinitions");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
