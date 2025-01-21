using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Core.Entities.Feedbacks;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Feadbacks
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedBackController : CSIControllerBase<FeedbackDto, FeedbackResponseDto, long, Feedback>
    {
        public FeedBackController(IService<FeedbackDto, FeedbackResponseDto, long, Feedback> serviceProvider, IAdditionalFeatures<FeedbackDto, FeedbackResponseDto, long, Feedback> additionalFeatures) : base(serviceProvider, additionalFeatures)
        {
        }
    }
}
