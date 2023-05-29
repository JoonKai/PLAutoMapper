namespace PLAutoMapperLib.Helpers
{
    public static  class Helper
    {
        public static LogHelper PLog { get; private set; }
        public static JsonHelper PJson { get; private set; }
        public static IniHelper PIni { get; private set; }
        public static RootHelper PRoot { get; private set; }
        static Helper()
        {
            PLog = new LogHelper();
            PJson = new JsonHelper();
            PIni = new IniHelper();
            PRoot = new RootHelper();
        }
    }
}
