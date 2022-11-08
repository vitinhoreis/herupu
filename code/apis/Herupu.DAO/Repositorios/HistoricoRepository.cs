using Herupu.DAL.Context;
using Herupu.DAO.Entidades;

namespace Herupu.DAO.Repositorios
{
    public class HistoricoAlunoRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public HistoricoAlunoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<HistoricoAluno> Listar()
        {
            return context.HistoricoAluno
                .ToList();
        }

        public HistoricoAluno Consultar(int id)
        {
            return context.HistoricoAluno.Find(id);
        }

        public void Inserir(HistoricoAluno historicoAluno)
        {
            historicoAluno.IdHistoricoAluno = 0;

            context.HistoricoAluno.Add(historicoAluno);
            context.SaveChanges();
        }

        public void Alterar(HistoricoAluno historicoAluno)
        {
            context.HistoricoAluno.Update(historicoAluno);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var historicoAluno = new HistoricoAluno()
            {
                 IdHistoricoAluno = id
            };

            context.HistoricoAluno.Remove(historicoAluno);
            context.SaveChanges();
        }
    }
}
