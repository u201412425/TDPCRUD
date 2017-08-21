using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.Models;
namespace TDPCRUD.ViewModel
{
    public class LstProfesorViewModel
    {
        public List<Profesor> LstProfesor { get; set; }
        public LstProfesorViewModel()
        {
            Fill();
        }
        public void Fill()
        {
            TDPCRUDEntities1 context = new TDPCRUDEntities1();
            LstProfesor = context.Profesor.ToList();
        }
    }
}