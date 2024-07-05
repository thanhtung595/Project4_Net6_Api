using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
using Lib_Models.Model_Get;
using Lib_Models.Model_Post;
using Lib_Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<CategoryEntity> _repositoryCategory;
        public CategoryService(IRepository<CategoryEntity> repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public async Task<StatusApplication> Add(CategoryModel category)
        {
            var checkName = await _repositoryCategory.GetAll(x => x.name!.ToLower() == category.name!.ToLower());
            if (checkName.Any())
            {
                return new StatusApplication { isBool = false, message = "Name category đã tồn tại" };
            }

            CategoryEntity categoryEntity = new CategoryEntity
            {
                name = category.name!,
                isActive = true,
                timeCreate = DateTime.Now,
            };

            if (category.parentID > 0)
            {
                var cateParent = await _repositoryCategory.GetById(category.parentID);
                if (cateParent == null)
                {
                    return new StatusApplication { isBool = false, message = "ParentID không tồn tại" };
                }
                categoryEntity.parentID = category.parentID;
                categoryEntity.lv = cateParent.lv + 1;
            }
            else
            {
                categoryEntity.parentID = null;
                categoryEntity.lv = 1;
            }
            await _repositoryCategory.Insert(categoryEntity);
            await _repositoryCategory.Commit();

            return new StatusApplication { isBool = true, message = "success" };
        }

        public async Task<List<CategoryModel_GetAll>> GetAll()
        {
            // Lấy danh sách các danh mục từ repository
            var categories = await _repositoryCategory.GetAll();

            // Tạo một lookup dựa trên parentID để nhóm các danh mục theo parentID
            var lookup = categories.ToLookup(c => c.parentID);

            // Lựa chọn các danh mục gốc (có parentID = null) và chuyển đổi chúng sang mô hình CategoryModel_GetAll
            var rootCategories = lookup[null].Select(c => MapToCategoryModel_GetAll(c, lookup)).ToList();

            // Trả về danh sách các danh mục gốc (cây danh mục)
            return rootCategories;
        }

        private CategoryModel_GetAll MapToCategoryModel_GetAll(CategoryEntity category, ILookup<int?, CategoryEntity> lookup)
        {
            // Lấy danh sách các danh mục con của danh mục hiện tại và chuyển đổi chúng thành mô hình CategoryModel_GetAll
            var subCategories = lookup[category.id].Select(c => MapToCategoryModel_GetAll(c, lookup)).ToList();

            // Tạo một đối tượng CategoryModel_GetAll từ đối tượng CategoryEntity và danh sách danh mục con đã được chuyển đổi
            return new CategoryModel_GetAll
            {
                Id = category.id,
                Name = category.name,
                SubCategories = subCategories
            };
        }

    }
}
