using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ContosoPizza.Pages
{
    [BindProperties]
    public class PizzaListModel : PageModel
    {

        private readonly PizzaService pizzaService;

        public IList<Pizza> ListPizza { get; set; } = default!;

        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService _servPizza)
        {
            this.pizzaService = _servPizza;
        }
        public void OnGet()
        {

            ListPizza = pizzaService.GetPizzas();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }
            this.pizzaService.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }
    }
}
