using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class itemBAL: IitemBAL
    {

        IitemDAL ItemDAL;

        public itemBAL(IitemDAL _ItemDAL)
        {
            this.ItemDAL = _ItemDAL;
        }

        public async Task<List<Item>> findById(long id)
        {
            return await ItemDAL.findById(id);
        }

        public async Task<List<Item>> findByName(string name)
        {
            return await ItemDAL.findByName(name);
        }

        public async Task<List<Item>> findBySupleir(string Supleir)
        {
            return await ItemDAL.findBySupleir(Supleir);
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await ItemDAL.GetAllItems();
        }

        public async Task<List<Item>> UpdateItems(long id, int price)
        {
            return await ItemDAL.UpdateItems(id, price);
        }
    }
}
