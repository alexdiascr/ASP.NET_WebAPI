using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);

        //Trabalhar com métodos especializados para a expressividade do código ficar melhor de 
        //entender
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
