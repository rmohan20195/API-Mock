using System;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities;
using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capredv2.backend.domain.DataContexts.CapRedV2SQLContext
{
    public static class CapRedV2ContextExtensionMethods
    {
        public static bool AllMigrationsApplied(this CapRedV2Context context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void Seed(this CapRedV2Context context)
        {
            // Dropdown Values
            SeedAssetCategorys(context);
            SeedBudgetItemTypes(context);
            SeedBusinessDrivers(context);
            SeedBusinessJustifications(context);
            SeedBusinessRisks(context);
            SeedCapitalOrExpense(context);
            SeedChangeOrderReason(context);
            SeedCipOrNonCip(context);
            SeedCostCodeLevel1(context);
            SeedCostCodeLevel2(context);
            SeedFacilityType(context);
            SeedFiscalYear(context);
            SeedItemCategory(context);
            SeedItemStatus(context);
            SeedLeasedOrOwned(context);
            SeedMilestones(context);
            SeedPlanProjectOrEmerging(context);
            SeedProjectTheme(context);
            SeedProjectType(context);
            SeedRealEstateOrBau(context);
            SeedRegion(context);
            SeedReportingMilestones(context);
            SeedRequiredOrDiscretionary(context);
            SeedRestorationRequirement(context);
            SeedRolloverCategory(context);
            SeedWorkPackagesLevel1(context);

            //Add methods to seed data here
            SeedUsers(context);
            context.SaveChanges();
        }

        private static void SeedUsers(CapRedV2Context context)
        {
            if (context.Users.Any(u => u.Id == "ff9398f7-7658-4f1b-b155-8b98e9dffc0c")) return;

            var nexusUser = new CapRedV2User
            {
                Id = "ff9398f7-7658-4f1b-b155-8b98e9dffc0c",
                AccessFailedCount = 0,
                ConcurrencyStamp = "f1e41336-f067-447f-ad6d-77c7715602c8",
                UserName = "capredadmin@topdevz.com",
                Email = "capredadmin@topdevz.com",
                EmailConfirmed = false,
                IsActive = null,
                LockoutEnabled = true,
                LockoutEnd = null,
                NormalizedEmail = "CAPREDADMIN@TOPDEVZ.COM",
                NormalizedUserName = "CAPREDADMIN@TOPDEVZ.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEIF95+8PMXIq+ABPZUGqspbx3NE/GPcOEh7N7ne98FolAGQQdjYIs2hQt18GFbHpKA==",
                PhoneNumberConfirmed = false,
                SecurityStamp = "503bd33d-df51-4dbf-9a73-c8f357f64232",
                TwoFactorEnabled = false
            };

            context.Users.Add(nexusUser);
        }

        private static void SeedAssetCategorys(CapRedV2Context context)
        {
            if (context.AssetCategorys.Any()) return;
            string[] assetCategories = {
                "5410105 Amortization lease improvements",
                "5410505 Depreciation - furniture & fixtures",
                "5410330 Firm Moving",
                "5415610 Art",
                "5410115 Core and Shell",
                "5410120 Infrastructure/Personal Property",
                "5411105 Hardware",
                "5410310 Repairs & Maintenance",
                "5410311 Repairs and Maintenance - Contract",
                "5415610 Consulting Other - TandM",
                "5415611 Consulting - Fixed Price SOW (stmt of work)",
                "5411220 Hardware < $25,000 (APAC < $5,000)",
                "5410610 Furniture and equipment <$25,000 (APAC < $5,000)",
                "5411115 Capitalization Technology",
                "5411110 Computer Software",
                "Software License",
                "Travel & Expenses"
            };

            for (int i = 0; i < assetCategories.Length; i++)
            {
                var assetCategory = new AssetCategory { Id = Guid.NewGuid(), Position = i, Value = assetCategories[i] };
                context.AssetCategorys.Add(assetCategory);
            }
        }

        private static void SeedBudgetItemTypes(CapRedV2Context context)
        {
            if (context.BudgetItemTypes.Any()) return;
            string[] budgetItemTypes = { "Original Order", "Pending Forecast", "Pending Change", "Change Order", "Budget Item" };

            for (int i = 0; i < budgetItemTypes.Length; i++)
            {
                var budgetItemType = new BudgetItemType { Id = Guid.NewGuid(), Position = i, Value = budgetItemTypes[i] };
                context.BudgetItemTypes.Add(budgetItemType);
            }
        }

        private static void SeedBusinessDrivers(CapRedV2Context context)
        {
            if (context.BusinessDrivers.Any()) return;
            string[] businessDrivers = { "Run", "Grow", "Transform", "BAU", "Regulatory", "Security" };

            for (int i = 0; i < businessDrivers.Length; i++)
            {
                var businessDriver = new BusinessDriver { Id = Guid.NewGuid(), Position = i, Value = businessDrivers[i] };
                context.BusinessDrivers.Add(businessDriver);
            }
        }

        private static void SeedBusinessJustifications(CapRedV2Context context)
        {
            if (context.BusinessJustifications.Any()) return;
            string[] businessJustifications = {
                "Required for Project Due Diligence",
                "Project Design Team Component",
                "Project Management Team Component",
                "Project Long Lead Item Procurement",
                "Required for Construction or Installation",
                "Replacement of Project Team Member"
            };

            for (int i = 0; i < businessJustifications.Length; i++)
            {
                var businessJustification = new BusinessJustification { Id = Guid.NewGuid(), Position = i, Value = businessJustifications[i] };
                context.BusinessJustifications.Add(businessJustification);
            }
        }

        private static void SeedBusinessRisks(CapRedV2Context context)
        {
            if (context.BusinessRisks.Any()) return;
            string[] businessRisks = { "Security", "Financial", "Compliance", "Operational" };

            for (int i = 0; i < businessRisks.Length; i++)
            {
                var businessRisk = new BusinessRisk { Id = Guid.NewGuid(), Position = i, Value = businessRisks[i] };
                context.BusinessRisks.Add(businessRisk);
            }
        }

        private static void SeedCapitalOrExpense(CapRedV2Context context)
        {
            if (context.CapitalOrExpenses.Any()) return;
            string[] capitalOrExpenses = { "Capital", "Expense" };

            for (int i = 0; i < capitalOrExpenses.Length; i++)
            {
                var capitalOrExpense = new CapitalOrExpense { Id = Guid.NewGuid(), Position = i, Value = capitalOrExpenses[i] };
                context.CapitalOrExpenses.Add(capitalOrExpense);
            }
        }

        private static void SeedChangeOrderReason(CapRedV2Context context)
        {
            if (context.ChangeOrderReasons.Any()) return;
            string[] changeOrderReasons = {
                "Client Design Change", "Design Omission/Correction", "Statutory Requirement", "Force Majeure",
                "Acceleration", "Delay by Client Team","Correction of Existing Conditions", "Scope Addition"
            };

            for (int i = 0; i < changeOrderReasons.Length; i++)
            {
                var changeOrderReason = new ChangeOrderReason { Id = Guid.NewGuid(), Position = i, Value = changeOrderReasons[i] };
                context.ChangeOrderReasons.Add(changeOrderReason);
            }
        }

        private static void SeedCipOrNonCip(CapRedV2Context context)
        {
            if (context.CipOrNonCips.Any()) return;
            string[] cipOrNonCips = { "CIP", "Non-CIP" };

            for (int i = 0; i < cipOrNonCips.Length; i++)
            {
                var cipOrNonCip = new CipOrNonCip { Id = Guid.NewGuid(), Position = i, Value = cipOrNonCips[i] };
                context.CipOrNonCips.Add(cipOrNonCip);
            }
        }

        private static void SeedCostCodeLevel1(CapRedV2Context context)
        {
            if (context.CostCodeLevel1s.Any()) return;
            string[] costCodeLevel1s = {
                "A10 - Foundations","A20 - Basement Construction","B10 - Superstructure","10 - Interior Construction",
                "D10 - Building Services","E10 - Equipment ES","E12 - Equipment Tech","E13 - Equipment AV",
                "E14 - Equipment Data Center","E20 - Furnishings and Furniture","F20 - Demolition","G10 - Sitework",
                "Z01 - Contractor Indirect Costs and Fee","Z10 - Design Consultants","Z20 - Project Management and Consultants",
                "Z30 - Approvals","Z40 - Migration","Z50 - Landlord Costs","Z60 - Sales/Use Tax and VAT",
                "Z72 - ARO & Restoration","Z80 - Land Purchase","Z90 - Contingencies and Allowances","Furnishings",
                "Selective Building Demolition","Site Preparation","Site Improvements","Site Civil/Mechanical Utilities",
                "Site Electrical Utilities","PreConstruction","General Requirements","Design Consultants",
                "Project Management","Statutory Approvals","Move costs",
                "Landlord Costs","Tax","Expensed Project Costs","Asset Restoration Requirements","Day Two",
                "Land & Building Purchase","Contingencies & Allowances"
            };

            for (int i = 0; i < costCodeLevel1s.Length; i++)
            {
                var costCodeLevel1 = new CostCodeLevel1 { Id = Guid.NewGuid(), Position = i, Value = costCodeLevel1s[i] };
                context.CostCodeLevel1s.Add(costCodeLevel1);
            }
        }

        private static void SeedCostCodeLevel2(CapRedV2Context context)
        {
            if (context.CostCodeLevel2s.Any()) return;
            string[] costCodeLevel2s = {
                "A1010 - Foundations","A1020 - Special Foundations","A1030 - Slab Construction","A2000 - Basement Construction",
                "B1010 - Floor and Frame Construction","B1020 - Roof Construction","B2000 - Enclosure, Windows and Ext. Doors",
                "B3000 - Roofing","C1001 - Interior Construction - General","C1010 - Wallboard Partitions",
                "C1011 - Glazed Partition Systems","C1012 - Moveable Walls","C1020 - Interior Doors, access panels etc.",
                "C1021 - Fixed Furnishings - Millwork","C1022 - Fixed Furnishings - Blinds and misc.",
                "C1023 - Fixed Furnishings - Countertops, mirrors, shelving, vanities","C1030 - Fittings Specialties - Toilet Ptns, closet accessories",
                "C2000 - Stair Construction and Finishes","C3010 - Wall Finishes","C3020 - Floor Finishes","C3025 - Raised Access Floor",
                "C3030 - Ceiling Finishes","D0001 - Services - General and Misc.","D1000 - Elevator","D2000 - Plumbing",
                "D3000 - HVAC","D3066 - Energy Monitoring and Control","D3067 - Building Automation Systems","D4010 - Fire Protection Systems",
                "D5010 - Electrical Services & Distribution","D5020 - Lighting & Branch Wiring","D5030 - Communications Systems (telecom, lv cabling, clocks, AV distribution etc)",
                "D5038 - Security Systems","E1018 - Office Equipment","E1023 - Theater & Stage Equipment","E1028 - Medical Equipment",
                "E1031 - Vehicular Service Equipment","E1032 - Parking Control Equipment","E1041 - Maintenance Equipment",
                "E1043 - Food Service Equipment","E1047 - Athletic, Recreation & Therapeutic","E1061 - Generator",
                "E1062 - UPS","E1063 - Server Racks and Cabinets","E1064 - CRAC Units","E1067 - Security Equipment",
                "E1068 - Fire Protection Specialties (extinguishers , cabinets etc)","E1069 - Health & Safety Equipment",
                "E1070 - MEP Equipment Purchases","E1071 - Misc. Equipment Purchases","E1210 - Technology - User Desktop Installations",
                "E1220 - Technology - Meeting Room Desktop Installations","E1230 - Technology - Network Equipment",
                "E1250 - Technology - Service Providers","E1260 - Technology - Outsourced Consultants",
                "E1270 - Technology - Software Installations and Upgrades","E1280 - Technology - Software Licenses",
                "E1290 - Technology - Fiber Circuit Installations (Cabling, etc)","E1310 - Audio-Visual -Meeting Room AV Installations",
                "E1320 - Audio-Visual -TV Installations","E1330 - Audio-Visual -Collaborative AV Installations",
                "E1340 - Audio-Visual -Server Hardware - Linux","E1350 - Audio-Visual -Server Hardware - Windows",
                "E1410 - Data Center Technology - Data Storage Installations","E1420 - Data Center Technology - Network Equipment",
                "E1430 - Data Center Technology - Service Providers","E1440 - Data Center Technology - Outsourced Consultants",
                "E1450 - Data Center Technology - Software Installations and Upgrades","E1460 - Data Center Technology - Software Licenses",
                "E1470 - Data Center Technology - Fiber Circuit Installations (Cabling, etc)","E1480 - Data Center Technology - Server Hardware - Linux",
                "E1490 - Data Center Technology - Server Hardware - Windows","E2100 - Furniture and Equipment - Misc.",
                "E2105 - Office Equipment - whiteboards, loose shelving etc.","E2110 - Office Furniture","E2115 - Office and Meeting Chairs",
                "E2120 - Client Suite Furniture","E2130 - Loose Furniture/furnishings - chairs, podium, misc. tables etc.",
                "E2150 - Pantry and Support Equipment/White Goods","E2200 - Branding Signage","E2250 - Wayfinding Signage","E2300 - Artwork",
                "F2010 - Building Elements Demolition","G1000 - Site Preparation","G2000 - Site Improvement","G3000 - Site Mechanical Utiities",
                "G4000 - Site Electrical and Communications Utilities","Z0100 - General Requirements and Logistics","Z0200 - Contractor/CM Insurance",
                "Z0300 - Bonding","Z0400 - CM Fee","Z0450 - CM Preconstruction Services","Z0900 - Retainage","Z1050 - Pre-Approval DesignWork - Expensed",
                "Z1100 - Architect","Z1150 - Interior Designer","Z1200 - Structural Engineering","Z1250 - Civil and Landscaping Engineering",
                "Z1300 - MEP Engineering","Z1400 - Low Voltage Cabling Engineering","Z1450 - Audio Visual Engineering","Z1480 - IT Design & Integration",
                "Z1500 - Acoustical Engineering","Z1600 - Lighting Design","Z1700 - Security Engineering",
                "Z1800 - Traffic Engineering","Z1810 - Elevator Consultant","Z1820 - Catering Consultant",
                "Z1840 - Signage Design","Z1860 - Art Consultant","Z1999 - Misc. Design Consultants","Z2050 - Pre-Approval Planning/DD Work - Expensed",
                "Z2100 - Project Manager","Z2150 - Cost Manager","Z2200 - BlackRock Project Manager","Z2220 - BlackRock PMO Consultant",
                "Z2240 - BlackRock PCG Consultant","Z2300 - Sustainability Consultant","Z2500 - Commissioning Services",
                "Z2550 - Health & Safety Consultant","Z2600 - Legal Services - D&C scope","Z2999 - Other Project Consultants",
                "Z3100 - Filing Fees","Z3200 - Code Expeditor and Planning Consultant","Z3999 - Approvals Charges Generally",
                "Z4100 - Move Manager","Z4200 - Move Courier Services","Z4300 - Move Supplies","Z4400 - Final Clean","Z4500 - Security Guard Service",
                "Z4999 - Misc. Migration Costs","Z5100 - Landlord Supervision","Z5200 - Landlord Protection Measures",
                "Z5300 - Use of Building Services during Construction","Z5999 - Misc. Landlord Costs","Z6100 - Recoverable Sales Tax/VAT (to P/R)",
                "Z6150 - Non-Recoverable Sales Tax/VAT (to P/R)","Z7200 - ARO - Restoration Cost","Z8100 - Land Purchase Price",
                "Z8200 - Agent Fees","Z8300 - Land Taxes and Disbursements","Z8999 - Misc. Land Purchase Costs","Z9100 - Design Development Allowance",
                "Z9200 - Project Working Balance","Z9300 - Construction Risk Contingency","Fixed Artwork",
                "Fixed Casework","Window Treatment","Fixed Floor Grilles & Mats","Fixed Multiple Seating","Fixed Interior Landscaping",
                "Fixed Furnishings - Blinds and misc.","Fixed Furnishings - Countertops, mirrors, shelving, vanities",
                "Fittings Specialties - Toilet Ptns, closet accessories","Moveable Artwork","Moveable Mats & Rugs",
                "Moveable Multiple Seating","Moveable Interior Landscaping","Furniture and Equipment - Misc.","Office Equipment - whiteboards, loose shelving etc.",
                "Office Furniture","Client Suite Furniture","Loose Furniture/furnishings - chairs, podium, misc. tables etc.",
                "Pantry Furniture","Pantry and Support Equipment/White Goods","Branding Signage",
                "Wayfinding Signage","Interior Demolition","Exterior Demolition","Removal of Hazardous Components","Clearing & Grubbing",
                "Building Demolition","Demolition of Site Components","Relocation of Building Utilities","Site Grading & Excavation",
                "Borrow Fill","Soil Stabilization & Treatment","Site Dewatering","Site Shoring","Removal of Contaminated Soil",
                "Restoration & Treatment","Paving & Surfacing","Rails & Barriers","Markings & Signage","Parking Booths & Equipment",
                "Exterior Steps","Fences & Gates","Retaining Walls","Terrace & Perimeter Walls","Miscellaneous Structures",
                "Top Soil & Planting Beds","Planting","Irrigation Systems","Piping System Testing & Balancing","Steam Supply",
                "Condensate Return","Hot Water Supply System","Pumping Stations","Chilled Water Piping","Cooling Towers on Site",
                "Piping","Equipment","Storage Tanks","Substations","Overhead Power Distribution","Underground Distribution",
                "Fixtures & Transformers","Poles","Wiring Conduits & Ductbanks","Controls","Site Security & Alarm System",
                "CM Design Services","CM Preconstruction Services","General Requirements and Logistics","Contractor/CM Insurance",
                "Retainage","Architect","Interior Designer","Structural Engineering","Civil and Landscaping Engineering",
                "MEP Engineering","Low Voltage Cabling Engineering","Audio Visual Engineering","IT Design & Integration",
                "Acoustical Engineering","Lighting Design"," Security Engineering","Traffic Engineering","Elevator Consultant",
                "Catering Consultant","Signage Design","Art Consultant","Misc. Design Consultants","Misc Blueprinting and Reimbursables",
                "Project Manager","Cost Manager","BlackRock Project Manager","BlackRock PMO Consultant","BlackRock PCG Consultant",
                "Sustainability Consultant","Commissioning Services","Health & Safety Consultant","Legal Services - D&C scope",
                "Tax Consultants","Other Project Consultants","Filing Fees","Code Expeditor and Planning Consultant","Approvals Charges Generally",
                "Move Manager","Move Courier Services","Move Supplies","Final Clean","Security Guard Service","Misc. Migration Costs",
                "Landlord Supervision","Landlord Protection Measures","Use of Building Services during Construction",
                "Misc. Landlord Costs","Recoverable Sales Tax/VAT (to P/R)","Non-Recoverable Sales Tax/VAT (to P/R)",
                "Non-CIP Expensed Consultants","Non-CIP Expensed construction (repairs & Maintenance)","Non-CIP Expensed Furniture & Fixtures",
                "Non-CIP Expensed Equipment","ARO - Restoration Cost","Day Two - Design","Day Two - Project Management","Day Two - Construction",
                "Day Two - Furniture & Equipment","Land Purchase Price","Agent Fees","Land Taxes and Disbursements",
                "Misc. Land Purchase Costs","Design Development Allowance","Construction Risk Contingency","Project Working Balance"
            };

            for (int i = 0; i < costCodeLevel2s.Length; i++)
            {
                var costCodeLevel2 = new CostCodeLevel2 { Id = Guid.NewGuid(), Position = i, Value = costCodeLevel2s[i] };
                context.CostCodeLevel2s.Add(costCodeLevel2);
            }
        }

        private static void SeedFacilityType(CapRedV2Context context)
        {
            if (context.FacilityTypes.Any()) return;
            string[] facilityTypes = {
                "Headquarters", "iHub","Regional Office","Local Sales Office","BCM Site","Data Center","Recovery Sites","Executive Suite"
            };

            for (int i = 0; i < facilityTypes.Length; i++)
            {
                var facilityType = new FacilityType { Id = Guid.NewGuid(), Position = i, Value = facilityTypes[i] };
                context.FacilityTypes.Add(facilityType);
            }
        }

        private static void SeedFiscalYear(CapRedV2Context context)
        {
            if (context.FiscalYears.Any()) return;
            string[] fiscalYears = { "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023" };

            for (int i = 0; i < fiscalYears.Length; i++)
            {
                var fiscalYear = new FiscalYear { Id = Guid.NewGuid(), Position = i, Value = fiscalYears[i] };
                context.FiscalYears.Add(fiscalYear);
            }
        }

        private static void SeedItemCategory(CapRedV2Context context)
        {
            if (context.ItemCategories.Any()) return;
            string[] itemCategories = {
                "Consultancy Fees",
                "Consultancy Expenses",
                "Consultancy Fees and Expenses",
                "Subconsultant fees and expenses",
                "Equipment Purchase & Install",
                "Furniture Purchase & Install",
                "CM/GC Fees and Trades",
                "Permitting/Authorities"
            };

            for (int i = 0; i < itemCategories.Length; i++)
            {
                var itemCategory = new ItemCategory { Id = Guid.NewGuid(), Position = i, Value = itemCategories[i] };
                context.ItemCategories.Add(itemCategory);
            }
        }

        private static void SeedItemStatus(CapRedV2Context context)
        {
            if (context.ItemStatuses.Any()) return;
            string[] itemStatuses = { "Approved", "In Review", "Pending", "Forecast" };

            for (int i = 0; i < itemStatuses.Length; i++)
            {
                var itemStatus = new ItemStatus { Id = Guid.NewGuid(), Position = i, Value = itemStatuses[i] };
                context.ItemStatuses.Add(itemStatus);
            }
        }

        private static void SeedLeasedOrOwned(CapRedV2Context context)
        {
            if (context.LeasedOrOwneds.Any()) return;
            string[] leasedOrOwneds = { "Leased", "Owned" };

            for (int i = 0; i < leasedOrOwneds.Length; i++)
            {
                var leasedOrOwned = new LeasedOrOwned { Id = Guid.NewGuid(), Position = i, Value = leasedOrOwneds[i] };
                context.LeasedOrOwneds.Add(leasedOrOwned);
            }
        }

        private static void SeedMilestones(CapRedV2Context context)
        {
            if (context.Milestones.Any()) return;
            string[] milestones = {
                "Project Start/Receive Business Request",
                "Complete Project Analysis",
                "Submit Project Request for Approval",
                "Receive Business Approval",
                "Design Brief Gateway Document Approval",
                "Lease Execution",
                "Design Development Complete",
                "Construction Document complete / issue for Bid",
                "Complete Purchase of long lead CE / AV / Tech / Circuits / Security Equipment",
                "Award Office Furniture Contracts",
                "Start on Site",
                "MDF / IDF MEP Commissioning and IST",
                "MDF / IDF Handover to Technology",
                "Commence Install Desktop and AV Equipment",
                "Handover to Facilities - Construction Substantial Completion",
                "Commence Move - In",
                "Installation Complete incl.Punchlist - Final Acceptance",
                "Receive Closeout Documentation and Final Accounts",
                "Project Complete"
            };

            for (int i = 0; i < milestones.Length; i++)
            {
                var milestone = new Milestones { Id = Guid.NewGuid(), Position = i, Value = milestones[i] };
                context.Milestones.Add(milestone);
            }
        }

        private static void SeedPlanProjectOrEmerging(CapRedV2Context context)
        {
            if (context.PlanProjectOrEmergings.Any()) return;
            string[] planProjectOrEmergings = {
                "Plan Project","Fiscal rollover project","Canceled","Requested Project","Emerging"
            };

            for (int i = 0; i < planProjectOrEmergings.Length; i++)
            {
                var planProjectOrEmerging = new PlanProjectOrEmerging { Id = Guid.NewGuid(), Position = i, Value = planProjectOrEmergings[i] };
                context.PlanProjectOrEmergings.Add(planProjectOrEmerging);
            }
        }

        private static void SeedProjectTheme(CapRedV2Context context)
        {
            if (context.ProjectThemes.Any()) return;
            string[] projectThemes = {
                "BAU","Corporate Platform","CSO","Real Estate","Aladdin Platform","Employee Experience","External Business Request - Aladdin Platform",
                "External Business Request - Aladdin Client","Information Security"
            };

            for (int i = 0; i < projectThemes.Length; i++)
            {
                var projectTheme = new ProjectTheme { Id = Guid.NewGuid(), Position = i, Value = projectThemes[i] };
                context.ProjectThemes.Add(projectTheme);
            }
        }

        private static void SeedProjectType(CapRedV2Context context)
        {
            if (context.ProjectTypes.Any()) return;
            string[] projectTypes = {
                "Densification","Renovation","Expansion/Contraction of Office","Infrastructure Upgrades","Existing Office Relocation",
                "New Location","Executive Suite",
            };

            for (int i = 0; i < projectTypes.Length; i++)
            {
                var projectType = new ProjectType { Id = Guid.NewGuid(), Position = i, Value = projectTypes[i] };
                context.ProjectTypes.Add(projectType);
            }
        }

        private static void SeedRealEstateOrBau(CapRedV2Context context)
        {
            if (context.RealEstateOrBaus.Any()) return;
            string[] realEstateOrBaus = { "BAU", "RE" };

            for (int i = 0; i < realEstateOrBaus.Length; i++)
            {
                var realEstateOrBau = new RealEstateOrBau { Id = Guid.NewGuid(), Position = i, Value = realEstateOrBaus[i] };
                context.RealEstateOrBaus.Add(realEstateOrBau);
            }
        }

        private static void SeedRegion(CapRedV2Context context)
        {
            if (context.Regions.Any()) return;
            string[] regions = { "AMER", "APAC", "EMEA", "GLOB" };

            for (int i = 0; i < regions.Length; i++)
            {
                var region = new Region { Id = Guid.NewGuid(), Position = i, Value = regions[i] };
                context.Regions.Add(region);
            }
        }

        private static void SeedReportingMilestones(CapRedV2Context context)
        {
            if (context.ReportingMilestones.Any()) return;
            string[] reportingMilestones = {
                "Receive Business Approval","Lease Execution","Design Development Complete",
                "Construction Document complete/issue for Bid","Start on Site","Commence Move - In"
            };

            for (int i = 0; i < reportingMilestones.Length; i++)
            {
                var reportingMilestone = new ReportingMilestones { Id = Guid.NewGuid(), Position = i, Value = reportingMilestones[i] };
                context.ReportingMilestones.Add(reportingMilestone);
            }
        }

        private static void SeedRequiredOrDiscretionary(CapRedV2Context context)
        {
            if (context.RequiredOrDiscretionaries.Any()) return;
            string[] requiredOrDiscretionaries = { "Required", "Discretionary" };

            for (int i = 0; i < requiredOrDiscretionaries.Length; i++)
            {
                var requiredOrDiscretionary = new RequiredOrDiscretionary { Id = Guid.NewGuid(), Position = i, Value = requiredOrDiscretionaries[i] };
                context.RequiredOrDiscretionaries.Add(requiredOrDiscretionary);
            }
        }

        private static void SeedRestorationRequirement(CapRedV2Context context)
        {
            if (context.RestorationRequirements.Any()) return;
            string[] restorationRequirements = {    "none",
                "Remove furniture & equipment & special construction",
                "Remove furniture & equipment & special construction and make good damaged areas",
                "Remove all improvements & restore to core + shell",
                "Remove all improvements & restore to Cat A"
            };

            for (int i = 0; i < restorationRequirements.Length; i++)
            {
                var restorationRequirement = new RestorationRequirement { Id = Guid.NewGuid(), Position = i, Value = restorationRequirements[i] };
                context.RestorationRequirements.Add(restorationRequirement);
            }
        }

        private static void SeedRolloverCategory(CapRedV2Context context)
        {
            if (context.RolloverCategories.Any()) return;
            string[] rolloverCategorys = {
                "Pending Submission","Presented for Approval","Onboarded","Completed project with spend in following year",
            };

            for (int i = 0; i < rolloverCategorys.Length; i++)
            {
                var rolloverCategory = new RolloverCategory { Id = Guid.NewGuid(), Position = i, Value = rolloverCategorys[i] };
                context.RolloverCategories.Add(rolloverCategory);
            }
        }

        private static void SeedWorkPackagesLevel1(CapRedV2Context context)
        {
            if (context.WorkPackagesLevel1s.Any()) return;
            string[] workPackagesLevel1s = {
                "Design Consultants","Project Management","Permitting and Legal","Main Contractor/CM",
                "BlackRock Direct Purchases - Equipment ES","BlackRock Direct Purchases - Equipment Tech",
                "BlackRock Direct Purchases - Equipment AV","BlackRock Direct Purchases - Equipment Data Center",
                "BlackRock Direct Purchases - Furniture","BlackRock Direct Purchases - Signage and Misc.",
                "Migration Management","Landlord Costs","Land Purchase","Sales/Use Tax and VAT","Non-CIP",
                "ARO & Restoration","Contingency","Day Two"
            };

            for (int i = 0; i < workPackagesLevel1s.Length; i++)
            {
                var workPackagesLevel1 = new WorkPackagesLevel1 { Id = Guid.NewGuid(), Position = i, Value = workPackagesLevel1s[i] };
                context.WorkPackagesLevel1s.Add(workPackagesLevel1);
            }
        }
    }
}
