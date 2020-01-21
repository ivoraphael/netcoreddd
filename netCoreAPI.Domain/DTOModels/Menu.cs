namespace netCoreAPI.Domain.DTOModels
{
    public partial class Menu : BaseDTO
    {
        public Menu()
        {

        }

        public int ParentId { get; set; }
        public string Label { get; set; }
    }
}