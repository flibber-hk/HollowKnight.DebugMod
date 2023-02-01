using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugMod.InfoPanels
{
    /// <summary>
    /// Class for an info panel that allows sending single-line messages to the panel
    /// </summary>
    public class UpdatingInfoPanel : CustomInfoPanel
    {
        private string _text = "";
        private readonly Queue<string> _lines = new();

        public void AddLine(string line)
        {
            _lines.Enqueue(line);
            while (_lines.Count > 35)
            {
                _lines.Dequeue();
            }

            _text = string.Join("\n", _lines.Reverse());
        }
        public string GetText() => _text;

        public UpdatingInfoPanel(string Name) : base(Name, true)
        {
            this.AddInfo(10f, 10f, 20f, "", GetText);
        }
    }
}
