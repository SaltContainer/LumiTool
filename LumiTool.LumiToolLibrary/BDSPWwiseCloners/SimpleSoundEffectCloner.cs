using LumiTool.Data;
using LumiTool.Data.Wwise;
using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool.BDSPWwiseCloners
{
    public class SimpleSoundEffectCloner : BaseCloner
    {
        public SimpleSoundEffectCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            uint oldEventID = engine.FNV132Hash("S_FI001");
            uint newEventID = engine.FNV132Hash(newEventName);

            engine.Log($"Creating new event {newEventID} ({newEventName})", LogLevel.Information);

            Dictionary<uint, uint> update = new();
            Dictionary<uint, uint> actionIDs = new();

            actionIDs.AddRange(CloneEventAndActions(wd, oldEventID, newEventID, 0, update));

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Clone the old Sounds
            List<Sound> allSounds = actionIDs.Select(kvp => ((ActionPlay)wd.objectsByID[kvp.Key]).idExt)
                .Select(i => ((Sound)wd.objectsByID[i]).Clone()).ToList();

            GenerateNewSoundAndSourceIDs(wd, allSounds, update);

            // Get the Sound ID -> parent ActorMixer list
            Dictionary<uint, ActorMixer> actorMixers = allSounds.Select(s => (s.id, (ActorMixer)wd.objectsByID[s.nodeBaseParams.directParentID]))
                .ToDictionary(kvp => kvp.id, kvp => kvp.Item2);

            // Add new Sound to parent ActorMixer
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
            foreach (Sound sound in allSounds)
            {
                sound.bankSourceData.streamType = 2;
                sound.bankSourceData.mediaInformation.sourceID = GetNewID(sound.bankSourceData.mediaInformation.sourceID, update);
            }

            return true;
        }
    }
}
