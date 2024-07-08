using Lib_Models.Model_Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Get
{
    public class CategoryModel_GetAll
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool isActive { get; set; }
        public List<CategoryModel_GetAll> SubCategories { get; set; } = new List<CategoryModel_GetAll>();
    }
}
