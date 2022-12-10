namespace CouponOps.Models
{
    public class Coupon
    {
        public Coupon(string code, int discountPercentage, int validity)
        {
            this.Code = code;
            this.DiscountPercentage = discountPercentage;
            this.Validity = validity;
        }

        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public int Validity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Coupon)
            {
                var entity = (Coupon)obj;
                return entity.Code == this.Code;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode();
        }
    }
}
