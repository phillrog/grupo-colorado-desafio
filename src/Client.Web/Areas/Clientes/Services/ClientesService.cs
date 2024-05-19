﻿using Client.Web.Areas.Clientes.Models;
using Client.Web.Utils;

namespace Client.Web.Areas.Clientes.Services
{
    public interface IClientesService
    {
        Task<ClientesLista> GetAllClients();
        Task<Cliente> GetClientById(int id);
        Task PostClient(Cliente client);
    }

    public class ClientesService : IClientesService
    {
        private readonly HttpClient _client;
        private readonly string _basePath = "api/v1/clientes";

        public ClientesService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ClientesLista> GetAllClients()
        {
            var response = await _client.GetAsync($"{_basePath}");
            return await response.ReadContentAs<ClientesLista>();
        }

        public async Task<Cliente> GetClientById(int id)
        {
            var response = await _client.GetAsync($"{_basePath}/{id}");
            return await response.ReadContentAs<Cliente>();
        }

        public async Task PostClient(Cliente client)
        {
            var response = await _client.PostAsJson($"{_basePath}", client);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro na execução da API");
        }
    }
}