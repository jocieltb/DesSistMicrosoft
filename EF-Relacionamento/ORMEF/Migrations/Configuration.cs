namespace ORMEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ORMEF.ModelPessoas>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ORMEF.ModelPessoas";
        }

        protected override void Seed(ORMEF.ModelPessoas context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
