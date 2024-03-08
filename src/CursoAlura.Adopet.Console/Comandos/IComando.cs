using FluentResults;

namespace CursoAlura.Adopet.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}
