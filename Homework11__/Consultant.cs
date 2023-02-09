using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homework11__
{
    public class Consultant : User
    {
        #region поля
        private string hiddenValue = "******";
        #endregion


        #region конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Db">БД клиентов</param>
        public Consultant(ref Database Db) : base(ref Db)
        {
            Refresh();
        }

        #endregion

        #region методы
        public override string GetLastChange(int Id)
        {
            return Db.RecordById(Id).LastChange;
        }
        
        public override string GetModifyType(int Id)
        {
            return Db.RecordById(Id).ModifyType;
        }

        public override string GetName(int Id)
        {
            return Db.RecordById(Id).Name;
        }

        public override string GetNameOfFieldChanged(int Id)
        {
            return Db.RecordById(Id).NameOfFieldChanged;
        }

        public override string GetPassport(int Id)
        {
            return hiddenValue;
        }

        public override string GetPatronymic(int Id)
        {
            return Db.RecordById(Id).Patronymic;
        }

        public override string GetPhoneNumber(int Id)
        {
            return Db.RecordById(Id).PhoneNumber;
        }

        public override string GetSurname(int Id)
        {
            return Db.RecordById(Id).Surname;
        }

        public override string GetUserType(int Id)
        {
            return Db.RecordById(Id).UserType;
        }

        public override void Refresh()
        {
            int id;
            Clients.Clear();
            for (int i = 0; i < Db.Clients.Count; i++)
            {
                id = Db.Clients[i].Id;
                Client client = new Client(id, GetName(id), GetSurname(id), GetPatronymic(id), GetPhoneNumber(id),
                    GetPassport(id), GetLastChange(id), GetNameOfFieldChanged(id), GetModifyType(id), GetUserType(id));
                Clients.Add(client);
                client.PropertyChanged += ClientChangedHandler;
            }
        }

        public void ClientChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            Client c = (Client)sender;
            switch (e.PropertyName)
            {
                case "Name": SetName(c.Id, c.Name); break;
                case "Surname": SetSurname(c.Id, c.Surname); break;
                case "Patronymic": SetPatronymic(c.Id, c.Patronymic); break;
                case "PhoneNumber": SetPhoneNumber(c.Id, c.PhoneNumber); break;
                case "Passport": SetPassport(c.Id, c.Passport); break;
                default: break;
            }
        }
        
        public override bool SetName(int Id, string Name)
        {
            // Тк у Consultant нету прав доступа на изменение поля, поле в Clients не меняем,
            // Clients[i] заменяем на новый экземпляр со значениями из Db
            NoChange(Id);
            return false;
        }

        public override bool SetPassport(int Id, string Passport)
        {
            // Тк у Consultant нету прав доступа на изменение поля, поле в Clients не меняем,
            // Clients[i] заменяем на новый экземпляр со значениями из Db
            NoChange(Id);
            return false;
        }

        public override bool SetPatronymic(int Id, string Patronymic)
        {
            // Тк у Consultant нету прав доступа на изменение поля, поле в Clients не меняем,
            // Clients[i] заменяем на новый экземпляр со значениями из Db
            NoChange(Id);
            return false;
        }

        public override bool SetPhoneNumber(int Id, string PhoneNumber)
        {
            if (PhoneNumber == "") 
            {
                // Тк у Consultant при заполнении номера телефона поле должно быть заполнено,
                // Clients[i] заменяем на новый экземпляр со значениями из Db
                NoChange(Id);
                return false;
            }
            else
            {
                int index = Db.IndexById(Id);

                Clients[index].LastChange = DateTime.Now.ToString();
                Clients[index].NameOfFieldChanged = "PhoneNumber";
                Clients[index].ModifyType = "Changed";
                Clients[index].UserType = "Consultant";

                Db.Clients[index].PhoneNumber = PhoneNumber;
                Db.Clients[index].LastChange = Clients[index].LastChange;
                Db.Clients[index].NameOfFieldChanged = "PhoneNumber";
                Db.Clients[index].ModifyType = "Changed";
                Db.Clients[index].UserType = "Consultant";

                return true;
            }
        }

        public override bool SetSurname(int Id, string Surname)
        {
            // Тк у Consultant нету прав доступа на изменение поля, поле в Clients не меняем,
            // Clients[i] заменяем на новый экземпляр со значениями из Db
            NoChange(Id);
            return false;
        }

        /// <summary>
        /// Clients[IndexById(Id)] заменяем на новый экземпляр со значениями из Db
        /// </summary>
        /// <param name="Id">id</param>
        private void NoChange(int Id)
        {
            Client client =
                new Client(
                    Id,
                    GetName(Id),
                    GetSurname(Id),
                    GetPatronymic(Id),
                    GetPhoneNumber(Id),
                    GetPassport(Id),
                    GetLastChange(Id),
                    GetNameOfFieldChanged(Id),
                    GetModifyType(Id),
                    GetUserType(Id)
                    );
            client.PropertyChanged += ClientChangedHandler;
            Clients[IndexById(Id)] = client;
        }
        #endregion
    }
}