using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IitemBAL
    {
   
        Task<List<Item>> UpdateItems(long id, int price);
        Task<List<Item>> findByName(string name);
        Task<List<Item>> findById(long id);
        Task<List<Item>> findBySupleir(string Supleir);
        Task<List<Item>> GetAllItems();
    }
}
