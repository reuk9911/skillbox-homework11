using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11__
{
    interface IClientMonitor
    {
        /// <summary>
        /// Запрашивает Clients в БД
        /// </summary>
        void Refresh();
        /// <summary>
        /// Запрашивает в БД поле Name по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Name</returns>
        string GetName(int Id);
        /// <summary>
        /// Запрашивает в БД поле Surname по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Surname</returns>
        string GetSurname(int Id);
        /// <summary>
        /// Запрашивает в БД поле Patronymic по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Patronymic</returns>
        string GetPatronymic(int Id);
        /// <summary>
        /// Запрашивает в БД поле PhoneNumber по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>PhoneNumber</returns>
        string GetPhoneNumber(int Id);
        /// <summary>
        /// Запрашивает в БД поле Passport по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>Passport</returns>
        string GetPassport(int Id);
        /// <summary>
        /// Запрашивает в БД поле UserType по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>UserType</returns>

        string GetUserType(int Id);
        /// <summary>
        /// Запрашивает в БД поле LastChange по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>LastChange</returns>
        string GetLastChange(int Id);
        /// <summary>
        /// Запрашивает в БД поле NameOfFieldChanged по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>NameOfFieldChanged</returns>
        string GetNameOfFieldChanged(int Id);
        /// <summary>
        /// Запрашивает в БД поле ModifyType по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>ModifyType</returns>
        string GetModifyType(int Id);
    }
}
