namespace API.Models
{
    public class AccountRole
    {
        public int Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int AccountGuid { get; set; }
        public int RoleGuid { get; set; }
    }
}