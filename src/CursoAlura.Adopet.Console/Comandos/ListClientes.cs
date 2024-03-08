using CursoAlura.Adopet.Console.Atributos;
using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Results;
using CursoAlura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace CursoAlura.Adopet.Console.Comandos;

[DocComando(instrucao: "list-clientes", 
    documentacao: "adopet list-clientes comando que exibe no" +
    " terminal o conteúdo de clientes na base de dados da AdoPet.")]
public class ListClientes : IComando
{
    private readonly IApiService<Cliente> service;

    public ListClientes(IApiService<Cliente> service)
    {
        this.service = service;
    }
    public async Task<Result> ExecutarAsync()
    {
        try
        {
            IEnumerable<Cliente>? clientes = await service.ListAsync();
            return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Clientess realizada com sucesso!"));
        }
        catch (Exception exception)
        {

            return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
        }
    }
}
