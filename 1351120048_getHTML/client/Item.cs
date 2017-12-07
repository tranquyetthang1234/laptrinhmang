using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Item
    {
        private float buy, sell;
        private string type;

        public Item()
        {
            buy = sell = 0;
            type = "";
        }

        public Item(float _buy, float _sell, string _type)
        {
            buy = _buy;
            sell = _sell;
            type = _type;
        }

        public float Buy
        {
            set { buy = value; }
            get { return buy; }
        }

        public float Sell
        {
            set { sell = value; }
            get { return sell; }
        }

        public string Type
        {
            set { type = value; }
            get { return type; }
        }
    }
}
