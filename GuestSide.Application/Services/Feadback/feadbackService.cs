using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.Interface.Feadback;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Feadback
{
    public class feadbackService : GenericService<FeedbackDto,FeedbackResponseDto, long, Feedback>, IFeadbackService
    {
        private readonly IAdditioalFeatures<Feedback> _features;
        private readonly IGenericRepository<Feedback> _servic;
        private readonly IMapper _map;
        public feadbackService(IGenericRepository<Feedback> servic,  IMapper Map, ILogger<GenericService<FeedbackDto,FeedbackResponseDto, long, Feedback>> log, IAdditioalFeatures<Feedback> features) : base(Map, servic, log)
        {
            _features=features;
            _servic = servic;
            _map = Map;
        }

        public async System.Threading.Tasks.Task InsertFewFeadback(List<FeedbackDto> feedbacks)
        {
            await _features.ExecuteInTransaction(async () =>
            {
                foreach (var feedback in feedbacks)
                {
                    await _servic.AddAsync(_map.Map<Feedback>(feedback));
                }
            });
        }
    }
}
