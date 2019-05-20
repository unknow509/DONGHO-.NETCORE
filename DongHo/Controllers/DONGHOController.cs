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
        public ActionResult Loai()
        {
            var loai = from l in data.LOAIs select l;
            return PartialView();
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
