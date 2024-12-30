using Dados.Models;
using Models;

namespace AdapterPorClasse.Adapters
{
    public interface IPagamentoAdapter
    {
        bool ProcessarPagamento(ColaboradorEntity colaborador);
    }
}
