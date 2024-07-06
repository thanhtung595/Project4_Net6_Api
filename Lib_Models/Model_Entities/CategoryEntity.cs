using Lib_Models.Model_Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string? name { get; set; }
        public int? parentID { get; set; }
        public int lv { get; set; }

        [ForeignKey("parentID")]
        public virtual CategoryEntity? ParentCategory { get; set; }
        public List<CategoryEntity> SubCategories { get; set; } = new List<CategoryEntity>();
    }
}
