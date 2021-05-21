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

        public int AssociateId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string AssociateFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string AssociateLastName { get; set; }
        public string? Company { get; set; }
        public DateTime? DateOfPayment { get; set; }
        [Range(0, 100)]
        [Display(Name = "Associate Split must be a whole number")]
        public int? SplitId { get; set; }

        public virtual ICollection<AssociateCommission> AssociateCommissions { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
