namespace Confeitaria.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredientes", "Receita_Id", "dbo.Receitas");
            DropIndex("dbo.Ingredientes", new[] { "Receita_Id" });
            CreateTable(
                "dbo.ReceitasItens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdReceita = c.Int(nullable: false),
                        Ingrediente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredientes", t => t.Ingrediente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Receitas", t => t.IdReceita, cascadeDelete: true)
                .Index(t => t.IdReceita)
                .Index(t => t.Ingrediente_Id);
            
            AlterColumn("dbo.Ingredientes", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Ingredientes", "Unidade", c => c.String(nullable: false));
            AlterColumn("dbo.Receitas", "Descricao", c => c.String(nullable: false));
            DropColumn("dbo.Ingredientes", "Receita_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredientes", "Receita_Id", c => c.Int());
            DropForeignKey("dbo.ReceitasItens", "IdReceita", "dbo.Receitas");
            DropForeignKey("dbo.ReceitasItens", "Ingrediente_Id", "dbo.Ingredientes");
            DropIndex("dbo.ReceitasItens", new[] { "Ingrediente_Id" });
            DropIndex("dbo.ReceitasItens", new[] { "IdReceita" });
            AlterColumn("dbo.Receitas", "Descricao", c => c.String());
            AlterColumn("dbo.Ingredientes", "Unidade", c => c.String());
            AlterColumn("dbo.Ingredientes", "Descricao", c => c.String());
            DropTable("dbo.ReceitasItens");
            CreateIndex("dbo.Ingredientes", "Receita_Id");
            AddForeignKey("dbo.Ingredientes", "Receita_Id", "dbo.Receitas", "Id");
        }
    }
}
