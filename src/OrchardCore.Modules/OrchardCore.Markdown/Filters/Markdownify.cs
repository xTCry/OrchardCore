using System.Threading.Tasks;
using Fluid;
using Fluid.Values;
using OrchardCore.Liquid;

namespace OrchardCore.Markdown.Filters
{
    public class Markdownify : ILiquidFilter
    {
        /// Converts a Markdown string to HTML.
        public ValueTask<FluidValue> ProcessAsync(FluidValue input, FilterArguments arguments, TemplateContext ctx)
        {
            return new ValueTask<FluidValue>(new StringValue(Markdig.Markdown.ToHtml(input.ToStringValue())));
        }
    }
}
