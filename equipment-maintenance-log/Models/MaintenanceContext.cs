using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using equipment_maintenance_log.Models;

namespace equipment_maintenance_log.Models
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options) : base(options)
        {

        }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        
    }
}