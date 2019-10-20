using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.Id)
                .NonNullType<IdType>();

            descriptor
                .Field(x => x.Number)
                .NonNullType<IntType>();

            descriptor
                .Field(x => x.Name)
                .NonNullType<FullNameType>();

            descriptor
                .Field(x => x.Address)
                .NonNullType<AddressType>();

            descriptor
                .Field(x => x.Email)
                .NonNullType<EmailType>();

            descriptor
                .Field(q => q.Animals)
                .NonNullListType<AnimalType>();
        }

    }
}