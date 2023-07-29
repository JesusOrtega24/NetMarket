using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoForCountingSpecification : BaseSpecification<Producto>
    {

        public ProductoForCountingSpecification(ProductoSpecificationParams ProductoParams)
           : base(x =>
                (string.IsNullOrEmpty(ProductoParams.Search) || x.Nombre.Contains(ProductoParams.Search)) &&
                (!ProductoParams.Marca.HasValue || x.MarcaId == ProductoParams.Marca) &&
                (!ProductoParams.Categoria.HasValue || x.CategoriaId == ProductoParams.Categoria)
           )
        {

        }



    }
}
