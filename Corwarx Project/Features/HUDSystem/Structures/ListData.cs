using Corwarx_Project.Features.HUDSystem.Enums;
using System.Collections.Generic;

namespace Corwarx_Project.Features.HUDSystem.Structures {
    public struct ListData {
        public List<string> Hint;
        public bool AutoStile;
        public Align Align;
        public int Size;
        public string Hex;
        public bool OverrideColor;
        public ListData(List<string> hint, bool autoStile = true, bool overrideColor = true, Align align = Align.right, int size = 15, string hex = "")  {
            Hint = hint;
            AutoStile = autoStile;
            this.Align = align;
            Size = size;
            Hex = hex;
            OverrideColor = overrideColor;
        }
    }
}
