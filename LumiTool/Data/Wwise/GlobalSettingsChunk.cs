namespace LumiTool.Data.Wwise
{
    public class GlobalSettingsChunk : Chunk
    {
        public float volumeThreshold;
        public ushort maxNumVoicesLimitInternal;
        public ushort maxNumDangerousVirtVoicesLimitInternal;
        public uint stateGroupsCount;
        public List<StateGroup> stateGroups;
        public uint switchGroupsCount;
        public List<SwitchGroups> items;
        public uint paramsCount;
        public List<RTPCRamping> pRTPCMgr;
        public uint texturesCount;
        public List<Unk> acousticTextures;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            stateGroups = new();
            items = new();
            pRTPCMgr = new();
            acousticTextures = new();
            volumeThreshold = Utils.ReadSingle(wd);
            maxNumVoicesLimitInternal = Utils.ReadUInt16(wd);
            maxNumDangerousVirtVoicesLimitInternal = Utils.ReadUInt16(wd);
            stateGroupsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < stateGroupsCount; i++)
            {
                StateGroup sg = new();
                sg.Deserialize(wd);
                stateGroups.Add(sg);
            }
            switchGroupsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < switchGroupsCount; i++)
            {
                SwitchGroups sg = new();
                sg.Deserialize(wd);
                items.Add(sg);
            }
            paramsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < paramsCount; i++)
            {
                RTPCRamping rtpcr = new();
                rtpcr.Deserialize(wd);
                pRTPCMgr.Add(rtpcr);
            }
            texturesCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < texturesCount; i++)
            {
                Unk u = new();
                u.Deserialize(wd);
                acousticTextures.Add(u);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(Utils.GetBytes(volumeThreshold));
            b0.AddRange(Utils.GetBytes(maxNumVoicesLimitInternal));
            b0.AddRange(Utils.GetBytes(maxNumDangerousVirtVoicesLimitInternal));
            stateGroupsCount = (uint)stateGroups.Count;
            b0.AddRange(Utils.GetBytes(stateGroupsCount));
            foreach (StateGroup sg in stateGroups)
                b0.AddRange(sg.Serialize());
            switchGroupsCount = (uint)items.Count;
            b0.AddRange(Utils.GetBytes(switchGroupsCount));
            foreach (SwitchGroups sg in items)
                b0.AddRange(sg.Serialize());
            paramsCount = (uint)pRTPCMgr.Count;
            b0.AddRange(Utils.GetBytes(paramsCount));
            foreach (RTPCRamping rtpcr in pRTPCMgr)
                b0.AddRange(rtpcr.Serialize());
            texturesCount = (uint)acousticTextures.Count;
            b0.AddRange(Utils.GetBytes(texturesCount));
            foreach (Unk u in acousticTextures)
                b0.AddRange(u.Serialize());
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
