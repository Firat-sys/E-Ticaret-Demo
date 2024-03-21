//using ETicaretApplication.Abstraction;
using Azure;
using ETicaretApi_Domain.Entitys;
using ETicaretApplication.Abstraction.Storage;
using ETicaretApplication.Features.Commands.Product.CreateProduct;
using ETicaretApplication.Features.Commands.Product.RemoveProduct;
using ETicaretApplication.Features.Commands.Product.UpdateProduct;
using ETicaretApplication.Features.Commands.ProductImageFile.RemoveProductImage;
using ETicaretApplication.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretApplication.Features.Queries.Product.GetAllProduct;
using ETicaretApplication.Features.Queries.Product.GetByIdProduct;
using ETicaretApplication.Features.Queries.ProductImageFile;
using ETicaretApplication.Repositories;
using ETicaretApplication.Repositories.File;
using ETicaretApplication.Repositories.Invoice;
using ETicaretApplication.Repositories.ProductImageFile;
using ETicaretApplication.Request_Parameters;
//using ETicaretApplication.Services;
using ETicaretApplication.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretAPI_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ProductsController : ControllerBase
    {
       
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
          
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response=await _mediator.Send(getByIdProductQueryRequest);

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {

            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }


        //[Authorize(AuthenticationSchemes = "Admin")]
        //  [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest productImageCommandRequest)
        {

            productImageCommandRequest.Files = Request.Form.Files;
            await _mediator.Send(productImageCommandRequest);
            //List<(string fileName, string pathOrContinerName)> results = await _storageService.UploadAsync("photo-images", Request.Form.Files);
            //Product product = await _productReadRepository.GetByIdAsync(id);

            //await _productImageWriteRepository.AddRangeAsync(results.Select(r => new ProductImageFile
            //{
            //    Name = r.fileName,
            //    Storage = _storageService.StorageName,
            //    Path = r.pathOrContinerName,
            //    Products = new List<Product>() { product }
            //}).ToList());
            //await _productImageWriteRepository.SaveAsync();
         


            return Ok();
        }


        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
            return Ok();
          
        }

    }
}
