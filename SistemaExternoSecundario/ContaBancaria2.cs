namespace SistemaExternoSecundario
{
    public class TransferenciaPayload
    {
        public TransferenciaPayload(string nome, int numeroConta, double valor, string tipoTransferencia)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            TipoTransferencia = tipoTransferencia;
            Valor = valor;
        }

        public string Nome { get; set; }
        public int NumeroConta { get; set; }
        public string TipoTransferencia { get; set; }
        public double Valor { get; set; }
    }
}
