using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

using ann_shop.Models;
using ann_shop.Utils;


namespace System.Web.Mvc.Html
{
    public static partial class Html
    {
        public static MvcHtmlString ANNProd(this HtmlHelper helper, ProductModel prod, MoneyType money_type = MoneyType.None, object htmlAttributes = null)
        {
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var temp = new StringBuilder();

            var @class = "col-md-3 col-sm-4 col-xs-6 item product-item product-grid-item h-hover-alt  product-wrapper product-item animated zoomIn";
            var urlProduct = url.RouteUrl("Product", new { slug = prod.Slug });
            var urlImage = url.Content(prod.Avartar);

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

                foreach(var att in attributes)
                {
                    if (att.Key.Trim().ToUpper() == "CLASS")
                    {
                        @class = att.Value.ToString().Trim();
                    }
                }
            }

            temp.Append(String.Format("<div class='{0}'>", @class));
            temp.Append("    <div class='product-wrapp product-resize'>");
            temp.Append("        <div class='product-element-top'>");
            temp.Append("            <div class='product-large large-resize'>");
            temp.Append(String.Format("                <a href='{0}' title='{1}'>", urlProduct, prod.Name));
            if (prod.DiscountPrice > 0)
            {
                temp.Append("                <div class='field-sale'>");
                temp.Append(String.Format("                    <span>-{0}%</span>", @prod.DiscountRatio));
                temp.Append("                </div>");
            }
            temp.Append(String.Format("                    <img src='{0}' alt='{1}' />", urlImage, prod.Name));
            temp.Append("                </a>");
            temp.Append("            </div>");
            temp.Append("        </div>");
            temp.Append("        <div class='product-info'>");
            temp.Append("            <h3 class='product-title'>");
            temp.Append(String.Format("                <a href='{0}' title='@product.Name'> {1}</a>", urlProduct, prod.Name));
            temp.Append("            </h3>");
            temp.Append("            <div class='wrap-price'>");
            temp.Append("                <div class='price-info clearfix'>");
            temp.Append("                    <div class='price-new-old price'>");
            if (prod.DiscountPrice > 0)
            {
                temp.Append(String.Format("                        <span>{0}</span>", StringFormat.Money(@prod.DiscountPrice, money_type)));
                temp.Append(String.Format("                        <small class='price2'><del> {0} </del></small>", StringFormat.Money(@prod.Price, money_type)));
            }
            else
            {
                temp.Append(String.Format("                        <span>{0}</span>", StringFormat.Money(@prod.Price, money_type)));
            }
            temp.Append("                    </div>");
            temp.Append("                </div>");
            temp.Append("            </div>");
            temp.Append("        </div>");
            temp.Append("    </div>");
            temp.Append("</div>");

            return new MvcHtmlString(temp.ToString());
        }
    }
}