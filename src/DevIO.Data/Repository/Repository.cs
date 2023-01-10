using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DevIO.Data.Repository
{
    //Uma vez implementada o contrado, tem que implementar todos os métodos do 
    //contrato
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //Para ter acesso a esse conty exto
        //Por que protected - Porque tanto o Repository quanto quem herdar de repository 
        //Vai poder ter acesso ao DbContext
        protected readonly MeuDbContext? Db;

        //Seria espécie de atalho
        protected readonly DbSet<TEntity> DbSet;


        //protected readonly MeuDbContext Db;
        //protected readonly DbSet<TEntity> DbSet;

        public Repository(MeuDbContext db)
        {
            Db = db;
            DbSet= db.Set<TEntity>();
        }

        //devolver uma consulta usando um predicate
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            //O que é Tracking do EF? 
            //Toda vez que se coloca alguma coisa na memória, começasse a se fazer o tracking(Rastrear), 
            //para perceber mudança de estado. Mas se faz a leitura do objeto sem intenção de devolver para
            //base, apenas por ler, ele fica no Tracking, ou seja, gasta mais da memória, pouca mais onerosa.  
            //Então se usa o AsNoTracking, retorna a resposta do banco, agora com mais performace 
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            //Db.Set<TEntity>().Add(entity);
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }    
    }
}
