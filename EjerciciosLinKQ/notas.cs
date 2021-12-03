namespace EjerciciosLinKQ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notas
    {
        [Key]
        public int idnota { get; set; }

        public int idalumno { get; set; }

        public int nota { get; set; }

        public virtual alumnos alumnos { get; set; }
    }
}
