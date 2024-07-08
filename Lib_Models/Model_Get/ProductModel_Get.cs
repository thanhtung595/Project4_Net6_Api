using Lib_Models.Model_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Get
{
    public class ProductModel_Get : BaseEntity
    {
        public string? name { get; set; }
        public string? describe { get; set; }
        public string? img { get; set; }
        public float price { get; set; }
        public float priceSale { get; set; }
        public bool isSale { get; set; }
        public int countProduct { get; set; }
        public int isDelete { get; set; }
        public int idCategory { get; set; }
        public int idBrand { get; set; }
    }
}
