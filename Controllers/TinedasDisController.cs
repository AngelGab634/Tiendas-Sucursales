using Microsoft.AspNetCore.Mvc;
using Tiendas.Entities;
using Tiendas.Models;

namespace Tiendas.Controllers
{
    public class TiendasDisController : Controller
    {
         private readonly ILogger<TiendasDisController> _logger;
        private readonly ApplicationDbContext _context;

        public TiendasDisController(ILogger<TiendasDisController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
         public IActionResult TiendaList()
        {
            List <SucursalModel> list = new List<SucursalModel> ();
            list=_context.Sucursales.Select(s => new SucursalModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    direccion = s.direccion,
                    gerenteSuc = s.gerenteSuc,
                    telefono = s.telefono

                }).ToList();

        return View(list);
        }

        public IActionResult TiendaAdd(SucursalModel sucursal)
        {
            if (!ModelState.IsValid)
            {
                return View(sucursal);
            }

            var sucursalEntity = new Sucursal
            {
                Id = Guid.NewGuid(),
                Name = sucursal.Name,
                direccion = sucursal.direccion,
                gerenteSuc = sucursal.gerenteSuc,
                telefono = sucursal.telefono
            };
    
            this._context.Sucursales.Add(sucursalEntity);
            this._context.SaveChanges();

            return RedirectToAction("TiendaList");
        }

        public IActionResult TiendaShowToDeleted(Guid id)
        {
            Sucursal? sucursal = this._context.Sucursales.FirstOrDefault(p => p.Id == id);
            if (sucursal == null)
            {
                return RedirectToAction("TiendaList");
            }

            SucursalModel model = new SucursalModel
            {
                Id = sucursal.Id,
                Name = sucursal.Name,
                direccion = sucursal.direccion,
                gerenteSuc = sucursal.gerenteSuc,
                telefono = sucursal.telefono
            };

            
            return View(model);
        }

        public IActionResult TiendaShowToEdit(Guid id)
        {
              var sucursal =_context.Sucursales.FirstOrDefault(p=>p.Id==id);
            if(sucursal == null)
            {
                return RedirectToAction("TiendaList");
            }

            var model = new SucursalModel
            {
                Id = sucursal.Id,
                Name = sucursal.Name,
                direccion = sucursal.direccion,
                gerenteSuc = sucursal.gerenteSuc,
                telefono = sucursal.telefono,
            };

            return View(model);
        }

        public IActionResult SucursalSave(SucursalModel model)
        {
            if(ModelState.IsValid)
            {
                var sucursal = _context.Sucursales.FirstOrDefault(p => p.Id==model.Id);
                if(sucursal!=null)
                {
                    sucursal.Name = model.Name;
                    sucursal.direccion = model.direccion;
                    sucursal.gerenteSuc = model.gerenteSuc;
                    sucursal.telefono = model.telefono;

                    _context.SaveChanges();
                    return RedirectToAction("TiendaList");
                }
            }
            return View(model);

        }

        [HttpPost]
        public IActionResult TiendaDeleted(Guid id)
        {
            var sucursal =_context.Sucursales.FirstOrDefault(p=>p.Id == id);
            if(sucursal != null)
            {
                _context.Sucursales.Remove(sucursal);
                _context.SaveChanges();
            }
            
            return RedirectToAction("TiendaList");
        }

       [HttpPost]
        public IActionResult SucursalEdit(SucursalModel model)
        {
               if (ModelState.IsValid)
            {
                var sucursal = _context.Sucursales.FirstOrDefault(p => p.Id == model.Id);
                if (sucursal!=null)
                {
                    sucursal.Name=model.Name;
                    sucursal.direccion = model.direccion;
                    sucursal.gerenteSuc = model.gerenteSuc;
                    sucursal.telefono=model.telefono;

                    _context.SaveChanges();
                    return RedirectToAction("TiendaList");
                }
            }

            return View(model);
         
        }

    }
}