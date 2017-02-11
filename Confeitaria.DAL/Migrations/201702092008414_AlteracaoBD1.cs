namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoBD1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceitasItens", "IdReceita", "dbo.Receitas");
            DropIndex("dbo.ReceitasItens", new[] { "IdReceita" });
            RenameColumn(table: "dbo.ReceitasItens", name: "IdReceita", newName: "Receita_Id");
            AlterColumn("dbo.ReceitasItens", "Receita_Id", c => c.Int());
            CreateIndex("dbo.ReceitasItens", "Receita_Id");
            AddForeignKey("dbo.ReceitasItens", "Receita_Id", "dbo.Receitas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceitasItens", "Receita_Id", "dbo.Receitas");
            DropIndex("dbo.ReceitasItens", new[] { "Receita_Id" });
            AlterColumn("dbo.ReceitasItens", "Receita_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ReceitasItens", name: "Receita_Id", newName: "IdReceita");
            CreateIndex("dbo.ReceitasItens", "IdReceita");
            AddForeignKey("dbo.ReceitasItens", "IdReceita", "dbo.Receitas", "Id", cascadeDelete: true);
        }
    }
}
