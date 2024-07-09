using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class ListProductBillEntity : BaseEntity
    {
        public float priceCost { get; set; }
        public int countProduct { get; set; }
        public int idBill { get; set; }
        public int idProduct { get; set; }

        [ForeignKey("idBill")]
        public virtual BillEntity? Bill { get; set; }

        [ForeignKey("idProduct")]
        public virtual ProductEntity? Product { get; set; }
    }
}
