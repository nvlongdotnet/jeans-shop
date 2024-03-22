namespace WebShopOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_ProductCategory", "Alias", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_ProductCategory", "Alias", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
