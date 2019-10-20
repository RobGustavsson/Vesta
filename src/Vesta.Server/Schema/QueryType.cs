using HotChocolate.Types;

namespace Vesta.Server.Schema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(q => q.GetCustomers(default))
                .NonNullListType<CustomerType>();

            descriptor
                .Field(q => q.GetCustomer(default, default))
                .NonNullType<CustomerType>();
        }
    }
}
