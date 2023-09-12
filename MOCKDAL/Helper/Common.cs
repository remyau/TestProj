using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOCKDAL.Helper
{
    public class Common
    {
        public static List<UI.MOCKTBL> GetEntries()
        {
            using (var db = new MOCKTESTDBEntities())
            {
                var cust = from tbl in db.MOCKTBLs
                           select new UI.MOCKTBL
                           {
                               FirstName = tbl.First_Name,
                               LastName = tbl.Last_Name,
                               Email = tbl.Email,
                               Id = tbl.Id
                           };
                return cust.ToList();
            }
        }

        public static UI.MOCKTBL GetEntryByID(int? Id)
        {
            var c = new UI.MOCKTBL();
            using (var db = new MOCKTESTDBEntities())
            {
                var cust = db.MOCKTBLs.Where(x => x.Id == Id).FirstOrDefault();
                if (cust != null)
                {
                    c.FirstName = cust.First_Name;
                    c.LastName = cust.Last_Name;
                    c.Email = cust.Email;
                    c.Id = cust.Id;
                }
                return c;
            }
        }

        public static void SaveRecord(UI.MOCKTBL cust)
        {
            using (var db = new MOCKTESTDBEntities())
            {
                if (cust.Id > 0)
                {
                    var cl = db.MOCKTBLs.Where(x => x.Id == cust.Id).FirstOrDefault();
                    cl.First_Name = cust.FirstName;
                    cl.Last_Name = cust.LastName;
                    cl.Email = cust.Email;
                }
                else
                {
                    MOCKTBL c = new MOCKTBL();
                    c.First_Name = cust.FirstName;
                    c.Last_Name = cust.LastName;
                    c.Email = cust.Email;
                    db.MOCKTBLs.Add(c);
                }

                db.SaveChanges();
            }
        }
    }
}
