using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class MarcaController : BaseApiController
    {

        private readonly IGenericRepository<Marca> Repository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            Repository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> ListMarcas()
        {
            return Ok(await Repository.List());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            return Ok(await Repository.Get(id));

        }
    }
}
