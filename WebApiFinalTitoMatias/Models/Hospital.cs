using System.Collections.Generic;

namespace WebApiFinalTitoMatias.Models
{
    public class Hospital
    {
        #region props
        public int Hospital_Cod { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Num_Cama { get; set; }
        #endregion

        #region prop nav
        public List<Doctor> Doctors { get; set; }
        #endregion
    }
}
