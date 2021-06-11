using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Broker.Models
{
    public partial class Associate
    {
        public Associate()
        {
            AssociateCommissions = new HashSet<AssociateCommission>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int AssociateId { get; set; }
        [Required]
        public string AssociateFirstName { get; set; }
        [Required]
        public string AssociateLastName { get; set; }
        public string Company { get; set; }
        public int? SplitId { get; set; }

        public virtual ICollection<AssociateCommission> AssociateCommissions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
