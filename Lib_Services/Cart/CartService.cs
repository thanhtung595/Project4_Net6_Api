using Lib_DatabaseEntity.Repository;
using Lib_Models.Model_Entities;
using Lib_Models.Model_Get;
using Lib_Models.Model_Post;
using Lib_Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IJwtService _jwtService;
        private readonly IRepository<CartEntity> _cartRepository;
        public CartService(IJwtService jwtService, IRepository<CartEntity> cartRepository)
        {
            _jwtService = jwtService;
            _cartRepository = cartRepository;
        }

        public async Task Add(CartAdd_Post cartAdd)
        {
            int idAccount = await _jwtService.GetIdAccount();
            var cartTonTai = await _cartRepository.GetAll(x => x.idProduct == cartAdd.idProduct && x.idAccount == idAccount);
            if (cartTonTai.Any())
            {
                cartTonTai.First().count += 1;
            }
            else
            {
                CartEntity cartEntity = new CartEntity
                {
                    count = 1,
                    priceTotal = 0,
                    idAccount = idAccount,
                    idProduct = cartAdd.idProduct,
                    isActive = true,
                    timeCreate = DateTime.Now
                };
                await _cartRepository.Insert(cartEntity);
            }
            await _cartRepository.Commit();
        }

        public async Task Delete(int id)
        {
            var cart = await _cartRepository.GetById(id);
            _cartRepository.Delete(cart);
            await _cartRepository.Commit();
        }

        public async Task<List<CartGetAll>> GetAll()
        {
            int idAccount = await _jwtService.GetIdAccount();
            var data = await _cartRepository.GetAllIncluding(x => x.idAccount == idAccount , x => x.Product!);
            var dataRl = data.Select(x => new CartGetAll
            {
                id = x.id,
                idProduct = x.Product!.id,
                nameProduct = x.Product.name,
                imgProduct = "img/product/"+x.Product.img,
                count = x.count,
                priceProduct = x.Product.priceSale,
                priceTotal = x.count * x.Product.priceSale,
                isActive = x.isActive,
                timeCreate = x.timeCreate
            }).ToList();
            return dataRl;
        }
        public async Task Update(CartModel_Update cart)
        {
            var cartUpdate = await _cartRepository.GetById(cart.id);
            cartUpdate.count = cart.count;
            _cartRepository.Update(cartUpdate);
            await _cartRepository.Commit();
        }
    }
}
