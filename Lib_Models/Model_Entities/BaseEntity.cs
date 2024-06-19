using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class BaseEntity
    {
        [Key]
        public int id { get; set; }
        public DateTime timeCreate { get; set; }
    }
}
