namespace LumiTool.Utils
{
    public static class IDictionaryExtensions
    {
        public static void AddRange<T, U>(this IDictionary<T, U> self, IDictionary<T, U> range)
        {
            foreach (var item in range)
                self.Add(item.Key, item.Value);
        }
    }
}
