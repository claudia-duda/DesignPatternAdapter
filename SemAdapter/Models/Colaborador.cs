namespace AdapterPorClasse
{
    public class Colaborador
    {
        public Colaborador( string nome, EArea area)
        {
            Nome = nome;
            Area = area;
        }

        public string Nome { get; set; }
        public EArea Area { get; set; }
    }

    public enum EArea
    {
        RH,
        TI,
        ATENDIMENTO
    }
}
