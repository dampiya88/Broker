using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Utility
{
    [Keyless]
    public class AssociateProductView
    {
        
        public string ApplicationNumber { get; set; }
        public decimal? TotalFileCommissions { get;  set; }
        public int? SplitID { get;  set; }
        public decimal? MortgageAmount { get; set; }


    }
}
