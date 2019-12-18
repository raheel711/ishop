using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ishop.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ishop.Controllers
{
    public class IshopProductsController : Controller
    {
        private readonly ishopContext _context;

        public IshopProductsController(ishopContext context)
        {
            _context = context;
        }

        // GET: IshopProducts
        public async Task<IActionResult> IndexCategory()
        {
            return View(await _context.IshopCategory.ToListAsync());
        }

        // GET: IshopProducts/Details/5
        public async Task<IActionResult> DetailsCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopCategory == null)
            {
                return NotFound();
            }

            return View(ishopCategory);
        }

        // GET: IshopProducts/Create
        public IActionResult CreateCategory()
        {
            ViewBag.cateorylist = ListCategories();

            return View();
        }

        // POST: IshopProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(IshopCategory ishopCategory,IFormFile FeaturedImage)
        {
            if (ModelState.IsValid)
            {
                var findCatCount = _context.IshopCategory.Where(a => a.CatName == ishopCategory.CatName).Count();
                if (findCatCount > 0)
                {
                    ViewBag.messageError = "Category Aleady Exists!!!!!";
                    ViewBag.cateorylist = ListCategories();
                    return View(ishopCategory);
                }
                if (FeaturedImage != null && FeaturedImage.Length > 0)
                {
                    //var fileName = Path.GetFileName(FeaturedImage.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(FeaturedImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Categories", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await FeaturedImage.CopyToAsync(fileSteam);
                    }
                    ishopCategory.CatFeatureImg = fileName;
                }

                ishopCategory.AddedBy = HttpContext.Session.GetString("SessionUsername");

                ishopCategory.AddedDate = DateTime.Now;
                _context.Add(ishopCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexCategory));
            }
            ViewBag.cateorylist = ListCategories();
            return View(ishopCategory);
        }

        // GET: IshopProducts/Edit/5
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory.FindAsync(id);
            if (ishopCategory == null)
            {
                return NotFound();
            }
            return View(ishopCategory);
        }

        // POST: IshopProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(int id, IshopCategory ishopCategory)
        {
            if (id != ishopCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopCategoryExists(ishopCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexCategory));
            }
            return View(ishopCategory);
        }

        // GET: IshopProducts/Delete/5
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopCategory = await _context.IshopCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopCategory == null)
            {
                return NotFound();
            }

            return View(ishopCategory);
        }

        // POST: IshopProducts/Delete/5
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedCategory(int id)
        {
            var ishopCategory = await _context.IshopCategory.FindAsync(id);
            _context.IshopCategory.Remove(ishopCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexCategory));
        }

        private bool IshopCategoryExists(int id)
        {
            return _context.IshopCategory.Any(e => e.Id == id);
        }



        /// <summary>
        /// 
        /// 
        ///         Products Actions
        /// 
        /// 
        /// </summary>
        /// <returns></returns>


        // GET: IshopProducts1
        public async Task<IActionResult> IndexProduct()
        {
            return View(await _context.IshopProduct.ToListAsync());
        }

        // GET: IshopProducts1/Details/5
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopProduct == null)
            {
                return NotFound();
            }

            return View(ishopProduct);
        }

        // GET: IshopProducts1/Create
        public IActionResult CreateProduct()
        {
            ViewBag.cateorylist = ListSubCategories();
            return View();
        }

        // POST: IshopProducts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(IshopProduct ishopProduct,IFormFile FeaturedImage)
        {
            if (ModelState.IsValid)
            {
                var findCatCount = _context.IshopProduct.Where(a => a.ProdName == ishopProduct.ProdName).Count();
                if (findCatCount > 0)
                {
                    ViewBag.messageError = "Product Aleady Exists!!!!!";
                    ViewBag.cateorylist = ListSubCategories();
                    return View(ishopProduct);
                }
                if (FeaturedImage != null && FeaturedImage.Length > 0)
                {
                    //var fileName = Path.GetFileName(FeaturedImage.FileName);
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(FeaturedImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\Products", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await FeaturedImage.CopyToAsync(fileSteam);
                    }
                    ishopProduct.ProdFeatureImg = fileName;
                }
                
                ishopProduct.AddedBy = HttpContext.Session.GetString("SessionUsername");
                ishopProduct.AddedDate = DateTime.Now;
                _context.Add(ishopProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexProduct));
            }
            ViewBag.cateorylist = ListSubCategories();
            return View(ishopProduct);
        }

        // GET: IshopProducts1/Edit/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct.FindAsync(id);
            if (ishopProduct == null)
            {
                return NotFound();
            }
            return View(ishopProduct);
        }

        // POST: IshopProducts1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id,IshopProduct ishopProduct)
        {
            if (id != ishopProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ishopProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IshopProductExists(ishopProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexProduct));
            }
            return View(ishopProduct);
        }

        // GET: IshopProducts1/Delete/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ishopProduct = await _context.IshopProduct
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ishopProduct == null)
            {
                return NotFound();
            }

            return View(ishopProduct);
        }

        // POST: IshopProducts1/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedProduct(int id)
        {
            var ishopProduct = await _context.IshopProduct.FindAsync(id);
            _context.IshopProduct.Remove(ishopProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexProduct));
        }

        private bool IshopProductExists(int id)
        {
            return _context.IshopProduct.Any(e => e.Id == id);
        }



        public List<IshopCategory> ListSubCategories() 
        {
            var data = _context.IshopCategory.Where(a=>a.ParentId!=0).OrderBy(a=>a.AddedDate).ToList();

            return data;
        }
        public List<IshopCategory> ListCategories() 
        {
            var data = _context.IshopCategory.Where(a=>a.ParentId==0).OrderBy(a=>a.AddedDate).ToList();

            return data;
        }

    }
}
