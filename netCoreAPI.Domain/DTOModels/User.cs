using System.Collections.Generic;

namespace netCoreAPI.Domain.DTOModels
{
    public partial class User : BaseDTO
    {
        public User()
        {

        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}