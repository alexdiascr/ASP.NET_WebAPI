using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        //Retorna uma lista de produtos por fornecedor
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);

        //Obter uma lista de produtos e fornecedores daquele produto
        // - Para ter produtos com informação do fornecedor
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedores();

        //Retorna um produto e o fornecedor dele - Id do produto
        Task<Produto> ObterProdutoFornecedor(Guid Id);
    }
}
