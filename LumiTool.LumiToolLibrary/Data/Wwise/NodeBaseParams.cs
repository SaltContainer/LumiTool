namespace LumiTool.Data.Wwise
{
    public class NodeBaseParams : ISerializable
    {
        public NodeInitialFxParams nodeInitialFxParams;
        public byte overrideAttachmentParams;
        public uint overrideBusId;
        public uint directParentID;
        public bool priorityOverrideParent;
        public bool priorityApplyDistFactor;
        public bool overrideMidiEventsBehavior;
        public bool overrideMidiNoteTracking;
        public bool enableMidiNoteTracking;
        public bool isMidiBreakLoopOnNoteOff;
        public NodeInitialParams nodeInitialParams;
        public PositioningParams positioningParams;
        public AuxParams auxParams;
        public AdvSettingsParams advSettingsParams;
        public StateChunk stateChunk;
        public InitialRTPC initialRTPC;

        public NodeBaseParams Clone()
        {
            NodeBaseParams mbp = (NodeBaseParams)this.MemberwiseClone();
            mbp.nodeInitialFxParams = nodeInitialFxParams.Clone();
            mbp.nodeInitialParams = nodeInitialParams.Clone();
            mbp.positioningParams = positioningParams.Clone();
            mbp.auxParams = auxParams.Clone();
            mbp.advSettingsParams = advSettingsParams.Clone();
            mbp.stateChunk = stateChunk.Clone();
            mbp.initialRTPC = initialRTPC.Clone();
            return mbp;
        }

        public void Deserialize(WwiseData wd)
        {
            nodeInitialFxParams = new();
            nodeInitialParams = new();
            positioningParams = new();
            auxParams = new();
            advSettingsParams = new();
            stateChunk = new();
            initialRTPC = new();
            nodeInitialFxParams.Deserialize(wd);
            overrideAttachmentParams = Utils.ReadUInt8(wd);
            overrideBusId = Utils.ReadUInt32(wd);
            directParentID = Utils.ReadUInt32(wd);
            bool[] flags = Utils.ReadFlags(wd);
            priorityOverrideParent = flags[0];
            priorityApplyDistFactor = flags[1];
            overrideMidiEventsBehavior = flags[2];
            overrideMidiNoteTracking = flags[3];
            enableMidiNoteTracking = flags[4];
            isMidiBreakLoopOnNoteOff = flags[5];
            nodeInitialParams.Deserialize(wd);
            positioningParams.Deserialize(wd);
            auxParams.Deserialize(wd);
            advSettingsParams.Deserialize(wd);
            stateChunk.Deserialize(wd);
            initialRTPC.Deserialize(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(nodeInitialFxParams.Serialize());
            b.Add(overrideAttachmentParams);
            b.AddRange(Utils.GetBytes(overrideBusId));
            b.AddRange(Utils.GetBytes(directParentID));
            bool[] flags = {
                    priorityOverrideParent,
                    priorityApplyDistFactor,
                    overrideMidiEventsBehavior,
                    overrideMidiNoteTracking,
                    enableMidiNoteTracking,
                    isMidiBreakLoopOnNoteOff
                };
            b.Add(Utils.GetByte(flags));
            b.AddRange(nodeInitialParams.Serialize());
            b.AddRange(positioningParams.Serialize());
            b.AddRange(auxParams.Serialize());
            b.AddRange(advSettingsParams.Serialize());
            b.AddRange(stateChunk.Serialize());
            b.AddRange(initialRTPC.Serialize());
            return b;
        }
    }
}
