using System;
using System.Collections.Generic;

#nullable disable

namespace Broker.Models
{
    public partial class CommissionsPaidProduct
    {
        public int CommissionsPaidProductId { get; set; }
        public int CommissionsPaidId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Commission { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public virtual CommissionsPaid CommissionsPaid { get; set; }
    }
}
