using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ann_shop.Services;

namespace ann_shop.Controllers
{
    public class ShortCodeController : ANNController
    {
        private ShortCodeService _service;

        public ShortCodeController()
        {
            _service = new ShortCodeService();
        }

        public MvcHtmlString GetHtmlStringShortCode(string name)
        {
            var model = _service.GetShortCode(name);

            return new MvcHtmlString(model == null ? null : model.content);
        }
    }
}