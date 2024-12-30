namespace PagamentoExternoPrincipal
{
    public class SistemaPagamentoExterno
    {
        public bool RealizarTransferencia(ContaBancaria contaBancaria, double valor)
        {
            Console.WriteLine($"Transferencia de R${valor} realizada para a conta bancária com número {contaBancaria.NumeroConta}");
            return true;
        }

    }
}
