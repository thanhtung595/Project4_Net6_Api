using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
using Lib_Models.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Brand
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<BrandEntity> _brandRepository;
        public BrandService(IRepository<BrandEntity> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<StatusApplication> Add(string name)
        {
            var checkName = await _brandRepository.GetAll(x => x.name!.ToLower() == name.ToLower());
            if (checkName.Any())
            {
                return new StatusApplication { isBool = false, message = "Tên đã tồn tại" };
            }
            BrandEntity brand = new BrandEntity
            {
                name = name,
                isActive = true,
                timeCreate = DateTime.Now,
            };
            await _brandRepository.Insert(brand);
            await _brandRepository.Commit();
            return new StatusApplication { isBool = true, message = "success" };
        }

        public async Task<List<BrandEntity>> GetAll()
        {
            var data = await _brandRepository.GetAll();
            return data.ToList();
        }
    }
}
