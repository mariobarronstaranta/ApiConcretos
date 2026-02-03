using System;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class TanqueMovimiento
    {
        // campos de la tabla
        public int      IdMovimiento { set; get; }
        public int      idtanque { set; get; }
        public int      IdTipoMovimiento { set; get; }
        public float    valor { set; get; }
        public DateTime FechaMovimiento { set; get; }
        public DateTime FechaActualizacion { set; get; }
        public int      IdUsuarioActualizacion { set; get; }
        public int      Idunidad { set; get; }
        public float    horimetro { set; get; }
        public float    odometro { set; get; }
        public int      idoperador { set; get; }

        // Campos salida
        public string nombretanque { set; get; }
        public string nombreunidad { set; get; }
        public string usuarioregistro { set; get; }
        public string tipomovimiento { set; get; }
        public string nombreproveedor { set; get; }
        public string Fecha { set; get; }
        public string Hora { set; get; }
        public string operdor { set; get; }
        public string nombreplanta { set; get; }
        public string referencia { set; get; }

        //DetalleEntrada
    }
}
