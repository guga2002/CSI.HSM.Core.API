using Common.Data.Entities.Advertisements;
using Core.API.Controllers.Advertisement;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.Interface.Advertisment;
using Core.Application.Interface.GenericContracts;
using Moq;

namespace CSI.UniteTests;

public class AdvertisementControllerTests
{
    private readonly Mock<IAdvertisementService> _advertisementServiceMock;
    private readonly Mock<IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>> _serviceMock;
    private readonly Mock<IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>> _featuresMock;
    private readonly AdvertisementController _controller;

    public AdvertisementControllerTests()
    {
        _advertisementServiceMock = new Mock<IAdvertisementService>();
        _serviceMock = new Mock<IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>>();
        _featuresMock = new Mock<IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisement>>();

        _controller = new AdvertisementController(
            _advertisementServiceMock.Object,
            _serviceMock.Object,
            null,
            _featuresMock.Object
        );
    }

    [Fact]
    public async Task GetActiveAdvertisementsAsync_ReturnsSuccess_WhenDataExists()
    {
        var data = new List<AdvertismentResponseDto> { new AdvertismentResponseDto { Id = 1, Title = "GugaTest" } };
        _advertisementServiceMock.Setup(s => s.GetActiveAdvertisementsAsync(It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(data);

        var result = await _controller.GetActiveAdvertisementsAsync();

        Assert.True(result.Success);
        Assert.Equal(data.Count, result.Data.Count());
    }

    [Fact]
    public async Task GetAdvertisementsByTypeAsync_ReturnsSuccess_WhenDataExists()
    {
        var data = new List<AdvertismentResponseDto> { new AdvertismentResponseDto { Id = 2, Title = "GugaTest" } };
        _advertisementServiceMock.Setup(s => s.GetAdvertisementsByTypeAsync(2, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(data);

        var result = await _controller.GetAdvertisementsByTypeAsync(2);

        Assert.True(result.Success);
        Assert.Single(result.Data);
    }

    [Fact]
    public async Task GetAdvertisementsByDateRangeAsync_ReturnsSuccess_WhenFound()
    {
        var data = new List<AdvertismentResponseDto> { new AdvertismentResponseDto { Id = 3, Title = "GugaTest" } };
        var start = DateTime.UtcNow.AddDays(-5);
        var end = DateTime.UtcNow;

        _advertisementServiceMock.Setup(s => s.GetAdvertisementsByDateRangeAsync(start, end, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(data);

        var result = await _controller.GetAdvertisementsByDateRangeAsync(start, end);

        Assert.True(result.Success);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task GetAdvertisementsByLanguageAsync_ReturnsSuccess_WhenDataExists()
    {
        var language = "en";
        var data = new List<AdvertismentResponseDto> { new AdvertismentResponseDto { Id = 4, Title = "GugaTest" } };

        _advertisementServiceMock.Setup(s => s.GetAdvertisementsByLanguageAsync(language, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(data);

        var result = await _controller.GetAdvertisementsByLanguageAsync(language);

        Assert.True(result.Success);
        Assert.Single(result.Data);
    }

    [Fact]
    public async Task GetAdvertisementByTitleAsync_ReturnsSuccess_WhenFound()
    {
        var title = "Promo";
        var dto = new AdvertismentResponseDto { Title = title };

        _advertisementServiceMock.Setup(s => s.GetAdvertisementByTitleAsync(title, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(dto);

        var result = await _controller.GetAdvertisementByTitleAsync(title);

        Assert.True(result.Success);
        Assert.Equal(title, result.Data?.Title);
    }

    [Fact]
    public async Task GetAdvertisementByTitleAsync_ReturnsFailure_WhenNotFound()
    {
        _advertisementServiceMock.Setup(s => s.GetAdvertisementByTitleAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync((AdvertismentResponseDto?)null);

        var result = await _controller.GetAdvertisementByTitleAsync("unknown");

        Assert.False(result.Success);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task UpdateAdvertisementDatesAsync_ReturnsSuccess_WhenUpdateSucceeds()
    {
        _advertisementServiceMock.Setup(s => s.UpdateAdvertisementDatesAsync(1, It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(true);

        var result = await _controller.UpdateAdvertisementDatesAsync(1, DateTime.UtcNow, DateTime.UtcNow.AddDays(2));

        Assert.True(result.Success);
        Assert.True(result.Data);
    }

    [Fact]
    public async Task UpdateAdvertisementDatesAsync_ReturnsFailure_WhenUpdateFails()
    {
        _advertisementServiceMock.Setup(s => s.UpdateAdvertisementDatesAsync(1, It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(false);

        var result = await _controller.UpdateAdvertisementDatesAsync(1, DateTime.UtcNow, DateTime.UtcNow.AddDays(2));

        Assert.False(result.Success);
        Assert.False(result.Data);
    }

    [Fact]
    public async Task DeleteAdvertisementByIdAsync_ReturnsSuccess_WhenDeleted()
    {
        _advertisementServiceMock.Setup(s => s.DeleteAdvertisementByIdAsync(1, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(true);

        var result = await _controller.DeleteAdvertisementByIdAsync(1);

        Assert.True(result.Success);
        Assert.True(result.Data);
    }

    [Fact]
    public async Task DeleteAdvertisementByIdAsync_ReturnsFailure_WhenDeleteFails()
    {
        _advertisementServiceMock.Setup(s => s.DeleteAdvertisementByIdAsync(1, It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(false);

        var result = await _controller.DeleteAdvertisementByIdAsync(1);

        Assert.False(result.Success);
        Assert.False(result.Data);
    }
}
