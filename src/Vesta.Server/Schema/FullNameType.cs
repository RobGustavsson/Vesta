using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class FullNameType : ObjectType<FullName>
    {
        protected override void Configure(IObjectTypeDescriptor<FullName> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.FirstName)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.LastName)
                .NonNullType<StringType>();
        }
    }
}