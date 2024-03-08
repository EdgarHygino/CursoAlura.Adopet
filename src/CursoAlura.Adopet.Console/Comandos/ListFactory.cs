﻿using CursoAlura.Adopet.Console.Servicos.Http;
using CursoAlura.Adopet.Console.Settings;

namespace CursoAlura.Adopet.Console.Comandos;
public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPetList = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}
