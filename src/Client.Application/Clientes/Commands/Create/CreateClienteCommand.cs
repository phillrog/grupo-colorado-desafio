using Client.Domain.Enums;
using FluentValidation.Results;

namespace Client.Application.Clientes.Commands.Create
{
    public record CreateClienteCommand : IRequest<bool>
    {
        public string RazaoSocial { get; init; }
        public string NomeFantasia { get; init; }
        public TipoPessoaEnum TipoPessoa { get; init; }
        public string Documento { get; init; }
        public string Endereco { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string Cidade { get; init; }
        public string Cep { get; init; }
        public string Uf { get; init; }
        public IEnumerable<TelefoneCreateCommand> Telefones { get; init; }

    }

    public record TelefoneCreateCommand
    {
        public Guid? Id { get; init; }
        public string NumeroTelefone { get; init; }
        public string Operadora { get; init; }
        public TipoTelefoneEnum IdTipoTelefone { get; init; }
    }

    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(v => v.RazaoSocial).MaximumLength(200).NotEmpty();
            RuleFor(v => v.NomeFantasia).MaximumLength(200).NotEmpty();
            RuleFor(v => v.TipoPessoa).IsInEnum().Must(i => Enum.IsDefined(typeof(TipoPessoaEnum), i));
            RuleFor(v => v.Documento).MaximumLength(15).NotEmpty();
            RuleFor(v => v.Endereco).MaximumLength(200);
            RuleFor(v => v.Complemento).MaximumLength(50);
            RuleFor(v => v.Bairro).MaximumLength(200);
            RuleFor(v => v.Cidade).MaximumLength(200);
            RuleFor(v => v.RazaoSocial).MaximumLength(200);
            RuleFor(v => v.Cep).MaximumLength(14);
            RuleFor(v => v.Uf).MaximumLength(2);
            RuleFor(v => v.Telefones).NotNull().Custom((lista, context) =>
            {
                if (lista == null || lista.Count() == 0)
                {
                    context.AddFailure(new ValidationFailure("Erro", "'Telefones' deve existir pelo menos 1."));
                }                
            });
            RuleForEach(x => x.Telefones).SetValidator(new TelefoneCreateCommandValidator());
        }
    }

    public class TelefoneCreateCommandValidator : AbstractValidator<TelefoneCreateCommand>
    {
        public TelefoneCreateCommandValidator()
        {
            RuleFor(v => v.IdTipoTelefone).IsInEnum().Must(i => Enum.IsDefined(typeof(TipoTelefoneEnum), i));
            RuleFor(v => v.NumeroTelefone).MaximumLength(12).NotEmpty();
            RuleFor(v => v.Operadora).MaximumLength(3).NotEmpty();
        }
    }
}
