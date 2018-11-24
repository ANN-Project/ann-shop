using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class ArchiveProductService: ANNService
    {
        private ArchiveProductModel _model;

        public ArchiveProductService()
        {
            _model = new ArchiveProductModel();
        }

        private void Init()
        {
        }

        private void GetProductPage(string slug, int page)
        {
            #region Create data product at category page
            var products = new List<ProductModel>()
            {
                new ProductModel() { ID = 1, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg", Slug="flobo-printed-bikini-tank",},
                new ProductModel() { ID = 2, Name="Bikini top flora wanabe", Price=3100000, DiscountRatio=7, DiscountPrice=2900000, Avartar="~/images/1_5fea415d1f4547358cfc53c11cc2d412_large.jpg", Slug="bikini-top-flora-wanabe"},
                new ProductModel() { ID = 3, Name="Victory Crochet Bikini", Price=2000000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/13487_shop1_938894_large.jpg", Slug="victory-crochet-bikini"},
                new ProductModel() { ID = 4, Name="Fifth memory crochet bikini", Price=1500000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/160426_11-2_large.jpg", Slug="fifth-memory-crochet-bikini"},
                new ProductModel() { ID = 5, Name="Bikini váy Shining Girls", Price=1900000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/13_large.jpg", Slug="bikini-vay-shining-girls"},
                new ProductModel() { ID = 6, Name="Caroline bikini một mảnh", Price=2500000, DiscountRatio=5, DiscountPrice=2390000, Avartar="~/images/10_large.jpg", Slug="caroline-bikini-mot-manh"},
                new ProductModel() { ID = 7, Name="Wanabe bra top bikini", Price=1500000, DiscountRatio=8, DiscountPrice=1390000, Avartar="~/images/8_large.jpg", Slug="wanabe-bra-top-bikini"},
                new ProductModel() { ID = 8, Name="Bikini Shining Girls", Price=700000, DiscountRatio=7, DiscountPrice=750000, Avartar="~/images/5_large.jpg", Slug="bikini-shining-girls"},
                new ProductModel() { ID = 9, Name="Bikini tay dài Juni", Price=1000000, DiscountRatio=10, DiscountPrice=900000, Avartar="~/images/4_large.jpg", Slug="bikini-tay-dai-juni"},
                new ProductModel() { ID = 10, Name="Crochet Bikini Xanh navi", Price=3900000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/3_large.jpg", Slug="crochet-bikini-xanh-navi"},
                new ProductModel() { ID = 11, Name="Bikini wanabe màu hồng", Price=560000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/2_large.jpg", Slug="bikini-wanabe-mau-hong"},
                new ProductModel() { ID = 12, Name="Bikini Peace sọc", Price=369000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_large.jpg", Slug="bikini-peace-soc"},
                new ProductModel() { ID = 13, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 14, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 15, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 16, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 17, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 18, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 19, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 20, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 21, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 22, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 23, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 24, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 25, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 26, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 27, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 28, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 29, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 30, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 31, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 32, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 33, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 34, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 35, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
                new ProductModel() { ID = 36, Name="Flobo printed bikini tank", Price=1200000, DiscountRatio=0, DiscountPrice=0, Avartar="~/images/1_8fc331c46d4d4f7a89641e0015f4f74c_large.jpg"},
            };
            #endregion

            products = db.tbl_ProductCategory.Where(
                    x => x.Slug == slug.Trim()
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

            _model.Page = page;
            _model.TotalProduct = products.Count;
            _model.TotalPage = Convert.ToInt32(Math.Ceiling(_model.TotalProduct * 1.0 / _model.PageSize));
            _model.Slug = slug;
            _model.Products = products
                .Skip(page * _model.PageSize)
                .Take(_model.PageSize)
                .ToList();
        }

        public ArchiveProductModel getIndex(string slug, int page)
        {
            Init();
            GetProductPage(slug, page);

            return _model;
        }
    }
}