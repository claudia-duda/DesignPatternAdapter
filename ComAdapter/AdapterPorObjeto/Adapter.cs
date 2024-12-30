using AdapterPorClasse.Adapters;
using Dados.Models;
using PagamentoExternoPrincipal;
using SistemaExternoSecundario;

namespace AdapterPorObjeto
{
    public class PagamentoAdapter2 : IPagamentoAdapter
    {
        private SistemaPagamentoExterno _pagamentoExterno = new SistemaPagamentoExterno(); // Um possível uso
        private SistemaPagamentoExterno2 _pagamentoExternoSecundario = new SistemaPagamentoExterno2(); // Um possível uso

        public bool ProcessarPagamento(ColaboradorEntity colaborador)
        {
           
            var (resultadoTransferencia, erroExterno) = RealizarTransferenciaPrincipal(colaborador);
            if (erroExterno)
            {
                var (resultado, erroExterno2) = RealizarTransferenciaSecundaria(colaborador);
                if (erroExterno2)
                {
                    Console.WriteLine("Transferência não realizada por erro nos parceiros");
                    return false;
                }

                return resultado;
            }

            return resultadoTransferencia;
        }

        private (bool transferenciaRealizada, bool sistemaExternoFuncionando) RealizarTransferenciaPrincipal(ColaboradorEntity contaParaConverter)
        {
            try
            {
                var conta = new ContaBancaria(contaParaConverter.Nome, contaParaConverter.ContaBancaria);

                var pagamentoRealizado = _pagamentoExterno.RealizarTransferencia(conta, contaParaConverter.Salario); //Forma de realizar a chamada
                return (true, pagamentoRealizado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao transferir utilizando o serviço externo {nameof(SistemaPagamentoExterno)}");
                return (false, false);
            }
        }

        private (bool transferenciaRealizada, bool sistemaExternoFuncionando) RealizarTransferenciaSecundaria(ColaboradorEntity contaParaConverter)
        {
            try
            {
                var payload = new TransferenciaPayload(contaParaConverter.Nome, contaParaConverter.ContaBancaria, contaParaConverter.ContaBancaria, "PIX");

                var transferenciaRealizada = _pagamentoExternoSecundario.RealizarTransferencia(payload); //Forma de realizar a chamada
                return (transferenciaRealizada, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao transferir utilizando o serviço externo {nameof(SistemaPagamentoExterno)}");
                return (false, false);
            }
        }

    }
}
