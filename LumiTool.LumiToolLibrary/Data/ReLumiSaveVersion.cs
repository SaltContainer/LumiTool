using System.ComponentModel;

namespace LumiTool
{
    public enum ReLumiSaveVersion
    {
        [Description("Pre-1.0.21 (Adds bikingMusicEnabled and surfingMusicEnabled)")]
        DEV_1,
        [Description("1.0.21 (TBD)")]
        DEV_2,
        [Description("1.0.22 (TBD)")]
        DEV_3,
        [Description("Re:Lease (3.0 Initial Release)")]
        RE_LEASE,
        [Description("Future (3.1 Release)")]
        FUTURE,

        // Keep at the bottom to mark a save as fully migrated
        PRESENT,
    }
}
