//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caja_Unapec
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.MOVIMIENTO = new HashSet<MOVIMIENTO>();
        }
    
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public System.DateTime Fecha_Ingreso { get; set; }
        public bool Estado { get; set; }
        public int IdTanda { get; set; }
    
        public virtual TANDA TANDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOVIMIENTO> MOVIMIENTO { get; set; }
    }
}
