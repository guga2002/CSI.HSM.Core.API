using Domain.Core.Data;
using Domain.Core.Entities.Contacts;
using Domain.Core.Interfaces.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;

namespace Core.Infrastructure.Repositories.Contacts;

public class ContactRepository : GenericRepository<Contact>, IContactRespository
{
    public ContactRepository(CoreSideDb context, IRedisCash redisCache,
        IHttpContextAccessor httpContextAccessor, ILogger<Contact> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
