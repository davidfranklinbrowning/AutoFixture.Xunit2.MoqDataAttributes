using AutoFixture.AutoMoq;
using AutoFixture.Xunit2.MoqDataAttributes.Customizations;

namespace AutoFixture.Xunit2.MoqDataAttributes
{
    public class AutoApiMoqDataAttribute : AutoDataAttribute
    {
        public AutoApiMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture();

                fixture.Customize(new ApiControllerCustomization())
                    .Customize(new AutoMoqCustomization())
                    .Behaviors.Add(new OmitOnRecursionBehavior());

                return fixture;
            })
        {
        }
    }
}