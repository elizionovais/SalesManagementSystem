using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class ItemSaleModel
    {
        public string code { get; set; }
        public string Description { get; set; }
        public string Qtd { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
    }
}
