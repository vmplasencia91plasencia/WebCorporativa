using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class ComunidadUniversitaria
    {
        [Key]
        private int id { get; set; }

        [Required]
        private String curso { get; set; }
        [Required]
        public int estudiantesPregrado { get; set; }
        [Required]
        public int estudiantesPosgrado { get; set; }

        public int[] integersArray { get; set; } // List of Integers
        public int selectedInteger { get; set; } // Somewhere to store selected integer

        [Required]
        public int estMaestrias { get; set; }
        [Required]
        public int estEspecialidad { get; set; }
        [Required]
        public int estDoctorado { get; set; }
        [Required]
        public int estCursos { get; set; }

        //********************Est. por categoria docente
        
        [Required]
        public int cantTitulares { get; set; }
        [Required]
        public int cantAuxiliares { get; set; }
        [Required]
        public int cantAsistentes { get; set; }
        [Required]
        public int cantInstructores { get; set; }
        [Required]
        public int cantNoDocentes { get; set; }

        //*********************Est. de la Universidad
        [Required]
        public int cantCarreras { get; set; }
        [Required]
        public int cantEspecialidades { get; set; }
        [Required]
        public int cantDoctorados { get; set; }
        [Required]
        public int cantMaestrias { get; set; }
        [Required]
        public int cantLineasInv { get; set; }
        [Required]
        public int cantProgInv { get; set; }
        public int totalEstudiantes { get => totalEstudiantes ; set => totalEstudiantes = estudiantesPregrado + estudiantesPosgrado; }
        public int totalEstudiantesPos { get => totalEstudiantesPos; set => totalEstudiantesPos = estMaestrias + estEspecialidad + estDoctorado + estCursos; } 
        public int totalDocentes { get => totalDocentes; set => totalDocentes = cantTitulares + cantAuxiliares + cantAsistentes + cantInstructores; }
        

    }
}