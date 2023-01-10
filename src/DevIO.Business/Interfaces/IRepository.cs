using DevIO.Business.Models;
using System.Linq.Expressions;

namespace DevIO.Business.Interfaces
{
    //Repositório generico Serve para qualquer entidade
    //Por quê ele está na camada de negócios? 
    // - Porque a camada de negócios não vai conhecer a camada de acesso a dados 
    //Quem vai conhecer a camada de negócios é acesso a dados
    // Única maneira de a camada de negócios conversar com a camada de acesso a dados é 
    // através dessa interface que será injetada por injeção de dependência 

    //IRepository<TEntity> => TEntity gênerico
    //IDisosable => Interface IDisposable obriga que a interface Repository faça o disposable para que libere memória
    //where TEntity : Entity => específica que o TEntity passado só pode ser utilizada se for filha de Entity
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        //Trabalhar desde sempre com métodos assíncronos para garantir melhor performace
        //para aplicação e para melhor saúde do servidor
        
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity obj);
        Task Remover(Guid id);

        //Dentro do método buscar está se possbilitando passar uma expressão lambda
        //para buscar qualquer entidade por qualquer parâmetro 
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        //Retorna o número de linhas afetadas. 
        Task<int> SaveChanges();
    }
}
