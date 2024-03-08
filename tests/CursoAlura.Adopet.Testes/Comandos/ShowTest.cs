using CursoAlura.Adopet.Console.Comandos;
using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Results;
using CursoAlura.Adopet.Testes.Builder;

namespace CursoAlura.Adopet.Testes.Comandos;

public class ShowTest
{
    [Fact]
    public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
    {
        //Arrange
        List<Pet> listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);
        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura());

        var show = new Show(leitor.Object);

        //Act
        var resultado = await show.ExecutarAsync();

        //Assert
        Assert.NotNull(resultado);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Exibição do arquivo realizada com sucesso!",
            sucesso.Message);
    }


}
