using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDPCRUD.Models;

namespace TDPCRUD.ViewModel
{
    public class LstCursoViewModel
    {
        public List<Curso> LstCurso { get; set; }
        public LstCursoViewModel()
        {
            Fill();
        }
        public void Fill()
        {
            TDPCRUDEntities1 context = new TDPCRUDEntities1();
            LstCurso = context.Curso.ToList();
        }
    }
}