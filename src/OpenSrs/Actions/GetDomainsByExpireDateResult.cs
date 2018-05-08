using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSrs
{
    public class GetDomainsByExpireDateResult
    {
        public IList<DomainsByExpireDateResultItem> DomainList { get; } = new List<DomainsByExpireDateResultItem>();
        public int Page { get; set; }
        public bool Remainder { get; set; }
        public int Total { get; set; }

        public static GetDomainsByExpireDateResult Parse(string responseText)
        {
            var response = new GetDomainsByExpireDateResult();

            var doc = XDocument.Parse(responseText);
            var resultArray = doc.XPathSelectElement(@"//item[@key=""exp_domains""]/dt_array");

            foreach (var item in ResponseHelper.ReadArray(resultArray))
            {
                var entry = new DomainsByExpireDateResultItem
                {
                    Name = item["name"],
                    LetExpire = (item["f_let_expire"] == "Y" ? true : false),
                    AutoRenew = (item["f_auto_renew"] == "Y" ? true : false),
                    ExpireDate = DateTime.ParseExact(item["expiredate"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                response.DomainList.Add(entry);
            }

            var attributes = ResponseHelper.ParseAttributes(responseText);
            response.Page = int.Parse(attributes["page"]);
            response.Remainder = (attributes["remainder"] == "1" ? true : false);
            response.Total = int.Parse(attributes["total"]);

            return response;
        }
    }

    public class DomainsByExpireDateResultItem
    {
        public string Name { get; set; }
        public bool LetExpire { get; set; }
        public bool AutoRenew { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
