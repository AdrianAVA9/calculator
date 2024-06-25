using Calculator.UI.Core.Models;

namespace Calculator.UI.Core.Repositories
{
    public interface ICalculatorRepository
    {
        Task<Operation> AddAsync(Operation operation);
        Task<Operation?> GetAsync(int id);
        Task<IEnumerable<Operation>> GetAllAsync();
    }
}
