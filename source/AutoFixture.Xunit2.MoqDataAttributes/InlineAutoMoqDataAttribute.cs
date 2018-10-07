using System.Diagnostics.CodeAnalysis;
using Xunit;
using Xunit.Sdk;

namespace AutoFixture.Xunit2.MoqDataAttributes
{
    [ExcludeFromCodeCoverage]
    public class InlineAutoMoqDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] values)
            : base(new DataAttribute[] {
                new InlineDataAttribute(values), new AutoMoqDataAttribute() })
        {
        }
    }
}