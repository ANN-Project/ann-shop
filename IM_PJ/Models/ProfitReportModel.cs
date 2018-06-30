using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM_PJ.Models
{
    public class ProfitReportModel
    {
        public int TotalNumberOfOrder { get; set; }
        public double TotalCostOfSales { get; set; }
        public double TotalSales { get; set; }
        public double TotalRefund { get; set; }
        public double TotalCostOfRefund { get; set; }
    }
}