using Core.API.Controllers.Item;
using Core.API.Response;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CSI.UniteTests
{
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

            Assert.True(result.Success);
            Assert.Equal(taskItems.Count, result.Data.Count());
        }

        [Fact]
        public async Task GetTaskItemsByTaskIdAsync_ReturnsErrorResponse_WhenNoItemsExist()
        {
            var taskId = 1L;
            var taskItems = new List<TaskItemResponseDto>();

            _mockTaskItemService.Setup(s => s.GetTaskItemsByTaskIdAsync(taskId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(taskItems);

            var result = await _controller.GetTaskItemsByTaskIdAsync(taskId);

            Assert.False(result.Success);
            Assert.Equal("No task items found.", result.Message);
        }

        [Fact]
        public async Task GetTaskItemsByItemIdAsync_ReturnsSuccessResponse_WhenItemsExist()
        {
            var itemId = 1L;
            var taskItems = new List<TaskItemResponseDto> { new TaskItemResponseDto { Id = 1 } };

            _mockTaskItemService.Setup(s => s.GetTaskItemsByItemIdAsync(itemId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(taskItems);

            var result = await _controller.GetTaskItemsByItemIdAsync(itemId);

            Assert.True(result.Success);
            Assert.Equal(taskItems.Count, result.Data.Count());
        }

        [Fact]
        public async Task GetTaskItemsByItemIdAsync_ReturnsErrorResponse_WhenNoItemsExist()
        {
            var itemId = 1L;
            var taskItems = new List<TaskItemResponseDto>();

            _mockTaskItemService.Setup(s => s.GetTaskItemsByItemIdAsync(itemId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(taskItems);

            var result = await _controller.GetTaskItemsByItemIdAsync(itemId);

            Assert.False(result.Success);
            Assert.Equal("No task items found.", result.Message);
        }

        [Fact]
        public async Task GetPendingTaskItemsAsync_ReturnsSuccessResponse()
        {
            var taskItems = new List<TaskItemResponseDto> { new TaskItemResponseDto { Id = 1 } };

            _mockTaskItemService.Setup(s => s.GetPendingTaskItemsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(taskItems);

            var result = await _controller.GetPendingTaskItemsAsync();

            Assert.True(result.Success);
            Assert.Equal(taskItems.Count, result.Data.Count());
        }

        [Fact]
        public async Task GetCompletedTaskItemsAsync_ReturnsSuccessResponse()
        {
            var taskItems = new List<TaskItemResponseDto> { new TaskItemResponseDto { Id = 1 } };

            _mockTaskItemService.Setup(s => s.GetCompletedTaskItemsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(taskItems);

            var result = await _controller.GetCompletedTaskItemsAsync();

            Assert.True(result.Success);
            Assert.Equal(taskItems.Count, result.Data.Count());
        }

        [Fact]
        public async Task UpdateItemQuantityAsync_ReturnsSuccessResponse_WhenUpdateSucceeds()
        {
            var taskItemId = 1L;
            var newQuantity = 10;

            _mockTaskItemService.Setup(s => s.UpdateItemQuantityAsync(taskItemId, newQuantity, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _controller.UpdateItemQuantityAsync(taskItemId, newQuantity);

            Assert.True(result.Success);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task UpdateItemQuantityAsync_ReturnsErrorResponse_WhenUpdateFails()
        {
            var taskItemId = 1L;
            var newQuantity = 10;

            _mockTaskItemService.Setup(s => s.UpdateItemQuantityAsync(taskItemId, newQuantity, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await _controller.UpdateItemQuantityAsync(taskItemId, newQuantity);

            Assert.False(result.Success);
            Assert.Equal("Failed to update quantity.", result.Message);
        }

        [Fact]
        public async Task MarkTaskItemCompletedAsync_ReturnsSuccessResponse_WhenMarkingSucceeds()
        {
            var taskItemId = 1L;

            _mockTaskItemService.Setup(s => s.MarkTaskItemCompletedAsync(taskItemId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _controller.MarkTaskItemCompletedAsync(taskItemId);

            Assert.True(result.Success);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task MarkTaskItemCompletedAsync_ReturnsErrorResponse_WhenMarkingFails()
        {
            var taskItemId = 1L;

            _mockTaskItemService.Setup(s => s.MarkTaskItemCompletedAsync(taskItemId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await _controller.MarkTaskItemCompletedAsync(taskItemId);

            Assert.False(result.Success);
            Assert.Equal("Failed to mark task item as completed.", result.Message);
        }

        [Fact]
        public async Task AddNotesToTaskItemAsync_ReturnsSuccessResponse_WhenAddingSucceeds()
        {
            var taskItemId = 1L;
            var notes = "Sample notes";

            _mockTaskItemService.Setup(s => s.AddNotesToTaskItemAsync(taskItemId, notes, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await _controller.AddNotesToTaskItemAsync(taskItemId, notes);

            Assert.True(result.Success);
            Assert.True(result.Data);
        }

        [Fact]
        public async Task AddNotesToTaskItemAsync_ReturnsErrorResponse_WhenAddingFails()
        {
            var taskItemId = 1L;
            var notes = "Sample notes";

            _mockTaskItemService.Setup(s => s.AddNotesToTaskItemAsync(taskItemId, notes, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await _controller.AddNotesToTaskItemAsync(taskItemId, notes);

            Assert.False(result.Success);
            Assert.Equal("Failed to add notes.", result.Message);
        }

        [Fact]
        public async Task CountTotalItemsInTaskAsync_ReturnsSuccessResponse()
        {
            var taskId = 1L;
            var count = 5;

            _mockTaskItemService.Setup(s => s.CountTotalItemsInTaskAsync(taskId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(count);

            var result = await _controller.CountTotalItemsInTaskAsync(taskId);

            Assert.True(result.Success);
            Assert.Equal(count, result.Data);
        }

        [Fact]
        public async Task CountCompletedItemsInTaskAsync_ReturnsSuccessResponse()
        {
            var taskId = 1L;
            var count = 3;

            _mockTaskItemService.Setup(s => s.CountCompletedItemsInTaskAsync(taskId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(count);

            var result = await _controller.CountCompletedItemsInTaskAsync(taskId);

            Assert.True(result.Success);
            Assert.Equal(count, result.Data);
        }
    }
}
