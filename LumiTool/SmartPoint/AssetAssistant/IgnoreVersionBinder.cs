using System.Runtime.Serialization;

namespace SmartPoint.AssetAssistant
{
    public class IgnoreVersionBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type type = Type.GetType(typeName + ", LumiTool, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", false);
            if (type != null)
                return type;

            return Type.GetType(typeName, false);
        }
    }
}
