﻿using ConsultorioLegal.api.UI.ModelViews.Endereco;
using FluentValidation;

namespace ConsultorioLegal.api.Application.Services.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.CEP).NotEmpty().NotNull();
            RuleFor(p => p.Estado).NotNull();
            RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(p => p.Logradouro).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(p => p.Numero).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(p => p.Complemento).MaximumLength(200);
        }
    }
}
