namespace OpenSrs
{
    using System;
    using System.Collections.Generic;
    using OpenSrs.Models;

    public class GetDomainsByExpireDateRequest : OpenSrsRequest
    {
        public GetDomainsByExpireDateRequest(DateTime expFrom, DateTime expTo, int page = 1, int limit = 40)
            : base("get_domains_by_expiredate", "domain")
        {
            this.ExpFrom = expFrom;
            this.ExpTo = expTo;
            this.Page = page;
            this.Limit = limit;
        }

        public int Page { get; set; }
        public int Limit { get; set; }
        public DateTime ExpFrom { get; set; }
        public DateTime ExpTo { get; set; }
        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "limit", Limit },
                { "exp_from", ExpFrom.ToString("yyyy-MM-dd") },
                { "exp_to", ExpTo.ToString("yyyy-MM-dd") },
                { "page", Page }
            };
        }
    }
}
