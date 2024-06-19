using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class Product : BaseEntity
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
        public virtual CategoryChildren? CategoryChildren { get; set; }

        [ForeignKey("idBrand")]
        public virtual Brand? Brand { get; set; }  
    }
}
