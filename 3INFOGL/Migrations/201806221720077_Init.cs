namespace _3INFOGL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Correspondants",
                c => new
                    {
                        CorrespondantId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NomCorrespondant = c.String(unicode: false),
                        Addresse_Pays = c.String(unicode: false),
                        Addresse_Ville = c.String(unicode: false),
                        Addresse_CodePostal = c.Int(nullable: false),
                        Addresse_Rue = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                        Fax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CorrespondantId);
            
            CreateTable(
                "dbo.Courriers",
                c => new
                    {
                        CourrierId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Sense = c.Boolean(nullable: false),
                        Etat = c.Boolean(nullable: false),
                        TypeCourrier = c.String(unicode: false),
                        ObjetCourrier = c.String(unicode: false),
                        Detail = c.String(unicode: false),
                        CorrespondantId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CourrierId)
                .ForeignKey("dbo.Correspondants", t => t.CorrespondantId)
                .Index(t => t.CorrespondantId);
            
            CreateTable(
                "dbo.Fichiers",
                c => new
                    {
                        FichierId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NomFichier = c.String(unicode: false),
                        UrlFichier = c.String(unicode: false),
                        CourrierId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.FichierId)
                .ForeignKey("dbo.Courriers", t => t.CourrierId)
                .Index(t => t.CourrierId);
            
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        Nom = c.String(unicode: false),
                        Responsable = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Matricule = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                        Prenom = c.String(unicode: false),
                        Cin = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        DateNaissance = c.String(unicode: false),
                        DateEmbauche = c.String(unicode: false),
                        DepartementId = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departements", t => t.DepartementId, cascadeDelete: true)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "dbo.ApplicationUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(unicode: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                        ApplicationRole_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.ApplicationRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationRole_Id);
            
            CreateTable(
                "dbo.WorkFlows",
                c => new
                    {
                        WorkFlowId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.WorkFlowId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NomDocument = c.String(unicode: false),
                        Etat = c.Boolean(nullable: false),
                        CurrentStat = c.Int(nullable: false),
                        DateCreation = c.String(unicode: false),
                        ApplicationUserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        WorkFlowId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Fichiers", t => t.DocumentId)
                .ForeignKey("dbo.WorkFlows", t => t.WorkFlowId)
                .Index(t => t.DocumentId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.WorkFlowId);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkFlowDepartements",
                c => new
                    {
                        WorkFlow_WorkFlowId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Departement_DepartementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WorkFlow_WorkFlowId, t.Departement_DepartementId })
                .ForeignKey("dbo.WorkFlows", t => t.WorkFlow_WorkFlowId, cascadeDelete: true)
                .ForeignKey("dbo.Departements", t => t.Departement_DepartementId, cascadeDelete: true)
                .Index(t => t.WorkFlow_WorkFlowId)
                .Index(t => t.Departement_DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationRole_Id", "dbo.ApplicationRoles");
            DropForeignKey("dbo.Documents", "WorkFlowId", "dbo.WorkFlows");
            DropForeignKey("dbo.Documents", "DocumentId", "dbo.Fichiers");
            DropForeignKey("dbo.Documents", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.WorkFlowDepartements", "Departement_DepartementId", "dbo.Departements");
            DropForeignKey("dbo.WorkFlowDepartements", "WorkFlow_WorkFlowId", "dbo.WorkFlows");
            DropForeignKey("dbo.ApplicationUsers", "DepartementId", "dbo.Departements");
            DropForeignKey("dbo.ApplicationUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Fichiers", "CourrierId", "dbo.Courriers");
            DropForeignKey("dbo.Courriers", "CorrespondantId", "dbo.Correspondants");
            DropIndex("WorkFlowDepartements", new[] { "Departement_DepartementId" });
            DropIndex("WorkFlowDepartements", new[] { "WorkFlow_WorkFlowId" });
            DropIndex("Documents", new[] { "WorkFlowId" });
            DropIndex("Documents", new[] { "ApplicationUserId" });
            DropIndex("Documents", new[] { "DocumentId" });
            DropIndex("ApplicationUserRoles", new[] { "ApplicationRole_Id" });
            DropIndex("ApplicationUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("ApplicationUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("ApplicationUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("ApplicationUsers", new[] { "DepartementId" });
            DropIndex("Fichiers", new[] { "CourrierId" });
            DropIndex("Courriers", new[] { "CorrespondantId" });
            DropTable("dbo.WorkFlowDepartements");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.Documents");
            DropTable("dbo.WorkFlows");
            DropTable("dbo.ApplicationUserRoles");
            DropTable("dbo.ApplicationUserLogins");
            DropTable("dbo.ApplicationUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Departements");
            DropTable("dbo.Fichiers");
            DropTable("dbo.Courriers");
            DropTable("dbo.Correspondants");
        }
    }
}
