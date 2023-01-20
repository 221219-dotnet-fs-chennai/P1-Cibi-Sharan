using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainerLibrary
{
    public interface IFileRepo<T>
    {
        public List<T> GetDetails();

        //public List<Details> Details();
        //public list<experience> Details();
        //public int CheckId(string id);
        public void AddDetails(T tb, int ID);
    }
}
