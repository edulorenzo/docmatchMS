using System.Collections.Generic;

namespace docmatchMS.Templates;

public static class TemplateRepository
{
    public static List<string> GetTemplates()
    {
        return new List<string>
        {
            "This is the first example template.",
            "Another sample template for matching."
        };
    }
}