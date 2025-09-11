namespace LumiTool.Data.Wwise
{
    public class AuxParams : ISerializable
    {
        public bool unkFlag0;
        public bool unkFlag1;
        public bool overrideUserAuxSends;
        public bool hasAux;
        public bool overrideReflectionsAuxBus;
        public uint[] auxIDs;
        public uint reflectionsAuxBus;

        public AuxParams Clone()
        {
            AuxParams ap = (AuxParams)this.MemberwiseClone();
            if (auxIDs != null)
            {
                ap.auxIDs = new uint[auxIDs.Length];
                for (int i = 0; i < auxIDs.Length; i++)
                    ap.auxIDs[i] = auxIDs[i];
            }
            return ap;
        }

        public void Deserialize(WwiseData wd)
        {
            bool[] flags = Utils.ReadFlags(wd);
            unkFlag0 = flags[0];
            unkFlag1 = flags[1];
            overrideUserAuxSends = flags[2];
            hasAux = flags[3];
            overrideReflectionsAuxBus = flags[4];
            if (hasAux)
            {
                auxIDs = new uint[4];
                for (int i = 0; i < 4; i++)
                    auxIDs[i] = Utils.ReadUInt32(wd);
            }
            reflectionsAuxBus = Utils.ReadUInt32(wd);
        }

        public IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            bool[] flags = {
                    unkFlag0,
                    unkFlag1,
                    overrideUserAuxSends,
                    hasAux,
                    overrideReflectionsAuxBus
                };
            b.Add(Utils.GetByte(flags));
            if (auxIDs != null)
                foreach (uint i in auxIDs)
                    b.AddRange(Utils.GetBytes(i));
            b.AddRange(Utils.GetBytes(reflectionsAuxBus));
            return b;
        }
    }
}
