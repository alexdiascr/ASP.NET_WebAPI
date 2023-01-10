using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        //Obter endereço do fornecedor
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
