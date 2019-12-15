using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ishop.Models;

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
            return View();
        }

        // POST: IshopProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory([Bind("Id,ParentId,CatName,CatShortDetail,CatDetail,CatFeatureImg,CatPic2,CatKeywords,Status,IsFeature,Ranking,CatPermalink,CatMetatag,ShowMenu,ShowFooter,ShowHome,GoogleCategory,AddedDate,AddedBy,Extra")] IshopCategory ishopCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ishopCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexCategory));
            }
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
        public async Task<IActionResult> EditCategory(int id, [Bind("Id,ParentId,CatName,CatShortDetail,CatDetail,CatFeatureImg,CatPic2,CatKeywords,Status,IsFeature,Ranking,CatPermalink,CatMetatag,ShowMenu,ShowFooter,ShowHome,GoogleCategory,AddedDate,AddedBy,Extra")] IshopCategory ishopCategory)
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
            return View();
        }

        // POST: IshopProducts1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([Bind("Id,ProdName,ItemCode,ProdFeatureImg,ProPic2,ProdShortDetail,ProdDetail,ProdKeywords,Status,IsSpecial,IsFeature,Ranking,ProdPermalink,ProdMetaTitle,ProdMetaKeyword,GoogleCateory,HitUrl,AddedDate,AddedBy,UpdatedDate,UpdatedBy,Extra")] IshopProduct ishopProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ishopProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexProduct));
            }
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
        public async Task<IActionResult> EditProduct(int id, [Bind("Id,ProdName,ItemCode,ProdFeatureImg,ProPic2,ProdShortDetail,ProdDetail,ProdKeywords,Status,IsSpecial,IsFeature,Ranking,ProdPermalink,ProdMetaTitle,ProdMetaKeyword,GoogleCateory,HitUrl,AddedDate,AddedBy,UpdatedDate,UpdatedBy,Extra")] IshopProduct ishopProduct)
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

    }
}
