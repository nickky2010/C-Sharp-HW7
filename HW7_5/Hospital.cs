//Создать структуру, которая должна содержать следующие элементы: 
//поля для хранения фамилии, даты рождения, даты поступления, диагноза, 
//свойство для определения продолжительности пребывания в больнице в днях, 
//метод для определения возраста.Для описания последнего поля необходимо создать перечисление
//(например, пусть diagnoz это перечисление с константами Грипп, Ангина, Пневмония, тогда поле с диагнозом должно быть описано так: 
//diagnoz bolezn;). 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_5
{
    struct Hospital
    {
        //поля для хранения фамилии
        public string LastName { get; set; }
        //даты рождения
        public DateTime DateBirthday { get; set; }
        //даты поступления 
        public DateTime DateReceipt { get; set; }
        //диагноза
        //Для описания последнего поля необходимо создать перечисление (например, пусть diagnoz это перечисление 
        //с константами Грипп, Ангина, Пневмония, тогда поле с диагнозом должно быть описано так: diagnoz bolezn;). 
        public Diagnoz Bolezn { get; set; }
        //конструктор
        public Hospital(string lastName, DateTime dateBirthday, DateTime dateReceipt, Diagnoz bolezn)
        {
            LastName = lastName;
            DateBirthday = dateBirthday;
            DateReceipt = dateReceipt;
            Bolezn = bolezn;
        }
        //свойство для определения продолжительности пребывания в больнице в днях 
        public int GetDurationOfStay()
        {
            TimeSpan ts = DateTime.Now - DateReceipt;
            return ts.Days;
        }
        //метод для определения возраста.
        public int GetAge()
        {
            return new DateTime((DateTime.Now - DateBirthday).Ticks).Year;
        }
    }
}
