using ReadMailData.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMailData.Dao
{
    public class RequestsDao
    {
        ReadMail db = null;
        public RequestsDao()
        {
            db = new ReadMail();
        }
        public bool CheckRequestID(string requestID)
        {
            if (db.tbl_Requests.FirstOrDefault(x => x.id.Trim() == requestID.Trim()) == null)
                return true;
            else
                return false;
        }
        public string InsertRequests(tbl_Requests requests)
        {
            db.tbl_Requests.Add(requests);
            db.SaveChanges();
            return requests.id;
        }
    }
}
