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
    /// Product(P_ID, RL_ID FK, R_ID FK, stockOnRack, stockInTotal)
    /// </summary>
    public class Product : ObservableObject
    {
        private long _productId;      // P_ID int(13) -> long
        private int _aisleLevelId;    // RL_ID FK
        private int _aisleId;         // R_ID FK
        private int _stockOnRack;     // int(4)
        private int _stockInTotal;    // int(8)

        [Key]
        public long ProductId
        {
            get => _productId;
            set => SetProperty(ref _productId, value);
        }

        [ForeignKey(nameof(AisleLevel))]
        public int AisleLevelId
        {
            get => _aisleLevelId;
            set => SetProperty(ref _aisleLevelId, value);
        }

        [ForeignKey(nameof(Aisle))]
        public int AisleId
        {
            get => _aisleId;
            set => SetProperty(ref _aisleId, value);
        }

        /// <summary>Stock currently placed on the rack (units)</summary>
        [Range(0, int.MaxValue)]
        public int StockOnRack
        {
            get => _stockOnRack;
            set => SetProperty(ref _stockOnRack, value);
        }

        /// <summary>Total stock counted across warehouse (units)</summary>
        [Range(0, int.MaxValue)]
        public int StockInTotal
        {
            get => _stockInTotal;
            set => SetProperty(ref _stockInTotal, value);
        }

        // Navigation
        public AisleLevel? AisleLevel { get; set; }
        public Aisle? Aisle { get; set; }

        /// <summary>
        /// stockCheck(): returns true if current rack stock is valid (non-negative and not exceeding total).
        /// </summary>
        public bool StockCheck() => StockOnRack >= 0 && StockInTotal >= 0 && StockOnRack <= StockInTotal;

        /// <summary>
        /// locateItem(P_ID) -> (RL_ID, R_ID)
        /// Convenience tuple that mirrors the diagram's method signature.
        /// </summary>
        public (int aisleLevelId, int aisleId) LocateItem() => (AisleLevelId, AisleId);

        public override string ToString() => $"#{ProductId} @ Aisle {AisleId} / Level {AisleLevelId} (Rack {StockOnRack}/{StockInTotal})";
    }
}
