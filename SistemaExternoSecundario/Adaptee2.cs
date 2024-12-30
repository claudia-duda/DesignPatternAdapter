namespace SistemaExternoSecundario
{
    public class SistemaPagamentoExterno2
    {
        public bool RealizarTransferencia(TransferenciaPayload payload)
        {
            Console.WriteLine($"Transferencia de R${payload.Valor} realizada para a conta bancária com número {payload.NumeroConta} enviada por {payload.TipoTransferencia}");
            return true;
        }

    }
}
