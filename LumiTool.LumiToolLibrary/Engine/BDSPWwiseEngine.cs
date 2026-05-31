using LumiTool.Data.Wwise;
using LumiTool.Data;
using LumiTool.BDSPWwiseCloners;

namespace LumiTool.Engine
{
    public class BDSPWwiseEngine
    {
        private LumiToolEngine engine;

        private BgmFieldBothIntroCloner bgmFieldBothIntroCloner;
        private BgmFieldBDSPWithIntroCloner bgmFieldBDSPWithIntroCloner;
        private BgmFieldBothNoIntroCloner bgmFieldBothNoIntroCloner;

        public BDSPWwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;
            this.bgmFieldBothIntroCloner = new BgmFieldBothIntroCloner(engine);
            this.bgmFieldBDSPWithIntroCloner = new BgmFieldBDSPWithIntroCloner(engine);
            this.bgmFieldBothNoIntroCloner = new BgmFieldBothNoIntroCloner(engine);
        }

        public void MakeNewBDSPWwiseEvent(WwiseData wd, BDSPWwiseEventType eventType, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            switch (eventType)
            {
                case BDSPWwiseEventType.BGM_FIELD_WITH_INTRO:
                    bgmFieldBothIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);
                    break;

                case BDSPWwiseEventType.BGM_FIELD_BDSP_INTRO:
                    bgmFieldBDSPWithIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);
                    break;

                case BDSPWwiseEventType.BGM_FIELD_DS_INTRO:
                    // TODO
                    break;

                case BDSPWwiseEventType.BGM_FIELD_NO_INTRO:
                    bgmFieldBothNoIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);
                    break;
            }
        }
    }
}
