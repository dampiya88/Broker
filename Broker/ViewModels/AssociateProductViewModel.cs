using Broker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class AssociateProductViewModel:DbContext
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Associate> Associates { get; set; }

    }
}
