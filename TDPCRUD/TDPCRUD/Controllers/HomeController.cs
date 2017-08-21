using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDPCRUD.ViewModel;
using TDPCRUD.Models;
using TDPCRUD.Business;
namespace TDPCRUD.Controllers
{
    public class HomeController : Controller
    {
        ProfesorService profesorService = new ProfesorService();
        CursoService cursoService = new CursoService();
        public ActionResult Index()
        {
            return RedirectToAction("LstProfesor");
        }
        public ActionResult LstCurso()
        {
            LstCursoViewModel objViewModel = new LstCursoViewModel();
            return View(objViewModel);
        }
        public ActionResult LstProfesor()
        {
            LstProfesorViewModel objViewModel = new LstProfesorViewModel();
            return View(objViewModel);
        }
        [HttpGet]
        public ActionResult AddEditProfesor(int? IdProfesor)
        {
            AddEditProfesorViewModel objViewModel = new AddEditProfesorViewModel();
            objViewModel.Fill(IdProfesor);
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult AddEditProfesor(AddEditProfesorViewModel objViewModel)
        {
            try
            {
                if (objViewModel.IdProfesor.HasValue)
                    profesorService.Update(objViewModel);
                else
                {
                    profesorService.Create(objViewModel);
                }

                return RedirectToAction("LstProfesor");
            }
            catch (Exception ex)
            {
                return View(objViewModel);
            }
        }
        [HttpGet]
        public ActionResult AddEditCurso(int? IdCurso)
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objViewModel.Fill(IdCurso);
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult AddEditCurso(AddEditCursoViewModel objViewModel)
        {
            try
            {
                if (objViewModel.IdCurso.HasValue)
                    cursoService.Update(objViewModel);
                else
                {
                    cursoService.Create(objViewModel);
                }

                return RedirectToAction("LstCurso");
            }
            catch (Exception ex)
            {
                return View(objViewModel);
            }
        }
        public ActionResult DeleteCurso(int? IdCurso)
        {
            try
            {
                cursoService.Delete(IdCurso);
                
                return RedirectToAction("LstCurso");
            }
            catch (Exception ex)
            {
                return RedirectToAction("LstCurso");
            }
        }
        public ActionResult DeleteProfesor(int? IdProfesor)
        {
            try
            {
                profesorService.Delete(IdProfesor);
                return RedirectToAction("LstProfesor");
            }
            catch (Exception ex)
            {
                return RedirectToAction("LstProfesor");
            }
        }
    }
}