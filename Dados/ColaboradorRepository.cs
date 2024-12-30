using Dados.Models;
using System.Text.Json;

namespace Dados
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly string _caminhoArquivo;

        public ColaboradorRepository()
        {
            _caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "Database", "Colaboradores.json");

            if (!File.Exists(_caminhoArquivo))
            {
                throw new FileNotFoundException($"O arquivo {_caminhoArquivo} não foi encontrado.");
            }
        }

        public List<ColaboradorEntity> ObterColaboradores()
        {
            var conteudoJson = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<ColaboradorEntity>>(conteudoJson);
        }

        public ColaboradorEntity BuscarColaborador(string nome, string area)
        {
            var colaboradores = ObterColaboradores();
            return colaboradores.FirstOrDefault(c => c.Area == area && c.Nome == nome);
        }
    }
}
