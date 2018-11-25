using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_5.Extend
{
    class TableHome : Table, IPrintTable
    {
        public TableHome(string headTable = "", params Column[] column) : base(headTable, column)
        {
        }
        public void Print(Diagnoz bolezn, Hospital[] hospital)
        {
            if (bolezn == Diagnoz.Грипп)
                HeadTable = "Грипп";
            else if (bolezn == Diagnoz.Ангина)
                HeadTable = "Ангина";
            else if (bolezn == Diagnoz.Пневмония)
                HeadTable = "Пневмония";
            PrintHead();
            for (int i = 0, j = 0; i < hospital.Length; i++)
            {
                if (hospital[i].Bolezn == bolezn)
                {
                    PrintString((++j).ToString(), hospital[i].LastName, hospital[i].GetAge().ToString());
                }
            }
            PrintBottom();
        }
    }
}
