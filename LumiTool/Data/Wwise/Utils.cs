using System.Text;

namespace LumiTool.Data.Wwise
{
    public static class Utils
    {
        public static bool[] ReadFlags(WwiseData wd)
        {
            bool[] result = new bool[8];
            byte b = ReadUInt8(wd);
            for (int i = 0; i < 8; i++)
                result[i] = ((1 << i) & b) != 0;
            return result;
        }

        public static byte GetByte(bool[] data)
        {
            byte result = 0;
            for (int i = 0; i < data.Length; i++)
                result |= (byte)(data[i] ? 1 << i : 0);
            return result;
        }

        public static byte ReadUInt8(WwiseData wd)
        {
            byte result = wd.buffer[wd.offset];
            wd.offset++;
            return result;
        }

        public static ushort ReadUInt16(WwiseData wd)
        {
            ushort result = BitConverter.ToUInt16(wd.buffer, wd.offset);
            wd.offset += 2;
            return result;
        }

        public static IEnumerable<byte> GetBytes(ushort data)
        {
            return BitConverter.GetBytes(data);
        }

        public static short ReadInt16(WwiseData wd)
        {
            short result = BitConverter.ToInt16(wd.buffer, wd.offset);
            wd.offset += 2;
            return result;
        }

        public static IEnumerable<byte> GetBytes(short data)
        {
            return BitConverter.GetBytes(data);
        }

        public static string ReadString(WwiseData wd, int length)
        {
            string result = Encoding.ASCII.GetString(wd.buffer, wd.offset, length);
            wd.offset += length;
            return result;
        }

        public static IEnumerable<byte> GetBytes(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }

        public static uint ReadUInt32(WwiseData wd)
        {
            uint result = BitConverter.ToUInt32(wd.buffer, wd.offset);
            wd.offset += 4;
            return result;
        }

        public static IEnumerable<byte> GetBytes(int data)
        {
            return BitConverter.GetBytes(data);
        }

        public static int ReadInt32(WwiseData wd)
        {
            int result = BitConverter.ToInt32(wd.buffer, wd.offset);
            wd.offset += 4;
            return result;
        }

        public static IEnumerable<byte> GetBytes(uint data)
        {
            return BitConverter.GetBytes(data);
        }

        public static float ReadSingle(WwiseData wd)
        {
            float result = BitConverter.ToSingle(wd.buffer, wd.offset);
            wd.offset += 4;
            return result;
        }

        public static IEnumerable<byte> GetBytes(float data)
        {
            return BitConverter.GetBytes(data);
        }

        public static double ReadDouble(WwiseData wd)
        {
            double result = BitConverter.ToDouble(wd.buffer, wd.offset);
            wd.offset += 8;
            return result;
        }

        public static IEnumerable<byte> GetVariableIntBytes(ulong data)
        {
            List<byte> result = new();
            while (data > 0)
            {
                result.Add((byte)(data & 0x7F));
                data >>= 7;
            }
            if (result.Count == 0)
                result.Add(0);
            result.Reverse();
            for (int i = 0; i < result.Count - 1; i++)
                result[i] += 0x80;
            return result;
        }

        public static ulong ReadVariableInt(WwiseData wd)
        {
            ulong b = ReadUInt8(wd);
            ulong result = b & 0x7F;
            while ((b & 0x80) > 0)
            {
                b = ReadUInt8(wd);
                result = (result << 7) | (b & 0x7F);
            }

            return result;
        }

        public static IEnumerable<byte> GetBytes(double data)
        {
            return BitConverter.GetBytes(data);
        }

        public static byte[] ReadUInt8Array(WwiseData wd, int count)
        {
            byte[] result = new byte[count];
            Array.Copy(wd.buffer, wd.offset, result, 0, count);
            wd.offset += count;
            return result;
        }

        public static sbyte[] ReadInt8Array(WwiseData wd, int count)
        {
            sbyte[] result = new sbyte[count];
            for (int i = 0; i < count; i++)
                result[i] = (sbyte)wd.buffer[wd.offset + i];
            wd.offset += count;
            return result;
        }

        public static IEnumerable<byte> GetBytes(sbyte[] data)
        {
            return data.Select(b => (byte)b);
        }
    }
}
