namespace LumiTool.Data.Wwise
{
    public class ActionPlay : Action
    {
        public byte fadeCurve;
        public uint bankID;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            fadeCurve = Utils.ReadUInt8(wd);
            bankID = Utils.ReadUInt32(wd);
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.Add(fadeCurve);
            b.AddRange(Utils.GetBytes(bankID));
            return b;
        }

        public override string ToString()
        {
            return $"[ActionPlay ({actionType}) of ID {id}] Plays {idExt} in Bank {bankID}";
        }
    }
}
