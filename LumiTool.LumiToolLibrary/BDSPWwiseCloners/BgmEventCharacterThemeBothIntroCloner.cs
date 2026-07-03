using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.Engine;

namespace LumiTool.BDSPWwiseCloners
{
    public class BgmEventCharacterThemeBothIntroCloner : BgmEventBaseCloner
    {
        public BgmEventCharacterThemeBothIntroCloner(LumiToolEngine engine) : base(engine) { }

        public override bool ExecuteClone(WwiseData wd, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            return ExecuteBgmEventClone(wd, "EV003", newEventName, new List<(int segmentIndex, uint segmentID, bool isDS, bool isLoop)>()
            {
                (0, 78203031,  false, false), // First segment (Regular)
                (1, 475432128, false, true),  // Second segment (Regular)
                (0, 414942274, true,  true),  // First segment (DS)
                (1, 489114199, true,  false), // Second segment (DS)
            },
            new List<(int segmentIndex, int trackIndex, uint trackID, int playlistItemIndex, bool isDS, bool isLoop)>()
            {
                (0, 0, 540561211, 0, false, false), // First segment, first track, first playlist item (Regular)
                (1, 0, 601111539, 0, false, true),  // Second segment, first track, first playlist item (Regular)
                (0, 0, 265267930, 0, true,  true),  // First segment, first track, first playlist item (DS)
                (1, 0, 184288298, 0, true,  false), // Second segment, first track, first playlist item (DS)
            }, loopData, dsLoopData, 564033298, 962324772, 634139454, 289001510);
        }
    }
}
