using Models;
using Services;

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

            ISalarioService _salarioService = new SalarioService();
            _salarioService.ProcessarPagamentoSalario(colaboradoresParaPagamento);
        }
    }
}