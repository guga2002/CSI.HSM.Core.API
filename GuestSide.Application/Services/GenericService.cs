using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.Application.Services
{
    public class GenericService<T, K> : IService<T, K>where T : class
    {
        private readonly IGenericRepository<T> service;

        public GenericService(IGenericRepository<T> servic)
        {
            this.service = servic;
        }
        public async Task<bool> CreateAsync(T entityDto)
        {
           var res=await service.AddAsync(entityDto);
            return res;
        }

        public async Task<bool> DeleteAsync(K id)
        {
            var res=await this.service.DeleteAsync(id);
            return res;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var res= await service.GetAllAsync();
            return res;
        }

        public async Task<T> GetByIdAsync(K id)
        {
            var res = await service.GetByIdAsync(id);
            return res;
        }

        public async Task<bool> UpdateAsync(K id, T entityDto)
        { 
           var result=await service.UpdateAsync(entityDto);
            return result;
        }
    }
}
