using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Broker.Models
{
    public partial class CommissionsPaidProduct
    {
        public int CommissionsPaidProductId { get; set; }
        public int CommissionsPaidId { get; set; }
        public int? ProductId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        public decimal? Commission { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public virtual CommissionsPaid CommissionsPaid { get; set; }
        public virtual Product Product { get; set; }
    }
}
