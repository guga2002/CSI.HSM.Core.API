﻿namespace GuestSide.Application.DTOs.Response.Task
{
    public class TaskResponseDto
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CategoryId { get; set; }

        public long CartId { get; set; }

        public long ItemId { get; set; }
    }
}
