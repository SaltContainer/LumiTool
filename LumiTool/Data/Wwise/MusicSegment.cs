namespace LumiTool.Data.Wwise
{
    public class MusicSegment : HircItem
    {
        public MusicNodeParams musicNodeParams;
        public double duration;
        public uint markersCount;
        public List<MusicMarkerWwise> arrayMarkers;

        public MusicSegment Clone()
        {
            MusicSegment ms = (MusicSegment)this.MemberwiseClone();
            ms.musicNodeParams = musicNodeParams.Clone();
            ms.arrayMarkers = new();
            foreach (MusicMarkerWwise mmw in arrayMarkers)
                ms.arrayMarkers.Add(mmw.Clone());
            return ms;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            musicNodeParams = new();
            arrayMarkers = new();
            musicNodeParams.Deserialize(wd);
            duration = Utils.ReadDouble(wd);
            markersCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < markersCount; i++)
            {
                MusicMarkerWwise mmw = new();
                mmw.Deserialize(wd);
                arrayMarkers.Add(mmw);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            b0.AddRange(musicNodeParams.Serialize());
            b0.AddRange(Utils.GetBytes(duration));
            markersCount = (uint)arrayMarkers.Count;
            b0.AddRange(Utils.GetBytes(markersCount));
            foreach (MusicMarkerWwise mmw in arrayMarkers)
                b0.AddRange(mmw.Serialize());
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }
    }
}
