using Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class CommissionsPaidProductViewModel
    {
        public Product Product { get; set; }
        public CommissionsPaidProduct CommissionsPaidProduct { get; set; }
        public AssociateCommission AssociateCommission { get; set; }
        public CommissionsPaid CommissionsPaid { get; set; }
        public Associate Associate { get; set; }
    }
}
