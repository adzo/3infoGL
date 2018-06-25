namespace _3INFOGL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Correspondants",
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
                .PrimaryKey(t => t.CorrespondantId)                ;
            
            CreateTable(
                "Courriers",
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
                .ForeignKey("Correspondants", t => t.CorrespondantId)
                .Index(t => t.CorrespondantId);
            
            CreateTable(
                "Fichiers",
                c => new
                    {
                        FichierId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NomFichier = c.String(unicode: false),
                        UrlFichier = c.String(unicode: false),
                        CourrierId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.FichierId)                
                .ForeignKey("Courriers", t => t.CourrierId)
                .Index(t => t.CourrierId);
            
            CreateTable(
                "Departements",
                c => new
                    {
                        DepartementId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NomDepartement = c.String(unicode: false),
                        Responsable = c.String(unicode: false),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.DepartementId)                ;
            
            CreateTable(
                "ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Matricule = c.String(unicode: false),
                        Nom = c.String(unicode: false),
                        Prenom = c.String(unicode: false),
                        Cin = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        DateNaissance = c.String(unicode: false),
                        DateEmbauche = c.String(unicode: false),
                        DepartementId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
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
                .ForeignKey("Departements", t => t.DepartementId, cascadeDelete: true)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "ApplicationUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(unicode: false),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "ApplicationUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId)                
                .ForeignKey("ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "ApplicationUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ApplicationUser_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                        ApplicationRole_Id = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })                
                .ForeignKey("ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("ApplicationRoles", t => t.ApplicationRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationRole_Id);
            
            CreateTable(
                "WorkFlows",
                c => new
                    {
                        WorkFlowId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.WorkFlowId)                ;
            
            CreateTable(
                "Documents",
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
                .ForeignKey("ApplicationUsers", t => t.ApplicationUserId)
                .ForeignKey("Fichiers", t => t.DocumentId)
                .ForeignKey("WorkFlows", t => t.WorkFlowId)
                .Index(t => t.DocumentId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.WorkFlowId);
            
            CreateTable(
                "ApplicationRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "WorkFlowDepartements",
                c => new
                    {
                        WorkFlow_WorkFlowId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Departement_DepartementId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.WorkFlow_WorkFlowId, t.Departement_DepartementId })                
                .ForeignKey("WorkFlows", t => t.WorkFlow_WorkFlowId, cascadeDelete: true)
                .ForeignKey("Departements", t => t.Departement_DepartementId, cascadeDelete: true)
                .Index(t => t.WorkFlow_WorkFlowId)
                .Index(t => t.Departement_DepartementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ApplicationUserRoles", "ApplicationRole_Id", "ApplicationRoles");
            DropForeignKey("Documents", "WorkFlowId", "WorkFlows");
            DropForeignKey("Documents", "DocumentId", "Fichiers");
            DropForeignKey("Documents", "ApplicationUserId", "ApplicationUsers");
            DropForeignKey("WorkFlowDepartements", "Departement_DepartementId", "Departements");
            DropForeignKey("WorkFlowDepartements", "WorkFlow_WorkFlowId", "WorkFlows");
            DropForeignKey("ApplicationUsers", "DepartementId", "Departements");
            DropForeignKey("ApplicationUserRoles", "ApplicationUser_Id", "ApplicationUsers");
            DropForeignKey("ApplicationUserLogins", "ApplicationUser_Id", "ApplicationUsers");
            DropForeignKey("ApplicationUserClaims", "ApplicationUser_Id", "ApplicationUsers");
            DropForeignKey("Fichiers", "CourrierId", "Courriers");
            DropForeignKey("Courriers", "CorrespondantId", "Correspondants");
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
            DropTable("WorkFlowDepartements");
            DropTable("ApplicationRoles");
            DropTable("Documents");
            DropTable("WorkFlows");
            DropTable("ApplicationUserRoles");
            DropTable("ApplicationUserLogins");
            DropTable("ApplicationUserClaims");
            DropTable("ApplicationUsers");
            DropTable("Departements");
            DropTable("Fichiers");
            DropTable("Courriers");
            DropTable("Correspondants");
        }
    }
}
