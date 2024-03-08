using FluentResults;

namespace CursoAlura.Adopet.Console.Comandos;
public interface IDepoisDaExecucao
{
    event Action<Result>? DepoisDaExecucao;
}
