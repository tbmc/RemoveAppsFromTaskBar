using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveShittyAppsFromTaskbar
{
    class RemoveFromTaskBar
    {

        public static bool RemoveListFromTaskbar(List<string> list)
        {
            bool success;
            try
            {
                Utils.ChangeImagePathName("explorer.exe");
                success = RemoveListFromTaskBarInternal(list);
            }
            finally
            {
                Utils.RestoreImagePathName();
            }
            return success;
        }

        private static bool RemoveListFromTaskBarInternal(List<string> list)
        {
            bool sucess = true;
            foreach(string fileName in list)
            {
                bool tempSuccess = Utils.PinUnpinTaskbar(fileName, false);
                if (!tempSuccess)
                    sucess = false;
            }
            return sucess;
        }

    }
}
