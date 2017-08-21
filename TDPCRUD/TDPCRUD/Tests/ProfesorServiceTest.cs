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

    public class ProfesorServiceTest
    {
        TDPCRUDEntities1 context = new TDPCRUDEntities1();
        ProfesorService profesorService = new ProfesorService();
        [Test,Order(1)]
        public void CreateProfesorTest()
        {
            AddEditProfesorViewModel objViewModel = new AddEditProfesorViewModel();
            int NumProf = context.Profesor.ToList().Count;
            objViewModel.GenerateProfesor(null, "Profesor1", "Apellidos1", "Lugar1", new DateTime(1996, 12, 18));
            profesorService.Create(objViewModel);
            int NewNumProf = context.Profesor.ToList().Count;
            Assert.AreEqual( NewNumProf,NumProf + 1);
        }
        [Test,Order(2)]
        public void UpdateProfesorTest()
        {
            Profesor objProfesor = context.Profesor.FirstOrDefault(x => x.Nombres == "Profesor1");
            AddEditProfesorViewModel objViewModel = new AddEditProfesorViewModel();
            objProfesor.Direccion = "Lugar2";
            objViewModel.GenerateProfesor(objProfesor);
            profesorService.Update(objViewModel);
            string DireccionActual = context.Profesor.FirstOrDefault(x => x.IdProfesor == objViewModel.IdProfesor).Direccion;
            Assert.AreEqual("Lugar2",DireccionActual);
        }
        [Test,Order(3)]
        public void DeleteProfesorTest()
        {
            Profesor objProfesor = context.Profesor.FirstOrDefault(x => x.Nombres == "Profesor1");
            int NumProf = context.Profesor.ToList().Count;
            profesorService.Delete(objProfesor.IdProfesor);
            int NewNumProf = context.Profesor.ToList().Count;
            Assert.AreEqual(NewNumProf, NumProf -1);
        }
    }
}