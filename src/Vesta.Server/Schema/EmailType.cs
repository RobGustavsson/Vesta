using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class EmailType : ObjectType<Email>
    {
        protected override void Configure(IObjectTypeDescriptor<Email> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.Value)
                .NonNullType<StringType>();
        }
    }
}