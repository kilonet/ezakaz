using System;
using System.Collections.Generic;
using System.Text;

namespace EZakaz.Domain
{
    public class Category: DomainObject<int>
    {
        private string name;
        private int number;

        public Category()
        {
        }

        public Category(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        /// <summary>
        /// this is from sklad_be
        /// </summary>
        public virtual int Number
        {
            get { return number; }
            set { number = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }


    }
}
