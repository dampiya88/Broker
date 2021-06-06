using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Broker.Models
{
    public partial class CommissionsPaid
    {
        public CommissionsPaid()
        {
            CommissionsPaidProducts = new HashSet<CommissionsPaidProduct>();
        }

        public int CommissionsPaidId { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? DatePaid { get; set; }
        public string CommissionType { get; set; }
        public string PaymentType { get; set; }
        public int? ChequeNumber { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public virtual ICollection<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }
    }
}
