using Dados;
using Dados.Models;
using PagamentoExternoPrincipal;
using SistemaExternoSecundario;

namespace AdapterPorClasse.Services
{
    public class ProcessadorDePagamentoService : IProcessadorDePagamentoService
    {
        private IColaboradorRepository _colaboradorRepository = new ColaboradorRepository();
        private SistemaPagamentoExterno _pagamentoExterno = new SistemaPagamentoExterno(); 
        private SistemaPagamentoExterno2 _pagamentoExternoSecundario = new SistemaPagamentoExterno2();
        public void ProcessarPagamentoSalario(List<Colaborador> colaboradores)
        {
            foreach (Colaborador colaborador in colaboradores)
            {
                Console.WriteLine($"Processando pagamento para o Colaborador: {colaborador.Nome} da área: {colaborador.Area}");
                var conta = _colaboradorRepository.BuscarColaborador(colaborador.Nome, colaborador.Area.ToString());

                if (conta != null)
                {
                    var pagamentoRealizado = ProcessarPagamento(conta);

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
