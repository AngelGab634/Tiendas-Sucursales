using Microsoft.AspNetCore.Mvc;
using Tiendas.Entities;
using Tiendas.Models;

namespace Tiendas.Controllers
{
    public class CategoryController : Controller
    {

    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        this._context = context;
    }

    public IActionResult CategoryList()
    {
        List<CategoryModel> categories = _context.Categorias.Select(category => new CategoryModel()
        {
            Id = category.Id,
            Name = category.Name,
            descripcion = category.descripcion
        }).ToList();

        return View(categories);
    }

    [HttpGet]
    public IActionResult CategoryAdd(Guid Id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult CategoryAdd(CategoryModel category)
    {
       if (!ModelState.IsValid)
    {
        return View(category);
    }

    var categoryEntity = new Categoria
    {
        Id = Guid.NewGuid(),
        Name = category.Name,
        descripcion = category.descripcion
    };

    _context.Categorias.Add(categoryEntity);
    _context.SaveChanges();

    return RedirectToAction("CategoryList", "Category");
        
    }

    public IActionResult CategoryEdit(Guid Id)
    {
        Categoria? category = this._context.Categorias.Where(p => p.Id == Id).FirstOrDefault();

        if(category == null)
        {
            return RedirectToAction("CategoryList", "Category");
        }

        CategoryModel model = new CategoryModel();
        model.Id = Id;
        model.Name = category.Name;
        model.descripcion = category.descripcion;

        return View(model);
    }

[HttpPost]
    public IActionResult CategoryEdit(CategoryModel category)
    {
        Categoria categoryEntity = this._context.Categorias.Where(p => p.Id == category.Id).First();
        if (category == null)
        {
            return View("Category");
        }
        categoryEntity.Name = category.Name;
        categoryEntity.descripcion = category.descripcion;

        this._context.Categorias.Update(categoryEntity);
        this._context.SaveChanges();

        return RedirectToAction("CategoryList", "Category");
    }
    [HttpGet]
    public IActionResult CategoryDeleted(Guid Id)
    {
        Categoria? category = this._context.Categorias.Where(p => p.Id == Id).FirstOrDefault();

        if (category == null)
        {
            return RedirectToAction("CateogryList", "Category");
        }

        CategoryModel model = new CategoryModel();
        model.Id = Id;
        model.Name = category.Name;
        model.descripcion = category.descripcion;
        
        return View(model);
    }
    [HttpPost]
    public IActionResult CategoryDeleted(CategoryModel category)
    {
        bool exits = this._context.Categorias.Any(p => p.Id == category.Id);
        if(!exits)
        {
            return View(category);
        }


        Categoria categoryEntity = this._context.Categorias.Where(p => p.Id == category.Id).First();

        this._context.Categorias.Remove(categoryEntity);
        this._context.SaveChanges();

        return RedirectToAction("CategoryList", "Category");

    }
    }
}
    
