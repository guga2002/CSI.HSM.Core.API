using Core.Core.Interfaces.Audio;
using Core.Persistance.Cashing;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Audio;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Audio;

public class AudioResponseCategoryRepository : GenericRepository<AudioResponseCategory>, IAudioResponseCategoryRepository
{
    public AudioResponseCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AudioResponseCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
