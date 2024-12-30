using AdapterPorClasse.Adapters;
using Dados.Models;
using PagamentoExternoPrincipal;

namespace AdapterPorClasse
{
    public class PagamentoAdapter : SistemaPagamentoExterno, IPagamentoAdapter
    {
        public bool ProcessarPagamento(ColaboradorEntity colaborador)
        {

            var (resultadoTransferencia, erroExterno) = RealizarTransferencia(colaborador);
            if (erroExterno)
            {
                Console.WriteLine("Transferência não realizada por erro nos parceiros");
                return false;
            }

            return resultadoTransferencia;
        }
        private (bool transferenciaRealizada, bool sistemaExternoFuncionando) RealizarTransferencia(ColaboradorEntity contaParaConverter)
        {
            try
            {
                var conta = new ContaBancaria(contaParaConverter.Nome, contaParaConverter.ContaBancaria);

                var pagamentoRealizado = RealizarTransferencia(conta, contaParaConverter.Salario); //Forma de realizar a chamada
                return (true, pagamentoRealizado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao transferir utilizando o serviço externo {nameof(SistemaPagamentoExterno)}");
                return (false, false);
            }
        }

    }
}
