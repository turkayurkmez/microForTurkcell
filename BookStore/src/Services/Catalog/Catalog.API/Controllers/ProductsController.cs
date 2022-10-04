using Catalog.Application;
using MassTransit;
using MessagesAndEvents;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBookService productService;
        private readonly IPublishEndpoint publishEndpoint;

        public ProductsController(IBookService productService, IPublishEndpoint publishEndpoint)
        {
            this.productService = productService;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(productService.GetBooks());
        }

        [Route("[action]")]
        [HttpGet("{id}")]
        public IActionResult AddProductToBasket(int id, string userId)
        {
            var addedBook = productService.GetBook(id);
            //asenkron iletişim
            //RabbitMQ Docker kurulumu
            //docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management
            //bu metot; Basket microservice'ine AddBookToBasketRequest mesajını iletir. 
            AddBookToBasketRequest addBookToBasketRequest = new AddBookToBasketRequest
            {
                BookId = addedBook.Id,
                Description = addedBook.Description,
                Name = addedBook.Name,
                Price = addedBook.Price,
                Quantity = 1,
                UserId = userId

            };

            publishEndpoint.Publish(addBookToBasketRequest);
            return Ok();
        }


    }
}
