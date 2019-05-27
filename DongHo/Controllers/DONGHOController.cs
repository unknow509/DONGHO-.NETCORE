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
        //private readonly DongHoDataContext data;


        //public DONGHOController(DongHoDataContext context)
        //{
        //    data = context;

        //}

        // DongHoDataContext data = new DongHoDataContext();
        DongHoDataContext data = new DongHoDataContext();

        // GET: DONGHO
        private List<SanPham> Laydongho(int count)
        {

            //return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
            return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var donghomoi = Laydongho(3);
            return View(donghomoi);
        }
        public ActionResult SPTheoNam()
        {
            var nam = from n in data.SanPhams where n.GioiTinh.Equals("Nam") select n;
            return View(nam);
        }
        public ActionResult SPTheoNu()
        {
            var nu = from u in data.SanPhams where u.GioiTinh.Equals("Nu") select u;
            return View(nu);
        }
        public ActionResult SPTheoAutomatic()
        {
            var auto = from at in data.SanPhams where at.MaLoai == 3 select at;
            return View(auto);
        }
        public ActionResult SPTheoQuartz()
        {
            var qua = from q in data.SanPhams where q.MaLoai == 4 select q;
            return View(qua);
        }
        public ActionResult ThuongHieu()
        {
            var thuonghieu = from th in data.ThuongHieus select th;
            return PartialView(thuonghieu);
        }
        public ActionResult SPTheothuonghieu(int id)
        {
            var dongho = from dh in data.SanPhams where dh.MaThuongHieu == id select dh;
            return View(dongho);
        }
        public ActionResult Details(int id)
        {
            SanPham ct = data.SanPhams.SingleOrDefault(t => t.MaSanPham == id);

            return View(ct);
        }

    }
}
