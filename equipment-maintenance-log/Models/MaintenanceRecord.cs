using Microsoft.EntityFrameworkCore;

namespace equipment_maintenance_log.Models;

public class MaintenanceRecord
{
    public int Id { get; set; }
    public string EquipmentName { get; set; }
    public string Description { get; set; }
    public DateTime MaintenanceDate { get; set; }
    public string PerformedB { get; set; }
    public bool IsCompleted { get; set; }
}


