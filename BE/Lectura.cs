using System;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Lectura
    {
        public int idlectura { set; get; }
        public int idtanque { set; get; }
        public string? nombretanque { set; get; }
        public string? fecha { set; get; }
        public string? hora { set; get; }
        public string? strhoralectura { set; get; }
        public float valor { set; get; }
        public int idusuario { set; get; }
        public string? nombreusuario { set; get; }
        public DateTime actualizacion { set; get; }

        public int Lectura_cms { set; get; }
        public int Vol_Ref { set; get; }
        public int Temperatura { set; get; }

    }
}
