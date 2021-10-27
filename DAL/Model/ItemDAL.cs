using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class ItemDAL : IitemDAL
    {
        tbl_items‏Context db;
        public ItemDAL(tbl_itemsContext _db)
        {
            this.db = _db;
        }
        //פונקציית עדכון
        public async Task<List<Item>> UpdateItems(long id, int newP)
        {

            var i = await db.Items.FirstOrDefaultAsync(x => id == x.Id);

            if (id == i.Id)
            {
                if (i.NewPrice > 0)
                {
                    i.NewPrice = Convert.ToInt32(i.NewPrice - ((Convert.ToDouble(i.NewPrice)) / 100 * newP));

                }
                else
                {
                    i.NewPrice = Convert.ToInt32(Convert.ToDouble(i.Price) - (Convert.ToDouble(i.Price) / 100 * newP));
                }
                i.NewPrice = newP;
                await db.SaveChangesAsync();

            }
            return await db.Items.ToListAsync();
        }
        //חיפושים
        public async Task<List<Item>> findById(long id)
        {
            return await db.Items.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<List<Item>> findByName(string name)
        {
            return await db.Items.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<List<Item>> findBySupleir(string Supleir)
        {
            return await db.Items.Where(x => x.Supplier.Contains(Supleir)).ToListAsync();
        }
        //GetAllItems
        public async Task<List<Item>> GetAllItems()
        {
            return await db.Items.ToListAsync();
        }

      

       
       
    }
}
