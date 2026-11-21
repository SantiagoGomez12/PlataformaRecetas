using Microsoft.AspNetCore.Mvc;
using PlataformaRecetas.Models;

namespace PlataformaRecetas.Controllers
{
    public class RecetasController : Controller
    {
        private static List<Receta> recetas = new List<Receta>
        {
            new Receta
                        {
                            Id = 1,
                            Nombre = "Arroz con pollo",
                            Categoria = "Almuerzo",
                            Ingredientes = "Arroz, pollo, zanahoria, arvejas y cebolla.",
                            Preparacion = "Cocinar el pollo, agregar las verduras y el arroz. Dejar cocinar hasta que esté listo."
                        },

                    new Receta
                    {
                        Id = 2,
                        Nombre = "Torta de chocolate",
                        Categoria = "Postre",
                        Ingredientes = "Harina, chocolate, huevos, azúcar y leche.",
                        Preparacion = "Mezclar los ingredientes, colocar en un molde y hornear hasta que esté lista."
                    },

                        new Receta
                        {
                            Id = 3,
                            Nombre = "Huevos revueltos",
                            Categoria = "Desayuno",
                            Ingredientes = "Huevos, sal, mantequilla y tomate.",
                            Preparacion = "Batir los huevos y cocinarlos en una sartén con mantequilla y tomate."
                        },

                    new Receta
                    {
                        Id = 4,
                        Nombre = "Ensalada de frutas",
                        Categoria = "Postre",
                        Ingredientes = "Banano, manzana, papaya, fresas y crema de leche.",
                        Preparacion = "Cortar las frutas en trozos, mezclarlas y agregar la crema de leche."
                    },

                        new Receta
                        {
                            Id = 5,
                            Nombre = "Pasta con pollo",
                            Categoria = "Almuerzo",
                            Ingredientes = "Pasta, pollo, tomate, cebolla y queso.",
                            Preparacion = "Cocinar la pasta y el pollo. Preparar la salsa con tomate y cebolla y mezclar."
                        }
        };

        public IActionResult Index(string busqueda, string categoria)
        {
            List<Receta> recetasMostrar = new List<Receta>();

            foreach (var receta in recetas)
                {
                    bool coincideBusqueda = true;
                    bool coincideCategoria = true;

                        if (!string.IsNullOrWhiteSpace(busqueda))
                        {
                            coincideBusqueda =
                                receta.Nombre.ToLower().Contains(busqueda.ToLower()) ||
                                receta.Ingredientes.ToLower().Contains(busqueda.ToLower());
                        }

                        if (!string.IsNullOrWhiteSpace(categoria))
                        {
                            coincideCategoria = receta.Categoria == categoria;
                        }

                        if (coincideBusqueda && coincideCategoria)
                        {
                            recetasMostrar.Add(receta);
                        }
            }

            ViewBag.Busqueda = busqueda; 
            ViewBag.Categoria = categoria;

            return View("~/Views/Home/Index.cshtml", recetasMostrar);
        }

        [HttpPost]
        public IActionResult Favorito(int id)
        {
            foreach (var receta in recetas)
            {
                if (receta.Id == id)
                {
                    receta.Favorita = !receta.Favorita;
                }
            }

            return RedirectToAction("Index");
        }
    }
}
