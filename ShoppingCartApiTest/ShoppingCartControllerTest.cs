using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingCartAPI.Commands;
using ShoppingCartAPI.Controllers;
using ShoppingCartAPI.Handlers;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repositories;

namespace ShoppingCartApiTest
{
    public class ShoppingCartControllerTest
    {        
        [Fact]
        public async Task CreateShoppingCart_ReturnsDiscoutAndTotalValue()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            var controller = new ShoppingCartController(mockMediator.Object);

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.User = new User();
            shoppingCart.User.UserName = "test user";
            shoppingCart.User.HasLoyaltyCard = true;
            shoppingCart.CartItems = new List<CartItem>();
            var cartItem1 = new CartItem();
            cartItem1.ProductId = 1;
            cartItem1.Quantity = 5;
            shoppingCart.CartItems.Add(cartItem1);
            var cartItem2 = new CartItem();
            cartItem2.ProductId = 2;
            cartItem2.Quantity = 3;
            shoppingCart.CartItems.Add(cartItem2);
            var cartItem3 = new CartItem();
            cartItem3.ProductId = 3;
            cartItem3.Quantity = 4;
            shoppingCart.CartItems.Add(cartItem3);
            var cartItem4 = new CartItem();
            cartItem4.ProductId = 4;
            cartItem4.Quantity = 2;
            shoppingCart.CartItems.Add(cartItem4);

            // Act
            var result = await controller.Checkout(shoppingCart);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(12.30m, ((ShoppingCartResult)okResult.Value).TotalCost);             
        }
    }
}