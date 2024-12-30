using Models;

namespace Services
{
    internal interface ISalarioService
    {
        public void ProcessarPagamentoSalario(List<Colaborador> colaboradores);
    }
}

