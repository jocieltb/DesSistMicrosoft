namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao201908191940 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NOME_CIDADE = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pessoas", "Cidade_Id", c => c.Int());
            CreateIndex("dbo.Pessoas", "Cidade_Id");
            AddForeignKey("dbo.Pessoas", "Cidade_Id", "dbo.Cidades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pessoas", "Cidade_Id", "dbo.Cidades");
            DropIndex("dbo.Pessoas", new[] { "Cidade_Id" });
            DropColumn("dbo.Pessoas", "Cidade_Id");
            DropTable("dbo.Cidades");
        }
    }
}
