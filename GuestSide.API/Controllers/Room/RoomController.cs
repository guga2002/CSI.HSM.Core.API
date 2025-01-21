﻿using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room;

[Route("api/[controller]")]
[ApiController]
public class RoomController : CSIControllerBase<RoomsDto, RoomsResponseDto, long, Rooms>
{
    public RoomController(IService<RoomsDto, RoomsResponseDto, long, Rooms> serviceProvider, IAdditionalFeatures<RoomsDto, RoomsResponseDto, long, Rooms> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}