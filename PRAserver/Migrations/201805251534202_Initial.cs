namespace PRAserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        CrewMemberId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.FilmCrews", t => t.CrewMemberId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CrewMemberId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.FilmCrews",
                c => new
                    {
                        CrewMemberId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Firstname = c.String(),
                        Age = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CrewMemberId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ProductionYear = c.Int(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        StudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.Studios", t => t.StudioId, cascadeDelete: true)
                .Index(t => t.StudioId);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        YearOfEstablishment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "StudioId", "dbo.Studios");
            DropForeignKey("dbo.Contracts", "CrewMemberId", "dbo.FilmCrews");
            DropForeignKey("dbo.FilmCrews", "PositionId", "dbo.Positions");
            DropIndex("dbo.Movies", new[] { "StudioId" });
            DropIndex("dbo.FilmCrews", new[] { "PositionId" });
            DropIndex("dbo.Contracts", new[] { "MovieId" });
            DropIndex("dbo.Contracts", new[] { "CrewMemberId" });
            DropTable("dbo.Studios");
            DropTable("dbo.Movies");
            DropTable("dbo.Positions");
            DropTable("dbo.FilmCrews");
            DropTable("dbo.Contracts");
        }
    }
}
