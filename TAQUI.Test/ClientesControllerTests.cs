using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using TAQUI.API.Controllers;
using TAQUI.Model;
using TAQUI.Model.DTO.Request;
using TAQUI.Model.DTO.Response;
using TAQUI.Repository;

namespace TAQUI.Tests
{
    public class ClientesControllerTests
    {
        private readonly Mock<IRepository<Cliente>> _mockClienteRepository;
        private readonly ClientesController _clientesController;

        public ClientesControllerTests()
        {
            _mockClienteRepository = new Mock<IRepository<Cliente>>();
            _clientesController = new ClientesController(_mockClienteRepository.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfClientes()
        {
            // Arrange
            var mockClientes = new List<Cliente>
            {
                new Cliente { Id = new ObjectId(), DsUser = "User1", DsEmail = "user1@example.com" },
                new Cliente { Id = new ObjectId(), DsUser = "User2", DsEmail = "user2@example.com" }
            };

            _mockClienteRepository.Setup(repo => repo.GetAll()).ReturnsAsync(mockClientes);

            // Act
            var result = await _clientesController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var clientes = Assert.IsAssignableFrom<IEnumerable<ClienteResponse>>(okResult.Value);
            Assert.Equal(2, clientes.Count());
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenClienteDoesNotExist()
        {
            // Arrange
            string nonExistentId = ObjectId.GenerateNewId().ToString();
            _mockClienteRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((Cliente)null);

            // Act
            var result = await _clientesController.Get(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsOkResult_WhenClienteIsCreated()
        {
            // Arrange
            var clienteRequest = new ClienteRequest
            {
                DsUser = "User1",
                DsSenha = "Password123456789012345",
                DsEmail = "user1@example.com",
                DsCpf = "12345678901",
                NrCep = "00000-000"
            };

            var cliente = new Cliente
            {
                Id = new ObjectId(),
                DsUser = "User1",
                DsEmail = "user1@example.com"
            };

            _mockClienteRepository.Setup(repo => repo.Add(It.IsAny<Cliente>())).Returns(Task.CompletedTask);
            _mockClienteRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(cliente);

            // Act
            var result = await _clientesController.Post(clienteRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var clienteResponse = Assert.IsType<ClienteResponse>(okResult.Value);
            Assert.Equal("User1", clienteResponse.DsUser);
        }

        [Fact]
        public async Task Put_ReturnsNotFound_WhenClienteDoesNotExist()
        {
            // Arrange
            string nonExistentId = ObjectId.GenerateNewId().ToString();
            var clienteRequest = new ClienteRequest
            {
                DsUser = "User1",
                DsSenha = "Password123456789012345",
                DsEmail = "user1@example.com",
                DsCpf = "12345678901"
            };

            _mockClienteRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((Cliente)null);

            // Act
            var result = await _clientesController.Put(nonExistentId, clienteRequest);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenClienteIsDeleted()
        {
            // Arrange
            var clienteId = ObjectId.GenerateNewId();
            var cliente = new Cliente { Id = clienteId };
            _mockClienteRepository.Setup(repo => repo.GetById(clienteId)).ReturnsAsync(cliente);
            _mockClienteRepository.Setup(repo => repo.Delete(clienteId)).Returns(Task.CompletedTask);

            // Act
            var result = await _clientesController.Delete(clienteId.ToString());

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
