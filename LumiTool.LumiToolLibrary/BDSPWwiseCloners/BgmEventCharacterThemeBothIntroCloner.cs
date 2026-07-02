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
                // TODO
            },
            new List<(int segmentIndex, int trackIndex, uint trackID, int playlistItemIndex, bool isDS, bool isLoop)>()
            {
                // TODO
            }, loopData, dsLoopData, 0, 0, 0, 0); // TODO: IDs
        }
    }
}
