using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using ann_shop.Models;

namespace ann_shop.Services
{
    public class ShortCodeService : ANNService
    {
        public ShortCodeModel GetShortCode(string name)
        {
            #region Create data demo
            var url = new UrlHelper(HttpContext.Current.Request.RequestContext);

            var short_codes = new List<ShortCodeModel>()
            {
                #region home-service
                new ShortCodeModel()
                {
                    name = "home-service",
                    container = new StringBuilder()
                        .Append("<div class='home-service mg10'>")
                        .Append("    <div class='container clearfix'>")
                        .Append("        <div class='row'>")
                        .Append("            <div class='col-xs-01 col-xs-6 col-sm-6 col-lg-3 col-md-3'>")
                        .Append("                <div class='service-col'>")
                        .Append("                    <div class='service-icon'>")
                        .Append(String.Format("                        <img src='{0}' alt='Bikini Beach'>", url.Content("~/images/home_service_1.png")))
                        .Append("                    </div>")
                        .Append("                    <h4>Giao hàng miễn phí </h4>")
                        .Append("                    <p>Đơn hàng ≥ 500.000 </p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("            <div class='col-xs-01 col-xs-6 col-sm-6 col-lg-3 col-md-3'>")
                        .Append("                <div class='service-col'>")
                        .Append("                    <div class='service-icon'>")
                        .Append(String.Format("                        <img src='{0}' alt='Bikini Beach'>", url.Content("~/images/home_service_2.png")))
                        .Append("                    </div>")
                        .Append("                    <h4>Quà tặng</h4>")
                        .Append("                    <p>Nhiều quà tặng và ưu đãi</p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("            <div class='col-xs-01 col-xs-6 col-sm-6 col-lg-3 col-md-3'>")
                        .Append("                <div class='service-col'>")
                        .Append("                    <div class='service-icon'>")
                        .Append(String.Format("                        <img src='{0}' alt='Bikini Beach'>", url.Content("~/images/home_service_3.png")))
                        .Append("                    </div>")
                        .Append("                    <h4>Thương hiệu số 1</h4>")
                        .Append("                    <p>Mua sắm trực tuyến  uy tín </p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("            <div class='col-xs-01 col-xs-6 col-sm-6 col-lg-3 col-md-3'>")
                        .Append("                <div class='service-col'>")
                        .Append("                    <div class='service-icon'>")
                        .Append(String.Format("                        <img src='{0}' alt='Bikini Beach'>", url.Content("~/images/home_service_4.png")))
                        .Append("                    </div>")
                        .Append("                    <h4>Hotline: 1900636099</h4>")
                        .Append("                    <p>Hỗ trợ nhanh chóng </p>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("        </div>")
                        .Append("    </div>")
                        .Append("</div>")
                        .ToString()
                },
                #endregion
                #region home-banner-about
                new ShortCodeModel()
                {
                    name = "home-banner-about",
                    container = new StringBuilder()
                        .Append("<div class='banner-about mg-10'>")
                        .Append("    <div class='container'>")
                        .Append("        <div class='row'>")
                        .Append("            <div class='col-md-12 col-sm-12 col-xs-12'>")
                        .Append("                <div class='row'>")
                        .Append("                    <div class='banner-about-img' style='background-size: cover; background-repeat: no-repeat; background-color: rgba(0, 0, 0, 0); background-image: url(./images/img_home_about.jpg); background-attachment: scroll; min-width: 1499px; left: -164.444px; width: 1499px;'></div>")
                        .Append("                    <div class='col-md-12 col-sm-12 col-xs-12'>")
                        .Append("                        <div class='row'>")
                        .Append("                            <div class='col-lg-3 col-sm-2 col-xs-1'>")
                        .Append("                            </div>")
                        .Append("                            <div class='col-lg-6 col-sm-8 col-xs-10'>")
                        .Append("                                <div class='hb_wrapper'>")
                        .Append("                                    <p class='banner-subtitle active margin0'>Phương châm kinh doanh của</p>")
                        .Append("                                    <h3>Shop Thời Trang Bikini Beach</h3>")
                        .Append("                                    <p></p>")
                        .Append("                                    <blockquote class='fl-l style2'>")
                        .Append("                                        <p>Mỗi nhân viên của Bikini Beach luôn tỏ ra biết ơn Khách hàng bằng việc kinh doanh những sản phẩm tốt nhất – thời thượng nhất và chu đáo nhất để đáp ứng được nhu cầu của quý khách hàng.</p>")
                        .Append("                                    </blockquote>")
                        .Append("                                    <p></p>")
                        .Append("                                    <div class='row text-right'>")
                        .Append("                                        <div class='col-md-4'></div>")
                        .Append("                                    </div>")
                        .Append("                                </div>")
                        .Append("                            </div>")
                        .Append("                            <div class='col-lg-3 col-sm-2 col-xs-1'>")
                        .Append("                            </div>")
                        .Append("                        </div>")
                        .Append("                    </div>")
                        .Append("                </div>")
                        .Append("            </div>")
                        .Append("        </div>")
                        .Append("    </div>")
                        .Append("</div>")
                        .ToString()
                }
                #endregion
            };
            #endregion

            var result = db.tbl_ShortCode.Where(
                    x => x.Name == name.Trim()
                ).Select(
                    x => new ShortCodeModel()
                    {
                        name = x.Name,
                        container = x.Container
                    }
                ).FirstOrDefault();

            return result;
        }
    }
}