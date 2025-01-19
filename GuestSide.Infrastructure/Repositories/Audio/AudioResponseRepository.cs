using Core.Core.Interfaces.Audio;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Audio;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Audio;

public class AudioResponseRepository : GenericRepository<AudioResponse>, IAudioResponseRepository
{
    public AudioResponseRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AudioResponse> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
