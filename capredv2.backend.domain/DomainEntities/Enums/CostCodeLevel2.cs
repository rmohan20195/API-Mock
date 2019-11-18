using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum CostCodeLevel2
    {
        [EnumMember(Value = "A1010 - Foundations")]
        A1010Foundations,
        [EnumMember(Value = "A1020 - Special Foundations")]
        A1020SpecialFoundations,
        [EnumMember(Value = "A1030 - Slab Construction")]
        A1030SlabConstruction,
        [EnumMember(Value = "A2000 - Basement Construction")]
        A2000BasementConstruction,
        [EnumMember(Value = "B1010 - Floor and Frame Construction")]
        B1010FloorandFrameConstruction,
        [EnumMember(Value = "B1020 - Roof Construction")]
        B1020RoofConstruction,
        [EnumMember(Value = "B2000 - Enclosure, Windows and Ext. Doors")]
        B2000EnclosureWindowsandExtDoors,
        [EnumMember(Value = "B3000 - Roofing")]
        B3000Roofing,
        [EnumMember(Value = "C1001 - Interior Construction - General")]
        C1001InteriorConstructionGeneral,
        [EnumMember(Value = "C1010 - Wallboard Partitions")]
        C1010WallboardPartitions,
        [EnumMember(Value = "C1011 - Glazed Partition Systems")]
        C1011GlazedPartitionSystems,
        [EnumMember(Value = "C1012 - Moveable Walls")]
        C1012MoveableWalls,
        [EnumMember(Value = "C1020 - Interior Doors, access panels etc.")]
        C1020InteriorDoorsaccesspanelsetc,
        [EnumMember(Value = "C1021 - Fixed Furnishings - Millwork")]
        C1021FixedFurnishingsMillwork,
        [EnumMember(Value = "C1022 - Fixed Furnishings - Blinds and misc.")]
        C1022FixedFurnishingsBlindsandmisc,
        [EnumMember(Value = "C1023 - Fixed Furnishings - Countertops, mirrors, shelving, vanities")]
        C1023FixedFurnishingsCountertopsmirrorsshelvingvanities,
        [EnumMember(Value = "C1030 - Fittings Specialties - Toilet Ptns, closet accessories")]
        C1030FittingsSpecialtiesToiletPtnsclosetaccessories,
        [EnumMember(Value = "C2000 - Stair Construction and Finishes")]
        C2000StairConstructionandFinishes,
        [EnumMember(Value = "C3010 - Wall Finishes")]
        C3010WallFinishes,
        [EnumMember(Value = "C3020 - Floor Finishes")]
        C3020FloorFinishes,
        [EnumMember(Value = "C3025 - Raised Access Floor")]
        C3025RaisedAccessFloor,
        [EnumMember(Value = "C3030 - Ceiling Finishes")]
        C3030CeilingFinishes,
        [EnumMember(Value = "D0001 - Services - General and Misc.")]
        D0001ServicesGeneralandMisc,
        [EnumMember(Value = "D1000 - Elevator")]
        D1000Elevator,
        [EnumMember(Value = "D2000 - Plumbing")]
        D2000Plumbing,
        [EnumMember(Value = "D3000 - HVAC")]
        D3000HVAC,
        [EnumMember(Value = "D3066 - Energy Monitoring and Control")]
        D3066EnergyMonitoringandControl,
        [EnumMember(Value = "D3067 - Building Automation Systems")]
        D3067BuildingAutomationSystems,
        [EnumMember(Value = "D4010 - Fire Protection Systems")]
        D4010FireProtectionSystems,
        [EnumMember(Value = "D5010 - Electrical Services & Distribution")]
        D5010ElectricalServicesDistribution,
        [EnumMember(Value = "D5020 - Lighting & Branch Wiring")]
        D5020LightingBranchWiring,
        [EnumMember(Value = "D5030 - Communications Systems (telecom, lv cabling, clocks, AV distribution etc)")]
        D5030CommunicationsSystemstelecomlvcablingclocksAVdistributionetc,
        [EnumMember(Value = "D5038 - Security Systems")]
        D5038SecuritySystems,
        [EnumMember(Value = "E1018 - Office Equipment")]
        E1018OfficeEquipment,
        [EnumMember(Value = "E1023 - Theater & Stage Equipment")]
        E1023TheaterStageEquipment,
        [EnumMember(Value = "E1028 - Medical Equipment")]
        E1028MedicalEquipment,
        [EnumMember(Value = "E1031 - Vehicular Service Equipment")]
        E1031VehicularServiceEquipment,
        [EnumMember(Value = "E1032 - Parking Control Equipment")]
        E1032ParkingControlEquipment,
        [EnumMember(Value = "E1041 - Maintenance Equipment")]
        E1041MaintenanceEquipment,
        [EnumMember(Value = "E1043 - Food Service Equipment")]
        E1043FoodServiceEquipment,
        [EnumMember(Value = "E1047 - Athletic, Recreation & Therapeutic")]
        E1047AthleticRecreationTherapeutic,
        [EnumMember(Value = "E1061 - Generator")]
        E1061Generator,
        [EnumMember(Value = "E1062 - UPS")]
        E1062UPS,
        [EnumMember(Value = "E1063 - Server Racks and Cabinets")]
        E1063ServerRacksandCabinets,
        [EnumMember(Value = "E1064 - CRAC Units")]
        E1064CRACUnits,
        [EnumMember(Value = "E1067 - Security Equipment")]
        E1067SecurityEquipment,
        [EnumMember(Value = "E1068 - Fire Protection Specialties (extinguishers , cabinets etc)")]
        E1068FireProtectionSpecialtiesextinguisherscabinetsetc,
        [EnumMember(Value = "E1069 - Health & Safety Equipment")]
        E1069HealthSafetyEquipment,
        [EnumMember(Value = "E1070 - MEP Equipment Purchases")]
        E1070MEPEquipmentPurchases,
        [EnumMember(Value = "E1071 - Misc. Equipment Purchases")]
        E1071MiscEquipmentPurchases,
        [EnumMember(Value = "E1210 - Technology - User Desktop Installations")]
        E1210TechnologyUserDesktopInstallations,
        [EnumMember(Value = "E1220 - Technology - Meeting Room Desktop Installations")]
        E1220TechnologyMeetingRoomDesktopInstallations,
        [EnumMember(Value = "E1230 - Technology - Network Equipment")]
        E1230TechnologyNetworkEquipment,
        [EnumMember(Value = "E1250 - Technology - Service Providers")]
        E1250TechnologyServiceProviders,
        [EnumMember(Value = "E1260 - Technology - Outsourced Consultants")]
        E1260TechnologyOutsourcedConsultants,
        [EnumMember(Value = "E1270 - Technology - Software Installations and Upgrades")]
        E1270TechnologySoftwareInstallationsandUpgrades,
        [EnumMember(Value = "E1280 - Technology - Software Licenses")]
        E1280TechnologySoftwareLicenses,
        [EnumMember(Value = "E1290 - Technology - Fiber Circuit Installations (Cabling, etc)")]
        E1290TechnologyFiberCircuitInstallationsCablingetc,
        [EnumMember(Value = "E1310 - Audio-Visual -Meeting Room AV Installations")]
        E1310AudioVisualMeetingRoomAVInstallations,
        [EnumMember(Value = "E1320 - Audio-Visual -TV Installations")]
        E1320AudioVisualTVInstallations,
        [EnumMember(Value = "E1330 - Audio-Visual -Collaborative AV Installations")]
        E1330AudioVisualCollaborativeAVInstallations,
        [EnumMember(Value = "E1340 - Audio-Visual -Server Hardware - Linux")]
        E1340AudioVisualServerHardwareLinux,
        [EnumMember(Value = "E1350 - Audio-Visual -Server Hardware - Windows")]
        E1350AudioVisualServerHardwareWindows,
        [EnumMember(Value = "E1410 - Data Center Technology - Data Storage Installations")]
        E1410DataCenterTechnologyDataStorageInstallations,
        [EnumMember(Value = "E1420 - Data Center Technology - Network Equipment")]
        E1420DataCenterTechnologyNetworkEquipment,
        [EnumMember(Value = "E1430 - Data Center Technology - Service Providers")]
        E1430DataCenterTechnologyServiceProviders,
        [EnumMember(Value = "E1440 - Data Center Technology - Outsourced Consultants")]
        E1440DataCenterTechnologyOutsourcedConsultants,
        [EnumMember(Value = "E1450 - Data Center Technology - Software Installations and Upgrades")]
        E1450DataCenterTechnologySoftwareInstallationsandUpgrades,
        [EnumMember(Value = "E1460 - Data Center Technology - Software Licenses")]
        E1460DataCenterTechnologySoftwareLicenses,
        [EnumMember(Value = "E1470 - Data Center Technology - Fiber Circuit Installations (Cabling, etc)")]
        E1470DataCenterTechnologyFiberCircuitInstallationsCablingetc,
        [EnumMember(Value = "E1480 - Data Center Technology - Server Hardware - Linux")]
        E1480DataCenterTechnologyServerHardwareLinux,
        [EnumMember(Value = "E1490 - Data Center Technology - Server Hardware - Windows")]
        E1490DataCenterTechnologyServerHardwareWindows,
        [EnumMember(Value = "E2100 - Furniture and Equipment - Misc.")]
        E2100FurnitureandEquipmentMisc,
        [EnumMember(Value = "E2105 - Office Equipment - whiteboards, loose shelving etc.")]
        E2105OfficeEquipmentwhiteboardslooseshelvingetc,
        [EnumMember(Value = "E2110 - Office Furniture")]
        E2110OfficeFurniture,
        [EnumMember(Value = "E2115 - Office and Meeting Chairs")]
        E2115OfficeandMeetingChairs,
        [EnumMember(Value = "E2120 - Client Suite Furniture")]
        E2120ClientSuiteFurniture,
        [EnumMember(Value = "E2130 - Loose Furniture/furnishings - chairs, podium, misc. tables etc.")]
        E2130LooseFurniturefurnishingschairspodiummisctablesetc,
        [EnumMember(Value = "E2150 - Pantry and Support Equipment/White Goods")]
        E2150PantryandSupportEquipmentWhiteGoods,
        [EnumMember(Value = "E2200 - Branding Signage")]
        E2200BrandingSignage,
        [EnumMember(Value = "E2250 - Wayfinding Signage")]
        E2250WayfindingSignage,
        [EnumMember(Value = "E2300 - Artwork")]
        E2300Artwork,
        [EnumMember(Value = "F2010 - Building Elements Demolition")]
        F2010BuildingElementsDemolition,
        [EnumMember(Value = "G1000 - Site Preparation")]
        G1000SitePreparation,
        [EnumMember(Value = "G2000 - Site Improvement")]
        G2000SiteImprovement,
        [EnumMember(Value = "G3000 - Site Mechanical Utiities")]
        G3000SiteMechanicalUtiities,
        [EnumMember(Value = "G4000 - Site Electrical and Communications Utilities")]
        G4000SiteElectricalandCommunicationsUtilities,
        [EnumMember(Value = "Z0100 - General Requirements and Logistics")]
        Z0100GeneralRequirementsandLogistics,
        [EnumMember(Value = "Z0200 - Contractor/CM Insurance")]
        Z0200ContractorCMInsurance,
        [EnumMember(Value = "Z0300 - Bonding")]
        Z0300Bonding,
        [EnumMember(Value = "Z0400 - CM Fee")]
        Z0400CMFee,
        [EnumMember(Value = "Z0450 - CM Preconstruction Services")]
        Z0450CMPreconstructionServices,
        [EnumMember(Value = "Z0900 - Retainage")]
        Z0900Retainage,
        [EnumMember(Value = "Z1050 - Pre-Approval DesignWork - Expensed")]
        Z1050PreApprovalDesignWorkExpensed,
        [EnumMember(Value = "Z1100 - Architect")]
        Z1100Architect,
        [EnumMember(Value = "Z1150 - Interior Designer")]
        Z1150InteriorDesigner,
        [EnumMember(Value = "Z1200 - Structural Engineering")]
        Z1200StructuralEngineering,
        [EnumMember(Value = "Z1250 - Civil and Landscaping Engineering")]
        Z1250CivilandLandscapingEngineering,
        [EnumMember(Value = "Z1300 - MEP Engineering")]
        Z1300MEPEngineering,
        [EnumMember(Value = "Z1400 - Low Voltage Cabling Engineering")]
        Z1400LowVoltageCablingEngineering,
        [EnumMember(Value = "Z1450 - Audio Visual Engineering")]
        Z1450AudioVisualEngineering,
        [EnumMember(Value = "Z1480 - IT Design & Integration")]
        Z1480ITDesignIntegration,
        [EnumMember(Value = "Z1500 - Acoustical Engineering")]
        Z1500AcousticalEngineering,
        [EnumMember(Value = "Z1600 - Lighting Design")]
        Z1600LightingDesign,
        [EnumMember(Value = "Z1700 - Security Engineering")]
        Z1700SecurityEngineering,
        [EnumMember(Value = "Z1800 - Traffic Engineering")]
        Z1800TrafficEngineering,
        [EnumMember(Value = "Z1810 - Elevator Consultant")]
        Z1810ElevatorConsultant,
        [EnumMember(Value = "Z1820 - Catering Consultant")]
        Z1820CateringConsultant,
        [EnumMember(Value = "Z1840 - Signage Design")]
        Z1840SignageDesign,
        [EnumMember(Value = "Z1860 - Art Consultant")]
        Z1860ArtConsultant,
        [EnumMember(Value = "Z1999 - Misc. Design Consultants")]
        Z1999MiscDesignConsultants,
        [EnumMember(Value = "Z2050 - Pre-Approval Planning/DD Work - Expensed")]
        Z2050PreApprovalPlanningDDWorkExpensed,
        [EnumMember(Value = "Z2100 - Project Manager")]
        Z2100ProjectManager,
        [EnumMember(Value = "Z2150 - Cost Manager")]
        Z2150CostManager,
        [EnumMember(Value = "Z2200 - BlackRock Project Manager")]
        Z2200BlackRockProjectManager,
        [EnumMember(Value = "Z2220 - BlackRock PMO Consultant")]
        Z2220BlackRockPMOConsultant,
        [EnumMember(Value = "Z2240 - BlackRock PCG Consultant")]
        Z2240BlackRockPCGConsultant,
        [EnumMember(Value = "Z2300 - Sustainability Consultant")]
        Z2300SustainabilityConsultant,
        [EnumMember(Value = "Z2500 - Commissioning Services")]
        Z2500CommissioningServices,
        [EnumMember(Value = "Z2550 - Health & Safety Consultant")]
        Z2550HealthSafetyConsultant,
        [EnumMember(Value = "Z2600 - Legal Services - D&C scope")]
        Z2600LegalServicesDCscope,
        [EnumMember(Value = "Z2999 - Other Project Consultants")]
        Z2999OtherProjectConsultants,
        [EnumMember(Value = "Z3100 - Filing Fees")]
        Z3100FilingFees,
        [EnumMember(Value = "Z3200 - Code Expeditor and Planning Consultant")]
        Z3200CodeExpeditorandPlanningConsultant,
        [EnumMember(Value = "Z3999 - Approvals Charges Generally")]
        Z3999ApprovalsChargesGenerally,
        [EnumMember(Value = "Z4100 - Move Manager")]
        Z4100MoveManager,
        [EnumMember(Value = "Z4200 - Move Courier Services")]
        Z4200MoveCourierServices,
        [EnumMember(Value = "Z4300 - Move Supplies")]
        Z4300MoveSupplies,
        [EnumMember(Value = "Z4400 - Final Clean")]
        Z4400FinalClean,
        [EnumMember(Value = "Z4500 - Security Guard Service")]
        Z4500SecurityGuardService,
        [EnumMember(Value = "Z4999 - Misc. Migration Costs")]
        Z4999MiscMigrationCosts,
        [EnumMember(Value = "Z5100 - Landlord Supervision")]
        Z5100LandlordSupervision,
        [EnumMember(Value = "Z5200 - Landlord Protection Measures")]
        Z5200LandlordProtectionMeasures,
        [EnumMember(Value = "Z5300 - Use of Building Services during Construction")]
        Z5300UseofBuildingServicesduringConstruction,
        [EnumMember(Value = "Z5999 - Misc. Landlord Costs")]
        Z5999MiscLandlordCosts,
        [EnumMember(Value = "Z6100 - Recoverable Sales Tax/VAT (to P/R)")]
        Z6100RecoverableSalesTaxVATtoPR,
        [EnumMember(Value = "Z6150 - Non-Recoverable Sales Tax/VAT (to P/R)")]
        Z6150NonRecoverableSalesTaxVATtoPR,
        [EnumMember(Value = "Z7200 - ARO - Restoration Cost")]
        Z7200ARORestorationCost,
        [EnumMember(Value = "Z8100 - Land Purchase Price")]
        Z8100LandPurchasePrice,
        [EnumMember(Value = "Z8200 - Agent Fees")]
        Z8200AgentFees,
        [EnumMember(Value = "Z8300 - Land Taxes and Disbursements")]
        Z8300LandTaxesandDisbursements,
        [EnumMember(Value = "Z8999 - Misc. Land Purchase Costs")]
        Z8999MiscLandPurchaseCosts,
        [EnumMember(Value = "Z9100 - Design Development Allowance")]
        Z9100DesignDevelopmentAllowance,
        [EnumMember(Value = "Z9200 - Project Working Balance")]
        Z9200ProjectWorkingBalance,
        [EnumMember(Value = "Z9300 - Construction Risk Contingency")]
        Z9300ConstructionRiskContingency,
        [EnumMember(Value = "Fixed Artwork")]
        FixedArtwork,
        [EnumMember(Value = "Fixed Casework")]
        FixedCasework,
        [EnumMember(Value = "Window Treatment")]
        WindowTreatment,
        [EnumMember(Value = "Fixed Floor Grilles & Mats")]
        FixedFloorGrillesMats,
        [EnumMember(Value = "Fixed Multiple Seating")]
        FixedMultipleSeating,
        [EnumMember(Value = "Fixed Interior Landscaping")]
        FixedInteriorLandscaping,
        [EnumMember(Value = "Fixed Furnishings - Blinds and misc.")]
        FixedFurnishingsBlindsandmisc,
        [EnumMember(Value = "Fixed Furnishings - Countertops, mirrors, shelving, vanities")]
        FixedFurnishingsCountertopsmirrorsshelvingvanities,
        [EnumMember(Value = "Fittings Specialties - Toilet Ptns, closet accessories")]
        FittingsSpecialtiesToiletPtnsclosetaccessories,
        [EnumMember(Value = "Moveable Artwork")]
        MoveableArtwork,
        [EnumMember(Value = "Moveable Mats & Rugs")]
        MoveableMatsRugs,
        [EnumMember(Value = "Moveable Multiple Seating")]
        MoveableMultipleSeating,
        [EnumMember(Value = "Moveable Interior Landscaping")]
        MoveableInteriorLandscaping,
        [EnumMember(Value = "Furniture and Equipment - Misc.")]
        FurnitureandEquipmentMisc,
        [EnumMember(Value = "Office Equipment - whiteboards, loose shelving etc.")]
        OfficeEquipmentwhiteboardslooseshelvingetc,
        [EnumMember(Value = "Office Furniture")]
        OfficeFurniture,
        [EnumMember(Value = "Client Suite Furniture")]
        ClientSuiteFurniture,
        [EnumMember(Value = "Loose Furniture/furnishings - chairs, podium, misc. tables etc.")]
        LooseFurniturefurnishingschairspodiummisctablesetc,
        [EnumMember(Value = "Pantry Furniture")]
        PantryFurniture,
        [EnumMember(Value = "Pantry and Support Equipment/White Goods")]
        PantryandSupportEquipmentWhiteGoods,
        [EnumMember(Value = "Branding Signage")]
        BrandingSignage,
        [EnumMember(Value = "Wayfinding Signage")]
        WayfindingSignage,
        [EnumMember(Value = "Interior Demolition")]
        InteriorDemolition,
        [EnumMember(Value = "Exterior Demolition")]
        ExteriorDemolition,
        [EnumMember(Value = "Removal of Hazardous Components")]
        RemovalofHazardousComponents,
        [EnumMember(Value = "Clearing & Grubbing")]
        ClearingGrubbing,
        [EnumMember(Value = "Building Demolition")]
        BuildingDemolition,
        [EnumMember(Value = "Demolition of Site Components")]
        DemolitionofSiteComponents,
        [EnumMember(Value = "Relocation of Building Utilities")]
        RelocationofBuildingUtilities,
        [EnumMember(Value = "Site Grading & Excavation")]
        SiteGradingExcavation,
        [EnumMember(Value = "Borrow Fill")]
        BorrowFill,
        [EnumMember(Value = "Soil Stabilization & Treatment")]
        SoilStabilizationTreatment,
        [EnumMember(Value = "Site Dewatering")]
        SiteDewatering,
        [EnumMember(Value = "Site Shoring")]
        SiteShoring,
        [EnumMember(Value = "Removal of Contaminated Soil")]
        RemovalofContaminatedSoil,
        [EnumMember(Value = "Restoration & Treatment")]
        RestorationTreatment,
        [EnumMember(Value = "Paving & Surfacing")]
        PavingSurfacing,
        [EnumMember(Value = "Rails & Barriers")]
        RailsBarriers,
        [EnumMember(Value = "Markings & Signage")]
        MarkingsSignage,
        [EnumMember(Value = "Parking Booths & Equipment")]
        ParkingBoothsEquipment,
        [EnumMember(Value = "Exterior Steps")]
        ExteriorSteps,
        [EnumMember(Value = "Fences & Gates")]
        FencesGates,
        [EnumMember(Value = "Retaining Walls")]
        RetainingWalls,
        [EnumMember(Value = "Terrace & Perimeter Walls")]
        TerracePerimeterWalls,
        [EnumMember(Value = "Miscellaneous Structures")]
        MiscellaneousStructures,
        [EnumMember(Value = "Top Soil & Planting Beds")]
        TopSoilPlantingBeds,
        [EnumMember(Value = "Planting")]
        Planting,
        [EnumMember(Value = "Irrigation Systems")]
        IrrigationSystems,
        [EnumMember(Value = "Piping System Testing & Balancing")]
        PipingSystemTestingBalancing,
        [EnumMember(Value = "Steam Supply")]
        SteamSupply,
        [EnumMember(Value = "Condensate Return")]
        CondensateReturn,
        [EnumMember(Value = "Hot Water Supply System")]
        HotWaterSupplySystem,
        [EnumMember(Value = "Pumping Stations")]
        PumpingStations,
        [EnumMember(Value = "Chilled Water Piping")]
        ChilledWaterPiping,
        [EnumMember(Value = "Cooling Towers on Site")]
        CoolingTowersonSite,
        [EnumMember(Value = "Piping")]
        Piping,
        [EnumMember(Value = "Equipment")]
        Equipment,
        [EnumMember(Value = "Storage Tanks")]
        StorageTanks,
        [EnumMember(Value = "Substations")]
        Substations,
        [EnumMember(Value = "Overhead Power Distribution")]
        OverheadPowerDistribution,
        [EnumMember(Value = "Underground Distribution")]
        UndergroundDistribution,
        [EnumMember(Value = "Fixtures & Transformers")]
        FixturesTransformers,
        [EnumMember(Value = "Poles")]
        Poles,
        [EnumMember(Value = "Wiring Conduits & Ductbanks")]
        WiringConduitsDuctbanks,
        [EnumMember(Value = "Controls")]
        Controls,
        [EnumMember(Value = "Site Security & Alarm System")]
        SiteSecurityAlarmSystem,
        [EnumMember(Value = "CM Design Services")]
        CMDesignServices,
        [EnumMember(Value = "CM Preconstruction Services")]
        CMPreconstructionServices,
        [EnumMember(Value = "General Requirements and Logistics")]
        GeneralRequirementsandLogistics,
        [EnumMember(Value = "Contractor/CM Insurance")]
        ContractorCMInsurance,
        [EnumMember(Value = "Retainage")]
        Retainage,
        [EnumMember(Value = "Architect")]
        Architect,
        [EnumMember(Value = "Interior Designer")]
        InteriorDesigner,
        [EnumMember(Value = "Structural Engineering")]
        StructuralEngineering,
        [EnumMember(Value = "Civil and Landscaping Engineering")]
        CivilandLandscapingEngineering,
        [EnumMember(Value = "MEP Engineering")]
        MEPEngineering,
        [EnumMember(Value = "Low Voltage Cabling Engineering")]
        LowVoltageCablingEngineering,
        [EnumMember(Value = "Audio Visual Engineering")]
        AudioVisualEngineering,
        [EnumMember(Value = "IT Design & Integration")]
        ITDesignIntegration,
        [EnumMember(Value = "Acoustical Engineering")]
        AcousticalEngineering,
        [EnumMember(Value = "Lighting Design")]
        LightingDesign,
        [EnumMember(Value = "Security Engineering")]
        SecurityEngineering,
        [EnumMember(Value = "Traffic Engineering")]
        TrafficEngineering,
        [EnumMember(Value = "Elevator Consultant")]
        ElevatorConsultant,
        [EnumMember(Value = "Catering Consultant")]
        CateringConsultant,
        [EnumMember(Value = "Signage Design")]
        SignageDesign,
        [EnumMember(Value = "Art Consultant")]
        ArtConsultant,
        [EnumMember(Value = "Misc. Design Consultants")]
        MiscDesignConsultants,
        [EnumMember(Value = "Misc Blueprinting and Reimbursables")]
        MiscBlueprintingandReimbursables,
        [EnumMember(Value = "Project Manager")]
        ProjectManager,
        [EnumMember(Value = "Cost Manager")]
        CostManager,
        [EnumMember(Value = "BlackRock Project Manager")]
        BlackRockProjectManager,
        [EnumMember(Value = "BlackRock PMO Consultant")]
        BlackRockPMOConsultant,
        [EnumMember(Value = "BlackRock PCG Consultant")]
        BlackRockPCGConsultant,
        [EnumMember(Value = "Sustainability Consultant")]
        SustainabilityConsultant,
        [EnumMember(Value = "Commissioning Services")]
        CommissioningServices,
        [EnumMember(Value = "Health & Safety Consultant")]
        HealthSafetyConsultant,
        [EnumMember(Value = "Legal Services - D&C scope")]
        LegalServicesDCscope,
        [EnumMember(Value = "Tax Consultants")]
        TaxConsultants,
        [EnumMember(Value = "Other Project Consultants")]
        OtherProjectConsultants,
        [EnumMember(Value = "Filing Fees")]
        FilingFees,
        [EnumMember(Value = "Code Expeditor and Planning Consultant")]
        CodeExpeditorandPlanningConsultant,
        [EnumMember(Value = "Approvals Charges Generally")]
        ApprovalsChargesGenerally,
        [EnumMember(Value = "Move Manager")]
        MoveManager,
        [EnumMember(Value = "Move Courier Services")]
        MoveCourierServices,
        [EnumMember(Value = "Move Supplies")]
        MoveSupplies,
        [EnumMember(Value = "Final Clean")]
        FinalClean,
        [EnumMember(Value = "Security Guard Service")]
        SecurityGuardService,
        [EnumMember(Value = "Misc. Migration Costs")]
        MiscMigrationCosts,
        [EnumMember(Value = "Landlord Supervision")]
        LandlordSupervision,
        [EnumMember(Value = "Landlord Protection Measures")]
        LandlordProtectionMeasures,
        [EnumMember(Value = "Use of Building Services during Construction")]
        UseofBuildingServicesduringConstruction,
        [EnumMember(Value = "Misc. Landlord Costs")]
        MiscLandlordCosts,
        [EnumMember(Value = "Recoverable Sales Tax/VAT (to P/R)")]
        RecoverableSalesTaxVATtoPR,
        [EnumMember(Value = "Non-Recoverable Sales Tax/VAT (to P/R)")]
        NonRecoverableSalesTaxVATtoPR,
        [EnumMember(Value = "Non-CIP Expensed Consultants")]
        NonCIPExpensedConsultants,
        [EnumMember(Value = "Non-CIP Expensed construction (repairs & Maintenance)")]
        NonCIPExpensedconstructionrepairsMaintenance,
        [EnumMember(Value = "Non-CIP Expensed Furniture & Fixtures ")]
        NonCIPExpensedFurnitureFixtures,
        [EnumMember(Value = "Non-CIP Expensed Equipment")]
        NonCIPExpensedEquipment,
        [EnumMember(Value = "ARO - Restoration Cost")]
        ARORestorationCost,
        [EnumMember(Value = "Day Two - Design")]
        DayTwoDesign,
        [EnumMember(Value = "Day Two - Project Management")]
        DayTwoProjectManagement,
        [EnumMember(Value = "Day Two - Construction")]
        DayTwoConstruction,
        [EnumMember(Value = "Day Two - Furniture & Equipment")]
        DayTwoFurnitureEquipment,
        [EnumMember(Value = "Land Purchase Price")]
        LandPurchasePrice,
        [EnumMember(Value = "Agent Fees")]
        AgentFees,
        [EnumMember(Value = "Land Taxes and Disbursements")]
        LandTaxesandDisbursements,
        [EnumMember(Value = "Misc. Land Purchase Costs")]
        MiscLandPurchaseCosts,
        [EnumMember(Value = "Design Development Allowance")]
        DesignDevelopmentAllowance,
        [EnumMember(Value = "Construction Risk Contingency")]
        ConstructionRiskContingency,
        [EnumMember(Value = "Project Working Balance")]
        ProjectWorkingBalance
    }
}
