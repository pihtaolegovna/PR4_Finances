using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace PR4_Finances
{
    class Data : MainWindow
    {
        private string Title;
        private string Type;
        private double Money;
        private string StatusColor;
        public string statusColor
        {
            get { return StatusColor; }
            set { StatusColor = value; }
        }

        public DateTime date { get; set; }

        public string title
        {
            get { return Title; }
            set { Title = value; }
        }

        public double money
        {
            get { return Money; }
            set { Money = value; }
        }

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

        void create()
        {
            
        }
    }
}
