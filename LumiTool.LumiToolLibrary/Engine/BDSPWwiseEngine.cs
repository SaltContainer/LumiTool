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
        private BgmBattleBothIntroCloner bgmBattleBothIntroCloner;
        private PokemonCrySetCloner pokemonCrySetCloner;
        private BgmEventCharacterThemeBothIntroCloner bgmEventCharacterThemeBothIntroCloner;

        public BDSPWwiseEngine(LumiToolEngine engine)
        {
            this.engine = engine;

            bgmFieldBothIntroCloner = new BgmFieldBothIntroCloner(engine);
            bgmFieldBDSPWithIntroCloner = new BgmFieldBDSPWithIntroCloner(engine);
            bgmFieldBothNoIntroCloner = new BgmFieldBothNoIntroCloner(engine);
            bgmBattleBothIntroCloner = new BgmBattleBothIntroCloner(engine);
            pokemonCrySetCloner = new PokemonCrySetCloner(engine);
            bgmEventCharacterThemeBothIntroCloner = new BgmEventCharacterThemeBothIntroCloner(engine);
        }

        public bool MakeNewBDSPWwiseEvent(WwiseData wd, BDSPWwiseEventType eventType, string newEventName, WwiseLoopPointData loopData, WwiseLoopPointData dsLoopData)
        {
            switch (eventType)
            {
                case BDSPWwiseEventType.BGM_FIELD_WITH_INTRO:
                    return bgmFieldBothIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                case BDSPWwiseEventType.BGM_FIELD_BDSP_INTRO:
                    return bgmFieldBDSPWithIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                case BDSPWwiseEventType.BGM_FIELD_NO_INTRO:
                    return bgmFieldBothNoIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                case BDSPWwiseEventType.BGM_BATTLE_WITH_INTRO:
                    return bgmBattleBothIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                case BDSPWwiseEventType.POKEMON_CRY_SET:
                    return pokemonCrySetCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                case BDSPWwiseEventType.BGM_EVENT_CHARACTER_THEME_WITH_INTRO:
                    return bgmEventCharacterThemeBothIntroCloner.ExecuteClone(wd, newEventName, loopData, dsLoopData);

                default:
                    engine.Log("No code is set up to clone this event at this time.", LogLevel.Error);
                    return false;
            }
        }
    }
}
