using System;
using System.Text;

namespace Concretec.Pedidos.BE
{
    public class Tanque
    {
        public int      IdTanque        { set; get; }
        public string? Nombre          { set; get; }
        public string   IdCiudad        { set; get; }
        public string   ciudad          { set; get; }
        public int      IdPlanta        { set; get; }
        public string   planta          { set; get; }
        public string   capacidad       { set; get; }
        public int      IdTipoCombustible { set; get; }
        public string   combustible     { set; get; }
        public float    lecturaactual   { set; get; }
        public string   fecha           { set; get; }
        public string   hora            { set; get; }
        public string   lectura         { set; get; }
        public string   lecturafinal    { set; get; }
        public string   entrada         { set; get; }
        public string   salida          { set; get; }
        public string   unidades        { set; get; }
        public string   observaciones   { set; get; }

        public int viajes               { set; get; }
        public double M3                { set; get; }
        public double Combustible       { set; get; }
        public double Horas             { set; get; }
        public double Kilometros        { set; get; }
        public string NombreUnidad      { set; get; }
        public int    IdUnidad          { set; get; }

        public decimal Altura { set; get; }
        public string Forma { set; get; }
        public decimal DiametroA  { set; get; }
        public decimal DiametroB  { set; get; }

        //Datos de la ultima lectura
        public double LecturaCms { set; get; }
        public double VolActual15C { set; get; }
        public double VolActualTA { set; get; }

        //Datos para guardar los valores
        public double InvActualCms { set; get; }
        public DateTime FechaMovimiento { set; get; }
        public DateTime HoraMovimiento { set; get; }
        public double TempActual { set; get; }
        public double InvActualLts { set; get; }
        public double InvActual15CLts { set; get; }
        public int UsuarioIdRegistro { set; get; }
        public int TipoMovimientoId { set; get; }

        //Datos detalle de la transaccion
        public int ProveedorId { set; get; }
        public string Remision { set; get; }
        public double LtsTempAmbiente { set; get; }
        public double NInvExistente15C { set; get; }
        public double NInvTAmbiente { set; get; }
        public double NInvCms { set; get; }
        public string ObservacionesIn { set; get; }
        // Volumen y Altura de un Tanque
        public float Volumen { set; get; }

        // Campos para SP BUSCA_VOLUMEN_TEMPERATURA
        public int AjusteVolumetricoId { set; get; }
        public float Temperatura { set; get; }
        public float FactorAjuste { set; get; }
        public float FactorEstimado { set; get; }
        public float Densidad { set; get; }
        public float DensidadEstimada { set; get; }
        public float VolumenAjustado { set; get; }

        //Campos Adicionales para la salida de combustible
        public float litrosCargados { set; get; }
        public float odometro_actual { set; get; }
        public float horimetro_actual { set; get; }
        public string FolioVale { set; get; }
        public string ConsecutivoBomba { set; get; }
        public int PlantaId_Unidad { set; get; }
        public int OperadorId { set; get; }

        //Campos Consulta de Calculo de salidas para la salida de combustible
        public float DistRecorridaOdometro { set; get; }
        public float TiempoTrabajado { set; get; }
        public float DistProductiva { set; get; }
        public float DistRecorrida { set; get; }
        public DateTime UltimaFechaCarga { set; get; }
        
        //Campos adicionales para la busqueda de la remision 
        public int idMovimientoDetalle { set; get; }
        public int IdMovimiento { set; get; }

        public string Movimiento { set; get; }

        public int ObservacionesIdOut { set; get; }
    }
}
