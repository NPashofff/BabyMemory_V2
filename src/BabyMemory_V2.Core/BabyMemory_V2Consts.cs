using BabyMemory_V2.Debugging;

namespace BabyMemory_V2
{
    public class BabyMemory_V2Consts
    {
        public const string LocalizationSourceName = "BabyMemory_V2";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ab2984bb5b5647b9a5ffb3eae1bedfc2";
    }
}
