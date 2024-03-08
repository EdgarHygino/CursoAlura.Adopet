using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Atributos;
using CursoAlura.Adopet.Console.Results;
using FluentResults;
using CursoAlura.Adopet.Console.Servicos.Abstracoes;

namespace CursoAlura.Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "list",
      documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List: IComando
    {
        private readonly IApiService<Pet> clientPet;

        public List(IApiService<Pet> clientPet)
        {
            this.clientPet = clientPet;
        }

        public Task<Result> ExecutarAsync()
        {
            return this.ListaDadosPetsDaAPIAsync();
        }

        private async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListAsync();               
                return Result.Ok().WithSuccess(new SuccessWithPets(pets,"Listagem de Pet's realizada com sucesso!"));
            }
            catch (Exception exception)
            {

                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }

        }

    }
}
