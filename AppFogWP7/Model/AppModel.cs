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
    public class AppModel
    {
        public string Name { get; set; }
        public int Instances { get; set; }
        public string Stack { get; set; }
        public int Memory { get; set; }
        public List<string> Uris { get; set; }
        public DateTime Created { get; set; }

        public AppModel()
        {
            Uris = new List<string>();
        }
    }
}
