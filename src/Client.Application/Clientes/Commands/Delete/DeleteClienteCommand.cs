namespace Client.Application.Clientes.Commands.Delete
{
    public class DeleteClienteCommand : IRequest<bool>
    {
        public int Id { get; init; }
    }

    public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
    {
        public DeleteClienteCommandValidator()
        {
            RuleFor(v => v.Id).NotNull().GreaterThan(0);     
        }
    }
}
