using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework11__
{
    public class CommonField
    {
        private AccessRightsEnum Access;
        public string Name { get; private set; }
        public string Value { get; set; }

        public CommonField(string Name, AccessRightsEnum Access)
        {
            this.Access = Access;
            this.Name = Name;
            this.Value = "";
        }

        //public override string ToString()
        //{
        //    return Value.ToString();
        //}
    }
}