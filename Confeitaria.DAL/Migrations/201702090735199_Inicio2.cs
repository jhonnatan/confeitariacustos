namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ingrediente", newName: "Ingredientes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Ingredientes", newName: "Ingrediente");
        }
    }
}
