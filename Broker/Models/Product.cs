using System;
using System.Collections.Generic;
using System.Data;

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
        public string ApplicationNumber { get; set; }
        public DateTime? DateFunded { get; set; }
        public string BorrowerName { get; set; }
        public string TransactionType { get; set; }
        public string ProductDescription { get; set; }
        public int? Term { get; set; }
        public decimal? MortgageAmount { get; set; }
        public decimal? TotalFileCommissions { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

        

        public virtual Associate Associate { get; set; }
        public virtual ICollection<CommissionsPaidProduct> CommissionsPaidProducts { get; set; }

    }
}
