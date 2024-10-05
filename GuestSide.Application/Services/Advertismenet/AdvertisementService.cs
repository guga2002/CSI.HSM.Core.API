using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Application.Services.Advertismenet
{
    public class AdvertisementService : GenericService<Advertisements, long>, IAdvertismentService
    {
        public AdvertisementService(IGenericRepository<Advertisements> servic) : base(servic)
        {
        }
    }
}
