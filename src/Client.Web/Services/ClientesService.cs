﻿using Client.Web.Models;
using Client.Web.Utils;

namespace Client.Web.Services
{
    public interface IClientesService
    {
        Task<ClientesViewModel> GetAllClients();
        Task<ClienteViewModel> GetClientById(int id);
    }

    public class ClientesService : IClientesService
    {
        private readonly HttpClient _client;
        private readonly string _basePath = "api/v1/clientes";

        public ClientesService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ClientesViewModel> GetAllClients()
        {
            var response = await _client.GetAsync($"{_basePath}");
            return await response.ReadContentAs<ClientesViewModel>();
        }

        public async Task<ClienteViewModel> GetClientById(int id)
        {
            var response = await _client.GetAsync($"{_basePath}/{id}");
            return await response.ReadContentAs<ClienteViewModel>();
        }
    }
}