using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.ViewModel;
using TDPCRUD.Models;

namespace TDPCRUD.Business
{
    public class ProfesorService
    {
        TDPCRUDEntities1 context = new TDPCRUDEntities1();
        public ProfesorService()
        {
        }
        public void Create(AddEditProfesorViewModel objViewModel)
        {
            Profesor objProfesor = new Profesor();
            context.Profesor.Add(objProfesor);
            objProfesor.Nombres = objViewModel.Nombres;
            objProfesor.Apellidos = objViewModel.Apellidos;
            objProfesor.Direccion = objViewModel.Direccion;
            objProfesor.FechaNacimiento = objViewModel.FechaNacimiento;

            context.SaveChanges();
        }
        public void Update(AddEditProfesorViewModel objViewModel)
        {
            Profesor objProfesor = context.Profesor.FirstOrDefault(x => x.IdProfesor == objViewModel.IdProfesor);
            objProfesor.Nombres = objViewModel.Nombres;
            objProfesor.Apellidos = objViewModel.Apellidos;
            objProfesor.Direccion = objViewModel.Direccion;
            objProfesor.FechaNacimiento = objViewModel.FechaNacimiento;

            context.SaveChanges();
        }
        public void Delete(int? IdProfesor)
        {
            Profesor objProfesor = null;
            if (IdProfesor.HasValue)
                objProfesor = context.Profesor.FirstOrDefault(x => x.IdProfesor == IdProfesor);
            else
            {
                return ;
            }
            context.Profesor.Remove(objProfesor);
            context.SaveChanges();
        }

    }
}