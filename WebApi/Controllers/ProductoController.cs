using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {

        private readonly IGenericRepository<Producto> Repository;
        private readonly IMapper Mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            Repository = productoRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductoDTO>>> ListProductos([FromQuery]ProductoSpecificationParams ProductoParams)
        {
            var spec = new ProductoCategoriasMarcasSpecification(ProductoParams);
            var productos = await Repository.ListEntity(spec);
            var specCount = new ProductoForCountingSpecification(ProductoParams);
            var totalProductos = await Repository.CountAsync(specCount);
            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / ProductoParams.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = Mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDTO>>(productos);

            return Ok(
                
                new Pagination<ProductoDTO>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = ProductoParams.PageIndex,
                    PageSize = ProductoParams.PageSize
                }

                );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto (int id)
        {

            var spec = new ProductoCategoriasMarcasSpecification(id);
            var producto = await Repository.GetEntity(spec);

            if(producto == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            return Mapper.Map<Producto, ProductoDTO>(producto);
        }

    }
}
