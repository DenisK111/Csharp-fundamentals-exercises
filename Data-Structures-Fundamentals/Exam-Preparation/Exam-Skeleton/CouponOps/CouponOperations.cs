namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<Website, HashSet<Coupon>> websites = new Dictionary<Website, HashSet<Coupon>>();
        private HashSet<Coupon> coupons = new HashSet<Coupon>();

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!websites.ContainsKey(website))
            {
                throw new ArgumentException();
            }

            if (coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }


            websites[website].Add(coupon);
            coupons.Add(coupon);
        }

        public bool Exist(Website website)
        {
            return websites.ContainsKey(website);
        }

        public bool Exist(Coupon coupon)
        {
            return coupons.Contains(coupon);
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!websites.ContainsKey(website))
            {
                throw new ArgumentException();
            }

            return websites[website];
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return coupons.OrderByDescending(x => x.Validity).ThenByDescending(x => x.DiscountPercentage);
        }

        public IEnumerable<Website> GetSites()
        {
            return websites.Keys;
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return websites.OrderBy(x=>x.Key.UsersCount).ThenByDescending(x=>x.Value.Count).Select(x=>x.Key);
        }

        public void RegisterSite(Website website)
        {
            if (websites.ContainsKey(website))
            {
                throw new ArgumentException();
            }

            websites[website] = new HashSet<Coupon>();
        }

        public Coupon RemoveCoupon(string code)
        {        
        
            Coupon coupon = new Coupon(code, 14, 14);
            Website website = null;
            bool isFound = false;

            foreach (var (key,value) in websites)
            {
                foreach (var c in value)
                {
                    if (c.Equals(coupon))
                    {
                        coupon = c;
                        website = key;
                        isFound = true;
                        break;
                    }
                }

                if (isFound) break;                
            }

            if (website is null)
            {
                throw new ArgumentException();
            }
            coupons.Remove(coupon);
            websites[website].Remove(coupon);
            return coupon;

        }

        public Website RemoveWebsite(string domain)
        {
            var website = websites.Keys.FirstOrDefault(x => x.Domain == domain);
            if (website is null)
            {
                throw new ArgumentException();
            }
            websites.Remove(website);
            return website;

        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!websites.ContainsKey(website))
            {
                throw new ArgumentException();
            }

            if (!websites[website].Contains(coupon))
            {
                throw new ArgumentException();
            }

            websites[website].Remove(coupon);
            coupons.Remove(coupon);
        }
    }
}
