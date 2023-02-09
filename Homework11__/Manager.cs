using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Homework11__
{
    class Manager : User
    {

        #region конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Db">БД клиентов</param>
        public Manager(ref Database Db) : base(ref Db)
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
            return Db.RecordById(Id).Passport;
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

        /// <summary>
        /// Обработчик события изменения Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Меняет Name в Db.Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="Name">Name</param>
        /// <returns>Прошло ли изменение</returns>
        public override bool SetName(int Id, string Name)
        {
            int index = Db.IndexById(Id);


            Clients[index].LastChange = DateTime.Now.ToString();
            Clients[index].NameOfFieldChanged = "Name";
            Clients[index].ModifyType = "Changed";
            Clients[index].UserType = "Manager";

            Db.Clients[index].Name = Name;
            Db.Clients[index].LastChange = Clients[index].LastChange;
            Db.Clients[index].NameOfFieldChanged = Clients[index].NameOfFieldChanged;
            Db.Clients[index].ModifyType = Clients[index].ModifyType;
            Db.Clients[index].UserType = Clients[index].UserType;

            return true;
        }
        
        public override bool SetPassport(int Id, string Passport)
        {
            int index = Db.IndexById(Id);


            Clients[index].LastChange = DateTime.Now.ToString();
            Clients[index].NameOfFieldChanged = "Passport";
            Clients[index].ModifyType = "Changed";
            Clients[index].UserType = "Manager";

            Db.Clients[index].Passport = Passport;
            Db.Clients[index].LastChange = Clients[index].LastChange;
            Db.Clients[index].NameOfFieldChanged = Clients[index].NameOfFieldChanged;
            Db.Clients[index].ModifyType = Clients[index].ModifyType;
            Db.Clients[index].UserType = Clients[index].UserType;

            return true;
        }
        
        public override bool SetPatronymic(int Id, string Patronymic)
        {
            int index = Db.IndexById(Id);


            Clients[index].LastChange = DateTime.Now.ToString();
            Clients[index].NameOfFieldChanged = "Patronymic";
            Clients[index].ModifyType = "Changed";
            Clients[index].UserType = "Manager";

            Db.Clients[index].Patronymic = Patronymic;
            Db.Clients[index].LastChange = Clients[index].LastChange;
            Db.Clients[index].NameOfFieldChanged = Clients[index].NameOfFieldChanged;
            Db.Clients[index].ModifyType = Clients[index].ModifyType;
            Db.Clients[index].UserType = Clients[index].UserType;

            return true;
        }
        
        public override bool SetPhoneNumber(int Id, string PhoneNumber)
        {
            int index = Db.IndexById(Id);

            Clients[index].LastChange = DateTime.Now.ToString();
            Clients[index].NameOfFieldChanged = "PhoneNumber";
            Clients[index].ModifyType = "Changed";
            Clients[index].UserType = "Manager";

            Db.Clients[index].PhoneNumber = PhoneNumber;
            Db.Clients[index].LastChange = Clients[index].LastChange;
            Db.Clients[index].NameOfFieldChanged = Clients[index].NameOfFieldChanged;
            Db.Clients[index].ModifyType = Clients[index].ModifyType;
            Db.Clients[index].UserType = Clients[index].UserType;

            return true;
        }
        
        public override bool SetSurname(int Id, string Surname)
        {
            int index = Db.IndexById(Id);


            Clients[index].LastChange = DateTime.Now.ToString();
            Clients[index].NameOfFieldChanged = "Surname";
            Clients[index].ModifyType = "Changed";
            Clients[index].UserType = "Manager";

            Db.Clients[index].Surname = Surname;
            Db.Clients[index].LastChange = Clients[index].LastChange;
            Db.Clients[index].NameOfFieldChanged = Clients[index].NameOfFieldChanged;
            Db.Clients[index].ModifyType = Clients[index].ModifyType;
            Db.Clients[index].UserType = Clients[index].UserType;

            return true;
        }
        /// <summary>
        /// Добавляет нового клиента    
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Patronymic">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="Passport">Паспорт</param>
        public void AddRecord(string Name, string Surname, string Patronymic, string PhoneNumber, string Passport)
        {
            int id = Db.GetNewId();
            Client client = new Client(id, Name, Surname, Patronymic, PhoneNumber, Passport);
            client.LastChange = DateTime.Now.ToString();
            client.UserType = "Manager";
            client.ModifyType = "Added";
            client.NameOfFieldChanged = "";
            Clients.Add(client);
            Db.Clients.Add(client);
            client.PropertyChanged += ClientChangedHandler;
        }
        #endregion
    }
}
