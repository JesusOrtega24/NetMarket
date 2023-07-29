using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoCategoriasMarcasSpecification : BaseSpecification<Producto>
    {

        public ProductoCategoriasMarcasSpecification(ProductoSpecificationParams ProductoParams) 
            : base(x => 
                (string.IsNullOrEmpty(ProductoParams.Search) || x.Nombre.Contains(ProductoParams.Search)) &&
                (!ProductoParams.Marca.HasValue || x.MarcaId == ProductoParams.Marca) &&
                (!ProductoParams.Categoria.HasValue || x.CategoriaId == ProductoParams.Categoria)
            )
                        
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);

            ApplyPaging(ProductoParams.PageSize * (ProductoParams.PageIndex - 1), ProductoParams.PageSize);


            if (!string.IsNullOrEmpty(ProductoParams.Sort))
            {
                switch (ProductoParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDesc(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDesc(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDesc(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;

                }
            }
        }

        public ProductoCategoriasMarcasSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }

    }
}
