using Calculator.UI.Core.Models;
using Calculator.UI.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICalculatorRepository calculatorRepository;
        public IEnumerable<Operation> Operations { get; set; } = Enumerable.Empty<Operation>();

        public IndexModel(ICalculatorRepository calculatorRepository)
        {
            this.calculatorRepository = calculatorRepository;
        }

        public async Task OnGet()
        {
            Operations = await calculatorRepository.GetAllAsync();
        }
    }
}
