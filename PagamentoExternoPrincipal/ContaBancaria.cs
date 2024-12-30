namespace PagamentoExternoPrincipal
{
    public class ContaBancaria
    {
        public ContaBancaria(string nome, int numeroConta)
        {
            Nome = nome;
            NumeroConta = numeroConta;
        }

        public string Nome { get; set; }
        public int NumeroConta { get; set; }
    }
}
