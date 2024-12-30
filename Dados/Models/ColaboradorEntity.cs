namespace Dados.Models
{
    public class ColaboradorEntity
    {
        public ColaboradorEntity(int id, string nome, string area, double salario, int contaBancaria)
        {
            Id = id;
            Nome = nome;
            Area = area;
            Salario = salario;
            ContaBancaria = contaBancaria;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public double Salario { get; set; }
        public int ContaBancaria { get; set; }
    }
}
