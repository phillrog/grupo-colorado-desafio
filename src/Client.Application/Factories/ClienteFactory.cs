using Client.Application.Clientes.Commands.Create;
using Client.Domain.Entities;


namespace Client.Application.Factories
{
    public static class ClienteFactory
    {
        public static ClienteDomain Create(CreateClienteCommand command)
        {
            return new ClienteDomain(command.RazaoSocial, command.NomeFantasia, command.TipoPessoa, command.Documento, command.Endereco, command.Complemento, command.Bairro, command.Cidade, command.Cep, command.Uf, TelefoneFactory.Create(command.Telefones));
        }
    }
}
