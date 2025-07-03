using AuraShop.PedidoFacil.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AuraShop.PedidoFacil.Tests.API
{
    public class ItemControllerTest
    {
        public ITestOutputHelper Output { get; private set; }

        public ItemControllerTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public async Task CreateItem_ShouldReturn200OK()
        {
            // Arrange
            var app = new AuraShopWebApplicationFactory();
            using var client = app.CreateClient();

            var dto = new CreateItemDto()
            {
                Nome = "Jaleco Teste",
                Cor = "Branco",
                Preco = 22.90f,
                Tamanho = "4"
            };

            // Act
            var result = await client.PostAsJsonAsync("/api/v1/item", dto);

            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public async Task CreateItem_InvalidData_ShouldReturn400BadRequest()
        {
            // Arrange
            var app = new AuraShopWebApplicationFactory();
            using var client = app.CreateClient();

            var dto = new CreateItemDto()
            {
                Nome = "Jaleco Errado",
                Cor = "Branco",
                Preco = -1,
                Tamanho = "4"
            };

            // Act
            var result = await client.PostAsJsonAsync("api/v1/item", dto);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
