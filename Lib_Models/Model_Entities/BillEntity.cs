using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class BillEntity : BaseEntity
    {
        public float subTotal{ get; set; }
        public float priceCost{ get; set; }
        public int idAccount { get; set; }

        [ForeignKey("idAccount")]
        public virtual AccountEntity? Account { get; set; }
    }
}
