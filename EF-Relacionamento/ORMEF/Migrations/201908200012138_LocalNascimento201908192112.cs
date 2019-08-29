namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalNascimento201908192112 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "LocalNascimento_Id", c => c.Int());
            AddColumn("dbo.Pessoas", "Cidade_Id1", c => c.Int());
            CreateIndex("dbo.Pessoas", "LocalNascimento_Id");
            CreateIndex("dbo.Pessoas", "Cidade_Id1");
            AddForeignKey("dbo.Pessoas", "LocalNascimento_Id", "dbo.Cidades", "Id");
            AddForeignKey("dbo.Pessoas", "Cidade_Id1", "dbo.Cidades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "Cidade_Id1", "dbo.Cidades");
            DropForeignKey("dbo.Pessoas", "LocalNascimento_Id", "dbo.Cidades");
            DropIndex("dbo.Pessoas", new[] { "Cidade_Id1" });
            DropIndex("dbo.Pessoas", new[] { "LocalNascimento_Id" });
            DropColumn("dbo.Pessoas", "Cidade_Id1");
            DropColumn("dbo.Pessoas", "LocalNascimento_Id");
        }
    }
}
