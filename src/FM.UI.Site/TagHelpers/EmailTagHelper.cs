using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FM.UI.Site.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        // Can be passed via <email mail-to="..." />. 
        // PascalCase gets translated into kebab-case.
        public string MailTo { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // will be generated a anchor element
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = $"{MailTo}@fmsoft.com.br";
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
