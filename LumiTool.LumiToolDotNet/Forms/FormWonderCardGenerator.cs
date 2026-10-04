using LumiTool.Data;
using LumiTool.Engine;
using LumiTool.Forms.Popups;

namespace LumiTool.Forms
{
    public partial class FormWonderCardGenerator : Form
    {
        LumiToolEngine engine;

        WonderCard card;

        private string[] nicknameStrings = new string[9]
        {
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
        };
        private string[] otStrings = new string[9]
        {
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
            string.Empty, string.Empty, string.Empty,
        };
        private BDSPLanguage[] nicknameLanguages = new BDSPLanguage[9]
        {
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
        };
        private BDSPLanguage[] otLanguages = new BDSPLanguage[9]
        {
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
        };

        public FormWonderCardGenerator(LumiToolEngine engine)
        {
            InitializeComponent();

            this.engine = engine;

            comboDataType.DataSource = Enum.GetValues(typeof(WonderCard.DataType));
        }

        private void UpdateComponentsOnStart()
        {
            ClearCommonTabControls();
            ClearPokemonTabControls();
            ClearItemTabControls();
            ClearOutfitTabControls();
            ClearMoneyTabControls();
            ClearUgItemTabControls();
            ClearFlagTabControls();
        }

        private void UpdateComponentsOnLoad()
        {
            ClearCommonTabControls();
            ClearPokemonTabControls();
            ClearItemTabControls();
            ClearOutfitTabControls();
            ClearMoneyTabControls();
            ClearUgItemTabControls();
            ClearFlagTabControls();

            txtCRC.Text = card.crc.ToString();
            numDeliveryID.Value = card.commonData.deliveryID;
            numTextID.Value = card.commonData.eventTextID;
            numVersionID.Value = card.commonData.romVersion;
            numReceiveFlag.Value = card.commonData.receiveFlag;
            comboDataType.SelectedItem = card.commonData.dataType;
            numCardMsgID.Value = card.commonData.cardMessageID;

            switch (comboDataType.SelectedItem)
            {
                case WonderCard.DataType.Monster:
                    nicknameStrings = card.pokemonData.nickNames.Select(x => x.name).ToArray();
                    nicknameLanguages = card.pokemonData.nickNames.Select(x => (BDSPLanguage)x.languageId).ToArray();
                    numPkmnSpecies.Value = card.pokemonData.monsNo;
                    numPkmnForm.Value = card.pokemonData.formNo;
                    numPkmnGender.Value = card.pokemonData.sex;
                    numPkmnLevel.Value = card.pokemonData.level;
                    numPkmnEgg.Value = card.pokemonData.isEgg;
                    numPkmnNature.Value = card.pokemonData.seikaku;
                    numPkmnAbility.Value = card.pokemonData.tokusei;
                    numPkmnShiny.Value = card.pokemonData.isRare;
                    numPkmnBall.Value = card.pokemonData.captureBallId;
                    numPkmnHeldItem.Value = card.pokemonData.itemId;
                    numPkmnVersion.Value = card.pokemonData.romVersion;

                    numOTID.Value = card.pokemonData.parentId;
                    otStrings = card.pokemonData.parentNames.Select(x => x.name).ToArray();
                    otLanguages = card.pokemonData.parentNames.Select(x => (BDSPLanguage)x.languageId).ToArray();
                    numOTGender.Value = card.pokemonData.parentSex;

                    numPkmnMetArea.Value = card.pokemonData.getArea;
                    numPkmnCaughtArea.Value = card.pokemonData.captureArea;
                    numPkmnCaughtLevel.Value = card.pokemonData.captureLevel;

                    numPkmnMove1.Value = card.pokemonData.skillIDs[0];
                    numPkmnMove2.Value = card.pokemonData.skillIDs[1];
                    numPkmnMove3.Value = card.pokemonData.skillIDs[2];
                    numPkmnMove4.Value = card.pokemonData.skillIDs[3];

                    numPkmnEggMove1.Value = card.pokemonData.eggSkillIDs[0];
                    numPkmnEggMove2.Value = card.pokemonData.eggSkillIDs[1];
                    numPkmnEggMove3.Value = card.pokemonData.eggSkillIDs[2];
                    numPkmnEggMove4.Value = card.pokemonData.eggSkillIDs[3];

                    numPkmnIVHP.Value = card.pokemonData.hpRandom;
                    numPkmnIVAtk.Value = card.pokemonData.attackRandom;
                    numPkmnIVDef.Value = card.pokemonData.defenseRandom;
                    numPkmnIVSpAtk.Value = card.pokemonData.spAttackRandom;
                    numPkmnIVSpDef.Value = card.pokemonData.spDefenseRandom;
                    numPkmnIVSpeed.Value = card.pokemonData.agilityRandom;

                    numPkmnEVHP.Value = card.pokemonData.hpEffort;
                    numPkmnEVAtk.Value = card.pokemonData.attackEffort;
                    numPkmnEVDef.Value = card.pokemonData.defenseEffort;
                    numPkmnEVSpAtk.Value = card.pokemonData.spAttackEffort;
                    numPkmnEVSpDef.Value = card.pokemonData.spDefenseEffort;
                    numPkmnEVSpeed.Value = card.pokemonData.agilityEffort;

                    numPkmnCool.Value = card.pokemonData.style;
                    numPkmnBeautiful.Value = card.pokemonData.beautiful;
                    numPkmnCute.Value = card.pokemonData.cute;
                    numPkmnClever.Value = card.pokemonData.clever;
                    numPkmnTough.Value = card.pokemonData.strong;
                    numPkmnSheen.Value = card.pokemonData.fur;

                    numRibbon0.Value = card.pokemonData.ribbonIds[0];
                    numRibbon1.Value = card.pokemonData.ribbonIds[1];
                    numRibbon2.Value = card.pokemonData.ribbonIds[2];
                    numRibbon3.Value = card.pokemonData.ribbonIds[3];
                    numRibbon4.Value = card.pokemonData.ribbonIds[4];
                    numRibbon5.Value = card.pokemonData.ribbonIds[5];
                    numRibbon6.Value = card.pokemonData.ribbonIds[6];
                    numRibbon7.Value = card.pokemonData.ribbonIds[7];
                    numRibbon8.Value = card.pokemonData.ribbonIds[8];
                    numRibbon9.Value = card.pokemonData.ribbonIds[9];
                    numRibbon10.Value = card.pokemonData.ribbonIds[10];
                    numRibbon11.Value = card.pokemonData.ribbonIds[11];
                    numRibbon12.Value = card.pokemonData.ribbonIds[12];
                    numRibbon13.Value = card.pokemonData.ribbonIds[13];
                    numRibbon14.Value = card.pokemonData.ribbonIds[14];
                    numRibbon15.Value = card.pokemonData.ribbonIds[15];
                    numRibbon16.Value = card.pokemonData.twoRibbonIds[0];
                    numRibbon17.Value = card.pokemonData.twoRibbonIds[1];
                    numRibbon18.Value = card.pokemonData.twoRibbonIds[2];
                    numRibbon19.Value = card.pokemonData.twoRibbonIds[3];
                    numRibbon20.Value = card.pokemonData.twoRibbonIds[4];
                    numRibbon21.Value = card.pokemonData.twoRibbonIds[5];
                    numRibbon22.Value = card.pokemonData.twoRibbonIds[6];
                    numRibbon23.Value = card.pokemonData.twoRibbonIds[7];
                    numRibbon24.Value = card.pokemonData.twoRibbonIds[8];
                    numRibbon25.Value = card.pokemonData.twoRibbonIds[9];
                    numRibbon26.Value = card.pokemonData.twoRibbonIds[10];
                    numRibbon27.Value = card.pokemonData.twoRibbonIds[11];
                    numRibbon28.Value = card.pokemonData.twoRibbonIds[12];
                    numRibbon29.Value = card.pokemonData.twoRibbonIds[13];
                    numRibbon30.Value = card.pokemonData.twoRibbonIds[14];
                    numRibbon31.Value = card.pokemonData.twoRibbonIds[15];

                    numPkmnSeed.Value = card.pokemonData.randomValue;
                    numPkmnSeedShiny.Value = card.pokemonData.colorRandomValue;
                    break;

                case WonderCard.DataType.Items:
                    numItemID1.Value = card.itemData.itemInfos[0].itemNo;
                    numItemAmount1.Value = card.itemData.itemInfos[0].num;
                    numItemID2.Value = card.itemData.itemInfos[1].itemNo;
                    numItemAmount2.Value = card.itemData.itemInfos[1].num;
                    numItemID3.Value = card.itemData.itemInfos[2].itemNo;
                    numItemAmount3.Value = card.itemData.itemInfos[2].num;
                    numItemID4.Value = card.itemData.itemInfos[3].itemNo;
                    numItemAmount4.Value = card.itemData.itemInfos[3].num;
                    numItemID5.Value = card.itemData.itemInfos[4].itemNo;
                    numItemAmount5.Value = card.itemData.itemInfos[4].num;
                    numItemID6.Value = card.itemData.itemInfos[5].itemNo;
                    numItemAmount6.Value = card.itemData.itemInfos[5].num;
                    numItemID7.Value = card.itemData.itemInfos[6].itemNo;
                    numItemAmount7.Value = card.itemData.itemInfos[6].num;
                    break;

                case WonderCard.DataType.DressUp:
                    numOutfitMale1.Value = card.dressUpData.maleDressIds[0];
                    numOutfitMale2.Value = card.dressUpData.maleDressIds[1];
                    numOutfitMale3.Value = card.dressUpData.maleDressIds[2];
                    numOutfitMale4.Value = card.dressUpData.maleDressIds[3];
                    numOutfitMale5.Value = card.dressUpData.maleDressIds[4];
                    numOutfitMale6.Value = card.dressUpData.maleDressIds[5];
                    numOutfitMale7.Value = card.dressUpData.maleDressIds[6];
                    numOutfitFemale1.Value = card.dressUpData.femaleDressIds[0];
                    numOutfitFemale2.Value = card.dressUpData.femaleDressIds[1];
                    numOutfitFemale3.Value = card.dressUpData.femaleDressIds[2];
                    numOutfitFemale4.Value = card.dressUpData.femaleDressIds[3];
                    numOutfitFemale5.Value = card.dressUpData.femaleDressIds[4];
                    numOutfitFemale6.Value = card.dressUpData.femaleDressIds[5];
                    numOutfitFemale7.Value = card.dressUpData.femaleDressIds[6];
                    break;

                case WonderCard.DataType.Money:
                    numMoney.Value = card.moneyData;
                    break;

                case WonderCard.DataType.UnderGroundItem:
                    numUgItemID1.Value = card.underGroundItemData.itemInfos[0].itemNo;
                    numUgItemAmount1.Value = card.underGroundItemData.itemInfos[0].num;
                    numUgItemID2.Value = card.underGroundItemData.itemInfos[1].itemNo;
                    numUgItemAmount2.Value = card.underGroundItemData.itemInfos[1].num;
                    numUgItemID3.Value = card.underGroundItemData.itemInfos[2].itemNo;
                    numUgItemAmount3.Value = card.underGroundItemData.itemInfos[2].num;
                    numUgItemID4.Value = card.underGroundItemData.itemInfos[3].itemNo;
                    numUgItemAmount4.Value = card.underGroundItemData.itemInfos[3].num;
                    numUgItemID5.Value = card.underGroundItemData.itemInfos[4].itemNo;
                    numUgItemAmount5.Value = card.underGroundItemData.itemInfos[4].num;
                    numUgItemID6.Value = card.underGroundItemData.itemInfos[5].itemNo;
                    numUgItemAmount6.Value = card.underGroundItemData.itemInfos[5].num;
                    numUgItemID7.Value = card.underGroundItemData.itemInfos[6].itemNo;
                    numUgItemAmount7.Value = card.underGroundItemData.itemInfos[6].num;
                    break;

                case WonderCard.DataType.FlagUnlock:
                    numFlagOn1.Value = card.dressUpData.maleDressIds[0];
                    numFlagOn2.Value = card.dressUpData.maleDressIds[1];
                    numFlagOn3.Value = card.dressUpData.maleDressIds[2];
                    numFlagOn4.Value = card.dressUpData.maleDressIds[3];
                    numFlagOn5.Value = card.dressUpData.maleDressIds[4];
                    numFlagOn6.Value = card.dressUpData.maleDressIds[5];
                    numFlagOn7.Value = card.dressUpData.maleDressIds[6];
                    numFlagOff1.Value = card.dressUpData.femaleDressIds[0];
                    numFlagOff2.Value = card.dressUpData.femaleDressIds[1];
                    numFlagOff3.Value = card.dressUpData.femaleDressIds[2];
                    numFlagOff4.Value = card.dressUpData.femaleDressIds[3];
                    numFlagOff5.Value = card.dressUpData.femaleDressIds[4];
                    numFlagOff6.Value = card.dressUpData.femaleDressIds[5];
                    numFlagOff7.Value = card.dressUpData.femaleDressIds[6];
                    break;
            }
        }

        private void ApplyComponentsToCard()
        {
            card.CreateArrays();

            card.commonData.timestamp = 0;
            card.commonData.deliveryID = (uint)numDeliveryID.Value;
            card.commonData.eventTextID = (ushort)numTextID.Value;
            card.commonData.romVersion = (ushort)numVersionID.Value;
            card.commonData.receiveFlag = (byte)numReceiveFlag.Value;
            card.commonData.dataType = (WonderCard.DataType)comboDataType.SelectedItem;
            card.commonData.cardMessageID = (byte)numCardMsgID.Value;

            switch (comboDataType.SelectedItem)
            {
                case WonderCard.DataType.Monster:
                    for (int i=0; i<card.pokemonData.nickNames.Length; i++)
                    {
                        card.pokemonData.nickNames[i].name = nicknameStrings[i];
                        card.pokemonData.nickNames[i].languageId = (byte)nicknameLanguages[i];
                    }
                    card.pokemonData.monsNo = (ushort)numPkmnSpecies.Value;
                    card.pokemonData.formNo = (byte)numPkmnForm.Value;
                    card.pokemonData.sex = (byte)numPkmnGender.Value;
                    card.pokemonData.level = (byte)numPkmnLevel.Value;
                    card.pokemonData.isEgg = (byte)numPkmnEgg.Value;
                    card.pokemonData.seikaku = (byte)numPkmnNature.Value;
                    card.pokemonData.tokusei = (byte)numPkmnAbility.Value;
                    card.pokemonData.isRare = (byte)numPkmnShiny.Value;
                    card.pokemonData.captureBallId = (ushort)numPkmnBall.Value;
                    card.pokemonData.itemId = (ushort)numPkmnHeldItem.Value;
                    card.pokemonData.romVersion = (uint)numPkmnVersion.Value;

                    card.pokemonData.parentId = (uint)numOTID.Value;
                    for (int i=0; i<card.pokemonData.parentNames.Length; i++)
                    {
                        card.pokemonData.parentNames[i].name = otStrings[i];
                        card.pokemonData.parentNames[i].languageId = (byte)otLanguages[i];
                    }
                    card.pokemonData.parentSex = (byte)numOTGender.Value;

                    card.pokemonData.getArea = (ushort)numPkmnMetArea.Value;
                    card.pokemonData.captureArea = (ushort)numPkmnCaughtArea.Value;
                    card.pokemonData.captureLevel = (byte)numPkmnCaughtLevel.Value;

                    card.pokemonData.skillIDs[0] = (ushort)numPkmnMove1.Value;
                    card.pokemonData.skillIDs[1] = (ushort)numPkmnMove2.Value;
                    card.pokemonData.skillIDs[2] = (ushort)numPkmnMove3.Value;
                    card.pokemonData.skillIDs[3] = (ushort)numPkmnMove4.Value;

                    card.pokemonData.eggSkillIDs[0] = (ushort)numPkmnEggMove1.Value;
                    card.pokemonData.eggSkillIDs[1] = (ushort)numPkmnEggMove2.Value;
                    card.pokemonData.eggSkillIDs[2] = (ushort)numPkmnEggMove3.Value;
                    card.pokemonData.eggSkillIDs[3] = (ushort)numPkmnEggMove4.Value;

                    card.pokemonData.hpRandom = (byte)numPkmnIVHP.Value;
                    card.pokemonData.attackRandom = (byte)numPkmnIVAtk.Value;
                    card.pokemonData.defenseRandom = (byte)numPkmnIVDef.Value;
                    card.pokemonData.spAttackRandom = (byte)numPkmnIVSpAtk.Value;
                    card.pokemonData.spDefenseRandom = (byte)numPkmnIVSpDef.Value;
                    card.pokemonData.agilityRandom = (byte)numPkmnIVSpeed.Value;

                    card.pokemonData.hpEffort = (byte)numPkmnEVHP.Value;
                    card.pokemonData.attackEffort = (byte)numPkmnEVAtk.Value;
                    card.pokemonData.defenseEffort = (byte)numPkmnEVDef.Value;
                    card.pokemonData.spAttackEffort = (byte)numPkmnEVSpAtk.Value;
                    card.pokemonData.spDefenseEffort = (byte)numPkmnEVSpDef.Value;
                    card.pokemonData.agilityEffort = (byte)numPkmnEVSpeed.Value;

                    card.pokemonData.style = (byte)numPkmnCool.Value;
                    card.pokemonData.beautiful = (byte)numPkmnBeautiful.Value;
                    card.pokemonData.cute = (byte)numPkmnCute.Value;
                    card.pokemonData.clever = (byte)numPkmnClever.Value;
                    card.pokemonData.strong = (byte)numPkmnTough.Value;
                    card.pokemonData.fur = (byte)numPkmnSheen.Value;

                    card.pokemonData.ribbonIds[0] = (byte)numRibbon0.Value;
                    card.pokemonData.ribbonIds[1] = (byte)numRibbon1.Value;
                    card.pokemonData.ribbonIds[2] = (byte)numRibbon2.Value;
                    card.pokemonData.ribbonIds[3] = (byte)numRibbon3.Value;
                    card.pokemonData.ribbonIds[4] = (byte)numRibbon4.Value;
                    card.pokemonData.ribbonIds[5] = (byte)numRibbon5.Value;
                    card.pokemonData.ribbonIds[6] = (byte)numRibbon6.Value;
                    card.pokemonData.ribbonIds[7] = (byte)numRibbon7.Value;
                    card.pokemonData.ribbonIds[8] = (byte)numRibbon8.Value;
                    card.pokemonData.ribbonIds[9] = (byte)numRibbon9.Value;
                    card.pokemonData.ribbonIds[10] = (byte)numRibbon10.Value;
                    card.pokemonData.ribbonIds[11] = (byte)numRibbon11.Value;
                    card.pokemonData.ribbonIds[12] = (byte)numRibbon12.Value;
                    card.pokemonData.ribbonIds[13] = (byte)numRibbon13.Value;
                    card.pokemonData.ribbonIds[14] = (byte)numRibbon14.Value;
                    card.pokemonData.ribbonIds[15] = (byte)numRibbon15.Value;
                    card.pokemonData.twoRibbonIds[0] = (byte)numRibbon16.Value;
                    card.pokemonData.twoRibbonIds[1] = (byte)numRibbon17.Value;
                    card.pokemonData.twoRibbonIds[2] = (byte)numRibbon18.Value;
                    card.pokemonData.twoRibbonIds[3] = (byte)numRibbon19.Value;
                    card.pokemonData.twoRibbonIds[4] = (byte)numRibbon20.Value;
                    card.pokemonData.twoRibbonIds[5] = (byte)numRibbon21.Value;
                    card.pokemonData.twoRibbonIds[6] = (byte)numRibbon22.Value;
                    card.pokemonData.twoRibbonIds[7] = (byte)numRibbon23.Value;
                    card.pokemonData.twoRibbonIds[8] = (byte)numRibbon24.Value;
                    card.pokemonData.twoRibbonIds[9] = (byte)numRibbon25.Value;
                    card.pokemonData.twoRibbonIds[10] = (byte)numRibbon26.Value;
                    card.pokemonData.twoRibbonIds[11] = (byte)numRibbon27.Value;
                    card.pokemonData.twoRibbonIds[12] = (byte)numRibbon28.Value;
                    card.pokemonData.twoRibbonIds[13] = (byte)numRibbon29.Value;
                    card.pokemonData.twoRibbonIds[14] = (byte)numRibbon30.Value;
                    card.pokemonData.twoRibbonIds[15] = (byte)numRibbon31.Value;

                    card.pokemonData.randomValue = (uint)numPkmnSeed.Value;
                    card.pokemonData.colorRandomValue = (uint)numPkmnSeedShiny.Value;
                    break;

                case WonderCard.DataType.Items:
                    card.itemData.itemInfos[0].itemNo = (ushort)numItemID1.Value;
                    card.itemData.itemInfos[0].num = (ushort)numItemAmount1.Value;
                    card.itemData.itemInfos[1].itemNo = (ushort)numItemID2.Value;
                    card.itemData.itemInfos[1].num = (ushort)numItemAmount2.Value;
                    card.itemData.itemInfos[2].itemNo = (ushort)numItemID3.Value;
                    card.itemData.itemInfos[2].num = (ushort)numItemAmount3.Value;
                    card.itemData.itemInfos[3].itemNo = (ushort)numItemID4.Value;
                    card.itemData.itemInfos[3].num = (ushort)numItemAmount4.Value;
                    card.itemData.itemInfos[4].itemNo = (ushort)numItemID5.Value;
                    card.itemData.itemInfos[4].num = (ushort)numItemAmount5.Value;
                    card.itemData.itemInfos[5].itemNo = (ushort)numItemID6.Value;
                    card.itemData.itemInfos[5].num = (ushort)numItemAmount6.Value;
                    card.itemData.itemInfos[6].itemNo = (ushort)numItemID7.Value;
                    card.itemData.itemInfos[6].num = (ushort)numItemAmount7.Value;
                    break;

                case WonderCard.DataType.DressUp:
                    card.dressUpData.maleDressIds[0] = (uint)numOutfitMale1.Value;
                    card.dressUpData.maleDressIds[1] = (uint)numOutfitMale2.Value;
                    card.dressUpData.maleDressIds[2] = (uint)numOutfitMale3.Value;
                    card.dressUpData.maleDressIds[3] = (uint)numOutfitMale4.Value;
                    card.dressUpData.maleDressIds[4] = (uint)numOutfitMale5.Value;
                    card.dressUpData.maleDressIds[5] = (uint)numOutfitMale6.Value;
                    card.dressUpData.maleDressIds[6] = (uint)numOutfitMale7.Value;
                    card.dressUpData.femaleDressIds[0] = (uint)numOutfitFemale1.Value;
                    card.dressUpData.femaleDressIds[1] = (uint)numOutfitFemale2.Value;
                    card.dressUpData.femaleDressIds[2] = (uint)numOutfitFemale3.Value;
                    card.dressUpData.femaleDressIds[3] = (uint)numOutfitFemale4.Value;
                    card.dressUpData.femaleDressIds[4] = (uint)numOutfitFemale5.Value;
                    card.dressUpData.femaleDressIds[5] = (uint)numOutfitFemale6.Value;
                    card.dressUpData.femaleDressIds[6] = (uint)numOutfitFemale7.Value;
                    break;

                case WonderCard.DataType.Money:
                    card.moneyData = (uint)numMoney.Value;
                    break;

                case WonderCard.DataType.UnderGroundItem:
                    card.underGroundItemData.itemInfos[0].itemNo = (ushort)numUgItemID1.Value;
                    card.underGroundItemData.itemInfos[0].num = (ushort)numUgItemAmount1.Value;
                    card.underGroundItemData.itemInfos[1].itemNo = (ushort)numUgItemID2.Value;
                    card.underGroundItemData.itemInfos[1].num = (ushort)numUgItemAmount2.Value;
                    card.underGroundItemData.itemInfos[2].itemNo = (ushort)numUgItemID3.Value;
                    card.underGroundItemData.itemInfos[2].num = (ushort)numUgItemAmount3.Value;
                    card.underGroundItemData.itemInfos[3].itemNo = (ushort)numUgItemID4.Value;
                    card.underGroundItemData.itemInfos[3].num = (ushort)numUgItemAmount4.Value;
                    card.underGroundItemData.itemInfos[4].itemNo = (ushort)numUgItemID5.Value;
                    card.underGroundItemData.itemInfos[4].num = (ushort)numUgItemAmount5.Value;
                    card.underGroundItemData.itemInfos[5].itemNo = (ushort)numUgItemID6.Value;
                    card.underGroundItemData.itemInfos[5].num = (ushort)numUgItemAmount6.Value;
                    card.underGroundItemData.itemInfos[6].itemNo = (ushort)numUgItemID7.Value;
                    card.underGroundItemData.itemInfos[6].num = (ushort)numUgItemAmount7.Value;
                    break;

                case WonderCard.DataType.FlagUnlock:
                    card.dressUpData.maleDressIds[0] = (uint)numFlagOn1.Value;
                    card.dressUpData.maleDressIds[1] = (uint)numFlagOn2.Value;
                    card.dressUpData.maleDressIds[2] = (uint)numFlagOn3.Value;
                    card.dressUpData.maleDressIds[3] = (uint)numFlagOn4.Value;
                    card.dressUpData.maleDressIds[4] = (uint)numFlagOn5.Value;
                    card.dressUpData.maleDressIds[5] = (uint)numFlagOn6.Value;
                    card.dressUpData.maleDressIds[6] = (uint)numFlagOn7.Value;
                    card.dressUpData.femaleDressIds[0] = (uint)numFlagOff1.Value;
                    card.dressUpData.femaleDressIds[1] = (uint)numFlagOff2.Value;
                    card.dressUpData.femaleDressIds[2] = (uint)numFlagOff3.Value;
                    card.dressUpData.femaleDressIds[3] = (uint)numFlagOff4.Value;
                    card.dressUpData.femaleDressIds[4] = (uint)numFlagOff5.Value;
                    card.dressUpData.femaleDressIds[5] = (uint)numFlagOff6.Value;
                    card.dressUpData.femaleDressIds[6] = (uint)numFlagOff7.Value;
                    break;
            }
        }

        private void TogglePokemonTabControls(bool value)
        {
            btnPkmnNickname.Enabled = value;
            numPkmnSpecies.Enabled = value;
            numPkmnForm.Enabled = value;
            numPkmnGender.Enabled = value;
            numPkmnLevel.Enabled = value;
            numPkmnEgg.Enabled = value;
            numPkmnNature.Enabled = value;
            numPkmnAbility.Enabled = value;
            numPkmnShiny.Enabled = value;
            numPkmnBall.Enabled = value;
            numPkmnHeldItem.Enabled = value;
            numPkmnVersion.Enabled = value;

            numOTID.Enabled = value;
            btnOTName.Enabled = value;
            numOTGender.Enabled = value;

            numPkmnMetArea.Enabled = value;
            numPkmnCaughtArea.Enabled = value;
            numPkmnCaughtLevel.Enabled = value;

            numPkmnMove1.Enabled = value;
            numPkmnMove2.Enabled = value;
            numPkmnMove3.Enabled = value;
            numPkmnMove4.Enabled = value;

            numPkmnEggMove1.Enabled = value;
            numPkmnEggMove2.Enabled = value;
            numPkmnEggMove3.Enabled = value;
            numPkmnEggMove4.Enabled = value;

            numPkmnIVHP.Enabled = value;
            numPkmnIVAtk.Enabled = value;
            numPkmnIVDef.Enabled = value;
            numPkmnIVSpAtk.Enabled = value;
            numPkmnIVSpDef.Enabled = value;
            numPkmnIVSpeed.Enabled = value;

            numPkmnEVHP.Enabled = value;
            numPkmnEVAtk.Enabled = value;
            numPkmnEVDef.Enabled = value;
            numPkmnEVSpAtk.Enabled = value;
            numPkmnEVSpDef.Enabled = value;
            numPkmnEVSpeed.Enabled = value;

            numPkmnCool.Enabled = value;
            numPkmnBeautiful.Enabled = value;
            numPkmnCute.Enabled = value;
            numPkmnClever.Enabled = value;
            numPkmnTough.Enabled = value;
            numPkmnSheen.Enabled = value;

            numRibbon0.Enabled = value;
            numRibbon1.Enabled = value;
            numRibbon2.Enabled = value;
            numRibbon3.Enabled = value;
            numRibbon4.Enabled = value;
            numRibbon5.Enabled = value;
            numRibbon6.Enabled = value;
            numRibbon7.Enabled = value;
            numRibbon8.Enabled = value;
            numRibbon9.Enabled = value;
            numRibbon10.Enabled = value;
            numRibbon11.Enabled = value;
            numRibbon12.Enabled = value;
            numRibbon13.Enabled = value;
            numRibbon14.Enabled = value;
            numRibbon15.Enabled = value;
            numRibbon16.Enabled = value;
            numRibbon17.Enabled = value;
            numRibbon18.Enabled = value;
            numRibbon19.Enabled = value;
            numRibbon20.Enabled = value;
            numRibbon21.Enabled = value;
            numRibbon22.Enabled = value;
            numRibbon23.Enabled = value;
            numRibbon24.Enabled = value;
            numRibbon25.Enabled = value;
            numRibbon26.Enabled = value;
            numRibbon27.Enabled = value;
            numRibbon28.Enabled = value;
            numRibbon29.Enabled = value;
            numRibbon30.Enabled = value;
            numRibbon31.Enabled = value;

            numPkmnSeed.Enabled = value;
            numPkmnSeedShiny.Enabled = value;
        }

        private void ToggleItemTabControls(bool value)
        {
            numItemID1.Enabled = value;
            numItemAmount1.Enabled = value;
            numItemID2.Enabled = value;
            numItemAmount2.Enabled = value;
            numItemID3.Enabled = value;
            numItemAmount3.Enabled = value;
            numItemID4.Enabled = value;
            numItemAmount4.Enabled = value;
            numItemID5.Enabled = value;
            numItemAmount5.Enabled = value;
            numItemID6.Enabled = value;
            numItemAmount6.Enabled = value;
            numItemID7.Enabled = value;
            numItemAmount7.Enabled = value;
        }

        private void ToggleOutfitTabControls(bool value)
        {
            numOutfitMale1.Enabled = value;
            numOutfitMale2.Enabled = value;
            numOutfitMale3.Enabled = value;
            numOutfitMale4.Enabled = value;
            numOutfitMale5.Enabled = value;
            numOutfitMale6.Enabled = value;
            numOutfitMale7.Enabled = value;
            numOutfitFemale1.Enabled = value;
            numOutfitFemale2.Enabled = value;
            numOutfitFemale3.Enabled = value;
            numOutfitFemale4.Enabled = value;
            numOutfitFemale5.Enabled = value;
            numOutfitFemale6.Enabled = value;
            numOutfitFemale7.Enabled = value;
        }

        private void ToggleMoneyTabControls(bool value)
        {
            numMoney.Enabled = value;
        }

        private void ToggleUgItemTabControls(bool value)
        {
            numUgItemID1.Enabled = value;
            numUgItemAmount1.Enabled = value;
            numUgItemID2.Enabled = value;
            numUgItemAmount2.Enabled = value;
            numUgItemID3.Enabled = value;
            numUgItemAmount3.Enabled = value;
            numUgItemID4.Enabled = value;
            numUgItemAmount4.Enabled = value;
            numUgItemID5.Enabled = value;
            numUgItemAmount5.Enabled = value;
            numUgItemID6.Enabled = value;
            numUgItemAmount6.Enabled = value;
            numUgItemID7.Enabled = value;
            numUgItemAmount7.Enabled = value;
        }

        private void ToggleFlagTabControls(bool value)
        {
            numFlagOn1.Enabled = value;
            numFlagOn2.Enabled = value;
            numFlagOn3.Enabled = value;
            numFlagOn4.Enabled = value;
            numFlagOn5.Enabled = value;
            numFlagOn6.Enabled = value;
            numFlagOn7.Enabled = value;
            numFlagOff1.Enabled = value;
            numFlagOff2.Enabled = value;
            numFlagOff3.Enabled = value;
            numFlagOff4.Enabled = value;
            numFlagOff5.Enabled = value;
            numFlagOff6.Enabled = value;
            numFlagOff7.Enabled = value;
        }

        private void ClearCommonTabControls()
        {
            txtCRC.Text = string.Empty;
            numDeliveryID.Value = 0;
            numTextID.Value = 0;
            numVersionID.Value = 0;
            numReceiveFlag.Value = 0;
            comboDataType.SelectedItem = WonderCard.DataType.Invalid;
            numCardMsgID.Value = 0;
        }

        private void ClearPokemonTabControls()
        {
            nicknameStrings = new string[9]
            {
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty,
            };
            nicknameLanguages = new BDSPLanguage[9]
            {
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            };
            numPkmnSpecies.Value = 0;
            numPkmnForm.Value = 0;
            numPkmnGender.Value = 0;
            numPkmnLevel.Value = 0;
            numPkmnEgg.Value = 0;
            numPkmnNature.Value = 0;
            numPkmnAbility.Value = 0;
            numPkmnShiny.Value = 0;
            numPkmnBall.Value = 0;
            numPkmnHeldItem.Value = 0;
            numPkmnVersion.Value = 0;

            numOTID.Value = 0;
            otStrings = new string[9]
            {
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty,
            };
            otLanguages = new BDSPLanguage[9]
            {
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
                BDSPLanguage.USA, BDSPLanguage.USA, BDSPLanguage.USA,
            };
            numOTGender.Value = 0;

            numPkmnMetArea.Value = 0;
            numPkmnCaughtArea.Value = 0;
            numPkmnCaughtLevel.Value = 0;

            numPkmnMove1.Value = 0;
            numPkmnMove2.Value = 0;
            numPkmnMove3.Value = 0;
            numPkmnMove4.Value = 0;

            numPkmnEggMove1.Value = 0;
            numPkmnEggMove2.Value = 0;
            numPkmnEggMove3.Value = 0;
            numPkmnEggMove4.Value = 0;

            numPkmnIVHP.Value = 0;
            numPkmnIVAtk.Value = 0;
            numPkmnIVDef.Value = 0;
            numPkmnIVSpAtk.Value = 0;
            numPkmnIVSpDef.Value = 0;
            numPkmnIVSpeed.Value = 0;

            numPkmnEVHP.Value = 0;
            numPkmnEVAtk.Value = 0;
            numPkmnEVDef.Value = 0;
            numPkmnEVSpAtk.Value = 0;
            numPkmnEVSpDef.Value = 0;
            numPkmnEVSpeed.Value = 0;

            numPkmnCool.Value = 0;
            numPkmnBeautiful.Value = 0;
            numPkmnCute.Value = 0;
            numPkmnClever.Value = 0;
            numPkmnTough.Value = 0;
            numPkmnSheen.Value = 0;

            numRibbon0.Value = 0;
            numRibbon1.Value = 0;
            numRibbon2.Value = 0;
            numRibbon3.Value = 0;
            numRibbon4.Value = 0;
            numRibbon5.Value = 0;
            numRibbon6.Value = 0;
            numRibbon7.Value = 0;
            numRibbon8.Value = 0;
            numRibbon9.Value = 0;
            numRibbon10.Value = 0;
            numRibbon11.Value = 0;
            numRibbon12.Value = 0;
            numRibbon13.Value = 0;
            numRibbon14.Value = 0;
            numRibbon15.Value = 0;
            numRibbon16.Value = 0;
            numRibbon17.Value = 0;
            numRibbon18.Value = 0;
            numRibbon19.Value = 0;
            numRibbon20.Value = 0;
            numRibbon21.Value = 0;
            numRibbon22.Value = 0;
            numRibbon23.Value = 0;
            numRibbon24.Value = 0;
            numRibbon25.Value = 0;
            numRibbon26.Value = 0;
            numRibbon27.Value = 0;
            numRibbon28.Value = 0;
            numRibbon29.Value = 0;
            numRibbon30.Value = 0;
            numRibbon31.Value = 0;

            numPkmnSeed.Value = 0;
            numPkmnSeedShiny.Value = 0;
        }

        private void ClearItemTabControls()
        {
            numItemID1.Value = 0;
            numItemAmount1.Value = 0;
            numItemID2.Value = 0;
            numItemAmount2.Value = 0;
            numItemID3.Value = 0;
            numItemAmount3.Value = 0;
            numItemID4.Value = 0;
            numItemAmount4.Value = 0;
            numItemID5.Value = 0;
            numItemAmount5.Value = 0;
            numItemID6.Value = 0;
            numItemAmount6.Value = 0;
            numItemID7.Value = 0;
            numItemAmount7.Value = 0;
        }

        private void ClearOutfitTabControls()
        {
            numOutfitMale1.Value = 0;
            numOutfitMale2.Value = 0;
            numOutfitMale3.Value = 0;
            numOutfitMale4.Value = 0;
            numOutfitMale5.Value = 0;
            numOutfitMale6.Value = 0;
            numOutfitMale7.Value = 0;
            numFlagOff1.Value = 0;
            numFlagOff2.Value = 0;
            numFlagOff3.Value = 0;
            numFlagOff4.Value = 0;
            numFlagOff5.Value = 0;
            numFlagOff6.Value = 0;
            numFlagOff7.Value = 0;
        }

        private void ClearMoneyTabControls()
        {
            numMoney.Value = 0;
        }

        private void ClearUgItemTabControls()
        {
            numUgItemID1.Value = 0;
            numUgItemAmount1.Value = 0;
            numUgItemID2.Value = 0;
            numUgItemAmount2.Value = 0;
            numUgItemID3.Value = 0;
            numUgItemAmount3.Value = 0;
            numUgItemID4.Value = 0;
            numUgItemAmount4.Value = 0;
            numUgItemID5.Value = 0;
            numUgItemAmount5.Value = 0;
            numUgItemID6.Value = 0;
            numUgItemAmount6.Value = 0;
            numUgItemID7.Value = 0;
            numUgItemAmount7.Value = 0;
        }

        private void ClearFlagTabControls()
        {
            numFlagOn1.Value = 0;
            numFlagOn2.Value = 0;
            numFlagOn3.Value = 0;
            numFlagOn4.Value = 0;
            numFlagOn5.Value = 0;
            numFlagOn6.Value = 0;
            numFlagOn7.Value = 0;
            numFlagOff1.Value = 0;
            numFlagOff2.Value = 0;
            numFlagOff3.Value = 0;
            numFlagOff4.Value = 0;
            numFlagOff5.Value = 0;
            numFlagOff6.Value = 0;
            numFlagOff7.Value = 0;
        }

        private void LoadWonderCard(string path)
        {
            try
            {
                switch (engine.CreateWonderCardFromFile(path, out WonderCard tempCard))
                {
                    case WonderCard.ConvertionResult.Success:
                        card = tempCard;
                        UpdateComponentsOnLoad();
                        break;

                    case WonderCard.ConvertionResult.BadData:
                        MessageBox.Show($"This Wonder Card has invalid data and could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case WonderCard.ConvertionResult.ChecksumError:
                        MessageBox.Show($"The checksum of this Wonder Card is invalid. It will still be loaded.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        card = tempCard;
                        UpdateComponentsOnLoad();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load a wonder card from this file. Full exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (string[], BDSPLanguage[]) OpenStringLocalizer(string elementName, int lengthLimit, string[] strings, BDSPLanguage[] languages)
        {
            using FormLocalizedWonderCardString stringLocalizer = new FormLocalizedWonderCardString(elementName, lengthLimit, strings, languages);

            if (stringLocalizer.ShowDialog() == DialogResult.OK)
                return (stringLocalizer.ResultStrings, stringLocalizer.ResultLanguages);
            else
                return (strings, languages);
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                LoadWonderCard(openFileDialog.FileName);
        }

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ApplyComponentsToCard();
                engine.SaveWonderCardToFile(card, saveFileDialog.FileName);
                MessageBox.Show("Successfully saved the Wonder Card!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboDataType_SelectedValueChanged(object sender, EventArgs e)
        {
            TogglePokemonTabControls(false);
            ToggleItemTabControls(false);
            ToggleOutfitTabControls(false);
            ToggleMoneyTabControls(false);
            ToggleUgItemTabControls(false);
            ToggleFlagTabControls(false);

            switch (comboDataType.SelectedItem)
            {
                case WonderCard.DataType.Monster:
                    TogglePokemonTabControls(true);
                    break;

                case WonderCard.DataType.Items:
                    ToggleItemTabControls(true);
                    break;

                case WonderCard.DataType.DressUp:
                    ToggleOutfitTabControls(true);
                    break;

                case WonderCard.DataType.Money:
                    ToggleMoneyTabControls(true);
                    break;

                case WonderCard.DataType.UnderGroundItem:
                    ToggleUgItemTabControls(true);
                    break;

                case WonderCard.DataType.FlagUnlock:
                    ToggleFlagTabControls(true);
                    break;
            }
        }

        private void FormWonderCard_Shown(object sender, EventArgs e)
        {
            UpdateComponentsOnStart();
        }

        private void FormWonderCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            card = default;
        }

        private void btnFileOpen_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btnFileOpen_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 1)
                MessageBox.Show("Multiple files were dragged into the tool. You can only load one Wonder Card at a time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                LoadWonderCard(files[0]);
        }

        private void btnPkmnNickname_Click(object sender, EventArgs e)
        {
            (nicknameStrings, nicknameLanguages) = OpenStringLocalizer("this Pokémon's nickname", 12, nicknameStrings, nicknameLanguages);
        }

        private void btnOTName_Click(object sender, EventArgs e)
        {
            (otStrings, otLanguages) = OpenStringLocalizer("this Pokémon's Original Trainer's name", 12, otStrings, otLanguages);
        }

        private void btnCRCRecalculate_Click(object sender, EventArgs e)
        {
            ApplyComponentsToCard();
            txtCRC.Text = engine.CalcWonderCardCrc(card).ToString();
        }
    }
}
