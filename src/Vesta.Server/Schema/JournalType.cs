using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class JournalType : ObjectType<Journal>
    {
        protected override void Configure(IObjectTypeDescriptor<Journal> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.Id)
                .NonNullType<IdType>();

            descriptor
                .Field(x => x.Aftercare)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Findings)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.FollowUp)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Result)
                .NonNullType<AddressType>();

            descriptor
                .Field(x => x.WorkDone)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Date)
                .NonNullType<DateTimeType>();
        }
    }
}