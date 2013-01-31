using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AppFogWP7.Model
{
    public class InfoModel
    {
        public string User { get; set; }
        public string Plan { get; set; }
        public int Apps { get; set; }
        public int MemoryUsed { get; set; }
        public int TotalMemory { get; set; }
        public List<string> Frameworks { get; set; }

        public InfoModel()
        {
            Frameworks = new List<string>();
        }
    }
}
