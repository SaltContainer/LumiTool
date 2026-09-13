using System.Runtime.InteropServices;

namespace LumiTool.Data
{
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct WonderCard
    {
        public const int DataSize = 732;
        public const int CrcIndex = 720;

        public CommonData commonData;
        public BufferData bufferData;
        public PokemonData pokemonData;
        public ItemData itemData;
        public DressUpData dressUpData;
        public uint moneyData;
        public UnderGroundItemData underGroundItemData;
        public ushort crc;
        public short reserved_short01;
        public int reserved_int01;
        public int reserved_int02;

        public void CreateArrays()
        {
            commonData.CreateArrays();
            bufferData.CreateArrays();
            pokemonData.CreateArrays();
            itemData.CreateArrays();
            dressUpData.CreateArrays();
            underGroundItemData.CreateArrays();
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct CommonData
        {
            public long timestamp;
            public uint deliveryID;
            public ushort eventTextID;
            public ushort romVersion;
            public byte receiveFlag;
            public DataType dataType;
            public byte cardMessageID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
            public byte[] padding;

            public void CreateArrays()
            {
                padding = new byte[13];
            }

            public bool IsReceiveOnce { get => (receiveFlag & 1) == 1; }

            public bool IsReceiveOneDay { get => ((receiveFlag >> 2) & 1) == 1; }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct BufferData
        {
            public const int BufferSize = 688;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = BufferSize)]
            public byte[] buffer;

            public void CreateArrays()
            {
                buffer = new byte[BufferSize];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct PokemonData
        {
            public const int NameInfoSize = 9;
            public const int RibbonSize = 16;

            public uint parentId;
            public uint romVersion;
            public uint randomValue;
            public uint colorRandomValue;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NameInfoSize)]
            public NameInfo[] nickNames;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NameInfoSize)]
            public NameInfo[] parentNames;
            public ushort getArea;
            public ushort captureArea;
            public ushort captureBallId;
            public ushort itemId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public ushort[] skillIDs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public ushort[] eggSkillIDs;
            public ushort monsNo;
            public byte formNo;
            public byte sex;
            public byte level;
            public byte isEgg;
            public byte seikaku;
            public byte tokusei;
            public byte isRare;
            public byte captureLevel;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RibbonSize)]
            public byte[] ribbonIds;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = RibbonSize)]
            public byte[] twoRibbonIds;
            public byte hpRandom;
            public byte attackRandom;
            public byte defenseRandom;
            public byte agilityRandom;
            public byte spAttackRandom;
            public byte spDefenseRandom;
            public byte parentSex;
            public byte hpEffort;
            public byte attackEffort;
            public byte defenseEffort;
            public byte agilityEffort;
            public byte spAttackEffort;
            public byte spDefenseEffort;
            public byte style;
            public byte beautiful;
            public byte cute;
            public byte clever;
            public byte strong;
            public byte fur;
            public byte padding;
            public short reserved_short01;
            public int reserved_int01;
            public int reserved_int02;

            public void CreateArrays()
            {
                nickNames = new NameInfo[NameInfoSize];
                parentNames = new NameInfo[NameInfoSize];
                skillIDs = new ushort[4];
                eggSkillIDs = new ushort[4];
                ribbonIds = new byte[RibbonSize];
                twoRibbonIds = new byte[RibbonSize];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct ItemData
        {
            public const int InfoSize = 7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = InfoSize)]
            public ItemInfo[] itemInfos;

            public void CreateArrays()
            {
                itemInfos = new ItemInfo[InfoSize];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct DressUpData
        {
            public const int InfoSize = 7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = InfoSize)]
            public uint[] maleDressIds;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = InfoSize)]
            public uint[] femaleDressIds;
            public int reserved_int01;
            public int reserved_int02;

            public void CreateArrays()
            {
                maleDressIds = new uint[InfoSize];
                femaleDressIds = new uint[InfoSize];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct UnderGroundItemData
        {
            public const int InfoSize = 7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = InfoSize)]
            public ItemInfo[] itemInfos;

            public void CreateArrays()
            {
                itemInfos = new ItemInfo[InfoSize];
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        [Serializable]
        public struct NameInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
            public string name;
            public byte languageId;
            public byte paddding;
            public int reserved_int01;
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct ItemInfo
        {
            public ushort itemNo;
            public ushort num;
            public int reserved_int01;
            public int reserved_int02;
            public int reserved_int03;
        }

        public enum DataType : byte
        {
            Invalid = 0,
            Monster = 1,
            Items = 2,
            BattlePoint = 3,
            DressUp = 4,
            Money = 5,
            UnderGroundItem = 6,

            // CUSTOM
            FlagUnlock = 7,
        }

        public enum ConvertionResult
        {
            Success = 0,
            BadData = 1,
            ChecksumError = 2,
        }
    }
}
