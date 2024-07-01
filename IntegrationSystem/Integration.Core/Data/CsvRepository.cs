using Dapper;
using Integration.Core.Models;
using QuickKit.Cmd;
using QuickKit.Cmd.Enums;
using System.Data;

namespace Integration.Core.Data;

public class CsvRepository : Repository
{
    public static async Task DeletarCsv()
    {
        using (IDbConnection conn = Connect())
        {
                await conn.ExecuteAsync(GetDeleteNoWhereStatement());
        }

    }

    public static async Task InserirAsync(DataModel model)
    {
        try
        {
            var sql =
                @"INSERT INTO monolito(genero, categoria, midia, tipo_midia, classificacao, participante)
            VALUES (@prm_genero, @prm_categoria, @prm_midia, @prm_tipo_midia, @prm_classificacao, @prm_participante)";

            var command = new CommandDefinition(
                sql,
                new
                {
                    @prm_genero = model.GENERO,
                    @prm_categoria = model.CATEGORIA,
                    @prm_midia = model.MIDIA,
                    @prm_tipo_midia = model.TIPO_MIDIA,
                    @prm_classificacao = model.CLASSIFICACAO,
                    @prm_participante = model.PARTICIPANTE
                },
                commandType: CommandType.Text
            );

            using (IDbConnection conn = Connect())
            {
                await conn.ExecuteAsync(command);
            }
        }
        catch (Exception ex)
        {
            Consoler.WriteLine(
                $"um erro ocorreu ao importar os dados. Error: {ex.Message}",
                AlertType.Error
            );
            throw;
        }
    }
}
