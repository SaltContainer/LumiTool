namespace LumiTool.Data.Wwise
{
    public class HircChunk : Chunk
    {
        public uint releasableHircItemCount;
        public List<HircItem> loadedItem;

        public override void Deserialize(WwiseData wd)
        {
            base.Deserialize(wd);

            loadedItem = new();
            releasableHircItemCount = Utils.ReadUInt32(wd);
            for (int i = 0; i < releasableHircItemCount; i++)
                loadedItem.Add(HircItem.Create(wd));
        }

        public override IEnumerable<byte> Serialize()
        {
            SortHircItems();

            List<byte> b0 = new();
            releasableHircItemCount = (uint)loadedItem.Count;
            b0.AddRange(Utils.GetBytes(releasableHircItemCount));
            foreach (HircItem hircItem in loadedItem)
                b0.AddRange(hircItem.Serialize());
            chunkSize = (uint)b0.Count;

            List<byte> b = new();
            b.AddRange(base.Serialize());
            b.AddRange(b0);
            return b;
        }

        private void SortHircItems()
        {
            List<HircItem> newList = new();

            Dictionary<uint, HircItem> hircLookup = new();
            foreach (HircItem hi in loadedItem)
                hircLookup.Add(hi.id, hi);

            List<HircItem> attenuation = new();
            List<HircItem> media = new();
            List<HircItem> events = new();


            foreach (HircItem hi in loadedItem)
            {
                if (hi is Attenuation)
                {
                    attenuation.Add(hi);
                    continue;
                }
                if (TryAddMediaItem(hi, media, hircLookup))
                    continue;
                if (TryAddEventItem(hi, events, hircLookup))
                    continue;
            }

            newList.AddRange(attenuation);
            newList.AddRange(media);
            newList.AddRange(events);

            loadedItem = newList;
        }

        private bool TryAddMediaItem(HircItem hi, List<HircItem> media, Dictionary<uint, HircItem> hircLookup)
        {
            if (media.Contains(hi))
                return false;

            if (hi is MusicTrack || hi is Sound)
            {
                media.Add(hi);
                return true;
            }
            else if (hi is MusicSegment ms)
                foreach (uint childID in ms.musicNodeParams.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is MusicRanSeqCntr mrsc)
                foreach (uint childID in mrsc.musicTransNodeParams.musicNodeParams.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is MusicSwitchCntr msc)
                foreach (uint childID in msc.musicTransNodeParams.musicNodeParams.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is RanSeqCntr rsc)
                foreach (uint childID in rsc.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is ActorMixer am)
                foreach (uint childID in am.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is LayerCntr lc)
                foreach (uint childID in lc.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else if (hi is SwitchCntr sc)
                foreach (uint childID in sc.children.childIDs)
                    TryAddMediaItem(hircLookup[childID], media, hircLookup);
            else
                return false;

            media.Add(hi);
            return true;
        }

        private bool TryAddEventItem(HircItem hi, List<HircItem> events, Dictionary<uint, HircItem> hircLookup)
        {
            if (events.Contains(hi))
                return false;

            if (hi is Action)
                events.Add(hi);
            else if (hi is Event e)
            {
                foreach (uint actionID in e.actionIDs)
                {
                    HircItem action = hircLookup[actionID];
                    if (!events.Contains(action))
                        events.Add(action);
                }
                events.Add(hi);
            }
            else
                return false;

            return true;
        }
    }
}
