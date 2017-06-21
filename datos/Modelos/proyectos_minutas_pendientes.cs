namespace datos.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proyectos_minutas_pendientes
    {
        [Key]
        public int id_minpendiente { get; set; }

        public int id_minuta { get; set; }

        public int? id_pinvolucrado { get; set; }

        [Required]
        [StringLength(8000)]
        public string descripcion { get; set; }

        public byte? avance { get; set; }

        [StringLength(1000)]
        public string responsable { get; set; }

        public DateTime fecha_planeada { get; set; }

        public DateTime fecha_registro { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string usuario_edicion { get; set; }

        public DateTime? fecha_edicion { get; set; }

        [StringLength(50)]
        public string usuario_borrado { get; set; }

        public DateTime? fecha_borrado { get; set; }

        [StringLength(250)]
        public string comentarios_borrado { get; set; }

        public virtual proyectos_involucrados proyectos_involucrados { get; set; }

        public virtual proyectos_minutas proyectos_minutas { get; set; }
    }
}
