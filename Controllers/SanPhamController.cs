using Microsoft.AspNetCore.Mvc;
using NhomSeven.Models;

namespace NhomSeven.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbcontext _context;
        public SanPhamController(ApplicationDbcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lstindex = _context.sanPhams.ToList();
            return View(lstindex);
        }
        public IActionResult Details(Guid Id) 
        {
            var lstde= _context.sanPhams.Find(Id);
            return View(lstde);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SanPham sp, IFormFile uploadFile)
        {
            if(uploadFile!= null && uploadFile.Length > 0)
            {
                using (var memorystream= new MemoryStream())
                {
                    uploadFile.CopyTo(memorystream);
                    sp.ImageUrl = memorystream.ToArray();
                }
            }
            _context.sanPhams.Add(sp);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid Id) 
        {
            var lsted = _context.sanPhams.Find(Id);
            return View(lsted);
        }
        [HttpPost]
        public IActionResult Edit(SanPham sp, IFormFile uploadFile)
        {
            var item = _context.sanPhams.Find(sp.ID);

            item.tensp = sp.tensp;
            item.giatien = sp.giatien;
            item.mota = sp.mota;
            item.trangthai = sp.trangthai;
            if (uploadFile != null && uploadFile.Length > 0)
            {
                using (var memorystream = new MemoryStream())
                {
                    uploadFile.CopyTo(memorystream);
                    sp.ImageUrl = memorystream.ToArray();
                }
            }
            _context.sanPhams.Update(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid Id)
        {
            var sanPham = _context.sanPhams.Find(Id);

            if (sanPham == null)
            {
                return NotFound(); // Handle the case where the entity does not exist
            }

            _context.sanPhams.Remove(sanPham);
            _context.SaveChanges(); // Persist the changes to the database

            return RedirectToAction(nameof(Index));
        }

    }
}
