namespace Antelope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _29092014 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionQSEs",
                c => new
                    {
                        ActionQSEId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DateButoireInitiale = c.DateTime(nullable: false),
                        DateButoireNouvelle = c.DateTime(),
                        ResponsableId = c.Int(nullable: false),
                        Avancement = c.String(),
                        CotationHumain = c.Short(nullable: false),
                        CotationOrganisationnel = c.Short(nullable: false),
                        CotationTechnique = c.Short(nullable: false),
                        CotationEfficacite = c.Short(nullable: false),
                        VerificateurId = c.Int(),
                        PreuveVerification = c.String(),
                        CommentaireEfficaciteVerification = c.String(),
                        Realise = c.Boolean(nullable: false),
                        RealiseDate = c.DateTime(),
                        Verifie = c.Boolean(nullable: false),
                        VerifieDate = c.DateTime(),
                        Cloture = c.Boolean(nullable: false),
                        ClotureDate = c.DateTime(),
                        CauseQSEId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActionQSEId)
                .ForeignKey("dbo.CauseQSEs", t => t.CauseQSEId, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.ResponsableId, cascadeDelete: true)
                .ForeignKey("dbo.Personnes", t => t.VerificateurId)
                .Index(t => t.CauseQSEId)
                .Index(t => t.ResponsableId)
                .Index(t => t.VerificateurId);
            
            CreateTable(
                "dbo.CauseQSEs",
                c => new
                    {
                        CauseQSEId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        FicheSecuriteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CauseQSEId)
                .ForeignKey("dbo.FicheSecurites", t => t.FicheSecuriteId, cascadeDelete: true)
                .Index(t => t.FicheSecuriteId);
            
            CreateTable(
                "dbo.FicheSecurites",
                c => new
                    {
                        FicheSecuriteID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Type = c.String(),
                        Age = c.String(),
                        PosteDeTravailId = c.Int(),
                        ServiceId = c.Int(),
                        DateCreation = c.DateTime(nullable: false),
                        DateEvenement = c.DateTime(nullable: false),
                        PersonnesConcernees = c.String(),
                        Description = c.String(nullable: false),
                        ActionImmediate1 = c.String(),
                        ActionImmediate2 = c.String(),
                        Temoins = c.String(),
                        CotationFrequence = c.Short(nullable: false),
                        CotationGravite = c.Short(nullable: false),
                        FicheSecuriteTypeId = c.Int(nullable: false),
                        RisqueId = c.Int(nullable: false),
                        DangerId = c.Int(nullable: false),
                        CorpsHumainZoneId = c.Int(nullable: false),
                        PlageHoraireId = c.Int(),
                        SiteId = c.Int(nullable: false),
                        ZoneId = c.Int(),
                        LieuId = c.Int(),
                        EnqueteRealisee = c.Boolean(nullable: false),
                        EnqueteDate = c.DateTime(),
                        EnqueteProtagoniste = c.String(),
                        CHSCTMembre = c.String(),
                        PersonneConcerneeId = c.Int(),
                        ResponsableId = c.Int(),
                        WorkFlowDiffusee = c.Boolean(nullable: false),
                        WorkFlowAttenteASEValidation = c.Boolean(nullable: false),
                        WorkFlowASEValidee = c.Boolean(nullable: false),
                        WorkFlowASERejetee = c.Boolean(nullable: false),
                        WorkFlowCloturee = c.Boolean(nullable: false),
                        Personne_PersonneId = c.Int(),
                    })
                .PrimaryKey(t => t.FicheSecuriteID)
                .ForeignKey("dbo.CorpsHumainZones", t => t.CorpsHumainZoneId, cascadeDelete: true)
                .ForeignKey("dbo.Dangers", t => t.DangerId, cascadeDelete: true)
                .ForeignKey("dbo.FicheSecuriteTypes", t => t.FicheSecuriteTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PosteDeTravails", t => t.PosteDeTravailId)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.Lieux", t => t.LieuId)
                .ForeignKey("dbo.Personnes", t => t.Personne_PersonneId)
                .ForeignKey("dbo.Personnes", t => t.PersonneConcerneeId)
                .ForeignKey("dbo.PlageHoraires", t => t.PlageHoraireId)
                .ForeignKey("dbo.Personnes", t => t.ResponsableId)
                .ForeignKey("dbo.Risques", t => t.RisqueId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .Index(t => t.CorpsHumainZoneId)
                .Index(t => t.DangerId)
                .Index(t => t.FicheSecuriteTypeId)
                .Index(t => t.PosteDeTravailId)
                .Index(t => t.SiteId)
                .Index(t => t.LieuId)
                .Index(t => t.Personne_PersonneId)
                .Index(t => t.PersonneConcerneeId)
                .Index(t => t.PlageHoraireId)
                .Index(t => t.ResponsableId)
                .Index(t => t.RisqueId)
                .Index(t => t.ServiceId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.CorpsHumainZones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dangers",
                c => new
                    {
                        DangerID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.DangerID);
            
            CreateTable(
                "dbo.FicheSecuriteTypes",
                c => new
                    {
                        FicheSecuriteTypeID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.FicheSecuriteTypeID);
            
            CreateTable(
                "dbo.Lieux",
                c => new
                    {
                        LieuID = c.Int(nullable: false, identity: true),
                        ZoneId = c.Int(nullable: false),
                        LieuTypeId = c.Int(nullable: false),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.LieuID)
                .ForeignKey("dbo.LieuTypes", t => t.LieuTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.LieuTypeId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.LieuTypes",
                c => new
                    {
                        LieuTypeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.LieuTypeId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        SiteId = c.Int(nullable: false),
                        ZoneTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZoneID)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .ForeignKey("dbo.ZoneTypes", t => t.ZoneTypeId, cascadeDelete: true)
                .Index(t => t.SiteId)
                .Index(t => t.ZoneTypeId);
            
            CreateTable(
                "dbo.PosteDeTravails",
                c => new
                    {
                        PosteDeTravailId = c.Int(nullable: false, identity: true),
                        ZoneId = c.Int(nullable: false),
                        PosteDeTravailTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PosteDeTravailId)
                .ForeignKey("dbo.PosteDeTravailTypes", t => t.PosteDeTravailTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.PosteDeTravailTypeId)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.PosteDeTravailTypes",
                c => new
                    {
                        PosteDeTravailTypeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.PosteDeTravailTypeId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Trigramme = c.String(),
                        Arouperr = c.String(),
                    })
                .PrimaryKey(t => t.SiteID);
            
            CreateTable(
                "dbo.ZoneTypes",
                c => new
                    {
                        ZoneTypeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ZoneTypeId);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        PersonneId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PersonneId);
            
            CreateTable(
                "dbo.PlageHoraires",
                c => new
                    {
                        PlageHoraireID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.PlageHoraireID);
            
            CreateTable(
                "dbo.Risques",
                c => new
                    {
                        RisqueId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        RisqueTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.RisqueId)
                .ForeignKey("dbo.RisqueTypes", t => t.RisqueTypeId)
                .Index(t => t.RisqueTypeId);
            
            CreateTable(
                "dbo.RisqueTypes",
                c => new
                    {
                        RisqueTypeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.RisqueTypeId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        SiteId = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.ActionSecurites",
                c => new
                    {
                        ActionSecuriteId = c.Int(nullable: false, identity: true),
                        FicheSecuriteId = c.Int(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        FaitPar = c.String(),
                    })
                .PrimaryKey(t => t.ActionSecuriteId)
                .ForeignKey("dbo.FicheSecurites", t => t.FicheSecuriteId, cascadeDelete: true)
                .Index(t => t.FicheSecuriteId);
            
            CreateTable(
                "dbo.ADRoles",
                c => new
                    {
                        ADRoleID = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(),
                        RoleType = c.String(),
                        Name = c.String(),
                        Guid = c.String(),
                    })
                .PrimaryKey(t => t.ADRoleID);
            
            CreateTable(
                "dbo.Interventions",
                c => new
                    {
                        InterventionID = c.Int(nullable: false, identity: true),
                        Intervenant = c.String(),
                        DateIntervention = c.String(),
                        Planifie = c.Boolean(nullable: false),
                        Demandeur = c.String(),
                        Motif = c.String(),
                        DureeIntervention = c.Int(nullable: false),
                        NoteFrais = c.Boolean(nullable: false),
                        PrimeIntervention = c.Single(nullable: false),
                        PrimeDimanche = c.Single(nullable: false),
                        Valide = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InterventionID);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        ProjetID = c.Int(nullable: false, identity: true),
                        NomProjet = c.String(),
                        StatutCouleur = c.Int(nullable: false),
                        StatutVisage = c.Int(nullable: false),
                        Commentaire = c.String(),
                        ProchaineEtape = c.String(),
                        DateOuverture = c.String(),
                        DateCloture = c.String(),
                        Service = c.String(),
                    })
                .PrimaryKey(t => t.ProjetID);
            
            CreateTable(
                "dbo.Sauvegardes",
                c => new
                    {
                        SauvegardeID = c.Int(nullable: false, identity: true),
                        Site = c.String(),
                        Date = c.Double(nullable: false),
                        Volume = c.Single(nullable: false),
                        Taux = c.Single(nullable: false),
                        Duree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SauvegardeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActionSecurites", "FicheSecuriteId", "dbo.FicheSecurites");
            DropForeignKey("dbo.ActionQSEs", "VerificateurId", "dbo.Personnes");
            DropForeignKey("dbo.ActionQSEs", "ResponsableId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.FicheSecurites", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.Risques", "RisqueTypeId", "dbo.RisqueTypes");
            DropForeignKey("dbo.FicheSecurites", "RisqueId", "dbo.Risques");
            DropForeignKey("dbo.FicheSecurites", "ResponsableId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "PlageHoraireId", "dbo.PlageHoraires");
            DropForeignKey("dbo.FicheSecurites", "PersonneConcerneeId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "Personne_PersonneId", "dbo.Personnes");
            DropForeignKey("dbo.FicheSecurites", "LieuId", "dbo.Lieux");
            DropForeignKey("dbo.Lieux", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "ZoneTypeId", "dbo.ZoneTypes");
            DropForeignKey("dbo.Zones", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.FicheSecurites", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.PosteDeTravails", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.PosteDeTravails", "PosteDeTravailTypeId", "dbo.PosteDeTravailTypes");
            DropForeignKey("dbo.FicheSecurites", "PosteDeTravailId", "dbo.PosteDeTravails");
            DropForeignKey("dbo.Lieux", "LieuTypeId", "dbo.LieuTypes");
            DropForeignKey("dbo.FicheSecurites", "FicheSecuriteTypeId", "dbo.FicheSecuriteTypes");
            DropForeignKey("dbo.FicheSecurites", "DangerId", "dbo.Dangers");
            DropForeignKey("dbo.FicheSecurites", "CorpsHumainZoneId", "dbo.CorpsHumainZones");
            DropForeignKey("dbo.CauseQSEs", "FicheSecuriteId", "dbo.FicheSecurites");
            DropForeignKey("dbo.ActionQSEs", "CauseQSEId", "dbo.CauseQSEs");
            DropIndex("dbo.ActionSecurites", new[] { "FicheSecuriteId" });
            DropIndex("dbo.ActionQSEs", new[] { "VerificateurId" });
            DropIndex("dbo.ActionQSEs", new[] { "ResponsableId" });
            DropIndex("dbo.FicheSecurites", new[] { "ZoneId" });
            DropIndex("dbo.FicheSecurites", new[] { "ServiceId" });
            DropIndex("dbo.Services", new[] { "SiteId" });
            DropIndex("dbo.Services", new[] { "ServiceTypeId" });
            DropIndex("dbo.Risques", new[] { "RisqueTypeId" });
            DropIndex("dbo.FicheSecurites", new[] { "RisqueId" });
            DropIndex("dbo.FicheSecurites", new[] { "ResponsableId" });
            DropIndex("dbo.FicheSecurites", new[] { "PlageHoraireId" });
            DropIndex("dbo.FicheSecurites", new[] { "PersonneConcerneeId" });
            DropIndex("dbo.FicheSecurites", new[] { "Personne_PersonneId" });
            DropIndex("dbo.FicheSecurites", new[] { "LieuId" });
            DropIndex("dbo.Lieux", new[] { "ZoneId" });
            DropIndex("dbo.Zones", new[] { "ZoneTypeId" });
            DropIndex("dbo.Zones", new[] { "SiteId" });
            DropIndex("dbo.FicheSecurites", new[] { "SiteId" });
            DropIndex("dbo.PosteDeTravails", new[] { "ZoneId" });
            DropIndex("dbo.PosteDeTravails", new[] { "PosteDeTravailTypeId" });
            DropIndex("dbo.FicheSecurites", new[] { "PosteDeTravailId" });
            DropIndex("dbo.Lieux", new[] { "LieuTypeId" });
            DropIndex("dbo.FicheSecurites", new[] { "FicheSecuriteTypeId" });
            DropIndex("dbo.FicheSecurites", new[] { "DangerId" });
            DropIndex("dbo.FicheSecurites", new[] { "CorpsHumainZoneId" });
            DropIndex("dbo.CauseQSEs", new[] { "FicheSecuriteId" });
            DropIndex("dbo.ActionQSEs", new[] { "CauseQSEId" });
            DropTable("dbo.Sauvegardes");
            DropTable("dbo.Projets");
            DropTable("dbo.Interventions");
            DropTable("dbo.ADRoles");
            DropTable("dbo.ActionSecurites");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.RisqueTypes");
            DropTable("dbo.Risques");
            DropTable("dbo.PlageHoraires");
            DropTable("dbo.Personnes");
            DropTable("dbo.ZoneTypes");
            DropTable("dbo.Sites");
            DropTable("dbo.PosteDeTravailTypes");
            DropTable("dbo.PosteDeTravails");
            DropTable("dbo.Zones");
            DropTable("dbo.LieuTypes");
            DropTable("dbo.Lieux");
            DropTable("dbo.FicheSecuriteTypes");
            DropTable("dbo.Dangers");
            DropTable("dbo.CorpsHumainZones");
            DropTable("dbo.FicheSecurites");
            DropTable("dbo.CauseQSEs");
            DropTable("dbo.ActionQSEs");
        }
    }
}
