using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IGenericRepository<Producto> Repository;
        private readonly IMapper Mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            Repository = productoRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> ListProductos()
        {
            var spec = new ProductoCategoriasMarcasSpecification();
            var productos = await Repository.ListEntity(spec);

            return Ok(Mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDTO>>(productos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto (int id)
        {

            var spec = new ProductoCategoriasMarcasSpecification(id);
            var producto = await Repository.GetEntity(spec);

            return Mapper.Map<Producto, ProductoDTO>(producto);
        }

    }
}
