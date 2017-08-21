using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.ViewModel;
using TDPCRUD.Models;

namespace TDPCRUD.Business
{
    public class CursoService
    {
        TDPCRUDEntities1 context = new TDPCRUDEntities1();
        public CursoService()
        {
        }
        public void Create(AddEditCursoViewModel objViewModel)
        {
            Curso objCurso = new Curso();
            context.Curso.Add(objCurso);

            objCurso.Nombre = objViewModel.Nombre;
            objCurso.Capacidad = objViewModel.Capacidad;
            objCurso.IdProfesor = objViewModel.IdProfesor;

            context.SaveChanges();
        }
        public void Update(AddEditCursoViewModel objViewModel)
        {
            Curso objCurso = context.Curso.FirstOrDefault(x => x.IdCurso == objViewModel.IdCurso);
            objCurso.Nombre = objViewModel.Nombre;
            objCurso.Capacidad = objViewModel.Capacidad;
            objCurso.IdProfesor = objViewModel.IdProfesor;

            context.SaveChanges();
        }
        public void Delete(int? IdCurso)
        {
            Curso objCurso = null;
            if (IdCurso.HasValue)
                objCurso = context.Curso.FirstOrDefault(x => x.IdCurso == IdCurso);
            else
            {
                return;
            }
            context.Curso.Remove(objCurso);
            context.SaveChanges();
        }
    }
}