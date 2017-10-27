using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WebApiReferenceImpl.Core.Reflection
{
    public interface Accessor
    {
        string FieldName { get; }

        Type PropertyType { get; }
        PropertyInfo InnerProperty { get; }
        Type DeclaringType { get; }
        string Name { get; }
        void SetValue(object target, object propertyValue);
        object GetValue(object target);
        Type OwnerType { get; }

        Accessor GetChildAccessor<T>(Expression<Func<T, object>> expression);
        //string ResolveName();
    }
}