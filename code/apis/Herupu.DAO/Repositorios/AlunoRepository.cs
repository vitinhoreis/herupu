using Herupu.DAL.Context;
using Herupu.DAO.Entidades;

namespace Herupu.DAO.Repositorios
{
    public class AlunoRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public AlunoRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<Aluno> Listar()
        {
            return context.Aluno
                .ToList();
        }

        public Aluno Consultar(int id)
        {
            return context.Aluno.Find(id);
        }

        public void Inserir(Aluno aluno)
        {
            aluno.IdAluno = 0;

            context.Aluno.Add(aluno);
            context.SaveChanges();
        }

        public void Alterar(Aluno aluno)
        {
            context.Aluno.Update(aluno);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var aluno = new Aluno()
            {
                 IdAluno = id
            };

            context.Aluno.Remove(aluno);
            context.SaveChanges();
        }
    }
}
