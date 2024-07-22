namespace SmartPoint.AssetAssistant
{
    [Serializable]
    public struct RecordedHash
    {
        public uint u0;
        public uint u1;
        public uint u2;
        public uint u3;

        public bool isValid { get => u0 != 0 || u1 != 0 || u2 != 0 || u3 != 0; }

        public RecordedHash(uint u0, uint u1, uint u2, uint u3)
        {
            this.u0 = u0;
            this.u1 = u1;
            this.u2 = u2;
            this.u3 = u3;
        }

        private static uint SwapEndian(uint x)
        {
            return x >> 24 & 0x000000FF | x >> 8 & 0x0000FF00 | x << 8 & 0x00FF0000 | x << 24 & 0xFF000000;
        }

        public static RecordedHash Parse(string hashString)
        {
            RecordedHash rec = new RecordedHash();
            if (!string.IsNullOrEmpty(hashString))
            {
                int currentLength = hashString.Length;
                int length;

                length = Math.Min(8, currentLength);
                rec.u0 = SwapEndian(Convert.ToUInt32(hashString.Substring(0, length), 16));
                currentLength -= length;

                length = Math.Min(8, currentLength);
                rec.u1 = SwapEndian(Convert.ToUInt32(hashString.Substring(8, length), 16));
                currentLength -= length;

                length = Math.Min(8, currentLength);
                rec.u2 = SwapEndian(Convert.ToUInt32(hashString.Substring(16, length), 16));
                currentLength -= length;

                length = Math.Min(8, currentLength);
                rec.u3 = SwapEndian(Convert.ToUInt32(hashString.Substring(24, length), 16));
            }

            return rec;
        }

        public override string ToString()
        {
            return string.Format("{0:X4}", u0) + string.Format("{0:X4}", u1) + string.Format("{0:X4}", u2) + string.Format("{0:X4}", u3);
        }

        public override int GetHashCode()
        {
            return u0.GetHashCode() ^ u1.GetHashCode() ^ u2.GetHashCode() ^ u3.GetHashCode();
        }

        public override bool Equals(object reference)
        {
            if (reference != null && reference is RecordedHash)
            {
                var other = (RecordedHash)reference;
                if (u0 == other.u0 && u1 == other.u1 && u2 == other.u2 && u3 == other.u3)
                    return true;
            }

            return false;
        }

        public static bool operator ==(RecordedHash lhs, RecordedHash rhs)
        {
            return lhs.u0 == rhs.u0 && lhs.u1 == rhs.u1 && lhs.u2 == rhs.u2 && lhs.u3 == rhs.u3;
        }

        public static bool operator !=(RecordedHash lhs, RecordedHash rhs)
        {
            return lhs.u0 != rhs.u0 || lhs.u1 != rhs.u1 || lhs.u2 != rhs.u2 || lhs.u3 != rhs.u3;
        }
    }
}
