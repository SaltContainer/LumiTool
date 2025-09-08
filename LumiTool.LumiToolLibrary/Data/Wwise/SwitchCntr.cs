namespace LumiTool.Data.Wwise
{
    public class SwitchCntr : HircItem
    {
        public NodeBaseParams nodeBaseParams;
        public byte groupType;
        public uint groupID;
        public uint defaultSwitch;
        public byte isContinuousValidation;
        public Children children;
        public uint switchGroupsCount;
        public List<SwitchPackage> switchList;
        public uint switchParamsCount;
        public List<SwitchNodeParams> paramList;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            nodeBaseParams = new();
            children = new();
            switchList = new();
            paramList = new();
            nodeBaseParams.Deserialize(wd);
            groupType = Utils.ReadUInt8(wd);
            groupID = Utils.ReadUInt32(wd);
            defaultSwitch = Utils.ReadUInt32(wd);
            isContinuousValidation = Utils.ReadUInt8(wd);
            children.Deserialize(wd);
            switchGroupsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < switchGroupsCount; i++)
            {
                SwitchPackage sp = new();
                sp.Deserialize(wd);
                switchList.Add(sp);
            }
            switchParamsCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < switchParamsCount; i++)
            {
                SwitchNodeParams snp = new();
                snp.Deserialize(wd);
                paramList.Add(snp);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(nodeBaseParams.Serialize());
            b0.Add(groupType);
            b0.AddRange(Utils.GetBytes(groupID));
            b0.AddRange(Utils.GetBytes(defaultSwitch));
            b0.Add(isContinuousValidation);
            b0.AddRange(children.Serialize());
            switchGroupsCount = (uint)switchList.Count;
            b0.AddRange(Utils.GetBytes(switchGroupsCount));
            foreach (SwitchPackage sp in switchList)
                b0.AddRange(sp.Serialize());
            switchParamsCount = (uint)paramList.Count;
            b0.AddRange(Utils.GetBytes(switchParamsCount));
            foreach (SwitchNodeParams snp in paramList)
                b0.AddRange(snp.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
