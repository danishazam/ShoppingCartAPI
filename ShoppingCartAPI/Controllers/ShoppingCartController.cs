using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Commands;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Queries;

namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMediator mediator;
        public ShoppingCartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<List<Product>> GetProductListAsync()
        {
            var products = await mediator.Send(new GetProductListQuery());

            return products;
        }

        // GET api/Products/2
        [HttpGet("productId")]
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await mediator.Send(new GetProductByIdQuery() { Id = productId });

            return product;
        }

        // POST api/Products
        [HttpPost]
        public async Task<Product> AddProductAsync(Product product)
        {
            var newProduct = await mediator.Send(new CreateProductCommand(
                product.Name,
                product.Price));
            return newProduct;
        }

        // PUT api/Products/2
        [HttpPut]
        public async Task<int> UpdateProductAsync(Product product)
        {
            var isProductUpdated = await mediator.Send(new UpdateProductCommand(
               product.Id,
               product.Name,
               product.Price));
            return isProductUpdated;
        }

        // DELETE api/Products/2
        [HttpDelete]
        public async Task<int> DeleteStudentAsync(int Id)
        {
            return await mediator.Send(new DeleteProductCommand() { Id = Id });
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] ShoppingCart shoppingCart)
        {
            bool hasLoyaltyCard = shoppingCart.User.HasLoyaltyCard;
            if (shoppingCart == null || shoppingCart.CartItems.Count == 0)
                return BadRequest("Cart is empty.");

            var itemizedCheckout = new List<object>();
            decimal totalCost = 0m;

            ShoppingCartResult shoppingCartResult = new ShoppingCartResult(0.0m, new List<CheckedOutItem>());

            var productList = await mediator.Send(new GetProductListQuery());
            if (productList == null || productList.Count == 0)
            {
                productList = new List<Product>
                {
                    new Product(1, "Milk", 0.99m),
                    new Product (2, "Bread", 1.49m),
                    new Product (3, "Sugar", 0.80m),
                    new Product (4, "Butter", 1.87m)
                };
            }
            var _products = productList.ToDictionary(key => key.Id, value => value);

            foreach (var item in shoppingCart.CartItems)
            {
                if (!_products.Keys.Contains(item.ProductId))
                    return BadRequest($"Product '{item}' is not available.");

                decimal singleItemPrice = _products[item.ProductId].Price;
                decimal price = _products[item.ProductId].Price * item.Quantity;                
                decimal discount = 0m;

                // Apply promotions for loyalty card holders
                if (hasLoyaltyCard)
                {
                    if (item.ProductId == productList.Where(p => p.Name == "Butter").FirstOrDefault().Id)
                    {                        
                        discount = (((item.Quantity / 2) - (item.Quantity % 2)) + 1) * singleItemPrice;
                    }
                    else if (item.ProductId == productList.Where(p => p.Name == "Sugar").FirstOrDefault().Id)
                    {
                        discount = price * 0.1m;
                    }
                }

                decimal discountedPrice = price - discount;
                shoppingCartResult.TotalCost += discountedPrice;

                shoppingCartResult.CheckedOutItems.Add(new CheckedOutItem(item, price, discount, discountedPrice)
                {
                    CartItem = item,
                    Price = price,
                    Discount = discount,
                    DiscountedPrice = discountedPrice
                });
            }

            return Ok(shoppingCartResult);

            return Ok(new
            {
                ItemizedCheckout = itemizedCheckout,
                TotalCost = totalCost
            });
        }
    }
}
