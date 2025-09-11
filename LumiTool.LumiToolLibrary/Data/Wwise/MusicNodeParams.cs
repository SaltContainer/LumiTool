namespace LumiTool.Data.Wwise
{
    public class MusicNodeParams : ISerializable
    {
        public bool overrideParentMidiTempo;
        public bool overrideParentMidiTarget;
        public bool midiTargetTypeBus;
        public NodeBaseParams nodeBaseParams;
        public Children children;
        public MeterInfo meterInfo;
        public byte meterInfoFlag;
        public uint stingersCount;
        public List<Unk> stingers;

        public MusicNodeParams Clone()
        {
            MusicNodeParams mnp = (MusicNodeParams)this.MemberwiseClone();
            mnp.nodeBaseParams = nodeBaseParams.Clone();
            mnp.children = children.Clone();
            mnp.meterInfo = meterInfo.Clone();
            mnp.stingers = new();
            foreach (Unk u in stingers)
                mnp.stingers.Add(u.Clone());
            return mnp;
        }

        public void Deserialize(WwiseData wd)
        {
            nodeBaseParams = new();
            children = new();
            meterInfo = new();
            stingers = new();
            bool[] flags = Utils.ReadFlags(wd);
            overrideParentMidiTempo = flags[1];
            overrideParentMidiTarget = flags[2];
            midiTargetTypeBus = flags[3];
            nodeBaseParams.Deserialize(wd);
            children.Deserialize(wd);
            meterInfo.Deserialize(wd);
            meterInfoFlag = Utils.ReadUInt8(wd);
            stingersCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < stingersCount; i++)
            {
                Unk u = new();
                u.Deserialize(wd);
                stingers.Add(u);
            }
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags = { false,
                    overrideParentMidiTempo,
                    overrideParentMidiTarget,
                    midiTargetTypeBus
                };
            b.Add(Utils.GetByte(flags));
            b.AddRange(nodeBaseParams.Serialize());
            b.AddRange(children.Serialize());
            b.AddRange(meterInfo.Serialize());
            b.Add(meterInfoFlag);
            stingersCount = (uint)stingers.Count;
            b.AddRange(Utils.GetBytes(stingersCount));
            foreach (Unk u in stingers)
                b.AddRange(u.Serialize());
            return b;
        }
    }
}
