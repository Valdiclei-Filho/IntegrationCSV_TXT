﻿using Core.Data;
using Core.Model;
using MySql.Data.MySqlClient; // Certifique-se de adicionar a referência ao assembly MySql.Data
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Csv
{
    public class CsvExporter
    {
        private readonly string connectionString; // Configuração de conexão com o banco de dados

        public CsvExporter(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExportToCsv(string filePath)
        {
            try
            {
                // Consulta SQL para recuperar todos os registros da tabela "monolito"
                string query = "SELECT * FROM monolito";

                // Lista para armazenar os registros
                List<MonolitoItem> monolitoItens = new List<MonolitoItem>();

                using (MySqlConnection connection = new MySqlConnection(Repository.CONNECTION_STRING_V))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string genero = reader["genero"].ToString();
                                string categoria = reader["categoria"].ToString();
                                string midia = reader["midia"].ToString();
                                string tipoMidia = reader["tipo_midia"].ToString();
                                int classificacao = Convert.ToInt32(reader["classificacao"]);
                                string participante = reader["participante"].ToString();

                                int tamanhoMaximoGenero = 20; 
                                genero = genero.PadRight(tamanhoMaximoGenero);

                                int tamanhoMaximoCategoria = 50; 
                                categoria = categoria.PadRight(tamanhoMaximoCategoria);

                                int tamanhoMaximoMidia = 50; 
                                midia = midia.PadRight(tamanhoMaximoMidia);

                                int tamanhoMaximoTipoMidia = 50; 
                                tipoMidia = tipoMidia.PadRight(tamanhoMaximoTipoMidia);
                                
                                int tamanhoMaximoClassificacao= 50; 
                                tipoMidia = tipoMidia.PadRight(tamanhoMaximoClassificacao);
                                
                                int tamanhoMaximoParticipante = 100; 
                                tipoMidia = tipoMidia.PadRight(tamanhoMaximoParticipante);

                                monolitoItens.Add(new MonolitoItem
                                {
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
                csvBuilder.AppendLine("Genero,Categoria,Midia,TipoMidia,Classificacao,Participante"); // Cabeçalho

                foreach (var item in monolitoItens)
                {
                    var linhaCsv = $"{item.Genero},{item.Categoria},{item.Midia},{item.TipoMidia},{item.Classificacao},{item.Participante}";
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

