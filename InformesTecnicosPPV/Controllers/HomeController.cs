using InformesTecnicosPPV.Filters;
using InformesTecnicosPPV.Models;
using InformesTecnicosPPV.Models.ViewModel;
using InformesTecnicosPPV.Models.ViewModelInformes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace InformesTecnicosPPV.Controllers
{
    public class HomeController : Controller
    {
        #region INICIO DE APLICACION
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region ADMINISTRACION DE CLIENTES
        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Clientes()
        {

            List<ListTablaViewModel> lst;
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {
                lst = (from d in db.Cliente
                       select new ListTablaViewModel
                       {
                           id = d.Id,
                           RazonSocial = d.RazonSocial,
                           NombreFantasia = d.NombreFantasia,
                           Direccion = d.Direccion,
                           Cuit = d.Cuit,
                           Telefono = d.Telefono,
                           Email = d.Email,
                           Responsable = d.Responsable
                        
                       }).ToList();
                
            }

            return View(lst);         

        }

        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
                    {
                        var oCliente = new Cliente();
                        oCliente.Email = model.Email;
                        oCliente.Fecha = model.Fecha;
                        oCliente.NombreFantasia = model.NombreFantasia;
                        oCliente.RazonSocial = model.RazonSocial;
                        oCliente.Responsable = model.Responsable;
                        oCliente.Telefono = model.Telefono;
                        oCliente.Cuit = model.Cuit;
                        oCliente.Direccion = model.Direccion;

                        db.Cliente.Add(oCliente);
                        db.SaveChanges();
                    }

                    return Redirect("~/Home/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        //Edicion de registros de Cliente
        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {
                var oCliente = db.Cliente.Find(Id);
                model.NombreFantasia = oCliente.NombreFantasia;
                model.Email = oCliente.Email;
                model.RazonSocial = oCliente.RazonSocial;
                model.Telefono = oCliente.Telefono;
                model.Cuit = oCliente.Cuit;
                model.Direccion = oCliente.Direccion;
                model.Id = oCliente.Id;
                model.Responsable = oCliente.Responsable;
                model.Fecha = oCliente.Fecha;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
                    {
                        var oCliente = db.Cliente.Find(model.Id);
                        oCliente.Email = model.Email;
                        oCliente.Fecha = model.Fecha;
                        oCliente.NombreFantasia = model.NombreFantasia;
                        oCliente.Cuit = model.Cuit;
                        oCliente.Responsable = model.Responsable;
                        oCliente.RazonSocial = model.RazonSocial;
                        oCliente.Direccion = model.Direccion;
                        oCliente.Telefono = model.Telefono;

                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Home/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



            // BOTON DE ELIMINAR CLIENTE
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {

                var oCliente = db.Cliente.Find(Id);
                db.Cliente.Remove(oCliente);
                db.SaveChanges();
            }
            return Redirect("~/Home/Clientes");
        }

        //public ActionResult Buscar( string filtro)
        //{
        //    using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
        //    {
        //        if (!string.IsNullOrEmpty(filtro))
        //        {
        //            var query = db.Cliente.Where(o => o.RazonSocial.Contains(filtro) || o.NombreFantasia.Contains(filtro) || o.Direccion.Contains(filtro) || o.Cuit.Contains(filtro) || o.Telefono.Contains(filtro) || o.Email.Contains(filtro) || o.Responsable.Contains(filtro)).ToList();
        //            return View(query);
        //        }
                
        //    }
        //    return Redirect("~/Home/");
        //}

        #endregion


        #region INFORMES TECNICOS
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult InformesTecnicos()
        {

            List<ListTablaViewModelInformes> lst;
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {
                lst = (from i in db.Informes
                       select new ListTablaViewModelInformes
                       {
                           Id = i.Id,
                           NombreInforme = i.NombreInforme,
                           Fecha = i.Fecha,
                           Vencimiento = i.Vencimiento,
                           Manual = i.Manual,
                           FileName = i.FileName,
                           ContentType = i.ContentType,
                           IdCliente = i.IdCliente


                       }).ToList();

                return View(lst);
            }

        }

        //CARGA DE INFORMES TECNICOS
        public ActionResult CargarInforme()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CargarInforme(TablaViewModelInformes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
                    {
                        var oInforme = new Informes();
                        oInforme.Fecha = model.Fecha;
                        oInforme.Vencimiento = model.Vencimiento;
                        oInforme.ContentType = model.ContentType;
                        oInforme.NombreInforme = model.NombreInforme;
                        oInforme.TipoInforme = model.TipoInforme;
                        //oInforme.Cliente = model.Cliente.RazonSocial;

                        db.Informes.Add(oInforme);
                        db.SaveChanges();
                    }

                    return Redirect("~/Home/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        //EDICION DE INFORMES
        public ActionResult EditarInforme(int Id)
        {
            TablaViewModelInformes model = new TablaViewModelInformes();
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {
                var oInforme = db.Informes.Find(Id);
                model.NombreInforme = oInforme.NombreInforme;
                model.TipoInforme = oInforme.TipoInforme;
                model.Fecha = oInforme.Fecha;
                model.Vencimiento = oInforme.Vencimiento;
                model.Cliente = oInforme.Cliente;
                model.ContentType = oInforme.ContentType;
                model.Id = oInforme.Id;
                model.Fecha = oInforme.Fecha;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditarInforme(TablaViewModelInformes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
                    {
                        var oInforme = db.Informes.Find(model.Id);
                        oInforme.NombreInforme = model.NombreInforme;
                        oInforme.Fecha = model.Fecha;
                        oInforme.TipoInforme = model.TipoInforme;
                        oInforme.Vencimiento = model.Vencimiento;
                        oInforme.ContentType = model.ContentType;
                        oInforme.Cliente = model.Cliente;

                        db.Entry(oInforme).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Home/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult EliminarInforme(int Id)
        {
            using (InformesTecnicosDBEntities db = new InformesTecnicosDBEntities())
            {

                var oInforme = db.Informes.Find(Id);
                db.Informes.Remove(oInforme);
                db.SaveChanges();
            }
            return Redirect("~/Home/InformesTecnicos");
        }



        #endregion
    }
}