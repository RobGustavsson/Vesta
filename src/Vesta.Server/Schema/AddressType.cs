using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class AddressType : ObjectType<Address>
    {
        protected override void Configure(IObjectTypeDescriptor<Address> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.Town)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Street)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.ZipCode)
                .NonNullType<StringType>();
        }
    }
}