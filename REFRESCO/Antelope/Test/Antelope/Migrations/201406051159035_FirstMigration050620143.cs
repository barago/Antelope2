namespace Antelope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration050620143 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.FicheSecurites",
                c => new
                    {
                        FicheSecuriteID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Type = c.String(),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        PosteDeTravail = c.String(),
                        Service = c.String(),
                        Responsable = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateEvenement = c.DateTime(nullable: false),
                        PersonnesConcernees = c.String(),
                        Description = c.String(nullable: false),
                        CotationFrequence = c.String(),
                        CotationGravite = c.String(),
                        CotationVolume = c.String(),
                        SiteId = c.Int(nullable: false),
                        ZoneId = c.Int(),
                        LieuId = c.Int(),
                    })
                .PrimaryKey(t => t.FicheSecuriteID)
                .ForeignKey("dbo.Lieux", t => t.LieuId)
                .ForeignKey("dbo.Zones", t => t.ZoneId)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.LieuId)
                .Index(t => t.ZoneId)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Lieux",
                c => new
                    {
                        LieuID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        ZoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LieuID)
                .ForeignKey("dbo.Zones", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.ZoneId);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZoneID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZoneID)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
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
                "dbo.ADRoles",
                c => new
                    {
                        ADRoleID = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(),
                        RoleType = c.String(),
                        Name = c.String(),
                        GUID = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lieux", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.Zones", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.FicheSecurites", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.FicheSecurites", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.FicheSecurites", "LieuId", "dbo.Lieux");
            DropForeignKey("dbo.ActionSecurites", "FicheSecuriteId", "dbo.FicheSecurites");
            DropIndex("dbo.Lieux", new[] { "ZoneId" });
            DropIndex("dbo.Zones", new[] { "SiteId" });
            DropIndex("dbo.FicheSecurites", new[] { "SiteId" });
            DropIndex("dbo.FicheSecurites", new[] { "ZoneId" });
            DropIndex("dbo.FicheSecurites", new[] { "LieuId" });
            DropIndex("dbo.ActionSecurites", new[] { "FicheSecuriteId" });
            DropTable("dbo.Projets");
            DropTable("dbo.Interventions");
            DropTable("dbo.ADRoles");
            DropTable("dbo.Sites");
            DropTable("dbo.Zones");
            DropTable("dbo.Lieux");
            DropTable("dbo.FicheSecurites");
            DropTable("dbo.ActionSecurites");
        }
    }
}
