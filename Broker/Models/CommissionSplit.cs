using System;
using System.Collections.Generic;

#nullable disable

namespace Broker.Models
{
    public partial class CommissionSplit
    {
        public CommissionSplit()
        {
            AssociateCommissions = new HashSet<AssociateCommission>();
        }

        public int CommissionSplitId { get; set; }
        public int AssociateSplitPortion { get; set; }

        public virtual ICollection<AssociateCommission> AssociateCommissions { get; set; }
    }
}
