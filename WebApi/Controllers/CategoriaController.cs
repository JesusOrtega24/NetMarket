using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   
    public class CategoriaController : BaseApiController
    {

        private readonly IGenericRepository<Categoria> Repository;

        public CategoriaController(IGenericRepository<Categoria> categoriaRepository)
        {
            Repository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> ListCategorias()
        {
            return Ok(await Repository.List());
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            return Ok(await Repository.Get(id));
        } 
    }
}
