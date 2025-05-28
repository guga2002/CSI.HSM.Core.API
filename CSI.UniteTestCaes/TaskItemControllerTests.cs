using Core.API.Controllers.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Moq;

namespace CSI.UniteTests;

public class TaskItemControllerTests
{
    private readonly Mock<ITaskItemService> _mockTaskItemService;
    private readonly TaskItemController _controller;

    public TaskItemControllerTests()
    {
        _mockTaskItemService = new Mock<ITaskItemService>();
        _controller = new TaskItemController(null, null, _mockTaskItemService.Object);
    }

    [Fact]
    public async Task GetTaskItemsByTaskIdAsync_ReturnsSuccessResponse_WhenItemsExist()
    {
        var taskId = 1L;
        var taskItems = new List<TaskItemResponseDto> { new TaskItemResponseDto { Id = 1 } };

        _mockTaskItemService.Setup(s => s.GetTaskItemsByTaskIdAsync(taskId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(taskItems);

        var result = await _controller.GetTaskItemsByTaskIdAsync(taskId);

        Assert.True(result.success);
        Assert.Equal(taskItems.Count, result.data.Count());
    }

    [Fact]
    public async Task GetTaskItemsByTaskIdAsync_ReturnsErrorResponse_WhenNoItemsExist()
    {
        var taskId = 1L;
        var taskItems = new List<TaskItemResponseDto>();

        _mockTaskItemService.Setup(s => s.GetTaskItemsByTaskIdAsync(taskId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(taskItems);

        var result = await _controller.GetTaskItemsByTaskIdAsync(taskId);

        Assert.False(result.success);
        Assert.Equal("No task items found.", result.message);
    }

    [Fact]
    public async Task GetTaskItemsByItemIdAsync_ReturnsSuccessResponse_WhenItemsExist()
    {
        var itemId = 1L;
        var taskItems = new List<TaskItemResponseDto> { new TaskItemResponseDto { Id = 1 } };

        _mockTaskItemService.Setup(s => s.GetTaskItemsByItemIdAsync(itemId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(taskItems);

        var result = await _controller.GetTaskItemsByItemIdAsync(itemId);

        Assert.True(result.success);
        Assert.Equal(taskItems.Count, result.data.Count());
    }

    [Fact]
    public async Task GetTaskItemsByItemIdAsync_ReturnsErrorResponse_WhenNoItemsExist()
    {
        var itemId = 1L;
        var taskItems = new List<TaskItemResponseDto>();

        _mockTaskItemService.Setup(s => s.GetTaskItemsByItemIdAsync(itemId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(taskItems);

        var result = await _controller.GetTaskItemsByItemIdAsync(itemId);

        Assert.False(result.success);
        Assert.Equal("No task items found.", result.message);
    }

    [Fact]
    public async Task UpdateItemQuantityAsync_ReturnsSuccessResponse_WhenUpdateSucceeds()
    {
        var taskItemId = 1L;
        var newQuantity = 10;

        _mockTaskItemService.Setup(s => s.UpdateItemQuantityAsync(taskItemId, newQuantity, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.UpdateItemQuantityAsync(taskItemId, newQuantity);

        Assert.True(result.success);
        Assert.True(result.data);
    }

    [Fact]
    public async Task UpdateItemQuantityAsync_ReturnsErrorResponse_WhenUpdateFails()
    {
        var taskItemId = 1L;
        var newQuantity = 10;

        _mockTaskItemService.Setup(s => s.UpdateItemQuantityAsync(taskItemId, newQuantity, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.UpdateItemQuantityAsync(taskItemId, newQuantity);

        Assert.False(result.success);
        Assert.Equal("Failed to update quantity.", result.message);
    }

    [Fact]
    public async Task AddNotesToTaskItemAsync_ReturnsSuccessResponse_WhenAddingSucceeds()
    {
        var taskItemId = 1L;
        var notes = "Sample notes";

        _mockTaskItemService.Setup(s => s.AddNotesToTaskItemAsync(taskItemId, notes, It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var result = await _controller.AddNotesToTaskItemAsync(taskItemId, notes);

        Assert.True(result.success);
        Assert.True(result.data);
    }

    [Fact]
    public async Task AddNotesToTaskItemAsync_ReturnsErrorResponse_WhenAddingFails()
    {
        var taskItemId = 1L;
        var notes = "Sample notes";

        _mockTaskItemService.Setup(s => s.AddNotesToTaskItemAsync(taskItemId, notes, It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var result = await _controller.AddNotesToTaskItemAsync(taskItemId, notes);

        Assert.False(result.success);
        Assert.Equal("Failed to add notes.", result.message);
    }

    [Fact]
    public async Task CountTotalItemsInTaskAsync_ReturnsSuccessResponse()
    {
        var taskId = 1L;
        var count = 5;

        _mockTaskItemService.Setup(s => s.CountTotalItemsInTaskAsync(taskId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(count);

        var result = await _controller.CountTotalItemsInTaskAsync(taskId);

        Assert.True(result.success);
        Assert.Equal(count, result.data);
    }
}
