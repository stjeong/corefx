// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Xunit;

namespace System.Reflection.Emit.Tests
{
    public class TypeBuilderSetParent
    {
        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(SetParentNonGenericClass))]
        [InlineData(typeof(SetParentGenericClass<>))]
        [InlineData(typeof(int?))]
        [InlineData(typeof(object))]
        [InlineData(null)]
        public void SetParent(Type parent)
        {
            TypeBuilder type = Helpers.DynamicType(TypeAttributes.NotPublic);
            type.SetParent(parent);
            Assert.Equal(parent ?? typeof(object), type.BaseType);
        }

        [Fact]
        public void SetParent_TypeCreated_ThrowsInvalidOperationException()
        {
            TypeBuilder type = Helpers.DynamicType(TypeAttributes.NotPublic);
            type.CreateTypeInfo().AsType();
            Assert.Throws<InvalidOperationException>(() => type.SetParent(typeof(string)));
        }
    }

    public class SetParentNonGenericClass { }
    public class SetParentGenericClass<T> { }
}
