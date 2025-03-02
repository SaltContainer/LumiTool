namespace LumiTool.Data.Wwise
{
    public abstract class HircItem : WwiseObject
    {
        public byte hircType;
        public uint sectionSize;
        public uint id;

        public override void Deserialize(WwiseData wd)
        {
            hircType = Utils.ReadUInt8(wd);
            sectionSize = Utils.ReadUInt32(wd);
            id = Utils.ReadUInt32(wd);
            wd.objectsByID[id] = this;
        }

        public static HircItem Create(WwiseData wd)
        {
            byte hircType = wd.buffer[wd.offset];
            HircItem hi = hircType switch
            {
                1 => new State(),
                2 => new Sound(),
                3 => Action.GetInstance(wd),
                4 => new Event(),
                5 => new RanSeqCntr(),
                6 => new SwitchCntr(),
                7 => new ActorMixer(),
                8 => new Bus(),
                9 => new LayerCntr(),
                10 => new MusicSegment(),
                11 => new MusicTrack(),
                12 => new MusicSwitchCntr(),
                13 => new MusicRanSeqCntr(),
                14 => new Attenuation(),
                16 => new FxCustom(),
                17 => new FxCustom(),
                18 => new Bus(),
                21 => new AudioDevice(),
                _ => throw new NotImplementedException("HircType " + hircType + " at " + wd.offset),
            };
            hi.Deserialize(wd);
            return hi;
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.Add(hircType);
            b.AddRange(Utils.GetBytes(sectionSize));
            b.AddRange(Utils.GetBytes(id));
            return b;
        }
    }
}
