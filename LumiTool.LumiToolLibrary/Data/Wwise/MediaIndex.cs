namespace LumiTool.Data.Wwise
{
    public class MediaIndex : Chunk
    {
        public List<MediaHeader> loadedMedia;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            loadedMedia = new();
            long endOffset = wd.offset + chunkSize;
            while (endOffset > wd.offset)
            {
                MediaHeader mh = new();
                mh.Deserialize(wd);
                loadedMedia.Add(mh);
            }
        }

        public override IEnumerable<byte> Serialize()
        {
            List<byte> b = new();
            b.AddRange(Utils.GetBytes(tag));
            List<byte> loadedMediaBuffer = new();
            foreach (MediaHeader mediaHeader in loadedMedia)
                loadedMediaBuffer.AddRange(mediaHeader.Serialize());
            chunkSize = (uint)loadedMediaBuffer.Count;
            b.AddRange(Utils.GetBytes(chunkSize));
            b.AddRange(loadedMediaBuffer);
            return b;
        }
    }
}
