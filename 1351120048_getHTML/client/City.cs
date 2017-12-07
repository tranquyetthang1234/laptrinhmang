using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class City
    {
        private string name;
        private ArrayList listItem;

        public City()
        {
            name = "";
            listItem = new ArrayList();
        }

        public City(string _name, ArrayList _listItem)
        {
            name = _name;
            listItem = _listItem;
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public ArrayList List
        {
            set { listItem = value; }
            get { return listItem; }
        }
    }


}
