using System.Threading.Tasks;
using OrchardCore.Indexing;
using OrchardCore.Markdown.Models;

namespace OrchardCore.Markdown.Indexing
{
    public class MarkdownBodyPartIndexHandler : ContentPartIndexHandler<MarkdownBodyPart>
    {
        public override Task BuildIndexAsync(MarkdownBodyPart part, BuildPartIndexContext context)
        {
            var options = context.Settings.ToOptions()
                | DocumentIndexOptions.Sanitize
                | DocumentIndexOptions.Analyze
                ;

            /// Setting options from context settings (with additional sanitize and analyze doc options) for fields.
            foreach (var key in context.Keys)
            {
                context.DocumentIndex.Set(key, part.Markdown, options);
            }

            return Task.CompletedTask;
        }
    }
}
