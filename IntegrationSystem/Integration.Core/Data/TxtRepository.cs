using System;
using System.Data;
using Dapper;
using Integration.Core.Models;
using QuickKit.Cmd;
using QuickKit.Cmd.Enums;

namespace Integration.Core.Data;

internal class TxtRepository : Repository
{
    public static Task<IEnumerable<DataModel>> ExportAll()
    {
        try
        {
            var sql = "SELECT * FROM monolito";
            using (var conn = Connect())
            {
                return conn.QueryAsync<DataModel>(sql);
            }
        }
        catch (Exception ex)
        {
            Consoler.WriteLine(
                $"um erro ocorreu ao exportar os dados. Error: {ex.Message}",
                AlertType.Error
            );
            throw;
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
                    @prm_genero = model.GENERO.Trim(),
                    @prm_categoria = model.CATEGORIA.Trim(),
                    @prm_midia = model.MIDIA.Trim(),
                    @prm_tipo_midia = model.TIPO_MIDIA.Trim(),
                    @prm_classificacao = model.CLASSIFICACAO.Trim(),
                    @prm_participante = model.PARTICIPANTE.Trim()
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
