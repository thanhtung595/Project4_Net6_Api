using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class CategoryChildren : BaseEntity
    {
        public string? name { get; set; }
        public int idCategoryParents { get; set; }

        [ForeignKey("idCategoryParents")]
        public virtual CategoryParents? CategoryParents { get; set; }
    }
}
