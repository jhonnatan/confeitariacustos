namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLength2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredientes", "Unidade", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredientes", "Unidade", c => c.String(nullable: false));
        }
    }
}
