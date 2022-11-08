
using Herupu.DAL.Context;
using Herupu.DAO.Entidades;

namespace Herupu.DAO.Repositorios
{ 
    public class AtividadeRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public AtividadeRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Atividade> Listar()
        {
            return context.Atividade.ToList();
        }

        public Atividade Consultar(int id)
        {
            return context.Atividade.Find(id);
        }

        public void Inserir(Atividade atividade)
        {
            atividade.IdAtividade = 0;

            context.Atividade.Add(atividade);
            context.SaveChanges();
        }

        public void Alterar(Atividade atividade)
        {
            context.Atividade.Update(atividade);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var atividade = new Atividade()
            {
                IdAtividade = id
            };

            context.Atividade.Remove(atividade);
            context.SaveChanges();
        }
    }
}
