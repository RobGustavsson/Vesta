using HotChocolate.Types;
using Vesta.Server.Domain;

namespace Vesta.Server.Schema
{
    public class AnimalType : ObjectType<Animal>
    {
        protected override void Configure(IObjectTypeDescriptor<Animal> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(x => x.Id)
                .NonNullType<IdType>();

            descriptor
                .Field(x => x.Exterior)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Name)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.Gender)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.LocatedAt)
                .NonNullType<AddressType>();

            descriptor
                .Field(x => x.MedicalHistory)
                .NonNullType<StringType>();

            descriptor
                .Field(x => x.YearOfBirth)
                .NonNullType<IntType>();

            descriptor
                .Field(x => x.Journals)
                .NonNullListType<JournalType>();
        }
    }
}