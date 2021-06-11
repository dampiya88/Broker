using Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class AssociateCreateViewModel
    {
        public Associate Associate { get; set; }
        public AssociateCommission AssociateCommission { get; set; }
        public CommissionSplit CommissionSplit { get; set; }
        public List<CommissionSplit> CommissionSplits { get; set; }
    }
}
