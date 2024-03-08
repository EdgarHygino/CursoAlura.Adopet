using CursoAlura.Adopet.Console.Servicos.Arquivos;
using CursoAlura.Adopet.Console.Servicos.Http;
using CursoAlura.Adopet.Console.Settings;

namespace CursoAlura.Adopet.Console.Comandos;
public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var service = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivosCliente = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
        if (leitorDeArquivosCliente is null) { return null; }
        return new ImportClientes(service, leitorDeArquivosCliente);
    }
}
