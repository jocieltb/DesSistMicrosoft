namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocalNascimento201908192124 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pessoas", "Cidade_Id1", "dbo.Cidades");
            DropIndex("dbo.Pessoas", new[] { "Cidade_Id1" });
            DropColumn("dbo.Pessoas", "Cidade_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoas", "Cidade_Id1", c => c.Int());
            CreateIndex("dbo.Pessoas", "Cidade_Id1");
            AddForeignKey("dbo.Pessoas", "Cidade_Id1", "dbo.Cidades", "Id");
        }
    }
}
