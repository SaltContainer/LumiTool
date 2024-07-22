using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartPoint.AssetAssistant
{
    internal static class StreamExtensions
    {
        public static void SerializeBinaryFormatter(this Stream stream, object content)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

            bf.Serialize(stream, content);
        }

        public static object DeserializeBinaryFormatter(this Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();
            IgnoreVersionBinder binder = new IgnoreVersionBinder();

            bf.Binder = binder;
            bf.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

            return bf.Deserialize(stream);
        }

        private static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            return Assembly.GetAssembly(typeof(AssetBundleDownloadManifest));
        }
    }
}
