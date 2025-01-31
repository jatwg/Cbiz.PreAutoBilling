using Cbiz.PreAutoBilling.Core.Interfaces.Templates;
using System.Text.RegularExpressions;

namespace Cbiz.PreAutoBilling.Infrastructure.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly string _templateDirectory;

        public TemplateService()
        {
            _templateDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");
        }

        public async Task<string> LoadTemplateAsync(string templateName)
        {
            var templatePath = Path.Combine(_templateDirectory, $"{templateName}.html");
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template {templateName} not found", templatePath);
            }

            return await File.ReadAllTextAsync(templatePath);
        }

        public async Task<string> RenderTemplateAsync(string templateName, object model)
        {
            var template = await LoadTemplateAsync(templateName);
            return RenderTemplate(template, model);
        }

        private string RenderTemplate(string template, object model)
        {
            return Regex.Replace(template, @"\{\{(\w+)\}\}", match =>
            {
                var propertyName = match.Groups[1].Value;
                var property = model.GetType().GetProperty(propertyName);
                return property?.GetValue(model)?.ToString() ?? string.Empty;
            });
        }
    }
} 