namespace LumiTool.Utils
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> FlattenRecursive<T>(this IEnumerable<T> self, Func<T, IEnumerable<T>> selector)
        {
            foreach (var item in self)
            {
                yield return item;
                foreach (var subItem in FlattenRecursive(selector(item), selector))
                    yield return subItem;
            }
        }
    }
}
