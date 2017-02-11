namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoModel1002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceitasItens", "Ingrediente_Id", "dbo.Ingredientes");
            DropForeignKey("dbo.ReceitasItens", "Receita_Id", "dbo.Receitas");
            DropIndex("dbo.ReceitasItens", new[] { "Ingrediente_Id" });
            RenameColumn(table: "dbo.ReceitasItens", name: "Ingrediente_Id", newName: "Ingrediente_IngredienteId");
            RenameColumn(table: "dbo.ReceitasItens", name: "Receita_Id", newName: "Receita_ReceitaId");
            RenameIndex(table: "dbo.ReceitasItens", name: "IX_Receita_Id", newName: "IX_Receita_ReceitaId");
            DropPrimaryKey("dbo.ReceitasItens");
            DropPrimaryKey("dbo.Ingredientes");
            DropPrimaryKey("dbo.Receitas");
            DropColumn("dbo.ReceitasItens", "Id");
            DropColumn("dbo.Ingredientes", "Id");
            DropColumn("dbo.Receitas", "Id");
            AddColumn("dbo.ReceitasItens", "IdReceitaItens", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ReceitasItens", "IdReceita", c => c.Int(nullable: false));
            AddColumn("dbo.ReceitasItens", "IdIngrediente", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredientes", "IngredienteId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Receitas", "ReceitaId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ReceitasItens", "Ingrediente_IngredienteId", c => c.Int());
            AddPrimaryKey("dbo.ReceitasItens", "IdReceitaItens");
            AddPrimaryKey("dbo.Ingredientes", "IngredienteId");
            AddPrimaryKey("dbo.Receitas", "ReceitaId");
            CreateIndex("dbo.ReceitasItens", "Ingrediente_IngredienteId");
            AddForeignKey("dbo.ReceitasItens", "Ingrediente_IngredienteId", "dbo.Ingredientes", "IngredienteId");
            AddForeignKey("dbo.ReceitasItens", "Receita_ReceitaId", "dbo.Receitas", "ReceitaId");            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receitas", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Ingredientes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ReceitasItens", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ReceitasItens", "Receita_ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.ReceitasItens", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropIndex("dbo.ReceitasItens", new[] { "Ingrediente_IngredienteId" });
            DropPrimaryKey("dbo.Receitas");
            DropPrimaryKey("dbo.Ingredientes");
            DropPrimaryKey("dbo.ReceitasItens");
            AlterColumn("dbo.ReceitasItens", "Ingrediente_IngredienteId", c => c.Int(nullable: false));
            DropColumn("dbo.Receitas", "ReceitaId");
            DropColumn("dbo.Ingredientes", "IngredienteId");
            DropColumn("dbo.ReceitasItens", "IdIngrediente");
            DropColumn("dbo.ReceitasItens", "IdReceita");
            DropColumn("dbo.ReceitasItens", "IdReceitaItens");
            AddPrimaryKey("dbo.Receitas", "Id");
            AddPrimaryKey("dbo.Ingredientes", "Id");
            AddPrimaryKey("dbo.ReceitasItens", "Id");
            RenameIndex(table: "dbo.ReceitasItens", name: "IX_Receita_ReceitaId", newName: "IX_Receita_Id");
            RenameColumn(table: "dbo.ReceitasItens", name: "Receita_ReceitaId", newName: "Receita_Id");
            RenameColumn(table: "dbo.ReceitasItens", name: "Ingrediente_IngredienteId", newName: "Ingrediente_Id");
            CreateIndex("dbo.ReceitasItens", "Ingrediente_Id");
            AddForeignKey("dbo.ReceitasItens", "Receita_Id", "dbo.Receitas", "Id");
            AddForeignKey("dbo.ReceitasItens", "Ingrediente_Id", "dbo.Ingredientes", "Id", cascadeDelete: true);
        }
    }
}
