using SMOS.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SMOS.Infra.Repositorio
{
    public class Repositorio<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        protected BalancaIOContext Db = new BalancaIOContext();

        public int TotalRegistros(TEntity entidadeEntity)
        {
            return Db.Set<TEntity>().Count();
        }

        public IList<TEntity> ObterTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> ObterTodosLazyLoad()
        {
            Db.Configuration.LazyLoadingEnabled = false;
            return Db.Set<TEntity>().ToList();
        }

        public IList<TEntity> ObterTodosOrdenacaoAscendente(string campo)
        {
            throw new NotImplementedException();
        }

        public IList<TEntity> ObterTodosOrdenacaoDescendente(string campo)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }
        public virtual TEntity ObterPorNome(string campo)
        {
            return Db.Set<TEntity>().Find(campo);
        }
        public virtual TEntity ObterPorIdLazyLoad(int id)
        {
            Db.Configuration.LazyLoadingEnabled = false;
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity ObterPorId(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void ExcluirPorId(int id)
        {
            var entidade = Db.Set<TEntity>().Find(id);
            Db.Set<TEntity>().Remove(entidade);
            Db.SaveChanges();
        }

        public virtual void Excluir(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Remove(entidadeEntity);
            Db.SaveChanges();
        }

        public virtual void Salvar(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            Db.SaveChanges();
        }

        public void SalvarLista(IList<TEntity> entidadeEntity)
        {
            foreach (var Entity in entidadeEntity)
            {
                Db.Set<TEntity>().Add(Entity);
            }
            Db.SaveChanges();
        }

        public virtual void Atualiza(TEntity entidadeEntity)
        {
            Db.Entry(entidadeEntity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void AtualizaLista(IList<TEntity> entidadesEntity)
        {
            foreach (var Entity in entidadesEntity)
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }

            Db.SaveChanges();
        }
        public IList<TEntity> PesquisarParametros(Expression<Func<TEntity, bool>> parametros)
        {
            return Db.Set<TEntity>().Where(parametros).ToList();
        }

        public void Atualizar(TEntity entity)
        {
            Db.Set<TEntity>().AddOrUpdate(entity);
            Db.SaveChanges();
        }
        public virtual async Task<string> SalvarAsync(TEntity entidadeEntity)
        {
            Db.Set<TEntity>().Add(entidadeEntity);
            await Db.SaveChangesAsync();
            return "Entidade adicionada com sucesso";
        }
        public void Dispose()
        {
            Db.Dispose();
        }


        int IRepositorio<TEntity>.TotalRegistros(TEntity countEntity)
        {
            throw new NotImplementedException();
        }

        IList<TEntity> IRepositorio<TEntity>.ObterTodos()
        {
            throw new NotImplementedException();
        }

        IList<TEntity> IRepositorio<TEntity>.ObterTodosOrdenacaoAscendente(string campo)
        {
            throw new NotImplementedException();
        }

        IList<TEntity> IRepositorio<TEntity>.ObterTodosOrdenacaoDescendente(string campo)
        {
            throw new NotImplementedException();
        }

        TEntity IRepositorio<TEntity>.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        TEntity IRepositorio<TEntity>.ObterPorId(string id)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.ExcluirPorId(int id)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.Excluir(TEntity entidadeEntity)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.Dispose()
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.Salvar(TEntity entidadeEntity)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.SalvarLista(IList<TEntity> entidadeEntity)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.Atualiza(TEntity entidadeEntity)
        {
            throw new NotImplementedException();
        }

        void IRepositorio<TEntity>.AtualizaLista(IList<TEntity> entidadesEntity)
        {
            throw new NotImplementedException();
        }

    }
}
