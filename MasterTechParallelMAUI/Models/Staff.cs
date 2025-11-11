using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Models
{
    /// <summary>
    /// Staff(SU_ID, Name)
    /// </summary>
    public class Staff : ObservableObject
    {
        private string _staffUserId = string.Empty;
        private string _name = string.Empty;

        /// <summary>SU_ID: String(16)</summary>
        [Required, MaxLength(16)]
        public string StaffUserId
        {
            get => _staffUserId;
            set => SetProperty(ref _staffUserId, value);
        }

        /// <summary>Name: Varchar(32)</summary>
        [Required, MaxLength(32)]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public override string ToString() => $"{StaffUserId} - {Name}";
    }
}
