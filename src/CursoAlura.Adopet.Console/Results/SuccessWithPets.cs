using CursoAlura.Adopet.Console.Modelos;
using FluentResults;

namespace CursoAlura.Adopet.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }
    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}
