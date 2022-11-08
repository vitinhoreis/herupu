using Herupu.DAL.Context;
using Herupu.DAO.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Herupu.DAO.Repositorios
{
    public class AtividadeItemRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public AtividadeItemRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }

        public IList<AtividadeItem> Listar(int idAtividade)
        {
            return context.AtividadeItem
                .Where(o => o.IdAtividade == idAtividade)
                .ToList();
        }

        public AtividadeItem Consultar(int id)
        {
            return context.AtividadeItem.Find(id);
        }

        public void Inserir(AtividadeItem atividadeItem)
        {
            atividadeItem.IdAtividadeItem = 0;

            context.AtividadeItem.Add(atividadeItem);
            context.SaveChanges();
        }

        public void Alterar(AtividadeItem atividadeItem)
        {
            context.AtividadeItem.Update(atividadeItem);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var AtividadeItem = new AtividadeItem()
            {
                IdAtividadeItem = id
            };

            context.AtividadeItem.Remove(AtividadeItem);
            context.SaveChanges();
        }
    }
}
