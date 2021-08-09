using HolaMundoBlazor.BD.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoBlazor.BD.Data.Entidades
{
    [Index(nameof(CodProvincia), Name = "UQ_Pronvicia_Cod", IsUnique = true)]
    public class Provincia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El maximo de caracteres es {1}.")]
        public string CodProvincia { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El maximo de caracteres es {1}.")]
        public string NombreProvincia { get; set; }

        public int PaisId { get; set; }

        public Pais Pais { get; set; }
    }
}
