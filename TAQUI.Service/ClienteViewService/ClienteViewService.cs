﻿using TAQUI.Model;
using TAQUI.Model.DTO.Request;
using TAQUI.Repository;

namespace TAQUI.Service.ClienteViewService
{
    public class ClienteViewService(IRepository<ClienteView> clienteViewRepository) : IClienteViewService
    {
        private readonly IRepository<ClienteView> _clienteViewRepository = clienteViewRepository;

        public void AddClienteView(ClienteViewRequest clienteViewRequest)
        {
            ClienteView clienteView = new ClienteView();

            clienteView.ClienteId = clienteViewRequest.ClienteId;
            clienteView.ProdutoId = clienteViewRequest.ProdutoId;
            clienteView.ViewedAt = clienteViewRequest.ViewedAt;

            _clienteViewRepository.Add(clienteView);
        }

        public async Task<IEnumerable<ClienteView>> GetClienteViews()
        {
            return await _clienteViewRepository.GetAll();
        }
    }
}
