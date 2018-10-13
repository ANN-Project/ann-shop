namespace ann_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tbl_Account",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Status = c.Int(),
                        Role = c.String(),
                        CustomerID = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Attribute",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_AttributeValue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AttributeID = c.Int(nullable: false),
                        AttributeName = c.String(),
                        AttributeValue = c.String(),
                        SKUText = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Comment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        PostID = c.Int(nullable: false),
                        PostType = c.String(),
                        Author = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Content = c.String(),
                        Approved = c.Int(),
                        Hidden = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.String(),
                        Nick = c.String(),
                        Phone = c.String(),
                        Phone2 = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Zalo = c.String(),
                        Facebook = c.String(),
                        Note = c.String(),
                        Avatar = c.String(),
                        Status = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Option",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemOrderID = c.Int(),
                        SystemUsername = c.String(),
                        Type = c.Int(),
                        CustomerID = c.Int(),
                        CustomerName = c.String(),
                        CustomerPhone = c.String(),
                        CustomerPhone2 = c.String(),
                        CustomerAddress = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAccept = c.Int(),
                        Note = c.String(),
                        Subtotal = c.Double(),
                        ShippingFee = c.Double(),
                        TotalDiscount = c.Double(),
                        DiscountPerItem = c.Double(),
                        OtherFeeName = c.String(),
                        OtherFeeValue = c.Double(),
                        RefundOrderID = c.Int(),
                        RefundFee = c.Double(),
                        Total = c.Double(),
                        ExcuteStatus = c.Int(),
                        PaymentStatus = c.Int(),
                        PaymentMethod = c.Int(),
                        TransportMethod = c.Int(),
                        ShippingCode = c.String(),
                        DoneDate = c.DateTime(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_OrderItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(),
                        ProductVariantID = c.Int(),
                        SystemUsername = c.String(),
                        SKU = c.String(),
                        Name = c.String(),
                        Quantity = c.Int(),
                        Price = c.Double(),
                        Discount = c.Double(),
                        Status = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Page",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Content = c.String(),
                        Slug = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Int(),
                        CommentSatus = c.Int(),
                        Image = c.String(),
                        Featured = c.Int(),
                        ViewCount = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Content = c.String(),
                        Slug = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        Status = c.Int(),
                        CommentSatus = c.Int(),
                        Image = c.String(),
                        ViewCount = c.Int(),
                        Featured = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PostCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        Hidden = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PostInCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PostInTag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PostTag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        Content = c.String(),
                        Materials = c.String(),
                        Type = c.String(),
                        Slug = c.String(),
                        WholesalePrice = c.Double(),
                        RetailPrice = c.Double(),
                        CostOfGoods = c.Double(),
                        ManageStock = c.Int(),
                        StockStatus = c.Int(),
                        Status = c.Int(),
                        CommentSatus = c.Int(),
                        Image = c.String(),
                        Featured = c.Int(),
                        ViewCount = c.Int(),
                        Hidden = c.Int(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        Name = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        Hidden = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductImage",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductInCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductInTag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductTag",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        Image = c.String(),
                        MetaTitle = c.String(),
                        MetaDescription = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductVariant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ParentSKU = c.String(),
                        SKU = c.String(),
                        Name = c.String(),
                        WholesalePrice = c.Double(),
                        RetailPrice = c.Double(),
                        CostOfGoods = c.Double(),
                        ManageStock = c.Int(),
                        StockStatus = c.Int(),
                        Status = c.Int(),
                        Image = c.String(),
                        Hidden = c.Int(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_ProductVariantValue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VariantID = c.Int(nullable: false),
                        VariantSKU = c.String(),
                        AttributeID = c.Int(nullable: false),
                        AttributeName = c.String(),
                        AttributeValue = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tbl_ProductVariantValue");
            DropTable("dbo.tbl_ProductVariant");
            DropTable("dbo.tbl_ProductTag");
            DropTable("dbo.tbl_ProductInTag");
            DropTable("dbo.tbl_ProductInCategory");
            DropTable("dbo.tbl_ProductImage");
            DropTable("dbo.tbl_ProductCategory");
            DropTable("dbo.tbl_Product");
            DropTable("dbo.tbl_PostTag");
            DropTable("dbo.tbl_PostInTag");
            DropTable("dbo.tbl_PostInCategory");
            DropTable("dbo.tbl_PostCategory");
            DropTable("dbo.tbl_Post");
            DropTable("dbo.tbl_Page");
            DropTable("dbo.tbl_OrderItem");
            DropTable("dbo.tbl_Order");
            DropTable("dbo.tbl_Option");
            DropTable("dbo.tbl_Customer");
            DropTable("dbo.tbl_Comment");
            DropTable("dbo.tbl_AttributeValue");
            DropTable("dbo.tbl_Attribute");
            DropTable("dbo.tbl_Account");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
