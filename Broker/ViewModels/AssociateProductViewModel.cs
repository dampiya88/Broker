using Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.ViewModels
{
    public class AssociateProductViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Associate> Associate { get; set; }

    }
}
