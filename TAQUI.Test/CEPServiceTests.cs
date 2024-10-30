using System.Threading.Tasks;
using Xunit;
using TAQUI.Model.DTO.Response;
using TAQUI.Service.CEP;

namespace TAQUI.Tests
{
    public class CEPServiceTests
    {
        private readonly CEPService _cepService;

        public CEPServiceTests()
        {
            _cepService = new CEPService();
        }

        [Fact]
        public async Task GetAddress_ValidCep_ReturnsAddressResponse()
        {
            // Arrange
            string validCep = "01001-000";

            // Act
            AddressResponse result = await _cepService.GetAddress(validCep);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(validCep, result.Cep);
            Assert.False(result.Erro == "true");
        }

        [Fact]
        public async Task GetAddress_InvalidCep_ReturnsNull()
        {
            // Arrange
            string invalidCep = "00000-000";

            // Act
            AddressResponse result = await _cepService.GetAddress(invalidCep);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAddress_NonExistentCep_ReturnsNull()
        {
            // Arrange
            string nonExistentCep = "00000-000";

            // Act
            AddressResponse result = await _cepService.GetAddress(nonExistentCep);

            // Assert
            Assert.Null(result);
        }
    }
}
