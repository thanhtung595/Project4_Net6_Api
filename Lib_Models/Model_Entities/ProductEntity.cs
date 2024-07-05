using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class ProductEntity : BaseEntity
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

        [ForeignKey("idCategory")]
        public virtual CategoryEntity? CategoryChildren { get; set; }

        [ForeignKey("idBrand")]
        public virtual BrandEntity? Brand { get; set; }  
    }
}
