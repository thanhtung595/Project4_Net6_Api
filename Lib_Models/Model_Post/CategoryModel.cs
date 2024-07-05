using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Post
{
    public class CategoryModel
    {
        public string? name { get; set; }
        public int? parentID { get; set; } = 0;
    }
}
