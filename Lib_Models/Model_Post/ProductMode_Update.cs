using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Post
{
    public class ProductMode_Update
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? describe { get; set; }
        public IFormFile? img { get; set; }
        public float price { get; set; }
        public float priceSale { get; set; }
        public bool isSale { get; set; }
        public bool isActive { get; set; }
        public int countProduct { get; set; }
        public int idCategory { get; set; }
        public int idBrand { get; set; }
    }
}
