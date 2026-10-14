
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productASP.Data;
using productASP.Models;

namespace productASP.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _db;

    public ProductsController(AppDbContext db)
    {
        _db = db;
    }

    // READ: Product List
    // GET /Products
    public async Task<IActionResult> Index()
    {
        var products = await _db.Products
            .AsNoTracking()
            .ToListAsync();

        return View(products);
    }

    // CREATE: Show Form
    // GET /Products/Create
    public IActionResult Create()
    {
        return View(new Product());
    }

    // CREATE: Save Product
    // POST /Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,Price,Quantity")] Product product)
    {
        if (!ModelState.IsValid)
            return View(product);

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // READ: Single Product
    // GET /Products/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    // UPDATE: Show Edit Form
    // GET /Products/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    // UPDATE: Save Changes
    // POST /Products/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Name,Price,Quantity")] Product input)
    {
        if (id != input.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(input);

        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        product.Name = input.Name;
        product.Price = input.Price;
        product.Quantity = input.Quantity;

        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // DELETE: Confirmation Page
    // GET /Products/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    // DELETE: Confirm
    // POST /Products/Delete/1
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        _db.Products.Remove(product);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
