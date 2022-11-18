using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalTitoMatias.Models
{
    public class Doctor
    {
        #region props

        

        public int Doctor_No { get; set; }
        
        public string Apellido { get; set; }    
        public string Especialidad { get; set; }

        [Required]
        public int HospitalCod { get; set; }

        #endregion

        #region prop nav
        [ForeignKey("HospitalCod")]
        public Hospital Hospital { get; set; }

        #endregion
    }
}
