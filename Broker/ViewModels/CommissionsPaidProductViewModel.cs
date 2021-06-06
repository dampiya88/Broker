using Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class CommissionsPaidProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }
        public IEnumerable<CommissionsPaid> CommissionsPaid { get; set; }
    }
}
