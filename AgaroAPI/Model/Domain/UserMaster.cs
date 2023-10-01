namespace AgaroAPI.Model.Domain
{
    public class UserMaster
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
        public Guid LocId { get; set; }

        //navigate property for locationmaster

        public LocationMaster locationMaster { get; set; }

    }
}
