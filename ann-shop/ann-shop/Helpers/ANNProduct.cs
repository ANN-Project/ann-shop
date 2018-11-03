using System.Text;

using ann_shop.Models;
using ann_shop.Utils;

namespace System.Web.Mvc.Html
{
    public static partial class Html
    {
        public static MvcHtmlString ANNProd(this HtmlHelper helper, ProductModel prod, object htmlAttributes = null)
        {
            var temp = new StringBuilder();
            var @class = "col-md-3 col-sm-4 col-xs-6";

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

            temp.Append(String.Format("<div class='{0} item product-item product-grid-item h-hover-alt  product-wrapper product-item animated zoomIn'>", @class));
            temp.Append(String.Format("    <div class='product-wrapp product-resize'>"));
            temp.Append(String.Format("        <div class='product-element-top'>"));
            temp.Append(String.Format("            <div class='product-image image-resize'>"));
            temp.Append(String.Format("                <a href='{0}' title='{1}'>", prod.Slug, prod.Name));
            if (prod.DiscountPrice > 0)
            {
                temp.Append(String.Format("                <div class='field-sale'>"));
                temp.Append(String.Format("                    <span>-{0}%</span>", @prod.DiscountRatio));
                temp.Append(String.Format("                </div>"));
            }
            temp.Append(String.Format("                    <img src='{0}' alt='{1}' />", prod.Image, prod.Name));
            temp.Append(String.Format("                </a>"));
            temp.Append(String.Format("            </div>"));
            temp.Append(String.Format("        </div>"));
            temp.Append(String.Format("        <div class='product-info'>"));
            temp.Append(String.Format("            <h3 class='product-title'>"));
            temp.Append(String.Format("                <a href='{0}' title='@product.Name'> {1}</a>", prod.Slug, prod.Name));
            temp.Append(String.Format("            </h3>"));
            temp.Append(String.Format("            <div class='wrap-price'>"));
            temp.Append(String.Format("                <div class='price-info clearfix'>"));
            temp.Append(String.Format("                    <div class='price-new-old price'>"));
            if (prod.DiscountPrice > 0)
            {
                temp.Append(String.Format("                        <span>{0}</span>", StringFormat.Money(@prod.DiscountPrice)));
                temp.Append(String.Format("                        <small class='price2'><del> {0} </del></small>", StringFormat.Money(@prod.Price)));
            }
            else
            {
                temp.Append(String.Format("                        <span>{0}</span>", StringFormat.Money(@prod.Price)));
            }
            temp.Append(String.Format("                    </div>"));
            temp.Append(String.Format("                </div>"));
            temp.Append(String.Format("            </div>"));
            temp.Append(String.Format("        </div>"));
            temp.Append(String.Format("    </div>"));
            temp.Append(String.Format("</div>"));

            return new MvcHtmlString(temp.ToString());
        }
    }
}