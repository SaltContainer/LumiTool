namespace LumiTool.Data.Wwise
{
    public class Bus : HircItem
    {
        public uint overrideBusId;
        public uint idDeviceShareset;
        public BusInitialParams busInitialParams;
        public int recoveryTime;
        public float maxDuckVolume;
        public uint ducksCount;
        public List<DuckInfo> toDuckList;
        public BusInitialFxParams busInitialFxParams;
        public byte overrideAttachmentParams;
        public InitialRTPC initialRTPC;
        public StateChunk stateChunk;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            busInitialParams = new();
            toDuckList = new();
            busInitialFxParams = new();
            initialRTPC = new();
            stateChunk = new();
            overrideBusId = Utils.ReadUInt32(wd);
            if (overrideBusId == 0)
                idDeviceShareset = Utils.ReadUInt32(wd);
            busInitialParams.Deserialize(wd);
            recoveryTime = Utils.ReadInt32(wd);
            maxDuckVolume = Utils.ReadSingle(wd);
            ducksCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < ducksCount; i++)
            {
                DuckInfo di = new();
                di.Deserialize(wd);
                toDuckList.Add(di);
            }
            busInitialFxParams.Deserialize(wd);
            overrideAttachmentParams = Utils.ReadUInt8(wd);
            initialRTPC.Deserialize(wd);
            stateChunk.Deserialize(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(Utils.GetBytes(overrideBusId));
            if (overrideBusId == 0)
                b0.AddRange(Utils.GetBytes(idDeviceShareset));
            b0.AddRange(busInitialParams.Serialize());
            b0.AddRange(Utils.GetBytes(recoveryTime));
            b0.AddRange(Utils.GetBytes(maxDuckVolume));
            ducksCount = (uint)toDuckList.Count;
            b0.AddRange(Utils.GetBytes(ducksCount));
            foreach (DuckInfo di in toDuckList)
                b0.AddRange(di.Serialize());
            b0.AddRange(busInitialFxParams.Serialize());
            b0.Add(overrideAttachmentParams);
            b0.AddRange(initialRTPC.Serialize());
            b0.AddRange(stateChunk.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
