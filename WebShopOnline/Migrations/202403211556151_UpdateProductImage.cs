namespace WebShopOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Image", c => c.String(nullable: false));
        }
    }
}
