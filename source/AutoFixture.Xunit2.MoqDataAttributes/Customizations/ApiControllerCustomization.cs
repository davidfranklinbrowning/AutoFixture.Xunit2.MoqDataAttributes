using System;
using AutoFixture.Kernel;

namespace AutoFixture.Xunit2.MoqDataAttributes.Customizations
{
    internal class ApiControllerCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new FilteringSpecimenBuilder(
                    new Postprocessor(
                        new MethodInvoker(
                            new ModestConstructorQuery()),
                        new ApiControllerFiller()),
                    new ApiControllerSpecification()));
        }

        private class ApiControllerFiller : ISpecimenCommand
        {
            public void Execute(object specimen, ISpecimenContext context)
            {
                if (specimen == null)
                    throw new ArgumentNullException("specimen");
                if (context == null)
                    throw new ArgumentNullException("context");

                var target = specimen as Microsoft.AspNetCore.Mvc.Controller;
                if (target == null)
                    throw new ArgumentException(
                        "The specimen must be an instance of ApiController.",
                        "specimen");


            }
        }

        private class ApiControllerSpecification : IRequestSpecification
        {
            public bool IsSatisfiedBy(object request)
            {
                var requestType = request as Type;
                if (requestType == null)
                    return false;
                return typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(requestType);
            }
        }
    }
}
