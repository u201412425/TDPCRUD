using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.Models;
namespace TDPCRUD.ViewModel
{
    public class AddEditCursoViewModel
    {
        public int? IdCurso     { get; set; }
        public String Nombre    { get; set; }
        public int? Capacidad   { get; set; }
        public List<Profesor> LstProfesor { get; set; }
        public int? IdProfesor  { get; set; }
        public AddEditCursoViewModel()
        {
            TDPCRUDEntities1 context = new TDPCRUDEntities1();
            LstProfesor = context.Profesor.ToList();
        }
        public void GenerateCurso(int? IdCurso,String Nombre, int? Capacidad,int? IdProfesor)
        {
            this.IdCurso = IdCurso;
            this.Nombre = Nombre;
            this.Capacidad = Capacidad;
            this.IdProfesor = IdProfesor;
        }
        public void GenerateCurso(Curso objCurso)
        {
            this.IdCurso =objCurso.IdCurso;
            this.Nombre = objCurso.Nombre;
            this.Capacidad = objCurso.Capacidad;
            this.IdProfesor = objCurso.IdProfesor;
        }
        public void Fill(int? IdCurso)
        {
            this.IdCurso = IdCurso;
            if (IdCurso.HasValue)
            {
                TDPCRUDEntities1 context = new TDPCRUDEntities1();
                Curso objCurso = context.Curso.FirstOrDefault(x => x.IdCurso == IdCurso);
                this.Nombre = objCurso.Nombre;
                this.Capacidad = objCurso.Capacidad;
                this.IdProfesor = objCurso.IdProfesor;
            }
        }
    }
}