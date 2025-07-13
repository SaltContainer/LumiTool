namespace LumiTool.Data
{
    public enum CommandLineResult
    {
        Success = 0,
        UnrecognizedCommand,
        FileNotFound,
        NotAFile,
        DirectoryNotFound,
        FileExists,

        OtherError,
    }
}
