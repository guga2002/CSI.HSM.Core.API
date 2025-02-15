using Core.Core.Entities.Language;
using Core.Core.Interfaces.AbstractInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Core.Interfaces.Language
{
    public interface ILanguagePackRepository : IGenericRepository<LanguagePack>
    {
        Task<IEnumerable<LanguagePack>> GetAllActiveLanguages();
        Task<LanguagePack?> GetLanguageByCode(string code);
        Task<bool> SoftDeleteLanguage(long languageId);
    }
}