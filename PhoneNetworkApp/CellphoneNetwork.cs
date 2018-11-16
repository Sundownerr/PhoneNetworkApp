using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNetworkApp
{
    public enum SearchType
    {
        ByName,
        ByPhoneNumber
    }

    public class CellphoneNetwork
    {
        private List<Person> personList;

        public List<Person> PersonList { get => personList; set => personList = value; }

        public CellphoneNetwork()
        {
            personList = new List<Person>();
        }

        public void SearchBy(SearchType searchType)
        {
            
        }
    }
}
