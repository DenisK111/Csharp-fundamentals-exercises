using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1.Prototype
{
    class Menu : IEnumerable<KeyValuePair<string,HamburgerPrototype>>
    {
        private Dictionary<string, HamburgerPrototype> menu;

        public Menu()
        {
            this.menu = new Dictionary<string, HamburgerPrototype>();
        }

        public HamburgerPrototype this[string key]

        {
            get
            {
                return menu[key];
            }
            set
            {
                menu[key] = value;
            }
        }

        public IEnumerator<KeyValuePair<string, HamburgerPrototype>> GetEnumerator()
        {
            foreach (var item in menu)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
