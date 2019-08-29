namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Casas201908192134 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Endereco = c.String(),
                        Cidade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cidades", t => t.Cidade_Id)
                .Index(t => t.Cidade_Id);
            
            CreateTable(
                "dbo.PessoaCasas",
                c => new
                    {
                        Pessoa_Id = c.Int(nullable: false),
                        Casa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pessoa_Id, t.Casa_Id })
                .ForeignKey("dbo.Pessoas", t => t.Pessoa_Id, cascadeDelete: true)
                .ForeignKey("dbo.Casas", t => t.Casa_Id, cascadeDelete: true)
                .Index(t => t.Pessoa_Id)
                .Index(t => t.Casa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PessoaCasas", "Casa_Id", "dbo.Casas");
            DropForeignKey("dbo.PessoaCasas", "Pessoa_Id", "dbo.Pessoas");
            DropForeignKey("dbo.Casas", "Cidade_Id", "dbo.Cidades");
            DropIndex("dbo.PessoaCasas", new[] { "Casa_Id" });
            DropIndex("dbo.PessoaCasas", new[] { "Pessoa_Id" });
            DropIndex("dbo.Casas", new[] { "Cidade_Id" });
            DropTable("dbo.PessoaCasas");
            DropTable("dbo.Casas");
        }
    }
}
