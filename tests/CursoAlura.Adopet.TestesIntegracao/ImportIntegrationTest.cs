using CursoAlura.Adopet.Console.Comandos;
using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Servicos.Http;
using CursoAlura.Adopet.Console.Settings;
using CursoAlura.Adopet.TestesIntegracao.Builder;

namespace CursoAlura.Adopet.TestesIntegracao;

public class ImportIntegrationTest
{

    [Fact]
    public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
    {
        //Arrange
        var listaDePet = new List<Pet>();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
              "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        listaDePet.Add(pet);
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePet);       
          var httpClientPet = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var import = new Import(httpClientPet,leitorDeArquivo.Object);
         
        //Act
        await import.ExecutarAsync();
        
        //Assert
        var listaPet = await httpClientPet.ListAsync();
        Assert.NotNull(listaPet);
    }
}
