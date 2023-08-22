using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LasPollasHermanas.Client.Models
{
    public class Dildo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Material { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
    }
}