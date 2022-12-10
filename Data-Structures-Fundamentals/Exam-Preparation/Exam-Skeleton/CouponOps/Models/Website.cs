namespace CouponOps.Models
{
    public class Website
    {
        public Website(string domain, int usersCount)
        {
            this.Domain = domain;
            this.UsersCount = usersCount;
        }

        public string Domain { get; set; }
        public int UsersCount { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Website)
            {
                var entity = (Website)obj;
                return entity.Domain == this.Domain;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Domain.GetHashCode();
        }
    }
}
