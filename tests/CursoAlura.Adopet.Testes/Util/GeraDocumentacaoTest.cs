using CursoAlura.Adopet.Console.Atributos;
using CursoAlura.Adopet.Console.Util;
using System.Reflection;

namespace CursoAlura.Adopet.Testes.Util;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert            
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(6, dicionario.Count);

    }
}
