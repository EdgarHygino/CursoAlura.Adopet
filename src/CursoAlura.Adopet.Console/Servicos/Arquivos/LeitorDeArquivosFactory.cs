using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Servicos.Abstracoes;

namespace CursoAlura.Adopet.Console.Servicos.Arquivos;
public static class LeitorDeArquivosFactory
{
    public static ILeitorDeArquivos<Pet>? CreatePetFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv":
                return new PetsDoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivosJson<Pet>(caminhoArquivo);
            default: return null;
        }
    }

    public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv":
                return new ClientesDoCsv(caminhoArquivo);
            case ".json":
                return new LeitorDeArquivosJson<Cliente>(caminhoArquivo);
            default: return null;
        }
    }
}
