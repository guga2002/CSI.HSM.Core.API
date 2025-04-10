using Core.API.Controllers.Advertisement;
using Core.API.Response;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Advertisements;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CSI.UniteTests
{
    public class AdvertisementTypeControllerTests
    {
        private readonly Mock<IAdvertisementTypeService> _advertisementTypeServiceMock;
        private readonly Mock<IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>> _serviceMock;
        private readonly Mock<IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>> _additionalFeaturesMock;
        private readonly AdvertisemenetTypeController _controller;

        public AdvertisementTypeControllerTests()
        {
            _advertisementTypeServiceMock = new Mock<IAdvertisementTypeService>();
            _serviceMock = new Mock<IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>>();
            _additionalFeaturesMock = new Mock<IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>>();

            _controller = new AdvertisemenetTypeController(
                _advertisementTypeServiceMock.Object,
                _serviceMock.Object,
                _additionalFeaturesMock.Object);
        }

        [Fact]
        public async Task GetAdvertisementTypeByNameAsync_ReturnsSuccess_WhenFound()
        {
            var name = "Banner";
            var dto = new AdvertisementTypeResponseDto { Id = 1, Name = name };

            _advertisementTypeServiceMock
                .Setup(s => s.GetAdvertisementTypeByNameAsync(name, It.IsAny<CancellationToken>()))
                .ReturnsAsync(dto);

            var result = await _controller.GetAdvertisementTypeByNameAsync(name);

            Assert.True(result.Success);
            Assert.Equal(name, result.Data?.Name);
        }

        [Fact]
        public async Task GetAdvertisementTypeByNameAsync_ReturnsFailure_WhenNotFound()
        {
            _advertisementTypeServiceMock
                .Setup(s => s.GetAdvertisementTypeByNameAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((AdvertisementTypeResponseDto?)null);

            var result = await _controller.GetAdvertisementTypeByNameAsync("Unknown");

            Assert.False(result.Success);
            Assert.Null(result.Data);
        }

        [Fact]
        public async Task GetAllAdvertisementTypesAsync_ReturnsSuccess_WhenItemsExist()
        {
            var data = new List<AdvertisementTypeResponseDto>
            {
                new AdvertisementTypeResponseDto { Id = 1, Name = "Banner" }
            };

            _advertisementTypeServiceMock
                .Setup(s => s.GetAllAdvertisementTypesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            var result = await _controller.GetAllAdvertisementTypesAsync();

            Assert.True(result.Success);
            Assert.Equal(1, result.Data.Count());
        }

        [Fact]
        public async Task GetAllAdvertisementTypesAsync_ReturnsFailure_WhenEmpty()
        {
            _advertisementTypeServiceMock
                .Setup(s => s.GetAllAdvertisementTypesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AdvertisementTypeResponseDto>());

            var result = await _controller.GetAllAdvertisementTypesAsync();

            Assert.False(result.Success);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task GetAdvertisementTypesByLanguageAsync_ReturnsSuccess_WhenFound()
        {
            var language = "en";
            var data = new List<AdvertisementTypeResponseDto>
            {
                new AdvertisementTypeResponseDto { Id = 2, Name = "Popup" }
            };

            _advertisementTypeServiceMock
                .Setup(s => s.GetAdvertisementTypesByLanguageAsync(language, It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            var result = await _controller.GetAdvertisementTypesByLanguageAsync(language);

            Assert.True(result.Success);
            Assert.Single(result.Data);
        }

        [Fact]
        public async Task GetAdvertisementTypesByLanguageAsync_ReturnsFailure_WhenEmpty()
        {
            _advertisementTypeServiceMock
                .Setup(s => s.GetAdvertisementTypesByLanguageAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<AdvertisementTypeResponseDto>());

            var result = await _controller.GetAdvertisementTypesByLanguageAsync("de");

            Assert.False(result.Success);
            Assert.Empty(result.Data);
        }

        [Fact]
        public async Task UpdateAdvertisementTypeDescriptionAsync_ReturnsSuccess_WhenUpdateSucceeds()
        {
            var id = 10L;
            var description = "New description";

            _advertisementTypeServiceMock
                .Setup(s => s.UpdateAdvertisementTypeDescriptionAsync(id, description, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _controller.UpdateAdvertisementTypeDescriptionAsync(id, description);

            Assert.True(result.Success);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task UpdateAdvertisementTypeDescriptionAsync_ReturnsFailure_WhenUpdateFails()
        {
            var id = 10L;
            var description = "Fail update";

            _advertisementTypeServiceMock
                .Setup(s => s.UpdateAdvertisementTypeDescriptionAsync(id, description, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await _controller.UpdateAdvertisementTypeDescriptionAsync(id, description);

            Assert.False(result.Success);
            Assert.False(result.Data);
        }

        [Fact]
        public async Task DeleteAdvertisementTypeByIdAsync_ReturnsSuccess_WhenDeleted()
        {
            var id = 99L;

            _advertisementTypeServiceMock
                .Setup(s => s.DeleteAdvertisementTypeByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _controller.DeleteAdvertisementTypeByIdAsync(id);

            Assert.True(result.Success);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task DeleteAdvertisementTypeByIdAsync_ReturnsFailure_WhenDeleteFails()
        {
            var id = 99L;

            _advertisementTypeServiceMock
                .Setup(s => s.DeleteAdvertisementTypeByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await _controller.DeleteAdvertisementTypeByIdAsync(id);

            Assert.False(result.Success);
            Assert.False(result.Data);
        }
    }
}
