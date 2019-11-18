using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;
using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DatabaseEntities.Projects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext
{
    public class CapRedV2Context : IdentityDbContext<CapRedV2User>
    {
        public CapRedV2Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectInformation> ProjectsInformation { get; set; }
        public DbSet<CapitalPlan> CapitalPlans { get; set; }
        public DbSet<RequisitionHeader> RequisitionHeaders { get; set; }
        public DbSet<RequisitionLineItem> RequisitionLineItems { get; set; }
        public DbSet<POHeader> PurchaseOrderHeaders { get; set; }
        public DbSet<POLineItem> PurchaseOrderLineItems { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<CoupaImporterJobDefinition> CoupaImporterJodDefinitions { get; set; }
        public DbSet<CoupaImporterJobDefinitionDetail> CoupaImporterJobDefinitionDetails { get; set; }

        // Dropdown tables
        public DbSet<AssetCategory> AssetCategorys { get; set; }
        public DbSet<BudgetItemType> BudgetItemTypes { get; set; }
        public DbSet<BusinessDriver> BusinessDrivers { get; set; }
        public DbSet<BusinessJustification> BusinessJustifications { get; set; }
        public DbSet<BusinessRisk> BusinessRisks { get; set; }
        public DbSet<CapitalOrExpense> CapitalOrExpenses { get; set; }
        public DbSet<ChangeOrderReason> ChangeOrderReasons { get; set; }
        public DbSet<CipOrNonCip> CipOrNonCips { get; set; }
        public DbSet<CostCodeLevel1> CostCodeLevel1s { get; set; }
        public DbSet<CostCodeLevel2> CostCodeLevel2s { get; set; }
        public DbSet<FacilityType> FacilityTypes { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemStatus> ItemStatuses { get; set; }
        public DbSet<LeasedOrOwned> LeasedOrOwneds { get; set; }
        public DbSet<Milestones> Milestones { get; set; }
        public DbSet<PlanProjectOrEmerging> PlanProjectOrEmergings { get; set; }
        public DbSet<ProjectTheme> ProjectThemes { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<RealEstateOrBau> RealEstateOrBaus { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ReportingMilestones> ReportingMilestones { get; set; }
        public DbSet<RequiredOrDiscretionary> RequiredOrDiscretionaries { get; set; }
        public DbSet<RestorationRequirement> RestorationRequirements { get; set; }
        public DbSet<RolloverCategory> RolloverCategories { get; set; }
        public DbSet<WorkPackagesLevel1> WorkPackagesLevel1s { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Project>()
                .HasKey(p => p.Id);

            builder.Entity<Project>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Entity<Project>()
                .HasOne(p => p.ProjectInformation).WithOne(i => i.Project);

            builder.Entity<Project>()
                .HasOne(p => p.CapitalPlan).WithOne(i => i.Project);

            builder.Entity<ProjectInformation>()
                .HasKey(p => p.ProjectId);

            builder.Entity<CapitalPlan>()
                .HasKey(c => c.Id);

            builder.Entity<CapitalPlan>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Entity<InvoiceHeader>()
                .HasKey(r => r.Id);

            builder.Entity<InvoiceHeader>()
                .Property(i => i.Id)
                .ValueGeneratedNever();

            builder.Entity<InvoiceLineItem>()
                .HasKey(i => i.Id);

            builder.Entity<InvoiceLineItem>()
                .Property(i => i.Id)
                .ValueGeneratedNever();

            builder.Entity<RequisitionHeader>()
               .HasKey(i => i.Id);

            builder.Entity<RequisitionHeader>()
                .Property(r => r.Id)
                .ValueGeneratedNever();

            builder.Entity<RequisitionLineItem>()
               .HasKey(i => i.Id);

            builder.Entity<RequisitionLineItem>()
                .Property(r => r.Id)
                .ValueGeneratedNever();

            builder.Entity<POHeader>()
               .HasKey(p => p.Id);

            builder.Entity<POHeader>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Entity<POLineItem>()
               .HasKey(p => p.Id);

            builder.Entity<POLineItem>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Entity<CoupaImporterJobDefinition>()
                .HasKey(g => g.Id);

            builder.Entity<CoupaImporterJobDefinition>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<CoupaImporterJobDefinitionDetail>()
                .HasKey(g => g.Id);

            builder.Entity<CoupaImporterJobDefinitionDetail>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            // Dropdowns
            builder.Entity<AssetCategory>()
             .HasKey(g => g.Id);

            builder.Entity<AssetCategory>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<BudgetItemType>()
             .HasKey(g => g.Id);

            builder.Entity<BudgetItemType>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<BusinessDriver>()
             .HasKey(g => g.Id);

            builder.Entity<BusinessDriver>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<BusinessJustification>()
             .HasKey(g => g.Id);

            builder.Entity<BusinessJustification>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<BusinessRisk>()
             .HasKey(g => g.Id);

            builder.Entity<BusinessRisk>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<CapitalOrExpense>()
             .HasKey(g => g.Id);

            builder.Entity<CapitalOrExpense>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<ChangeOrderReason>()
             .HasKey(g => g.Id);

            builder.Entity<ChangeOrderReason>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<CipOrNonCip>()
             .HasKey(g => g.Id);

            builder.Entity<CipOrNonCip>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<CostCodeLevel1>()
             .HasKey(g => g.Id);

            builder.Entity<CostCodeLevel1>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<CostCodeLevel2>()
             .HasKey(g => g.Id);

            builder.Entity<CostCodeLevel2>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<FacilityType>()
             .HasKey(g => g.Id);

            builder.Entity<FacilityType>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<FiscalYear>()
             .HasKey(g => g.Id);

            builder.Entity<FiscalYear>()
                .Property(g => g.Id)
                .ValueGeneratedNever();


            builder.Entity<ItemCategory>()
             .HasKey(g => g.Id);

            builder.Entity<ItemCategory>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<ItemStatus>()
             .HasKey(g => g.Id);

            builder.Entity<ItemStatus>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<LeasedOrOwned>()
             .HasKey(g => g.Id);

            builder.Entity<LeasedOrOwned>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<Milestones>()
             .HasKey(g => g.Id);

            builder.Entity<Milestones>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<PlanProjectOrEmerging>()
             .HasKey(g => g.Id);

            builder.Entity<PlanProjectOrEmerging>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<ProjectTheme>()
             .HasKey(g => g.Id);

            builder.Entity<ProjectTheme>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<ProjectType>()
             .HasKey(g => g.Id);

            builder.Entity<ProjectType>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<RealEstateOrBau>()
           .HasKey(g => g.Id);

            builder.Entity<RealEstateOrBau>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<Region>()
           .HasKey(g => g.Id);

            builder.Entity<Region>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<ReportingMilestones>()
           .HasKey(g => g.Id);

            builder.Entity<ReportingMilestones>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<RequiredOrDiscretionary>()
           .HasKey(g => g.Id);

            builder.Entity<RequiredOrDiscretionary>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<RestorationRequirement>()
           .HasKey(g => g.Id);

            builder.Entity<RestorationRequirement>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<RolloverCategory>()
           .HasKey(g => g.Id);

            builder.Entity<RolloverCategory>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

            builder.Entity<WorkPackagesLevel1>()
           .HasKey(g => g.Id);

            builder.Entity<WorkPackagesLevel1>()
                .Property(g => g.Id)
                .ValueGeneratedNever();

        }
    }
}
