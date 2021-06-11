using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Broker.Models
{
    public partial class Product
    {
        public Product()
        {
            CommissionsPaidProducts = new HashSet<CommissionsPaidProduct>();
        }

        public int ProductId { get; set; }
        public int AssociateId { get; set; }
        [Required]
        public string ApplicationNumber { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? DateFunded { get; set; }
        [Required]
        public string BorrowerName { get; set; }
        public string TransactionType { get; set; }
        public string ProductDescription { get; set; }
        public int? Term { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        [Required]
        public decimal? MortgageAmount { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N}")]
        [Required]
        public decimal? TotalFileCommissions { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public string LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        public virtual Associate Associate { get; set; }
        public virtual ICollection<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }
    }
}
