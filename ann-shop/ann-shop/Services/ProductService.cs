using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ann_shop.Services
{
    public class ProductService: ANNService
    {
        private ProductModel _model;

        public ProductService()
        {
            _model = new ProductModel();
        }

        private void Init()
        {
        }

        public ProductModel GetProduct(string slug)
        {
            var product = new ProductModel()
            {
                ID = 2,
                SKU = "DB12345",
                Name = "Tankini top swimskirt Juni",
                Price = 1390000,
                DiscountRatio = 0,
                DiscountPrice = 0,
                Avartar = "~/images/0530_la_07_1024x1024.jpg",
                Slug = "tankini-top-swimskirt-juni",
                Images = new List<ImageModel>()
                {
                    new ImageModel() { small="~/images/0530_la_07_small.jpg", large="~/images/0530_la_07_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_12_small.jpg", large="~/images/0530_la_12_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_76_small.jpg", large="~/images/0530_la_76_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_02_small.jpg", large="~/images/0530_la_02_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_rg1_sp1_06_small.jpg", large="~/images/0530_rg1_sp1_06_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_33_small.jpg", large="~/images/0530_la_33_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_49_small.jpg", large="~/images/0530_la_49_1024x1024.jpg" },
                    new ImageModel() { small="~/images/0530_la_25_small.jpg", large="~/images/0530_la_25_1024x1024.jpg" },
                },
                Size="M",
                Color="Xanh",
                Number=1,
                CategoryID=1,
                CategoryName="Bikini",
                Tage= "Bikini Juni",
                Description = new StringBuilder()
                    .Append("<p>Bikini Beach sở hữu kiểu dáng thời trang, thiết kế phối dây quyến rũ, phối họa tiết tropical đẹp mắt, mang đến vẻ ngoài nóng bỏng và năng động.</p>")
                    .Append("<ul>")
                    .Append("    <li>Chất liệu vải thun</li>")
                    .Append("    <li>Áo thiết kế thể thao phối dây quyến rũ</li>")
                    .Append("    <li>Quần lưng thấp phối 3 dây gợi cảm</li>")
                    .Append("    <li>Họa tiết tropical năng động</li>")
                    .Append("    <li>Sản xuất tại Việt Nam</li>")
                    .Append("    < li >Size mẫu mặc: S. Số đo mẫu:&nbsp;80 - 58 - 88 - 171 (cm)</li>")
                    .Append("</ul>")
                    .ToString()
            };

            return product;
        }

        public ProductModel GetIndex(string slug)
        {
            Init();

            _model = GetProduct(slug);

            return _model;
        }

        public List<ProductModel> GetProductNew()
        {
            #region Create data produuct new
            var products = new List<ProductModel>()
            {
                new ProductModel() { ID = 1, Name = "Bikini áo ba lỗ Blue Hawaiian", Price = 2700000, DiscountRatio = 8, DiscountPrice = 2500000, Avartar = "~/images/18_large.jpg", Slug = "bikini-ao-ba-lo-blue-hawaiian", },
                new ProductModel() { ID = 2, Name = "Bikini kèo áo lưới kimono", Price = 1700000, DiscountRatio = 12, DiscountPrice = 1500000, Avartar = "~/images/20160614-bi_48_large.jpg", Slug = "bikini-keo-ao-luoi-kimono" },
                new ProductModel() { ID = 3, Name = "Bikini lưng cao Juni house", Price = 1000000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/6_large.jpg", Slug = "bikini-lung-cao-juni-house" },
                new ProductModel() { ID = 4, Name= "Bikini Peace sọc", Price=369000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_large.jpg", Slug="bikini-peace-soc"},
                new ProductModel() { ID = 5, Name = "Bikini Shining Girls", Price = 700000, DiscountRatio = 7, DiscountPrice = 750000, Avartar = "~/images/5_large.jpg", Slug = "bikini-shining-girls" },
                new ProductModel() { ID = 6, Name = "Bikini tay dài Juni", Price = 1000000, DiscountRatio = 10, DiscountPrice = 900000, Avartar = "~/images/4_large.jpg", Slug = "bikini-tay-dai-juni" },
                new ProductModel() { ID = 7, Name= "Bikini wanabe màu hồng", Price=560000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/2_large.jpg", Slug="bikini-wanabe-mau-hong"},
                new ProductModel() { ID = 8, Name = "Caroline bikini một mảnh", Price = 2500000, DiscountRatio = 5, DiscountPrice = 2390000, Avartar = "~/images/10_large.jpg", Slug = "caroline-bikini-mot-manh" }
            };
            #endregion

            return products;
        }

        public List<ProductModel> GetProductTop(int category_id)
        {
            #region Create data product top
            var products = new List<ProductModel>()
            {
                new ProductModel() { ID = 1, Name="Bikini kèm áo lady swim", Price=2500000, DiscountRatio=8, DiscountPrice=2300000, Avartar="~/images/a_medium.jpg", Slug="bikini-kem-ao-lady-swim",},
                new ProductModel() { ID = 2, Name="Tankini top swimskirt Juni", Price=1390000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/0530_la_07_medium.jpg", Slug="tankini-top-swimskirt-juni"},
                new ProductModel() { ID = 3, Name="Tankini top swimskirt Juni", Price=1390000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/0530_la_07_medium.jpg", Slug="tankini-top-swimskirt-juni"},
                new ProductModel() { ID = 4, Name="Tankini top swimskirt Juni", Price=1390000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/0530_la_07_medium.jpg", Slug="tankini-top-swimskirt-juni"},
                new ProductModel() { ID = 5, Name="Tankini top swimskirt Juni", Price=1390000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/0530_la_07_medium.jpg", Slug="tankini-top-swimskirt-juni"},
                new ProductModel() { ID = 6, Name="Tankini top swimskirt Juni", Price=1390000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/0530_la_07_medium.jpg", Slug="tankini-top-swimskirt-juni"},
            };
            #endregion

            return products;
        }

        public List<ProductModel> GetProductSame(int category_id)
        {
            #region Create data produuct same
            var products = new List<ProductModel>()
            {
                new ProductModel() { ID = 1, Name= "Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg", Slug="flobo-printed-bikini-tank",},
                new ProductModel() { ID = 2, Name= "Bikini top flora wanabe", Price=3100000, DiscountRatio=7, DiscountPrice=2900000, Avartar="~/images/1_5fea415d1f4547358cfc53c11cc2d412_large.jpg", Slug="bikini-top-flora-wanabe"},
                new ProductModel() { ID = 3, Name= "Victory Crochet Bikini", Price=2000000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/13487_shop1_938894_large.jpg", Slug="victory-crochet-bikini"},
                new ProductModel() { ID = 4, Name= "Fifth memory crochet bikini", Price=1500000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/160426_11-2_large.jpg", Slug="fifth-memory-crochet-bikini"},
                new ProductModel() { ID = 5, Name= "Bikini váy Shining Girls", Price=1900000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/13_large.jpg", Slug="bikini-vay-shining-girls"},
                new ProductModel() { ID = 6, Name= "Caroline bikini một mảnh", Price=2500000, DiscountRatio=5, DiscountPrice=2390000, Avartar="~/images/10_large.jpg", Slug="caroline-bikini-mot-manh"},
                new ProductModel() { ID = 7, Name= "Wanabe bra top bikini", Price=1500000, DiscountRatio=8, DiscountPrice=1390000, Avartar="~/images/8_large.jpg", Slug="wanabe-bra-top-bikini"},
                new ProductModel() { ID = 8, Name= "Bikini Shining Girls", Price=700000, DiscountRatio=7, DiscountPrice=750000, Avartar="~/images/5_large.jpg", Slug="bikini-shining-girls"},
                new ProductModel() { ID = 9, Name= "Bikini tay dài Juni", Price=1000000, DiscountRatio=10, DiscountPrice=900000, Avartar="~/images/4_large.jpg", Slug="bikini-tay-dai-juni"},
                new ProductModel() { ID = 10, Name= "Crochet Bikini Xanh navi", Price=3900000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/3_large.jpg", Slug="crochet-bikini-xanh-navi"},
                new ProductModel() { ID = 11, Name= "Bikini wanabe màu hồng", Price=560000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/2_large.jpg", Slug="bikini-wanabe-mau-hong"},
                new ProductModel() { ID = 12, Name= "Bikini Peace sọc", Price=369000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_large.jpg", Slug="bikini-peace-soc"}
            };
            #endregion

            return products;
        }

        public List<ProductModel> GetProductInCategory(string category_slug)
        {
            #region Create data product at home page
            var products = new List<ProductModel>();

            switch (category_slug)
            {
                case "bikini-mot-manh":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini áo ba lỗ Caroline", Price = 2500000, DiscountRatio = 16, DiscountPrice = 2100000, Avartar = "~/images/12_large.jpg", Slug = "bikini-ao-ba-lo-caroline", });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini kèm áo lady swim", Price = 2500000, DiscountRatio = 8, DiscountPrice = 2300000, Avartar = "~/images/a_large.jpg", Slug = "bikini-kem-ao-lady-swim" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini váy Shining Girls", Price = 1900000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/13_large.jpg", Slug = "bikini-vay-shining-girls" });
                    products.Add(new ProductModel() { ID = 4, Name = "Caroline bikini một mảnh", Price = 2500000, DiscountRatio = 5, DiscountPrice = 2390000, Avartar = "~/images/10_large.jpg", Slug = "caroline-bikini-mot-manh" });
                    break;
                case "bikini-hai-manh":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini áo ba lỗ Blue Hawaiian", Price = 2700000, DiscountRatio = 8, DiscountPrice = 2500000, Avartar = "~/images/18_large.jpg", Slug = "bikini-ao-ba-lo-blue-hawaiian", });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini kèo áo lưới kimono", Price = 1700000, DiscountRatio = 12, DiscountPrice = 1500000, Avartar = "~/images/20160614-bi_48_large.jpg", Slug = "bikini-keo-ao-luoi-kimono" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini lưng cao Juni house", Price = 1000000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/6_large.jpg", Slug = "bikini-lung-cao-juni-house" });
                    products.Add(new ProductModel() { ID = 4, Name = "Bikini Peace sọc", Price = 369000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/1_large.jpg", Slug = "bikini-peace-soc" });
                    break;
                case "bikini-cap-cao":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini kèo áo lưới kimono", Price = 1700000, DiscountRatio = 12, DiscountPrice = 1500000, Avartar = "~/images/20160614-bi_48_large.jpg", Slug = "bikini-keo-ao-luoi-kimono" });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini Shining Girls", Price = 700000, DiscountRatio = 7, DiscountPrice = 750000, Avartar = "~/images/5_large.jpg", Slug = "bikini-shining-girls" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini tay dài Juni", Price = 1000000, DiscountRatio = 10, DiscountPrice = 900000, Avartar = "~/images/4_large.jpg", Slug = "bikini-tay-dai-juni" });
                    products.Add(new ProductModel() { ID = 4, Name = "Bikini top flora wanabe", Price = 3100000, DiscountRatio = 7, DiscountPrice = 2900000, Avartar = "~/images/1_5fea415d1f4547358cfc53c11cc2d412_large.jpg", Slug = "bikini-top-flora-wanabe" });
                    break;
                case "khan-tam":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini áo ba lỗ Blue Hawaiian", Price = 2700000, DiscountRatio = 8, DiscountPrice = 2500000, Avartar = "~/images/18_large.jpg", Slug = "bikini-ao-ba-lo-blue-hawaiian", });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini kèo áo lưới kimono", Price = 1700000, DiscountRatio = 12, DiscountPrice = 1500000, Avartar = "~/images/20160614-bi_48_large.jpg", Slug = "bikini-keo-ao-luoi-kimono" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini lưng cao Juni house", Price = 1000000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/6_large.jpg", Slug = "bikini-lung-cao-juni-house" });
                    products.Add(new ProductModel() { ID = 4, Name = "Bikini Peace sọc", Price = 369000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/1_large.jpg", Slug = "bikini-peace-soc" });
                    break;
                case "kinh-boi":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini kèo áo lưới kimono", Price = 1700000, DiscountRatio = 12, DiscountPrice = 1500000, Avartar = "~/images/20160614-bi_48_large.jpg", Slug = "bikini-keo-ao-luoi-kimono" });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini Shining Girls", Price = 700000, DiscountRatio = 7, DiscountPrice = 750000, Avartar = "~/images/5_large.jpg", Slug = "bikini-shining-girls" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini tay dài Juni", Price = 1000000, DiscountRatio = 10, DiscountPrice = 900000, Avartar = "~/images/4_large.jpg", Slug = "bikini-tay-dai-juni" });
                    products.Add(new ProductModel() { ID = 4, Name = "Bikini top flora wanabe", Price = 3100000, DiscountRatio = 7, DiscountPrice = 2900000, Avartar = "~/images/1_5fea415d1f4547358cfc53c11cc2d412_large.jpg", Slug = "bikini-top-flora-wanabe" });
                    break;
                case "mu-boi":
                    products.Add(new ProductModel() { ID = 1, Name = "Bikini áo ba lỗ Caroline", Price = 2500000, DiscountRatio = 16, DiscountPrice = 2100000, Avartar = "~/images/12_large.jpg", Slug = "bikini-ao-ba-lo-caroline", });
                    products.Add(new ProductModel() { ID = 2, Name = "Bikini kèm áo lady swim", Price = 2500000, DiscountRatio = 8, DiscountPrice = 2300000, Avartar = "~/images/a_large.jpg", Slug = "bikini-kem-ao-lady-swim" });
                    products.Add(new ProductModel() { ID = 3, Name = "Bikini váy Shining Girls", Price = 1900000, DiscountRatio = 0, DiscountPrice = 0, Avartar = "~/images/13_large.jpg", Slug = "bikini-vay-shining-girls" });
                    products.Add(new ProductModel() { ID = 4, Name = "Caroline bikini một mảnh", Price = 2500000, DiscountRatio = 5, DiscountPrice = 2390000, Avartar = "~/images/10_large.jpg", Slug = "caroline-bikini-mot-manh" });
                    break;
                default:
                    break;
            }
            #endregion

            var result = db.tbl_ProductCategory.Where(
                    x => x.Slug == category_slug.Trim()
                ).Join(
                    db.tbl_ProductInCategory,
                    category => category.ID,
                    product => product.CategoryID,
                    (category, product) => product
                ).Join(
                    db.tbl_Product,
                    product => product.ProductID,
                    info => info.ID,
                    (product, info) => info
                ).Select(
                    x => new ProductModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Price = x.CostOfGoods,
                        Avartar = x.Image,
                        Slug = x.Slug
                    }
                ).ToList();

            return result;
        }

        public List<ProductModel> GetProductInCategories(List<string> category_slugs)
        {
            category_slugs = category_slugs.Select(x => x.Trim()).ToList();

            var result = db.tbl_ProductCategory.Where(
                    x => category_slugs.Contains(x.Slug)
                ).Join(
                    db.tbl_ProductInCategory,
                    category => category.ID,
                    product => product.CategoryID,
                    (category, product) => product
                ).Join(
                    db.tbl_Product,
                    product => product.ProductID,
                    info => info.ID,
                    (product, info) => info
                ).Select(
                    x => new ProductModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Price = x.CostOfGoods,
                        Avartar = x.Image,
                        Slug = x.Slug
                    }
                ).ToList();

            return result;
        }
    }
}