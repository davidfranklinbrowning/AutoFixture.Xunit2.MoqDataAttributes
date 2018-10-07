using System.Diagnostics.CodeAnalysis;
using AutoFixture.AutoMoq;

namespace AutoFixture.Xunit2.MoqDataAttributes
{
    [ExcludeFromCodeCoverage]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : this(new Fixture())
        {

        }

        public AutoMoqDataAttribute(IFixture fixture) : base(() => fixture.Customize(new AutoMoqCustomization()))
        {

        }
    }
}