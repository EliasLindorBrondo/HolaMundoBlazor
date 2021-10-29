
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoBlazor.BD.Data.Entidades
{
    [Index(nameof(CodArticulo), Name = "UQ_Articulo_Cod", IsUnique = true)]

    public class Articulo
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo es obligatorio.")]
        [MaxLength(5, ErrorMessage = "El maximo es  de {1} caracteres.")]
        public string CodArticulo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(120,ErrorMessage ="El maximo de caracteres es {1}.")]
        public string NombreArticulo { get; set; }
        [Required(ErrorMessage = "El descripción es obligatorio.")]
        public string DescripcionArticulo { get; set; }

        [Required(ErrorMessage = "La unidad es obligatoria.")]
        public int UnidadArticulo { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int CantidadArticulo { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria.")]
        [MaxLength(100,ErrorMessage ="El maximo de caracteres es {1}.")]
        public string Categoria { get; set; }



    }
}
