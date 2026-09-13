using LumiTool.Data;
using LumiTool.Data.Wwise;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public class SimpleFanfareCloner : BaseCloner
    {
        public SimpleFanfareCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            uint oldEventID = engine.FNV132Hash("M_FI001");
            uint newEventID = engine.FNV132Hash(newEventName);

            engine.Log($"Creating new event {newEventID} ({newEventName})", LogLevel.Information);

            Dictionary<uint, uint> update = new();
            Dictionary<uint, uint> actionIDs = new();

            actionIDs.AddRange(CloneEventAndActions(wd, oldEventID, newEventID, 0, update));

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Clone the old SwitchCntrs
            List<SwitchCntr> allSwitchCntrs = actionIDs.Select(kvp => ((ActionPlay)wd.objectsByID[kvp.Key]).idExt)
                .Select(i => ((SwitchCntr)wd.objectsByID[i]).Clone()).ToList();

            // Clone the old Sounds
            List<(SwitchCntr, List<Sound>)> allSounds = allSwitchCntrs.Select(sc => (sc, sc.children.childIDs.Select(c => ((Sound)wd.objectsByID[c]).Clone()).ToList())).ToList();

            foreach (var (sc, sounds) in allSounds)
                GenerateNewSwitchCntrAndSourceIDs(wd, sc, sounds, update, 349208412, 119304627);

            // Get the SwitchCntr ID -> parent ActorMixer list
            Dictionary<uint, ActorMixer> actorMixers = allSwitchCntrs.Select(sc => (sc.id, (ActorMixer)wd.objectsByID[sc.nodeBaseParams.directParentID]))
                .ToDictionary(kvp => kvp.id, kvp => kvp.Item2);

            // Add new SwitchCntr to parent ActorMixer
            foreach (var (sid, am) in actorMixers)
                am.children.childIDs.Add(sid);

            // Adjust new Actions
            List<ActionPlay> actions = actionIDs.Select(kvp => (ActionPlay)wd.objectsByID[kvp.Value]).ToList();
            foreach (ActionPlay action in actions)
            {
                action.id = GetNewID(action.id, update);
                action.idExt = GetNewID(action.idExt, update);
            }

            // Adjust new Sounds
            foreach (var (sc, sounds) in allSounds)
            {
                foreach (Sound sound in sounds)
                {
                    sound.nodeBaseParams.directParentID = GetNewID(sound.nodeBaseParams.directParentID, update);
                    sound.bankSourceData.streamType = 2;
                    sound.bankSourceData.mediaInformation.sourceID = GetNewID(sound.bankSourceData.mediaInformation.sourceID, update);
                }
            }

            return true;
        }
    }
}

