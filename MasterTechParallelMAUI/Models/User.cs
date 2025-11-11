using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTechParallelMAUI.Models
{
    /// <summary>
    /// User(U_ID, Name)
    /// </summary>
    public class User : ObservableObject
    {
        private string _userId = string.Empty;
        private string _name = string.Empty;

        /// <summary>U_ID: String(16)</summary>
        [Required, MaxLength(16)]
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        /// <summary>Name: Varchar(32)</summary>
        [Required, MaxLength(32)]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public override string ToString() => $"{UserId} - {Name}";
    }
}
