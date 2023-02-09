using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11__
{
    interface IClientEdit
    {

        bool SetName(int Id, string Name);
        /// <summary>
        /// Меняет Surname в Db.Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="Name">Surname</param>
        /// <returns>Прошло ли изменение</returns>
        bool SetSurname(int Id, string Surname);
        /// <summary>
        /// Меняет Patronymic в Db.Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="Name">Patronymic</param>
        /// <returns>Прошло ли изменение</returns>
        bool SetPatronymic(int Id, string Patronymic);
        /// <summary>
        /// Меняет PhoneNumber в Db.Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="Name">PhoneNumber</param>
        /// <returns>Прошло ли изменение</returns>
        bool SetPhoneNumber(int Id, string PhoneNumber);
        /// <summary>
        /// Меняет Passport в Db.Clients по Id
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="Name">Passport</param>
        /// <returns>Прошло ли изменение</returns>
        bool SetPassport(int Id, string Passport);

    }
}
