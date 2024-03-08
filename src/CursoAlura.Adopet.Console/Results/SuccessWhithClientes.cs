﻿using CursoAlura.Adopet.Console.Modelos;
using FluentResults;

namespace CursoAlura.Adopet.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}