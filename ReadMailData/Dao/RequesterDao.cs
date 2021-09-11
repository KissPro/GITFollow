using ReadMailData.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMailData.Dao
{
    public class RequesterDao
    {
        ReadMail db = null;
        public RequesterDao()
        {
            db = new ReadMail();
        }

        public int InsertRequester(tbl_Requester requester)
        {
            db.tbl_Requester.Add(requester);
            db.SaveChanges();
            return requester.id;
        }
    }
}
