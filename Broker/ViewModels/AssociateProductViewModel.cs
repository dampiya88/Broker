using Broker.Models;
using Broker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class AssociateProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Associate Associate { get; set; }
        public IEnumerable<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }
        public IEnumerable<AssociateProductView> AssociateProductViews { get; set; }
    }
}
