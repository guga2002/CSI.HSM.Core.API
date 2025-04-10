using Domain.Core.Entities.Language;
using Domain.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Language
{
    public interface ILanguagePackRepository : IGenericRepository<LanguagePack>
    {
        Task<IEnumerable<LanguagePack>> GetAllActiveLanguages();
        Task<LanguagePack?> GetLanguageByCode(string code);
        Task<bool> SoftDeleteLanguage(long languageId);
    }
}