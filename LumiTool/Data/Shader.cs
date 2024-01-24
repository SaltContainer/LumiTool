namespace LumiTool.Data
{
    public class Shader
    {
        public string Name { get; }
        public long PathID { get; }

        public Shader(string name, long pathID)
        {
            Name = name;
            PathID = pathID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
