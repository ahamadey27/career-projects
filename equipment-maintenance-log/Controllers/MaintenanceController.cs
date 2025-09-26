using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using equipment_maintenance_log.Models;

namespace equipment_maintenance_log.Controllers
{
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
         private readonly MaintenanceContext _context;

        public MaintenanceController(MaintenanceContext context)
        {
            _context = context;
        }

        // GET: api/maintenance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceRecord>>> GetMaintenanceRecords()
        {
            return await _context.MaintenanceRecords
               .FromSqlRaw("EXEC sp_GetAllMaintenanceRecords")
               .ToListAsync();
        }

        // GET: api/maintenance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceRecord>> GetMaintenanceRecord(int id)
        {
            var record = await _context.MaintenanceRecords
               .FromSqlRaw("EXEC sp_GetMaintenanceRecordById @Id", new SqlParameter("@Id", id))
               .ToListAsync();

            if (record == null |

| record.Count == 0)
            {
                return NotFound();
            }
            return record.First();
        }

        // POST: api/maintenance
        [HttpPost]
        public async Task<ActionResult<MaintenanceRecord>> PostMaintenanceRecord(MaintenanceRecord record)
        {
            var parameters = new
            {
                new SqlParameter("@EquipmentName", record.EquipmentName),
                new SqlParameter("@Description", record.Description),
                new SqlParameter("@MaintenanceDate", record.MaintenanceDate),
                new SqlParameter("@PerformedBy", record.PerformedBy),
                new SqlParameter("@IsCompleted", record.IsCompleted)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_CreateMaintenanceRecord @EquipmentName, @Description, @MaintenanceDate, @PerformedBy, @IsCompleted", parameters);
            
            return CreatedAtAction(nameof(GetMaintenanceRecord), new { id = record.Id }, record);
        }

        // PUT: api/maintenance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceRecord(int id, MaintenanceRecord record)
        {
            if (id!= record.Id)
            {
                return BadRequest();
            }

            var parameters = new
            {
                new SqlParameter("@Id", record.Id),
                new SqlParameter("@EquipmentName", record.EquipmentName),
                new SqlParameter("@Description", record.Description),
                new SqlParameter("@MaintenanceDate", record.MaintenanceDate),
                new SqlParameter("@PerformedBy", record.PerformedBy),
                new SqlParameter("@IsCompleted", record.IsCompleted)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_UpdateMaintenanceRecord @Id, @EquipmentName, @Description, @MaintenanceDate, @PerformedBy, @IsCompleted", parameters);

            return NoContent();
        }

        // DELETE: api/maintenance/5
       
        public async Task<IActionResult> DeleteMaintenanceRecord(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteMaintenanceRecord @Id", new SqlParameter("@Id", id));

            return NoContent();
        }
    }
        
        
    }
}