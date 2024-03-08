﻿using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Servicos.Arquivos;

namespace CursoAlura.Adopet.Testes.Servicos;

public class LeitorDeArquivoFactoryTest
{
    [Fact]
    public void QuantoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
    {
        // arrange
        string caminhoArquivo = "pets.csv";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.IsType<PetsDoCsv>(leitor);
    }

    [Fact]
    public void QuantoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
    {
        // arrange
        string caminhoArquivo = "pets.json";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.IsType<LeitorDeArquivosJson<Pet>>(leitor);
    }

    [Fact]
    public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        string caminhoArquivo = "pets.xsl";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.Null(leitor);
    }
}