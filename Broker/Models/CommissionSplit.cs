using System;
using System.Collections.Generic;

#nullable disable

namespace Broker.Models
{
    public partial class CommissionSplit
    {
        public int CommissionSplitId { get; set; }
        public int AssociateSplitPortion { get; set; }
    }
}
