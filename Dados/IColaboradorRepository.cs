using Dados.Models;

namespace Dados
{
    public interface IColaboradorRepository
    {
        public List<ColaboradorEntity> ObterColaboradores();
        public ColaboradorEntity BuscarColaborador(string nome, string area);
    }
}
