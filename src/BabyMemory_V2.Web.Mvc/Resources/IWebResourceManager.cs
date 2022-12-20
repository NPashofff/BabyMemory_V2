using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace BabyMemory_V2.Web.Resources
{
    public interface IWebResourceManager
    {
        void AddScript(string url, bool addMinifiedOnProd = true);

        IReadOnlyList<string> GetScripts();

        HelperResult RenderScripts();
    }
}
