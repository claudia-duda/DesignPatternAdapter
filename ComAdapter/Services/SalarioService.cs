using AdapterPorClasse;
using AdapterPorClasse.Adapters;
using Dados;
using Models;

namespace Services
{
    public class SalarioService : ISalarioService
    {
        private IPagamentoAdapter _pagamentoAdapter = new PagamentoAdapter();
        private IColaboradorRepository _colaboradorRepository = new ColaboradorRepository();

        public void ProcessarPagamentoSalario(List<Colaborador> colaboradores)
        {
            foreach (Colaborador colaborador in colaboradores)
            {
                Console.WriteLine($"Processando pagamento para o Colaborador: {colaborador.Nome} da área: {colaborador.Area}");
                var conta = _colaboradorRepository.BuscarColaborador(colaborador.Nome, colaborador.Area.ToString());

                if (conta != null)
                {
                    var pagamentoRealizado = _pagamentoAdapter.ProcessarPagamento(conta);

                    if (pagamentoRealizado)
                    {
                        Console.WriteLine("Transferencia realizada com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Colaborador não foi encontrado");
                    }
                }                    
            }
        }
    }
}
