using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyExploits;

namespace Orion
{
    class CoreFunctions
    {
        public static EasyExploits.Module EEModule = new EasyExploits.Module();

        public async static void Hook()
        {
            EEModule.LaunchExploit();
            await Task.Delay(5000);
            EEModule.ExecuteScript("while wait()do if _G.GayAPIScreen then return end;for a,b in pairs(game:GetService('CoreGui'):GetChildren())do if b.Name=='CoreScriptLocalization'or b.Name=='RobloxGui'or b.Name=='RobloxPromptGui'or b.Name=='PurchasePromptApp'or b.Name=='RobloxLoadingGui'or b.Name=='RobloxNetworkPauseNotification'or b.Name=='DevConsoleMaster'or b.Name=='Chat'or b.Name=='BubbleChat'then else b:Destroy()end end end");
            await Task.Delay(2000);
            EEModule.ExecuteScript("_G.GayAPIScreen = true");
            AutoExec();
        }
        public static void Execute(string Script)
        {
            EEModule.ExecuteScript(Script);
        }

        public static void Exit()
        {
            Process.GetCurrentProcess().Kill();
        }

        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dirInfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        public static void AutoExec()
        {
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\autoexec");
            FileInfo[] TXTFiles = d.GetFiles("*.txt");
            foreach (FileInfo file in TXTFiles)
            {
                Execute(File.ReadAllText($"./autoexec/{file.Name}"));
            }
            FileInfo[] LUAFiles = d.GetFiles("*.lua");
            foreach (FileInfo file in LUAFiles)
            {
                Execute(File.ReadAllText($"./autoexec/{file.Name}"));
            }
        }

        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            InitialDirectory = Directory.GetCurrentDirectory() + "\\scripts",
            Filter = "Lua (*.lua)|*.lua|Txt (*.txt)|*.txt|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Orion Open Script"
        };
    }
}
