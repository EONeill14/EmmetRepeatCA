//using EmmetRepeatCA.Models;
//using EmmetRepeatCA.Pages;
//using EmmetRepeatCA.Infrastructure;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Moq;
//using Xunit;

//namespace EmmetRepeatCA.Tests
//{
//    public class CartPageTests
//    {
//        [Fact]
//        public void Can_Add_Item_To_Cart()
//        {
//            // Arrange
//            var vinyl1 = new Vinyl { VinylId = 1, Title = "Vinyl 1", Price = 50m };
//            var vinyl2 = new Vinyl { VinylId = 2, Title = "Vinyl 2", Price = 60m };

//            var mockRepo = new Mock<IStoreRepository>();
//            mockRepo.Setup(m => m.Vinyls).Returns((new Vinyl[] { vinyl1, vinyl2 }).AsQueryable<Vinyl>());

//            var session = new Mock<ISession>();
//            byte[] data = new byte[0];
//            session.Setup(s => s.TryGetValue(It.IsAny<string>(), out data)).Returns(false);
//            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>())).Callback<string, byte[]>((key, val) => { data = val; });

//            var mockContext = new Mock<HttpContext>();
//            mockContext.Setup(c => c.Session).Returns(session.Object);

//            var pageContext = new PageContext
//            {
//                HttpContext = mockContext.Object
//            };

//            var cartModel = new CartModel(mockRepo.Object)
//            {
//                PageContext = pageContext
//            };

//            // Act
//            cartModel.OnPost(vinyl1.VinylId, "/");

//            // Assert
//            Assert.Single(cartModel.Cart.Lines);
//            Assert.Equal("Vinyl 1", cartModel.Cart.Lines.First().Vinyl.Title);
//        }

//        [Fact]
//        public void Can_Remove_Item_From_Cart()
//        {
//            // Arrange
//            var vinyl1 = new Vinyl { VinylId = 1, Title = "Vinyl 1", Price = 50m };
//            var cart = new Cart();
//            cart.AddItem(vinyl1, 1);

//            var mockRepo = new Mock<IStoreRepository>();
//            var session = new Mock<ISession>();
//            byte[] data = new byte[0];
//            session.Setup(s => s.TryGetValue(It.IsAny<string>(), out data)).Returns(false);
//            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>())).Callback<string, byte[]>((key, val) => { data = val; });

//            var mockContext = new Mock<HttpContext>();
//            mockContext.Setup(c => c.Session).Returns(session.Object);

//            var pageContext = new PageContext
//            {
//                HttpContext = mockContext.Object
//            };

//            var cartModel = new CartModel(mockRepo.Object)
//            {
//                PageContext = pageContext,
//                Cart = cart
//            };

//            // Act
//            cartModel.OnPostRemove(vinyl1.VinylId, "/");

//            // Assert
//            Assert.Empty(cartModel.Cart.Lines);
//        }
//    }
//}
