using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework11__
{
    public class CommonRecord
    {
        public List<CommonField> Fields { get; }


        private ReadOnlyDictionary<string, AccessRightsEnum> FieldsAccess;
        private int FieldsCount;

        public static ReadOnlyCollection<string> FieldNames { get; }

        protected string GetFieldValue(string FieldName)
        {
            AccessRightsEnum access;
            if (FieldsAccess.TryGetValue(FieldName, out access) == true)
            {
                if (access == AccessRightsEnum.Read || access == AccessRightsEnum.ReadWrite)
                {
                    return FieldByName(FieldName);
                }
                else return "*****";
            }
            else return "";
        }

        static CommonRecord()
        {
            List<string> FNames = new List<string>();
            FNames.Add("Id");
            FNames.Add("FirstName");
            FNames.Add("LastName");
            FNames.Add("SecondName");
            FNames.Add("PhoneNumber");
            FNames.Add("Passport");

            FieldNames = new ReadOnlyCollection<string>(FNames);
            
        }


        public Record(ReadOnlyDictionary<string, AccessRightsEnum> FieldsAccess)
        {
            this.FieldsCount = FieldNames.Count;

            this.Id = new Field<int>(Id);
            this.FirstName = new Field<string>(FirstName);
            this.LastName = new Field<string>(LastName);
            this.SecondName = new Field<string>(SecondName);
            this.PhoneNumber = new Field<string>(PhoneNumber);
            this.Passport = new Field<string>(Passport);
        }

        public string FieldByName(string FieldName)
        {
            switch (FieldName)
            {
                case "Id": return this.Id;
                case "FirstName": return this.FirstName;
                case "LastName": return this.LastName;
                case "SecondName": return this.SecondName;
                case "PhoneNumber": return this.FirstName;
                case "Passport": return this.FirstName;
                default: return "";
            }
        }

    }
}
