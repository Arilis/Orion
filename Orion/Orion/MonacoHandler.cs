using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Orion
{ 
    // now hold up
    public struct MonacoSettings
    {
        public bool ReadOnly;                 // Disables/Enables The Ability to Edit The Text.
        public bool AutoIndent;               // Enables auto Indentation & Adjustment
        public bool DragAndDrop;              // Enables Drag & Drop For Moving Selections of Text.
        public bool Folding;                  // Enables Code Folding.
        public bool FontLigatures;            // Enables Font Ligatures.
        public bool FormatOnPaste;            // Enables Formatting on Copy & Paste.
        public bool FormatOnType;             // Enables Formatting On Typing.
        public bool Links;                    // Enables Whether Links are clickable & detectible.
        public bool MinimapEnabled;           // Enables Whether Code Minimap is Enabled.
        public bool MatchBrackets;            // Enables Highlighting of Matching Brackets.
        public int LetterSpacing;            // Set's the Letter Spacing Between Characters.
        public int LineHeight;               // Set's the Line Height.
        public int FontSize;                 // Determine's the Font Size of the Text.
        public string FontFamily;               // Set's The Font Family for the Editor.
        public string RenderWhitespace;         // "none" | "boundary" | "all"
    };

    public enum MonacoTheme
    {
        Light = 0,
        Dark = 1
    }

    public class RegistryException : Exception
    {
        public RegistryException(string exceptionMessage = "A Registry Exception has Occured")
        {
            Message = exceptionMessage;
        }

        public override string Message { get; } = "A Registry Exception has Occured";
    }

    [ComVisible(true)]
    public class Monaco : WebBrowser
    {
        private string _renderWhitespaceObj = "none";
        public Action StartupFunction;
        private Thread _tStart;

        public Monaco()
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                var name = AppDomain.CurrentDomain.FriendlyName;
                if (key != null)
                    if (key.GetValue(name) == null)
                        key.SetValue(name, 11001, RegistryValueKind.DWord);

                ScriptErrorsSuppressed = true;
                ObjectForScripting = this;
            }
            catch (Exception e)
            {
                // Registry Error
                MessageBox.Show("Error in Monaco Class Constructor: " + e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Console.WriteLine("file:///{0}/Monaco/Monaco.html", Environment.CurrentDirectory.Replace("\\", "/"));
            Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html",
                Environment.CurrentDirectory.Replace("\\", "/")));
            DocumentCompleted += OnDocumentLoaded;
        }

        /// <summary>
        ///     Determines Whether Monaco is Readonly
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        ///     Determines Whether Minimap View for Monaco is Enabled
        /// </summary>
        public bool MinimapEnabled { get; set; }

        /// <summary>
        ///     Editor Text
        /// </summary>
        public override string Text
        {
            get => GetText();
            set => SetText(value);
        }

        /// <summary>
        ///     Determines Whether the Monaco Editor will render Whitespace
        /// </summary>
        public string RenderWhitespace
        {
            get => _renderWhitespaceObj;
            set
            {
                switch (value)
                {
                    case "none":
                        _renderWhitespaceObj = "none";
                        break;
                    case "all":
                        _renderWhitespaceObj = "all";
                        break;
                    case "boundary":
                        _renderWhitespaceObj = "boundary";
                        break;
                    default:
                        _renderWhitespaceObj = "none";
                        break;
                }
            }
        }

        public void OnDocumentLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                _tStart = new Thread(OnMonacoLoad);
                _tStart.Start();
            }
            catch (Exception)
            {
                _tStart.Start();
            }
        }

        /// <summary>
        ///     Set's Monaco Editor's Theme to the Selected Choice.
        /// </summary>
        /// <param name="theme"></param>
        public void SetTheme(MonacoTheme theme)
        {
            if (Document != null)
                switch (theme)
                {
                    case MonacoTheme.Dark:
                        Document.InvokeScript("SetTheme", new object[] { "Dark" });
                        break;
                    case MonacoTheme.Light:
                        Document.InvokeScript("SetTheme", new object[] { "Light" });
                        break;
                    default:
                        Document.InvokeScript("SetTheme", new object[] { "Light" });
                        break;
                }
            else
                throw new Exception("Cannot set Monaco theme while Document is null.");
        }

        /// <summary>
        ///     Set's the Text of Monaco to the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(string text)
        {
            if (Document != null)
                Document.InvokeScript("SetText", new object[] { text });
            else
                throw new Exception("Cannot set Monaco's text while Document is null.");
        }

        /// <summary>
        ///     Get's the Text of Monaco and returns it.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            if (Document != null)
                return Document.InvokeScript("GetText") as string;

            throw new Exception("Cannot get Monaco's text while Document is null.");
        }

        /// <summary>
        ///     Appends the Text of Monaco with the Parameter text.
        /// </summary>
        /// <param name="text"></param>
        public void AppendText(string text)
        {
            if (Document != null)
                SetText(GetText() + text);
            else
                throw new Exception("Cannot append Monaco's text while Document is null.");
        }

        public void GoToLine(int lineNumber)
        {
            if (Document != null)
                Document.InvokeScript("SetScroll", new object[] { lineNumber });
            else
                throw new Exception("Cannot go to Line in Monaco's Editor while Document is null.");
        }

        /// <summary>
        ///     Refreshes the Monaco editor.
        /// </summary>
        public void EditorRefresh()
        {
            if (Document != null)
                Document.InvokeScript("Refresh");
            else
                throw new Exception("Cannot refresh Monaco's editor while the Document is null.");
        }

        /// <summary>
        ///     Updates Monaco Editor's Settings with it's Parameter Structure.
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(MonacoSettings settings)
        {
            if (Document != null)
            {
                Document.InvokeScript("SwitchMinimap", new object[] { settings.MinimapEnabled });
                Document.InvokeScript("SwitchReadonly", new object[] { settings.ReadOnly });
                if (settings.RenderWhitespace != null)
                    Document.InvokeScript("SwitchRenderWhitespace", new object[] { settings.RenderWhitespace });
                Document.InvokeScript("SwitchLinks", new object[] { settings.Links });
                Document.InvokeScript("SwitchLineHeight", new object[] { settings.LineHeight });
                Document.InvokeScript("SwitchFontSize", new object[] { settings.FontSize });
                Document.InvokeScript("SwitchFolding", new object[] { settings.Folding });
                Document.InvokeScript("SwitchAutoIndent", new object[] { settings.AutoIndent });
                if (settings.RenderWhitespace != null)
                    Document.InvokeScript("SwitchFontFamily", new object[] { settings.FontFamily });
                Document.InvokeScript("SwitchFontLigatures", new object[] { settings.FontLigatures });
            }
            else
            {
                throw new Exception("Cannot change Monaco's settings while Document is null.");
            }
        }

        /// <summary>
        ///     Add's Intellisense for the specified Type.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="insert"></param>
        public void AddIntellisense(string label, string type, string description, string insert)
        {
            if (Document != null)
                Document.InvokeScript("AddIntellisense", new object[]
                {
                    label,
                    type,
                    description,
                    insert
                });
            else
                throw new Exception("Cannot edit Monaco's Intellisense while Document is null.");
        }

        /// <summary>
        ///     Creates a Syntax Error Symbol (Squigly Red Line) on the Specific Paramaters in the Editor.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="endLine"></param>
        /// <param name="endColumn"></param>
        /// <param name="message"></param>
        public void ShowSyntaxError(int line, int column, int endLine, int endColumn, string message)
        {
            if (Document != null)
                Document.InvokeScript("ShowErr", new object[] { line, column, endLine, endColumn, message });
            else
                throw new Exception("Cannot show Syntax Error for Monaco while Document is null.");
        }



        /// <summary>
        ///     This is for Loading Settings that are from the Control's Initializing Settings
        /// </summary>
        protected virtual void OnMonacoLoad()
        {
            Application.DoEvents();
            Thread.Sleep(100);
            BeginInvoke(new MethodInvoker(delegate
            {

                UpdateSettings(new MonacoSettings
                {
                    ReadOnly = ReadOnly,
                    MinimapEnabled = MinimapEnabled,
                    RenderWhitespace = _renderWhitespaceObj
                });
                StartupFunction?.Invoke();
            }));
        }

    }
}
