using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Broker.Models
{
    public partial class AssociateCommission
    {
        public int AssociateCommissionId { get; set; }
        public int AssociateId { get; set; }
        public int AssociateCommission1 { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? EffectiveDate { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public int CommissionSplitId { get; set; }

        public virtual Associate Associate { get; set; }
        public virtual CommissionSplit CommissionSplit { get; set; }
    }
}
