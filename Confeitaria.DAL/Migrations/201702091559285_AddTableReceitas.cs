namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableReceitas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        QtdePorReceita = c.Double(nullable: false),
                        TotalPorReceita = c.Double(nullable: false),
                        TotalPorUnidade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ingredientes", "Receita_Id", c => c.Int());
            CreateIndex("dbo.Ingredientes", "Receita_Id");
            AddForeignKey("dbo.Ingredientes", "Receita_Id", "dbo.Receitas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredientes", "Receita_Id", "dbo.Receitas");
            DropIndex("dbo.Ingredientes", new[] { "Receita_Id" });
            DropColumn("dbo.Ingredientes", "Receita_Id");
            DropTable("dbo.Receitas");
        }
    }
}
