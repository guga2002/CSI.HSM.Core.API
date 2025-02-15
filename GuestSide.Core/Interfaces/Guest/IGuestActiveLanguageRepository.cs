using Core.Core.Entities.Guest;
using Core.Core.Interfaces.AbstractInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.Guest
{
    public interface IGuestActiveLanguageRepository : IGenericRepository<GuestActiveLanguage>
    {
        Task<GuestActiveLanguage> GetActiveLanguageByGuestIdAsync(long guestId);
        Task<IEnumerable<GuestActiveLanguage>> GetGuestLanguageHistoryAsync(long guestId);
        Task<bool> SetGuestActiveLanguageAsync(long guestId, string languageCode);
        Task<bool> RemoveGuestActiveLanguageAsync(long guestId);
    }
}