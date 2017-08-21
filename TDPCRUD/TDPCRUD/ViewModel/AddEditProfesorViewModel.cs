using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.Models;
namespace TDPCRUD.ViewModel
{
    public class AddEditProfesorViewModel
    {
        public int? IdProfesor          { get; set; }
        public String Nombres            { get; set; }
        public String Apellidos          { get; set; }
        public String Direccion          { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public AddEditProfesorViewModel()
        {
        }

        public void GenerateProfesor(Profesor objProfesor)
        {
            IdProfesor = objProfesor.IdProfesor;
            Nombres = objProfesor.Nombres;
            Apellidos = objProfesor.Apellidos;
            Direccion = objProfesor.Direccion;
            FechaNacimiento = objProfesor.FechaNacimiento;
        }
        public void GenerateProfesor(int? IdProfesor,String Nombres,String Apellidos
            , String Direccion,DateTime? FechaNacimiento)
        {
            this.IdProfesor = IdProfesor;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Direccion  = Direccion;
            this.FechaNacimiento = FechaNacimiento;
        }
        public void Fill(int? IdProfesor)
        {
            this.IdProfesor = IdProfesor;

            if (IdProfesor.HasValue)
            {
                TDPCRUDEntities1 context = new TDPCRUDEntities1();
                Profesor objProfesor= context.Profesor.FirstOrDefault(x => x.IdProfesor == IdProfesor);
                this.Nombres = objProfesor.Nombres;
                this.Apellidos = objProfesor.Apellidos;
                this.Direccion = objProfesor.Direccion;
                this.FechaNacimiento = (DateTime)objProfesor.FechaNacimiento;
            }
        }
    }
}