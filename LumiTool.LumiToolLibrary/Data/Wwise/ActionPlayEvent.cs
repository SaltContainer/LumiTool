namespace LumiTool.Data.Wwise
{
    public class ActionPlayEvent : Action
    {
        public override string ToString()
        {
            return $"[ActionPlayEvent ({actionType}) of ID {id}] Plays event {idExt}";
        }
    }
}
