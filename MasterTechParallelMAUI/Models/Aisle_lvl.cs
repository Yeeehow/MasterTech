using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Models
{
    /// <summary>
    /// Aisle_lvl(RL_ID, R_ID FK)
    /// </summary>
    public class AisleLevel : ObservableObject
    {
        private int _levelId;   // RL_ID int(2)
        private int _aisleId;   // R_ID FK

        [Key]
        public int LevelId
        {
            get => _levelId;
            set => SetProperty(ref _levelId, value);
        }

        [ForeignKey(nameof(Aisle))]
        public int AisleId
        {
            get => _aisleId;
            set => SetProperty(ref _aisleId, value);
        }

        // Navigation
        public Aisle? Aisle { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();

        public override string ToString() => $"Aisle {AisleId} - Level {LevelId}";
    }
}
