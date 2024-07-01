using Integration.Core;
using Integration.Core.Data;
using Integration.Core.Model;
using Integration.Core.Shared;
using MySql.Data.MySqlClient;
using System.Text;

namespace Integration.Core.Csv
{
    public class CsvExporter
    {
        public static void ExportToCsv()
        {
            string filePath = @$"{FilePath.PATH}/{Exporter.FILENAME_CSV}";
            try
            {
                Directory.CreateDirectory(FilePath.PATH);
                // Consulta SQL para recuperar todos os registros da tabela "monolito"
                string query = "SELECT * FROM monolito";

                // Lista para armazenar os registros
                List<MonolitoItem> monolitoItens = new List<MonolitoItem>();

                using (MySqlConnection connection = new MySqlConnection(Repository.CONNECTION_STRING))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string genero = reader["genero"].ToString();
                                string categoria = reader["categoria"].ToString();
                                string midia = reader["midia"].ToString();
                                string tipoMidia = reader["tipo_midia"].ToString();
                                int classificacao = Convert.ToInt32(reader["classificacao"]);
                                string participante = reader["participante"].ToString();

                                monolitoItens.Add(new MonolitoItem
                                {
                                    Id = id,
                                    Genero = genero,
                                    Categoria = categoria,
                                    Midia = midia,
                                    TipoMidia = tipoMidia,
                                    Classificacao = classificacao,
                                    Participante = participante
                                });
                            }
                        }
                    }
                }

                // Criando o conteúdo do CSV
                var csvBuilder = new StringBuilder();
                csvBuilder.AppendLine("Id;Genero;Categoria;Midia;TipoMidia;Classificacao;Participante"); // Cabeçalho

                foreach (var item in monolitoItens)
                {
                    var linhaCsv = $"{item.Id};{item.Genero};{item.Categoria};{item.Midia};{item.TipoMidia};{item.Classificacao};{item.Participante}";
                    csvBuilder.AppendLine(linhaCsv);
                }

                // Escrevendo o conteúdo no arquivo
                File.WriteAllText(filePath, csvBuilder.ToString());

                Console.WriteLine($"Arquivo CSV criado em: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar para CSV: {ex.Message}");
            }
        }
    }
}
