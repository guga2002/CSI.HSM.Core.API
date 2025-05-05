using Domain.Core.Data;
using Domain.Core.Entities.Contacts;
using Domain.Core.Interfaces.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;

namespace Core.Infrastructure.Repositories.Contacts;

public class ContactsStaffTypeRepository : GenericRepository<ContactsStaffType>, IContactsStaffTypeRepository
{
    public ContactsStaffTypeRepository(CoreSideDb context, IRedisCash redisCache,
        IHttpContextAccessor httpContextAccessor, ILogger<ContactsStaffType> logger)
        : base(context, redisCache, httpContextAccessor, logger)
    {
    }
}
