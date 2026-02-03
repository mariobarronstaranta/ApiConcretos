using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace TanquesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturasController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LecturasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearLectura([FromBody] LecturaRequest request)
        {
            // Validaciones
            if (request == null)
                return BadRequest("El cuerpo de la solicitud es requerido.");

            if (request.IDTanque <= 0)
                return BadRequest("IDTanque debe ser un número positivo.");

            if (request.IDUsuarioRegistro <= 0)
                return BadRequest("IDUsuarioRegistro debe ser un número positivo.");

            if (request.CuentaLitros < 0)
                return BadRequest("CuentaLitros debe ser un número no negativo.");

            // Parsear Fecha
            if (!DateTime.TryParse(request.Fecha, out var fechaDate))
                return BadRequest("Formato de Fecha inválido. Ejemplo: 2026-02-01");

            // Parsear Hora (como TimeSpan o DateTime)
            TimeSpan horaTime;
            if (!TimeSpan.TryParse(request.Hora, out horaTime))
            {
                if (DateTime.TryParse(request.Hora, out var horaDateTime))
                {
                    horaTime = horaDateTime.TimeOfDay;
                }
                else
                {
                    return BadRequest("Formato de Hora inválido. Ejemplo: 14:30:00 o 14:30");
                }
            }

            // Construir valores para SMALLDATETIME
            var fechaParam = new DateTime(fechaDate.Year, fechaDate.Month, fechaDate.Day, 0, 0, 0);
            var horaParam = new DateTime(fechaDate.Year, fechaDate.Month, fechaDate.Day,
                                         horaTime.Hours, horaTime.Minutes, horaTime.Seconds);

            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                
                if (string.IsNullOrEmpty(connectionString))
                    return StatusCode(500, "Error de configuración: ConnectionString no está configurada.");
                
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (var command = new SqlCommand("INSERTA_LECTURA", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@IDTanque", SqlDbType.Int).Value = request.IDTanque;
                        command.Parameters.Add("@Fecha", SqlDbType.SmallDateTime).Value = fechaParam;
                        command.Parameters.Add("@Hora", SqlDbType.SmallDateTime).Value = horaParam;
                        command.Parameters.Add("@LecturaCms", SqlDbType.Float).Value = request.LecturaCms;
                        command.Parameters.Add("@Temperatura", SqlDbType.Int).Value = request.Temperatura;
                        command.Parameters.Add("@CuentaLitros", SqlDbType.Int).Value = request.CuentaLitros;
                        command.Parameters.Add("@IDUsuarioRegistro", SqlDbType.Int).Value = request.IDUsuarioRegistro;

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok(new { success = true, message = "Lectura registrada exitosamente." });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inesperado: {ex.Message}");
            }
        }
    }

    public class LecturaRequest
    {
        public int IDTanque { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public float LecturaCms { get; set; }
        public int Temperatura { get; set; }
        public int CuentaLitros { get; set; }
        public int IDUsuarioRegistro { get; set; }
    }
}