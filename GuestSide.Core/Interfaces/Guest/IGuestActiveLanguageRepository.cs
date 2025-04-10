using Domain.Core.Entities.Guest;
using Domain.Core.Interfaces.AbstractInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Guest
{
    public interface IGuestActiveLanguageRepository : IGenericRepository<GuestActiveLanguage>
    {
        Task<GuestActiveLanguage> GetActiveLanguageByGuestIdAsync(long guestId);
        Task<IEnumerable<GuestActiveLanguage>> GetGuestLanguageHistoryAsync(long guestId);
        Task<bool> SetGuestActiveLanguageAsync(long guestId, string languageCode);
        Task<bool> RemoveGuestActiveLanguageAsync(long guestId);
    }
}