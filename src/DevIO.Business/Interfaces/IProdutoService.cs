using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto fonecedor);

        Task Atualizar(Produto fonecedor);
        Task Remover(Guid id);
    }
}
