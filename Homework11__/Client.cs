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
    public class Client : INotifyPropertyChanged
    {
        #region поля

        /// <summary>
        /// Использованные Id
        /// </summary>
        private static List<int> UsedIds;


        private int id;
        private string name;
        private string surname;
        private string patronymic;
        private string phoneNumber;
        private string passport;
        private string userType;
        private string lastChange;
        private string nameOfFieldChanged;
        private string modifyType;
        #endregion

        #region свойства
        /// <summary>
        /// Id
        /// </summary>
        public int Id
        {
            get => this.id;
            set => value = this.Id;
        }


        /// <summary>
        /// Имя
        /// </summary>

        public string Name
        {
            get => this.name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>

        public string Surname
        {
            get => this.surname;
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>

        public string Patronymic
        {
            get => this.patronymic;
            set
            {
                if (patronymic != value)
                {
                    patronymic = value;
                    OnPropertyChanged("Patronymic");
                }
            }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        /// <summary>
        /// Паспорт
        /// </summary>

        public string Passport
        {
            get => this.passport;
            set
            {
                if (passport != value)
                {
                    passport = value;
                    OnPropertyChanged("Passport");
                }
            }
        }

        /// <summary>
        /// Кто изменил данные(консультант или менеджер).
        /// </summary>

        public string UserType
        {
            get => this.userType;
            set
            {
                if (userType != value)
                {
                    userType = value;
                    OnPropertyChanged("UserType");
                }
            }
        }
        /// <summary>
        /// дата и время изменения записи
        /// </summary>

        public string LastChange
        {
            get => this.lastChange;
            set
            {
                if (lastChange != value)
                {
                    lastChange = value;
                    OnPropertyChanged("LastChange");
                }
            }
        }
        /// <summary>
        /// какие данные изменены
        /// </summary>

        public string NameOfFieldChanged
        {
            get => this.nameOfFieldChanged;
            set
            {
                if (nameOfFieldChanged != value)
                {
                    nameOfFieldChanged = value;
                    OnPropertyChanged("NameOfFieldChanged");
                }
            }
        }
        /// <summary>
        /// Тип изменений
        /// </summary>

        public string ModifyType
        {
            get => this.modifyType;
            set
            {
                if (modifyType != value)
                {
                    modifyType = value;
                    OnPropertyChanged("ModifyType");
                }
            }
        }

        #endregion

        #region конструкторы

        static Client()
        {
            UsedIds = new List<int>();
        }

        public Client(int Id, string Name, string Surname, string Patronymic, string PhoneNumber,
            string Passport, string LastChange, string NameOfFieldChanged, string ModifyType, string UserType) :
            this(Id, Name, Surname, Patronymic, PhoneNumber, Passport)
        {
            this.lastChange = LastChange;
            this.nameOfFieldChanged = NameOfFieldChanged;
            this.modifyType = ModifyType;
            this.userType = UserType;

        }

        public Client(int Id, string Name, string Surname, string Patronymic, string PhoneNumber, string Passport)
        {
            this.id = Id;
            this.name = Name;
            this.surname = Surname;
            this.patronymic = Patronymic;
            this.phoneNumber = PhoneNumber;
            this.passport = Passport;
            Client.UsedIds.Add(Id);
        }

        public Client(string Name, string Surname, string Patronymic, string PhoneNumber, string Passport)
        {
            this.id = Client.GetNewId();
            this.name = Name;
            this.surname = Surname;
            this.patronymic = Patronymic;
            this.phoneNumber = PhoneNumber;
            this.passport = Passport;
            Client.UsedIds.Add(Id);
        }

        #endregion

        #region события
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        #region методы
        /// <summary>
        /// Выдает новый Id для записи
        /// </summary>
        /// <returns>Id для новой записи</returns>
        private static int GetNewId()
        {
            int i = 0;
            do
            {
                i++;
            }
            while (Client.UsedIds.Contains(i));
            Client.UsedIds.Add(i);
            return i;
        }

        public static IComparer<Client> SortBy(SortCriterion Criterion)
        {
            switch (Criterion)
            {
                case SortCriterion.Id: return new SortById(); 
                case SortCriterion.Name: return new SortByName(); 
                case SortCriterion.Surname: return new SortBySurname(); 
                case SortCriterion.Patronymic: return new SortByPatronymic(); 
                default: return null; 
            }
        }

        #endregion

        #region перечисления

        public enum SortCriterion{Id, Name, Surname, Patronymic};

        #endregion

        #region вложенные классы
        private class SortByName : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return String.Compare(x.Name, y.Name);
            }
        }

        private class SortBySurname : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return String.Compare(x.Surname, y.Surname);
            }
        }

        private class SortByPatronymic : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return String.Compare(x.Patronymic, y.Patronymic);
            }
        }

        private class SortById : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                if (x.Id >= y.Id) return 0;
                else return -1;
            }
        }

        #endregion

    }
}
