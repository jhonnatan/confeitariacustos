namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredientes", "Descricao", c => c.String(nullable: false, maxLength:50));
            AlterColumn("dbo.Receitas", "Descricao", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
        }
    }
}
