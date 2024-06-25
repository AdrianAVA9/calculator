using Calculator.UI.Core.Models;
using Calculator.UI.Core.Repositories;

namespace Calculator.UI.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private static List<Operation> Operations;
        public CalculatorRepository()
        {
            Operations = new List<Operation>();
        }

        public async Task<Operation> AddAsync(Operation operation)
        {
            operation.Id = Operations.Count + 1;
            await Task.Run(() => Operations.Add(operation));
            return operation;
        }

        public async Task<Operation?> GetAsync(int id)
        {
            return await Task.Run(() => Operations.FirstOrDefault(o => o.Id == id));
        }

        public async Task<IEnumerable<Operation>> GetAllAsync()
        {
            return await Task.Run(() => Operations);
        }
    }
}
