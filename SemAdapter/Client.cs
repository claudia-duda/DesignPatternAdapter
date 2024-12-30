using AdapterPorClasse.Services;

namespace AdapterPorClasse
{
    class Client
    {
        static void Main(string[] args)
        {

            var colaboradoresParaPagamento = new List<Colaborador>
            {
                   new Colaborador("John", EArea.ATENDIMENTO),
                   new Colaborador("Vitoria", EArea.RH),
                   new Colaborador("Fátima", EArea.TI),
                   new Colaborador("Carlos", EArea.ATENDIMENTO),
                   new Colaborador("Jorge", EArea.RH)
            };

            IProcessadorDePagamentoService _salarioService = new ProcessadorDePagamentoService();
            _salarioService.ProcessarPagamentoSalario(colaboradoresParaPagamento);
        }
    }
}