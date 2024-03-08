namespace CursoAlura.Adopet.Console.Servicos.Abstracoes;
public interface ILeitorDeArquivos<T>
{
    IEnumerable<T> RealizaLeitura();
}
