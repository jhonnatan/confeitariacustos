namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterModel11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceitasItens", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.ReceitasItens", "Receita_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.ReceitasItens", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.ReceitasItens", new[] { "Receita_ReceitaId" });
            RenameColumn(table: "dbo.ReceitasItens", name: "Ingrediente_IngredienteId", newName: "IngredienteId");
            RenameColumn(table: "dbo.ReceitasItens", name: "Receita_ReceitaId", newName: "ReceitaId");
            AlterColumn("dbo.ReceitasItens", "IngredienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.ReceitasItens", "ReceitaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceitasItens", "ReceitaId");
            CreateIndex("dbo.ReceitasItens", "IngredienteId");
            AddForeignKey("dbo.ReceitasItens", "IngredienteId", "dbo.Ingredientes", "IngredienteId", cascadeDelete: true);
            AddForeignKey("dbo.ReceitasItens", "ReceitaId", "dbo.Receitas", "ReceitaId", cascadeDelete: true);
            DropColumn("dbo.ReceitasItens", "IdReceita");
            DropColumn("dbo.ReceitasItens", "IdIngrediente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceitasItens", "IdIngrediente", c => c.Int(nullable: false));
            AddColumn("dbo.ReceitasItens", "IdReceita", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReceitasItens", "ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.ReceitasItens", "IngredienteId", "dbo.Ingredientes");
            DropIndex("dbo.ReceitasItens", new[] { "IngredienteId" });
            DropIndex("dbo.ReceitasItens", new[] { "ReceitaId" });
            AlterColumn("dbo.ReceitasItens", "ReceitaId", c => c.Int());
            AlterColumn("dbo.ReceitasItens", "IngredienteId", c => c.Int());
            RenameColumn(table: "dbo.ReceitasItens", name: "ReceitaId", newName: "Receita_ReceitaId");
            RenameColumn(table: "dbo.ReceitasItens", name: "IngredienteId", newName: "Ingrediente_IngredienteId");
            CreateIndex("dbo.ReceitasItens", "Receita_ReceitaId");
            CreateIndex("dbo.ReceitasItens", "Ingrediente_IngredienteId");
            AddForeignKey("dbo.ReceitasItens", "Receita_ReceitaId", "dbo.Receitas", "ReceitaId");
            AddForeignKey("dbo.ReceitasItens", "Ingrediente_IngredienteId", "dbo.Ingredientes", "IngredienteId");
        }
    }
}
