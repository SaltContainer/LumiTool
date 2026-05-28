using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.BDSPWwiseCloners;

namespace LumiTool.Engine
{
    public class BDSPWwiseEngine
    {
        private LumiToolEngine engine;
        private BgmFieldC01NightCloner bgmFieldC01NightCloner;

        public BDSPWwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;
            this.bgmFieldC01NightCloner = new BgmFieldC01NightCloner(engine);
        }

        public void MakeNewBDSPWwiseEvent(WwiseData wd, BDSPWwiseEventType eventType, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            switch (eventType)
            {
                case BDSPWwiseEventType.BGM_FIELD_C01_NIGHT:
                    bgmFieldC01NightCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);
                    break;
            }
        }
    }
}
