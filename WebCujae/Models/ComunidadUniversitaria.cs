using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCujae.Models
{
    public class ComunidadUniversitaria
    {
        int estudiantesPregrado;
        int estudiantesPosgrado;
        int estMaestrias;
        int estEspecialidad;
        int estDoctorado;
        int estCursos;

        //********************Est. por categoria docente
        int cantDocentes;
        int cantTitulares;
        int cantAuxiliares;
        int cantAsistentes;
        int cantInstructores;

        int cantNoDocentes;

        //*********************Est. de la Universidad
        int cantCarreras;
        int cantEspecialidades;
        int cantDoctorados;
        int cantMaestrias;
        int cantLineasInv;
        int cantProgInv;

        public int EstudiantesPregrado { get => estudiantesPregrado; set => estudiantesPregrado = value; }
        public int EstudiantesPosgrado { get => estudiantesPosgrado; set => estudiantesPosgrado = value; }
        public int EstMaestrias { get => estMaestrias; set => estMaestrias = value; }
        public int EstEspecialidad { get => estEspecialidad; set => estEspecialidad = value; }
        public int EstDoctorado { get => estDoctorado; set => estDoctorado = value; }
        public int EstCursos { get => estCursos; set => estCursos = value; }
        public int CantDocentes { get => cantDocentes; set => cantDocentes = value; }
        public int CantTitulares { get => cantTitulares; set => cantTitulares = value; }
        public int CantAuxiliares { get => cantAuxiliares; set => cantAuxiliares = value; }
        public int CantAsistentes { get => cantAsistentes; set => cantAsistentes = value; }
        public int CantInstructores { get => cantInstructores; set => cantInstructores = value; }
        public int CantNoDocentes { get => cantNoDocentes; set => cantNoDocentes = value; }
        public int CantCarreras { get => cantCarreras; set => cantCarreras = value; }
        public int CantEspecialidades { get => cantEspecialidades; set => cantEspecialidades = value; }
        public int CantDoctorados { get => cantDoctorados; set => cantDoctorados = value; }
        public int CantMaestrias { get => cantMaestrias; set => cantMaestrias = value; }
        public int CantLineasInv { get => cantLineasInv; set => cantLineasInv = value; }
        public int CantProgInv { get => cantProgInv; set => cantProgInv = value; }

        public int totalEstudiantes()
        {
            return estudiantesPregrado + EstudiantesPosgrado;
        }

        


    }
}