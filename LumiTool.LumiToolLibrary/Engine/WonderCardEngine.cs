using LumiTool.Data;
using System.Runtime.InteropServices;

namespace LumiTool.Engine
{
    public class WonderCardEngine
    {
        private LumiToolEngine engine;

        public WonderCardEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public WonderCard.ConvertionResult CreateWonderCardFromFile(string path, out WonderCard wonderCard)
        {
            return CreateWonderCardFromBytes(File.ReadAllBytes(path), out wonderCard);
        }

        public WonderCard.ConvertionResult CreateWonderCardFromBytes(byte[] dataBytes, out WonderCard wonderCard)
        {
            wonderCard = default;

            if (dataBytes.Length != WonderCard.DataSize)
                return WonderCard.ConvertionResult.BadData;

            wonderCard.commonData = ConvertDataToStruct<WonderCard.CommonData>(dataBytes, 0);

            var offset = Marshal.SizeOf<WonderCard.CommonData>();

            switch (wonderCard.commonData.dataType)
            {
                case WonderCard.DataType.Monster:
                    wonderCard.pokemonData = ConvertDataToStruct<WonderCard.PokemonData>(dataBytes, offset);
                    break;

                case WonderCard.DataType.Items:
                    wonderCard.itemData = ConvertDataToStruct<WonderCard.ItemData>(dataBytes, offset);
                    break;

                case WonderCard.DataType.DressUp:
                    wonderCard.dressUpData = ConvertDataToStruct<WonderCard.DressUpData>(dataBytes, offset);
                    break;

                case WonderCard.DataType.Money:
                    wonderCard.moneyData = ConvertDataToStruct<uint>(dataBytes, offset);
                    break;

                case WonderCard.DataType.UnderGroundItem:
                    wonderCard.underGroundItemData = ConvertDataToStruct<WonderCard.UnderGroundItemData>(dataBytes, offset);
                    break;

                case WonderCard.DataType.FlagUnlock:
                    wonderCard.dressUpData = ConvertDataToStruct<WonderCard.DressUpData>(dataBytes, offset);
                    break;

                default:
                    return WonderCard.ConvertionResult.BadData;
            }

            wonderCard.crc = ConvertDataToStruct<ushort>(dataBytes, WonderCard.CrcIndex);

            if (CheckCrc(dataBytes, wonderCard.crc))
                return WonderCard.ConvertionResult.Success;

            return WonderCard.ConvertionResult.ChecksumError;
        }

        public void SaveWonderCardToFile(WonderCard card, string path)
        {
            var dataBytes = ConvertWonderCardToBytes(card);
            File.WriteAllBytes(path, dataBytes);
        }

        public ushort CalcCrc(WonderCard card)
        {
            var dataBytes = ConvertWonderCardToBytes(card);
            return BitConverter.ToUInt16(dataBytes, WonderCard.CrcIndex);
        }

        private byte[] ConvertWonderCardToBytes(WonderCard card)
        {
            var dataBytes = new byte[WonderCard.DataSize];

            var commonData = ConvertDataToByteArray(card.commonData);
            Array.Copy(commonData, 0, dataBytes, 0, commonData.Length);

            var offset = commonData.Length;

            switch (card.commonData.dataType)
            {
                case WonderCard.DataType.Monster:
                    var pokemonData = ConvertDataToByteArray(card.pokemonData);
                    Array.Copy(pokemonData, 0, dataBytes, offset, pokemonData.Length);
                    break;

                case WonderCard.DataType.Items:
                    var itemData = ConvertDataToByteArray(card.itemData);
                    Array.Copy(itemData, 0, dataBytes, offset, itemData.Length);
                    break;

                case WonderCard.DataType.DressUp:
                    var dressUpData = ConvertDataToByteArray(card.dressUpData);
                    Array.Copy(dressUpData, 0, dataBytes, offset, dressUpData.Length);
                    break;

                case WonderCard.DataType.Money:
                    var moneyData = ConvertDataToByteArray(card.moneyData);
                    Array.Copy(moneyData, 0, dataBytes, offset, moneyData.Length);
                    break;

                case WonderCard.DataType.UnderGroundItem:
                    var underGroundItemData = ConvertDataToByteArray(card.underGroundItemData);
                    Array.Copy(underGroundItemData, 0, dataBytes, offset, underGroundItemData.Length);
                    break;

                case WonderCard.DataType.FlagUnlock:
                    var flagData = ConvertDataToByteArray(card.dressUpData);
                    Array.Copy(flagData, 0, dataBytes, offset, flagData.Length);
                    break;
            }

            var crc = ConvertDataToByteArray(CalcCrcValue(dataBytes));
            Array.Copy(crc, 0, dataBytes, WonderCard.CrcIndex, crc.Length);

            return dataBytes;
        }

        private T ConvertDataToStruct<T>(byte[] dataBytes, int start)
        {
            var size = Marshal.SizeOf<T>();

            var trimmedBytes = dataBytes[start..(start+size)];

            var handle = GCHandle.Alloc(trimmedBytes, GCHandleType.Pinned);
            var result = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
            handle.Free();

            return result;
        }

        private byte[] ConvertDataToByteArray<T>(T dataStruct)
        {
            var size = Marshal.SizeOf<T>();
            var data = new byte[size];

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(dataStruct, ptr, true);
            Marshal.Copy(ptr, data, 0, size);
            Marshal.FreeHGlobal(ptr);

            return data;
        }

        private bool CheckCrc(byte[] data, ushort crc)
        {
            if (data.Length > WonderCard.CrcIndex)
                for (int i = WonderCard.CrcIndex; i < data.Length; i++)
                    data[i] = 0;

            return CalcCrcValue(data) == crc;
        }

        private ushort CalcCrcValue(byte[] dataBytes)
        {
            var powers = new int[8];

            for (int i = 0; i < powers.Length; i++)
                powers[i] = (int)Math.Pow(2.0d, i);

            if (dataBytes.Length > 0)
            {
                if (powers.Length > 0)
                {
                    int crc = ushort.MaxValue;

                    for (int i = 0; i < dataBytes.Length; i++)
                    {
                        for (int j = powers.Length - 1; j >= 0; j--)
                        {
                            var power = powers[j];

                            var bottom15 = (crc & 0x7FFF) << 1;
                            var sign = crc >> 0xF;

                            crc = bottom15;

                            if (((power & (dataBytes[i] ^ 0xFFFFFFFF)) != 0) == (sign != 0))
                                crc = bottom15 ^ 0x1021;
                        }
                    }

                    return Convert.ToUInt16(crc);
                }

                // Ignores result, maybe commented out logs
                for (int i = 0; i < dataBytes.Length; i++)
                    _ = dataBytes[i];
            }

            return ushort.MaxValue;
        }
    }
}
