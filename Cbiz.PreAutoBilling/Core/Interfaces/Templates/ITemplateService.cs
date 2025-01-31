namespace Cbiz.PreAutoBilling.Core.Interfaces.Templates
{
    public interface ITemplateService
    {
        Task<string> LoadTemplateAsync(string templateName);
        Task<string> RenderTemplateAsync(string templateName, object model);
    }
} 