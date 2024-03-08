using CursoAlura.Adopet.Console.Servicos.Arquivos;
using CursoAlura.Adopet.Console.Servicos.Http;
using CursoAlura.Adopet.Console.Servicos.Mail;
using CursoAlura.Adopet.Console.Settings;

namespace CursoAlura.Adopet.Console.Comandos;
public class ImportFactory: IComandoFactory
{
    public bool ConsegueCriarOTipo(Type tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivos is null) { return null; }
        var import = new Import(httpClientPet, leitorDeArquivos);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        return import;
    }
}
