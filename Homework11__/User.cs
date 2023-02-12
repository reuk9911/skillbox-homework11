using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace Homework11__
{
    public abstract class User : IClientMonitor, IClientEdit
    {
        #region свойства

        /// <summary>
        /// Ссылка на БД
        /// </summary>
        protected Database Db { get; }

        /// <summary>
        /// Записи текущего пользователя
        /// </summary>
        public ObservableCollection<Client> Clients { get; /*protected */set; }

        #endregion

        #region конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Db">Ссылка на БД</param>
        public User(ref Database Db)
        {
            this.Db = Db;
            
            this.Clients = new ObservableCollection<Client>();
        }

        #endregion

        

        #region методы
        /// <summary>
        /// Возвращает запись по Id
        /// </summary>
        /// <param name="Id">Id записи</param>
        /// <returns>Запись</returns>
        public Client RecordById(int Id)
        {
            var selection = from i in Clients
                            where i.Id == Id
                            select i;
            if (selection.ToArray().Length > 0)
                return selection.ToArray()[0];
            else
                return null;
        }

        /// <summary>
        /// Ищет индекс элемента в Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Возвращает индекс, или -1, если не нашел Id</returns>
        public int IndexById(int Id)
        {
            for (int i=0;i<Clients.Count; i++)
            {
                if (Clients[i].Id == Id)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Получает записи от БД и записывает их в записи User
        /// </summary>
        public abstract void Refresh();
        public abstract string GetName(int Id);
        public abstract string GetSurname(int Id);
        public abstract string GetPatronymic(int Id);
        public abstract string GetPhoneNumber(int Id);
        public abstract string GetPassport(int Id);
        public abstract string GetUserType(int Id);
        public abstract string GetLastChange(int Id);
        public abstract string GetNameOfFieldChanged(int Id);
        public abstract string GetModifyType(int Id);
        public abstract bool SetName(int Id, string Name);
        public abstract bool SetSurname(int Id, string Surname);
        public abstract bool SetPatronymic(int Id, string Patronymic);
        public abstract bool SetPhoneNumber(int Id, string PhoneNumber);
        public abstract bool SetPassport(int Id, string Passport);

        public void Sort(Client.SortCriterion sortCriterion)
        {
            List<Client> l = new List<Client>(this.Clients);
            l.Sort(Client.SortBy(sortCriterion));
            this.Clients = new ObservableCollection<Client>(l);
        }

        #endregion
    }
}