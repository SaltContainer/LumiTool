using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Utils;
using System.Text.RegularExpressions;

namespace LumiTool.BDSPWwiseCloners
{
    public class PokemonCrySetCloner : BaseCloner
    {
        public PokemonCrySetCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            List<Dictionary<string, uint>> oldEvents = new List<Dictionary<string, uint>>()
            {
                new Dictionary<string, uint>()
                {
                    { "PLAY_PV_001_00_00", engine.FNV132Hash("PLAY_PV_001_00_00") },
                    { "PLAY_PV_001_00_01", engine.FNV132Hash("PLAY_PV_001_00_01") },
                    { "PLAY_PV_001_00_02", engine.FNV132Hash("PLAY_PV_001_00_02") },
                    { "PLAY_PV_001_00_03", engine.FNV132Hash("PLAY_PV_001_00_03") },
                    { "PLAY_PV_001_00_04", engine.FNV132Hash("PLAY_PV_001_00_04") },
                },
                new Dictionary<string, uint>()
                {
                    { "PLAY_PV_EV_001_00_00", engine.FNV132Hash("PLAY_PV_EV_001_00_00") },
                    { "PLAY_PV_EV_001_00_01", engine.FNV132Hash("PLAY_PV_EV_001_00_01") },
                    { "PLAY_PV_EV_001_00_02", engine.FNV132Hash("PLAY_PV_EV_001_00_02") },
                    { "PLAY_PV_EV_001_00_03", engine.FNV132Hash("PLAY_PV_EV_001_00_03") },
                    { "PLAY_PV_EV_001_00_04", engine.FNV132Hash("PLAY_PV_EV_001_00_04") },
                },
                new Dictionary<string, uint>()
                {
                    { "PLAY_PV_BTL_001_00_00", engine.FNV132Hash("PLAY_PV_BTL_001_00_00") },
                    { "PLAY_PV_BTL_001_00_01", engine.FNV132Hash("PLAY_PV_BTL_001_00_01") },
                    { "PLAY_PV_BTL_001_00_02", engine.FNV132Hash("PLAY_PV_BTL_001_00_02") },
                    { "PLAY_PV_BTL_001_00_03", engine.FNV132Hash("PLAY_PV_BTL_001_00_03") },
                    { "PLAY_PV_BTL_001_00_04", engine.FNV132Hash("PLAY_PV_BTL_001_00_04") },
                },
            };
            List<Dictionary<string, uint>> newEvents = new List<Dictionary<string, uint>>()
            {
                new Dictionary<string, uint>(), new Dictionary<string, uint>(), new Dictionary<string, uint>(),
            };

            // Figure out how to name the new events
            var regexMatch = Regex.Match(newEventName, @"^PLAY_PV_(?:|EV_|BTL_)(\d{3,})_(\d{2})_0[01234*]$");
            if (regexMatch.Success)
            {
                var monsno = regexMatch.Groups[1].Value;
                var formno = regexMatch.Groups[2].Value;

                AddEventNameAndHashToDict(newEvents[0], $"PLAY_PV_{monsno}_{formno}_00");
                AddEventNameAndHashToDict(newEvents[0], $"PLAY_PV_{monsno}_{formno}_01");
                AddEventNameAndHashToDict(newEvents[0], $"PLAY_PV_{monsno}_{formno}_02");
                AddEventNameAndHashToDict(newEvents[0], $"PLAY_PV_{monsno}_{formno}_03");
                AddEventNameAndHashToDict(newEvents[0], $"PLAY_PV_{monsno}_{formno}_04");

                AddEventNameAndHashToDict(newEvents[1], $"PLAY_PV_EV_{monsno}_{formno}_00");
                AddEventNameAndHashToDict(newEvents[1], $"PLAY_PV_EV_{monsno}_{formno}_01");
                AddEventNameAndHashToDict(newEvents[1], $"PLAY_PV_EV_{monsno}_{formno}_02");
                AddEventNameAndHashToDict(newEvents[1], $"PLAY_PV_EV_{monsno}_{formno}_03");
                AddEventNameAndHashToDict(newEvents[1], $"PLAY_PV_EV_{monsno}_{formno}_04");

                AddEventNameAndHashToDict(newEvents[2], $"PLAY_PV_BTL_{monsno}_{formno}_00");
                AddEventNameAndHashToDict(newEvents[2], $"PLAY_PV_BTL_{monsno}_{formno}_01");
                AddEventNameAndHashToDict(newEvents[2], $"PLAY_PV_BTL_{monsno}_{formno}_02");
                AddEventNameAndHashToDict(newEvents[2], $"PLAY_PV_BTL_{monsno}_{formno}_03");
                AddEventNameAndHashToDict(newEvents[2], $"PLAY_PV_BTL_{monsno}_{formno}_04");
            }
            else
            {
                engine.Log($"Could not figure out how to name the new events based off of \"{newEventName}\"", LogLevel.Error);
                return false;
            }

            // If all the events currently exist
            bool existingEvent = newEvents.All(e => e.All(kvp => wd.objectsByID.ContainsKey(kvp.Value)));

            if (!existingEvent)
            {
                foreach (var newEventSet in newEvents)
                    engine.Log($"Creating new events {string.Join(", ", newEventSet.Keys)} ({string.Join(", ", newEventSet.Values)})", LogLevel.Information);
            }

            Dictionary<uint, uint> update = new();
            List<Dictionary<uint, uint>> actionIDs = new();

            if (!existingEvent)
            {
                for (int i=0; i<newEvents.Count; i++)
                {
                    var actionIDSet = new Dictionary<uint, uint>();
                    foreach (var (oldEvent, newEvent) in oldEvents[i].Zip(newEvents[i]))
                        actionIDSet.AddRange(CloneEventAndActions(wd, oldEvent.Value, newEvent.Value, update));

                    actionIDs.Add(actionIDSet);
                }
            }
            else
            {
                for (int i=0; i<newEvents.Count; i++)
                {
                    var actionIDSet = new Dictionary<uint, uint>();
                    foreach (var (oldEvent, newEvent) in oldEvents[i].Zip(newEvents[i]))
                        actionIDSet.AddRange(((Event)wd.objectsByID[oldEvent.Value]).actionIDs
                            .Zip(((Event)wd.objectsByID[newEvent.Value]).actionIDs)
                            .ToDictionary(kvp => kvp.First, kvp => kvp.Second));

                    actionIDs.Add(actionIDSet);
                }
            }

            HircChunk hc = (HircChunk)wd.banks[0].chunks.First(c => c is HircChunk);

            // Clone the old Sounds
            List<Sound> allSounds = actionIDs.SelectMany(dict => dict.Select(kvp => ((ActionPlay)wd.objectsByID[kvp.Key]).idExt))
                .Select(i => ((Sound)wd.objectsByID[i]).Clone()).ToList();

            GenerateNewSoundAndSourceIDs(wd, allSounds, update);

            // Split the new Sounds (Old Actions -> ID Ext -> Updated ID -> Sound)
            List<List<Sound>> splitSounds = actionIDs.Select(dict => dict.Select(kvp => (Sound)wd.objectsByID[update[((ActionPlay)wd.objectsByID[kvp.Key]).idExt]]).ToList()).ToList();

            // Clone the ActorMixer and adjust hierarchy
            CloneActorMixer(wd, splitSounds[0], 122632777, 440545423, update);
            CloneActorMixer(wd, splitSounds[1], 3889686, 647490159, update);
            CloneActorMixer(wd, splitSounds[2], 591188006, 721736679, update);

            if (existingEvent)
            {
                // Add the stubbed Sound ID -> new Sound ID mapping
                update.AddRange(actionIDs.SelectMany(dict => dict.Select(kvp => (((ActionPlay)wd.objectsByID[kvp.Value]).idExt, update[((ActionPlay)wd.objectsByID[kvp.Key]).idExt])))
                    .ToDictionary(kvp => kvp.idExt, kvp => kvp.Item2));
            }

            // Adjust new Actions
            List<ActionPlay> actions = actionIDs.SelectMany(dict => dict.Select(kvp => (ActionPlay)wd.objectsByID[kvp.Value])).ToList();
            foreach (ActionPlay action in actions)
            {
                action.id = GetNewID(action.id, update);
                action.idExt = GetNewID(action.idExt, update);
            }

            // Adjust new Sounds
            foreach (Sound sound in allSounds)
            {
                sound.nodeBaseParams.directParentID = GetNewID(sound.nodeBaseParams.directParentID, update);
                sound.bankSourceData.mediaInformation.sourceID = GetNewID(sound.bankSourceData.mediaInformation.sourceID, update);
            }

            // Log the final changes (Event -> Source)
            foreach (var (ev, id) in newEvents[0])
            {
                var eventObj = wd.objectsByID[id] as Event;
                var action = wd.objectsByID[eventObj.actionIDs[0]] as ActionPlay;
                var sound = wd.objectsByID[action.idExt] as Sound;
                engine.Log($"{ev} → {sound.bankSourceData.mediaInformation.sourceID}", LogLevel.Information);
            }

            return true;
        }
    }
}
