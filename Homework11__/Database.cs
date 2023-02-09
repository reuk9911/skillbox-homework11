using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Homework11__
{
    public class Database
    {
        #region поля

        /// <summary>
        /// Использованные Id
        /// </summary>
        private HashSet<int> UsedIds;

        /// <summary>
        /// Последний выданный Id методом GetNewId
        /// </summary>
        private int LastId;

        #endregion

        #region свойства
        
        /// <summary>
        /// Коллекция записей
        /// </summary>
        public ObservableCollection<Client> Clients { get; private set; }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="FileName">Имя текстового файла с БД</param>
        public Database(string FileName)
        {
            UsedIds = new HashSet<int>();
            LastId = 1;

            Clients = new ObservableCollection<Client>();


            StreamReader Sr = new StreamReader(FileName, Encoding.Default);
            using (Sr)
            {
                string line;

                while ((line = Sr.ReadLine()) != null)
                {
                    string[] arr = line.Split('|');
                    UsedIds.Add(Convert.ToInt32(arr[0]));
                    Client r = new Client(Convert.ToInt32(arr[0]), arr[1], arr[2], arr[3], arr[4],
                        arr[5], arr[6], arr[7], arr[8], arr[9]);
                    Clients.Add(r);
                }
            }
        }

        #endregion

        #region методы

        /// <summary>
        /// Выдает новый Id для записи
        /// </summary>
        /// <returns>Id для новой записи</returns>
        public int GetNewId()
        {

            do
            {
                LastId += 1;
            }
            while (UsedIds.Contains(LastId));
            UsedIds.Add(LastId);
            return LastId;

        }

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
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].Id == Id)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Сохраняет изменения БД в файл
        /// </summary>
        public void Save()
        {
            StreamWriter Sw = new StreamWriter("Database.txt", false, Encoding.Default);
            using (Sw)
            {


                for (int i = 0; i < Clients.Count; i++)
                {
                    string line = "";
                    line += Clients[i].Id + "|";
                    line += Clients[i].Name + "|";
                    line += Clients[i].Surname + "|";
                    line += Clients[i].Patronymic + "|";
                    line += Clients[i].PhoneNumber + "|";
                    line += Clients[i].Passport + "|";
                    line += Clients[i].LastChange + "|";
                    line += Clients[i].NameOfFieldChanged + "|";
                    line += Clients[i].ModifyType + "|";
                    line += Clients[i].UserType;

                    Sw.WriteLine(line);
                }
            }
        }

        #endregion
    }
}