using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface.AdvertiementType;
using GuestSide.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.Services.AdvertisementType
{
    public class AdvertisementTypeService : GenericService<AdvertisementTypeDto, long>, IAdvertisementTypeService
    {
        public AdvertisementTypeService(IGenericRepository<AdvertisementTypeDto> servic) : base(servic)
        {
        }
    }
}
