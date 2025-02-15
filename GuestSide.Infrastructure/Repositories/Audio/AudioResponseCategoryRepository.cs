using Core.Core.Data;
using Core.Core.Entities.Audio;
using Core.Core.Interfaces.Audio;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Audio;

public class AudioResponseCategoryRepository : GenericRepository<AudioResponseCategory>, IAudioResponseCategoryRepository
{
    public AudioResponseCategoryRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<AudioResponseCategory> logger) : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
