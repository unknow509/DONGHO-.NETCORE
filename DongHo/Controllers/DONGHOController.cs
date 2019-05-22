using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DongHo.Models;
namespace DongHo.Controllers
{
    public class DONGHOController : Controller
    {
  
        DongHoDataContext data = new DongHoDataContext();
        // GET: DONGHO
        private List<SANPHAM> Laydongho(int count)
        {

            return data.SANPHAMs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var donghomoi = Laydongho(3);
            return View(donghomoi);
        }
        public ActionResult SPTheoNam()
        {
            var nam = from n in data.SANPHAMs where n.Gioitinh.Equals("Nam") select n ;
            return View(nam);
        }
        public ActionResult SPTheoNu()
        {
            var nu = from u in data.SANPHAMs where u.Gioitinh.Equals("Nu") select u;
            return View(nu);
        }
        public ActionResult SPTheoAutomatic()
        {
            var auto = from at in data.SANPHAMs where at.MaLoai == 3 select at;
            return View(auto);
        }
        public ActionResult SPTheoQuartz()
        {
            var qua = from q in data.SANPHAMs where q.MaLoai == 4 select q;
            return View(qua);
        }
        public ActionResult ThuongHieu()
        {
            var thuonghieu = from th in data.THUONGHIEUs select th;
            return PartialView(thuonghieu);
        }
        public ActionResult SPTheothuonghieu(int id)
        {
            var dongho = from dh in data.SANPHAMs where dh.MaTH == id select dh;
            return View(dongho);
        }
        public ActionResult Details(int id)
        {
            SANPHAM ct = data.SANPHAMs.SingleOrDefault(t => t.MaSP == id);
            return View(ct);
        }

    }
}
