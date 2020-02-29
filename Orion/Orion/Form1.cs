using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Orion
{
    public partial class Form1 : Form
    {
        Monaco monaco = new Monaco();
        private PresenceHandler PHandler = new PresenceHandler();
        private DiscordJoiner DHandler = new DiscordJoiner();
        public Form1()
        {
           InitializeComponent();
           this.FormClosed += ClosingHandler;
        }

        protected void ClosingHandler(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + "\\bin\\settings\\script.txt"))
            {
                sw.Write(monaco.Text);
            }
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            // Directory Starting
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\scripts"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\scripts");
            }

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\autoexec"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\autoexec");
            }

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\bin"))
            {
                string settingsText;
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\bin");
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\bin\\settings");
                using (WebClient client = new WebClient())
                {
                    settingsText = client.DownloadString("https://pastebin.com/raw/MEK13jhT");
                }
                using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + "\\bin\\settings\\configuration.json"))
                {
                    sw.Write(settingsText);
                }
                var scriptFile = File.Create(Directory.GetCurrentDirectory() + "\\bin\\settings\\script.txt");
                scriptFile.Close();
            }

            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\Monaco"))
            {
                MessageBox.Show("Monaco folder not found, please redownload Orion.", "Orion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CoreFunctions.Exit();
            }
            // Directory Ending

            // Monaco Setup
            string CFGPath = Directory.GetCurrentDirectory() + "\\bin\\settings\\configuration.json";
            string themeJson = File.ReadAllText(CFGPath);
            JObject Theme = JObject.Parse(themeJson);

            monaco.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            monaco.Size = new Size(494, 273);
            monaco.Location = new Point(5, 25);

            monaco.StartupFunction += delegate ()
            {
                if (Theme["Monaco Theme"].ToString() == "Dark")
                {
                    monaco.SetTheme(MonacoTheme.Dark);
                }
                else if (Theme["Monaco Theme"].ToString() == "Light")
                {
                    monaco.SetTheme(MonacoTheme.Light);
                }
                else
                {
                    monaco.SetTheme(MonacoTheme.Dark);
                }

                if (Theme["Text Minimap"].ToString() == "true")
                {
                    monaco.UpdateSettings(new MonacoSettings()
                    {
                        MinimapEnabled = true
                    });
                }
                else if (Theme["Text Minimap"].ToString() == "false")
                {
                    monaco.UpdateSettings(new MonacoSettings()
                    {
                        MinimapEnabled = false
                    });
                }
                else
                {
                    monaco.UpdateSettings(new MonacoSettings()
                    {
                        MinimapEnabled = true
                    });
                }
            };

            monaco.UpdateSettings(new MonacoSettings()
            {

            });
            await Task.Delay(5);
            Controls.Add(monaco);
            if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\bin\\settings\\script.txt") == "")
            {
                monaco.SetText(@"--[[
    Orion | The open-sourced EasyExploit executor.
	UI & UI Functions by ArilisDev
    DLL Functions by EasyExploit developers.
--]]");
            } else {
                monaco.SetText(File.ReadAllText(Directory.GetCurrentDirectory() + "\\bin\\settings\\script.txt"));
            }
            

            // Monaco Ending

            SavedScripts.Items.Clear();
            CoreFunctions.PopulateListBox(SavedScripts, "./scripts", "*.txt");
            CoreFunctions.PopulateListBox(SavedScripts, "./scripts", "*.lua");
            
            if (Theme["DiscordRPC"].ToString() == "true")
            {
                PHandler.StartRPC();
            }

            if (Theme["Topmost"].ToString() == "true")
            {
                this.TopMost = true;
            }
            DHandler.startJoining();
        }

        

        private void HookButton_Click(object sender, EventArgs e)
        {
            CoreFunctions.Hook();
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            CoreFunctions.Execute(monaco.Text);
        }

        private async void ExitLabel_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + "\\bin\\settings\\script.txt"))
            {
                sw.Write(monaco.Text);
            }
            await Task.Delay(1000);
            CoreFunctions.Exit();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            monaco.SetText("");
        }

        private void MinimizeLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void RefreshScriptBox_Click(object sender, EventArgs e)
        {
            SavedScripts.Items.Clear();
            CoreFunctions.PopulateListBox(SavedScripts, "./scripts", "*.txt");
            CoreFunctions.PopulateListBox(SavedScripts, "./scripts", "*.lua");
        }

        private void SavedScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            monaco.SetText(File.ReadAllText($"./scripts/{SavedScripts.SelectedItem}"));
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (CoreFunctions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(CoreFunctions.openfiledialog.FileName);
                    monaco.SetText(MainText);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void OrionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Orion was developed by ArilisDev. \n\nAdditional Credits:\n - DLL Function: EasyExploit Developers", "Orion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
