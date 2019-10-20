using HotChocolate.Types;

namespace Vesta.Server.Schema
{
    public static class DescriptorExtensions
    {
        public static IObjectFieldDescriptor NonNullType<T>(this IObjectFieldDescriptor descriptor) where T : class, IOutputType
        {
            return descriptor.Type<NonNullType<T>>();
        }

        public static IObjectFieldDescriptor NonNullListType<T>(this IObjectFieldDescriptor descriptor) where T : class, IOutputType
        {
            return descriptor.NonNullType<ListType<NonNullType<T>>>();
        }
    }
}