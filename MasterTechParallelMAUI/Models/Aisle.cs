using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Models
{
    /// <summary>
    /// Aisle(R_ID, RackId, FloorLvl)
    /// </summary>
    public class Aisle : ObservableObject
    {
        private int _aisleId;     // R_ID int(4)
        private int _rackId;      // Rack_ID int(4)
        private int _floorLevel;  // Floor_lvl int(1)

        [Key]
        public int AisleId
        {
            get => _aisleId;
            set => SetProperty(ref _aisleId, value);
        }

        public int RackId
        {
            get => _rackId;
            set => SetProperty(ref _rackId, value);
        }

        public int FloorLevel
        {
            get => _floorLevel;
            set => SetProperty(ref _floorLevel, value);
        }

        // Navigation
        public IList<AisleLevel> Levels { get; set; } = new List<AisleLevel>();

        public override string ToString() => $"Aisle {AisleId} (Rack {RackId}, L{FloorLevel})";
    }
}
