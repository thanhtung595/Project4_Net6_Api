using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
using Lib_Models.Model_Get;
using Lib_Models.Model_Post;
using Lib_Models.Status;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<ProductEntity> _repositoryProduct;
        public ProductService(IRepository<ProductEntity> repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }
        public async Task<StatusApplication> Add(ProductPost product)
        {
            var checkName = await _repositoryProduct.GetAll(x => x.name!.ToLower() == product.name);
            if (checkName.Any())
            {
                return new StatusApplication { isBool = false, message = "Name product đã tồn tại" };
            }
            bool isSaleRs = false;
            if (product.isSale == "true")
            {
                isSaleRs = true;
            }
            else
            {
                isSaleRs = false;
            }
            ProductEntity productEntity = new ProductEntity
            {
                name = product.name,
                describe = product.describe,
                img = product.name + TypeFile(product.img!),
                price = product.price,
                priceSale = product.priceSale,
                countProduct = product.countProduct,
                isSale = isSaleRs,
                idCategory = product.idCategory,
                idBrand = product.idBrand,
                isActive = true,
                isDelete = 0,
                timeCreate = DateTime.Now,
            };
            await _repositoryProduct.Insert(productEntity);
            await _repositoryProduct.Commit();
            return new StatusApplication { isBool = true, message = productEntity.name };
        }

        public async Task<List<ProductModel_Get>> GetAll()
        {
            var data = await _repositoryProduct.GetAll();
            var rel = data.Select(x => new ProductModel_Get
            {
                id = x.id,
                name = x.name,
                describe = x.describe,
                img = "img/product/"+ x.img,
                price = x.price,
                priceSale = x.priceSale,
                isSale = x.isSale,
                countProduct = x.countProduct,
                idCategory = x.idCategory,
                idBrand= x.idBrand,
                isActive = x.isActive,
                isDelete = x.isDelete,
            }).ToList();
            return rel;
        }

        private string TypeFile(IFormFile file)
        {
            IFormFile fileAdd = file;
            string fileNameRequest = fileAdd.FileName;
            int lenghtFileNameRequest = fileNameRequest.Length;
            int lastIndexOfDot = fileNameRequest.LastIndexOf('.');
            int count_Cut_FrommatFile = lenghtFileNameRequest - lastIndexOfDot;
            string text_Cut_FrommatFile = fileNameRequest.Substring(lastIndexOfDot + 1, count_Cut_FrommatFile - 1);
            return "."+text_Cut_FrommatFile!;
        }
    }
}
