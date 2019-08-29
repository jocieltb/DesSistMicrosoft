namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Casas201908192143 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PessoaCasas", newName: "CasaPessoas");
            DropPrimaryKey("dbo.CasaPessoas");
            AddPrimaryKey("dbo.CasaPessoas", new[] { "Casa_Id", "Pessoa_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CasaPessoas");
            AddPrimaryKey("dbo.CasaPessoas", new[] { "Pessoa_Id", "Casa_Id" });
            RenameTable(name: "dbo.CasaPessoas", newName: "PessoaCasas");
        }
    }
}
