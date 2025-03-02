namespace LumiTool.Data.Wwise
{
    public class MusicTrack : HircItem
    {
        public bool overrideParentMidiTempo;
        public bool overrideParentMidiTarget;
        public bool midiTargetTypeBus;
        public uint sourceCount;
        public List<BankSourceData> source;
        public uint playlistItemCount;
        public List<TrackSrcInfo> playlist;
        public uint subTrackCount;
        public uint clipAutomationItemCount;
        public List<ClipAutomation> items;
        public NodeBaseParams nodeBaseParams;
        public byte trackType;
        public SwitchParams switchParams;
        public TransParams transParams;
        public int lookAheadTime;

        public MusicTrack Clone()
        {
            MusicTrack mt = (MusicTrack)this.MemberwiseClone();
            mt.source = new();
            foreach (BankSourceData bsd in source)
                mt.source.Add(bsd.Clone());
            mt.playlist = new();
            foreach (TrackSrcInfo tsi in playlist)
                mt.playlist.Add(tsi.Clone());
            mt.items = new();
            foreach (ClipAutomation ca in items)
                mt.items.Add(ca.Clone());
            mt.nodeBaseParams = nodeBaseParams.Clone();
            if (switchParams != null)
                mt.switchParams = switchParams.Clone();
            if (transParams != null)
                mt.transParams = transParams.Clone();
            return mt;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            source = new();
            playlist = new();
            items = new();
            nodeBaseParams = new();
            bool[] flags = Utils.ReadFlags(wd);
            overrideParentMidiTempo = flags[1];
            overrideParentMidiTarget = flags[2];
            midiTargetTypeBus = flags[3];
            sourceCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < sourceCount; i++)
            {
                BankSourceData bsd = new();
                bsd.Deserialize(wd);
                source.Add(bsd);
            }
            playlistItemCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < playlistItemCount; i++)
            {
                TrackSrcInfo tsi = new();
                tsi.Deserialize(wd);
                playlist.Add(tsi);
            }
            subTrackCount = Utils.ReadUInt32(wd);
            clipAutomationItemCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < clipAutomationItemCount; i++)
            {
                ClipAutomation ca = new();
                ca.Deserialize(wd);
                items.Add(ca);
            }
            nodeBaseParams.Deserialize(wd);
            trackType = Utils.ReadUInt8(wd);
            switch (trackType)
            {
                case 3:
                    switchParams = new();
                    transParams = new();
                    switchParams.Deserialize(wd);
                    transParams.Deserialize(wd);
                    break;
            }
            lookAheadTime = Utils.ReadInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            bool[] flags = { false,
                    overrideParentMidiTempo,
                    overrideParentMidiTarget,
                    midiTargetTypeBus
                };
            b0.Add(Utils.GetByte(flags));
            sourceCount = (uint)source.Count;
            b0.AddRange(Utils.GetBytes(sourceCount));
            foreach (BankSourceData bsd in source)
                b0.AddRange(bsd.Serialize());
            playlistItemCount = (uint)playlist.Count;
            b0.AddRange(Utils.GetBytes(playlistItemCount));
            foreach (TrackSrcInfo tsi in playlist)
                b0.AddRange(tsi.Serialize());
            b0.AddRange(Utils.GetBytes(subTrackCount));
            clipAutomationItemCount = (uint)items.Count;
            b0.AddRange(Utils.GetBytes(clipAutomationItemCount));
            foreach (ClipAutomation ca in items)
                b0.AddRange(ca.Serialize());
            b0.AddRange(nodeBaseParams.Serialize());
            b0.Add(trackType);
            if (switchParams != null)
                b0.AddRange(switchParams.Serialize());
            if (transParams != null)
                b0.AddRange(transParams.Serialize());
            b0.AddRange(Utils.GetBytes(lookAheadTime));
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
