using ECommerce.Application.Features.Commands.Product.CreateProduct;
using ECommerce.Application.Features.Commands.Product.RemoveProduct;
using ECommerce.Application.Features.Commands.Product.UpdateProduct;
using ECommerce.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ECommerce.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ECommerce.Application.Features.Queries.Product.GetAllProduct;
using ECommerce.Application.Features.Queries.Product.GetByIdProduct;
using ECommerce.Application.Features.Queries.ProductImageFile.GetProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Application.Features.Commands.ProductImageFile.ChangeShowCaseImage;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
           GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

           return Ok(value: response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(value: response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);

            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);

            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            uploadProductImageCommandRequest.Files = Request.Form.Files;

            UploadProductImageCommandResponse response =  await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImageQueryRequest getProductImageQueryRequest)
        {
            List<GetProductImageQueryResponse> response = await _mediator.Send(getProductImageQueryRequest);

            return Ok(value: response);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")] //login olmuş mu bu kullanıcı yetkisi var mı bunu kontrol ederiz. 200 ok. 401 unauthrize 
        public async Task<IActionResult> DeleteProductImage([FromRoute]RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ChangeShowcase([FromQuery] ChangeShowCaseImageCommandRequest changeShowCaseImageCommandRequest)
        {
            ChangeShowCaseImageCommandResponse response=await  _mediator.Send(changeShowCaseImageCommandRequest);
            return Ok(response);
        }

    }
}
