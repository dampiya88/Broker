using System;
using System.Collections.Generic;

#nullable disable

namespace Broker.Models
{
    public partial class AssociateCommission
    {
        public int AssociateCommissionId { get; set; }
        public int AssociateId { get; set; }
        public int AssociateCommission1 { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public int CommissionSplitId { get; set; }

        public virtual Associate Associate { get; set; }
    }
}
