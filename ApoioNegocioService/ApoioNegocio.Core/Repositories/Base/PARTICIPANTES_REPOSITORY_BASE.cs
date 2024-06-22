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

public class PARTICIPANTES_REPOSITORY_BASE : Repository, IPARTICIPANTES_REPOSITORY_BASE
{
    private IDbConnection _connection;

    public async Task<int> DeleteAsync(
        PARTICIPANTES_BASE participantes,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new { idParam = participantes.ID };
            var sql =
                @"DELETE FROM participantes
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
        PARTICIPANTES_BASE participantes,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new
            {
                nomeParam = participantes.NOME,
                dataregistroParam = participantes.DATAREGISTRO,
                datainativacaoParam = participantes.DATAINATIVACAO,
            };
            var sql =
                @"					INSERT INTO participantes
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

    public async Task<IEnumerable<PARTICIPANTES_BASE>> GetAllAsync(
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            var sql = @"SELECT * FROM participantes WHERE DATAINATIVACAO IS NULL";
            using (_connection = Create())
            {
                CommandDefinition command = new(sql, cancellationToken: cancellationToken);
                return await _connection.QueryAsync<PARTICIPANTES_BASE>(command);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PARTICIPANTES_BASE?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new { idParam = id };
            var sql = @"SELECT * FROM participantes WHERE ID = @idParam";
            using (_connection = Create())
            {
                CommandDefinition command =
                    new(sql, parameters, cancellationToken: cancellationToken);
                return await _connection.QuerySingleOrDefaultAsync<PARTICIPANTES_BASE>(command);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> UpdateAsync(
        PARTICIPANTES_BASE participantes,
        CancellationToken cancellationToken = default
    )
    {
        try
        {
            object parameters = new
            {
                idParam = participantes.ID,
                nomeParam = participantes.NOME,
                dataregistroParam = participantes.DATAREGISTRO,
                datainativacaoParam = participantes.DATAINATIVACAO,
            };
            var sql =
                @"					UPDATE participantes SET
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
