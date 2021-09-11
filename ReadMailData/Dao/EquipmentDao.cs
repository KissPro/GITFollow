using ReadMailData.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMailData.Dao
{
    public class EquipmentDao
    {
        ReadMail db = null;
        public EquipmentDao()
        {
            db = new ReadMail();
        }

        public int InsertEquipment(tbl_Equipment equipment)
        {
            db.tbl_Equipment.Add(equipment);
            db.SaveChanges();
            return equipment.id;
        }
        //public int InsertListImages(tbl_ImagesList imagesList)
        //{
        //    db.tbl_ImagesList.Add(imagesList);
        //    db.SaveChanges();
        //    return imagesList.id;
        //}
    }
}
