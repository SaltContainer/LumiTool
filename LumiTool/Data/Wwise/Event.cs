namespace LumiTool.Data.Wwise
{
    public class Event : HircItem
    {
        public ulong actionListSize;
        public List<uint> actionIDs;

        public Event Clone()
        {
            Event e = (Event)this.MemberwiseClone();
            e.actionIDs = new();
            e.actionIDs.AddRange(actionIDs);
            return e;
        }

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            actionIDs = new();
            actionListSize = Utils.ReadVariableInt(wd);
            for (ulong i = 0; i < actionListSize; i++)
                actionIDs.Add(Utils.ReadUInt32(wd));
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b0 = new();
            actionListSize = (ulong)actionIDs.Count;
            b0.AddRange(Utils.GetVariableIntBytes(actionListSize));
            foreach (uint i in actionIDs)
                b0.AddRange(Utils.GetBytes(i));
            sectionSize = (uint)(b0.Count + 4);

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }

        public override string ToString()
        {
            return $"[{id}] {actionListSize} action{(actionListSize != 1 ? "s" : "")}";
        }
    }
}
