using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.Models;
using TDPCRUD.ViewModel;
using TDPCRUD.Business;
using NUnit.Framework;

namespace TDPCRUD.Tests
{
    public class CursoServiceTest
    {
        TDPCRUDEntities1 context = new TDPCRUDEntities1();
        CursoService cursoService = new CursoService();
        [Test, Order(4)]
        public void CreateCursoTest()
        {
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            int NumCur = context.Curso.ToList().Count;
            objViewModel.GenerateCurso(null, "Curso1", 50, null);
            cursoService.Create(objViewModel);
            int NewNumCur = context.Curso.ToList().Count;
            Assert.AreEqual(NewNumCur, NumCur + 1);
        }
        [Test, Order(5)]
        public void UpdateCursoTest()
        {
            Curso objCurso = context.Curso.FirstOrDefault(x => x.Nombre == "Curso1");
            AddEditCursoViewModel objViewModel = new AddEditCursoViewModel();
            objCurso.Capacidad = 30;
            objViewModel.GenerateCurso(objCurso);
            cursoService.Update(objViewModel);
            int? CapacidadActual = context.Curso.FirstOrDefault(x => x.IdCurso == objViewModel.IdCurso).Capacidad;
            Assert.AreEqual(30, CapacidadActual);
        }
        [Test, Order(6)]
        public void DeleteCursoTest()
        {
            Curso objCurso = context.Curso.FirstOrDefault(x => x.Nombre == "Curso1");
            int NumCur = context.Curso.ToList().Count;
            cursoService.Delete(objCurso.IdCurso);
            int NewNumCur = context.Curso.ToList().Count;
            Assert.AreEqual(NewNumCur, NumCur - 1);
        }
    }
}