using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Models;

namespace Core.Persistance.PtmsCsi;
public interface ITemplateGatewayService
{
    Task<string> GetAllAsync(string? type, string? language);
    Task<string> GetByKeyAsync(string key, string? language);
    Task<string> CreateAsync(Template template);
    Task<string> UpdateAsync(string id, Template template);
    Task<string> DeleteAsync(string id);
    Task<(byte[] File, string ContentType, string FileName)> RenderTemplateAsFileAsync(TemplateRenderRequest request);
}
