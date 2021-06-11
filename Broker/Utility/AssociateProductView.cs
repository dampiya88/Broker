using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Utility
{
    
    public class AssociateProductView
    {
        [Key]
        public string AssociateId { get; set; }
        public string ApplicationNumber { get; set; }
        public decimal? TotalFileCommissions { get;  set; }
        public int? SplitID { get;  set; }
        public decimal? MortgageAmount { get; set; }


    }
}
