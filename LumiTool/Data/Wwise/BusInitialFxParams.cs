namespace LumiTool.Data.Wwise
{
    public class BusInitialFxParams : ISerializable
    {
        public byte fxCount;
        public byte bitsFXBypass;
        public List<FXChunk> fxChunk;
        public uint fxID0;
        public byte IsShareSet0;

        public void Deserialize(WwiseData wd)
        {
            fxCount = Utils.ReadUInt8(wd);
            if (fxCount > 0)
            {
                fxChunk = new();
                bitsFXBypass = Utils.ReadUInt8(wd);
                for (int i = 0; i < fxCount; i++)
                {
                    FXChunk fxc = new();
                    fxc.Deserialize(wd);
                    fxChunk.Add(fxc);
                }
            }
            fxID0 = Utils.ReadUInt32(wd);
            IsShareSet0 = Utils.ReadUInt8(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            if (fxChunk != null)
                fxCount = (byte)fxChunk.Count;
            b.Add(fxCount);
            if (fxCount > 0)
            {
                b.Add(bitsFXBypass);
                foreach (FXChunk fxc in fxChunk)
                    b.AddRange(fxc.Serialize());
            }
            b.AddRange(Utils.GetBytes(fxID0));
            b.Add(IsShareSet0);
            return b;
        }
    }
}
