namespace System;

public static class TypeExtensions
{
    public static IEnumerable<Type> Derives(
        this IEnumerable<Type> allTypes,
        Type baseType)
    {
        ArgumentNullException.ThrowIfNull(baseType);

        return baseType.IsGenericType
            ? allTypes.DerivesGeneric(baseType)
            : allTypes.DerivesNonGeneric(baseType);
    }

    private static IEnumerable<Type> DerivesGeneric(
        this IEnumerable<Type> allTypes,
        Type baseType)
    {
        ArgumentNullException.ThrowIfNull(baseType);

        return allTypes
            .Where(t =>
                t.BaseType != null
                && t.BaseType.IsGenericType
                && t.BaseType.GetGenericTypeDefinition() == baseType)
            .DerivesRecursively(allTypes);
    }

    private static IEnumerable<Type> DerivesNonGeneric(
        this IEnumerable<Type> allTypes,
        Type baseType)
    {
        ArgumentNullException.ThrowIfNull(baseType);

        return allTypes
            .Where(t => t != baseType && baseType.IsAssignableFrom(t))
            .DerivesRecursively(allTypes);
    }

    private static IEnumerable<Type> DerivesRecursively(
        this IEnumerable<Type> derivedTypes,
        IEnumerable<Type> allTypes)
    {
        foreach (var derivedType in derivedTypes)
        {
            yield return derivedType;

            var recursiveTypes = Derives(allTypes, derivedType);

            foreach (var recursiveType in recursiveTypes)
            {
                yield return recursiveType;
            }
        }
    }
}
