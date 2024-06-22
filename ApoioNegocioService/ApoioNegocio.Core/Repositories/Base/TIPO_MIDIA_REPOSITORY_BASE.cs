using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ApoioNegocio.Core.Entities.Base;
using ApoioNegocio.Core.Repositories.Base.Interfaces;
using ApoioNegocio.Core.Repositories.Shared;
using Dapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;

// File Auto Generated. DOT NOT MODIFY
namespace ApoioNegocio.Core.Repositories.Base;

public class TIPO_MIDIA_REPOSITORY_BASE : Repository, ITIPO_MIDIA_REPOSITORY_BASE
{
    private IDbConnection _connection;

    public async Task<int> DeleteAsync(
        TIPO_MIDIA_BASE tipo_midia,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new { idParam = tipo_midia.ID };
            var sql =
                @"DELETE FROM tipo_midia
WHERE ID = @idParam
";
            using (_connection = Create())
            {
                CommandDefinition command =
                    new(sql, parameters, cancellationToken: cancellationToken);
                var affectedRows = await _connection.ExecuteAsync(command);

                return affectedRows;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> InsertAsync(
        TIPO_MIDIA_BASE tipo_midia,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new
            {
                nomeParam = tipo_midia.NOME,
                dataregistroParam = tipo_midia.DATAREGISTRO,
                datainativacaoParam = tipo_midia.DATAINATIVACAO,
            };
            var sql =
                @"					INSERT INTO tipo_midia
					(
					NOME
					,DATAREGISTRO
					,DATAINATIVACAO
					)
					VALUES
					(
					@nomeParam
					,@dataregistroParam
					,@datainativacaoParam
					)
";
            using (_connection = Create())
            {
                CommandDefinition command =
                    new(sql, parameters, cancellationToken: cancellationToken);
                var affectedRows = await _connection.ExecuteAsync(command);

                return affectedRows;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<TIPO_MIDIA_BASE>> GetAllAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var sql = @"SELECT * FROM tipo_midia WHERE DATAINATIVACAO IS NULL";
            using (_connection = Create())
            {
                CommandDefinition command = new(sql, cancellationToken: cancellationToken);
                return await _connection.QueryAsync<TIPO_MIDIA_BASE>(command);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<TIPO_MIDIA_BASE?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new { idParam = id };
            var sql = @"SELECT * FROM tipo_midia WHERE ID = @idParam";
            using (_connection = Create())
            {
                CommandDefinition command =
                    new(sql, parameters, cancellationToken: cancellationToken);
                return await _connection.QuerySingleOrDefaultAsync<TIPO_MIDIA_BASE>(command);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> UpdateAsync(
        TIPO_MIDIA_BASE tipo_midia,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new
            {
                idParam = tipo_midia.ID,
                nomeParam = tipo_midia.NOME,
                dataregistroParam = tipo_midia.DATAREGISTRO,
                datainativacaoParam = tipo_midia.DATAINATIVACAO,
            };
            var sql =
                @"					UPDATE tipo_midia SET
                    NOME = @nomeParam
                    ,DATAREGISTRO = @dataregistroParam
                    ,DATAINATIVACAO = @datainativacaoParam
                     WHERE ID = @idParam;
";
            using (_connection = Create())
            {
                CommandDefinition command =
                    new(sql, parameters, cancellationToken: cancellationToken);
                var affectedRows = await _connection.ExecuteAsync(command);

                return affectedRows;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
