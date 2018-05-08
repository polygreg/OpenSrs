using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OpenSrs.Tests.Responses
{
    public class GetDomainsByExpireDateResultTests
    {
        [Fact]
        public void A()
        {
            var text = @"<?xml version='1.0' encoding=""UTF-8"" standalone=""no"" ?>
<!DOCTYPE OPS_envelope SYSTEM ""ops.dtd"">
<OPS_envelope>
 <header>
  <version>0.9</version>
  </header>
 <body>
  <data_block>
   <dt_assoc>
    <item key=""protocol"">XCP</item>
    <item key=""object"">DOMAIN</item>
    <item key=""response_text"">Command successful</item>
    <item key=""action"">REPLY</item>
    <item key=""attributes"">
     <dt_assoc>
      <item key=""exp_domains"">
       <dt_array>
        <item key=""0"">
         <dt_assoc>
          <item key=""f_let_expire"">N</item>
          <item key=""name"">test.co.uk</item>
          <item key=""expiredate"">2018-05-15 11:23:49</item>
          <item key=""f_auto_renew"">N</item>
         </dt_assoc>
        </item>
        <item key=""1"">
         <dt_assoc>
          <item key=""f_let_expire"">N</item>
          <item key=""name"">test2.de</item>
          <item key=""expiredate"">2018-05-16 00:00:00</item>
          <item key=""f_auto_renew"">Y</item>
         </dt_assoc>
        </item>
        <item key=""2"">
         <dt_assoc>
          <item key=""f_let_expire"">N</item>
          <item key=""name"">test3.com</item>
          <item key=""expiredate"">2018-06-10 13:57:19</item>
          <item key=""f_auto_renew"">Y</item>
         </dt_assoc>
        </item>
       </dt_array>
      </item>
      <item key=""page"">1</item>
      <item key=""remainder"">0</item>
      <item key=""total"">3</item>
     </dt_assoc>
    </item>
    <item key=""response_code"">200</item>
    <item key=""is_success"">1</item>
   </dt_assoc>
  </data_block>
 </body>
</OPS_envelope>";

            var x = GetDomainsByExpireDateResult.Parse(text);

           Assert.Equal(3, x.DomainList.Count);
           Assert.Equal("test2.de", x.DomainList[1].Name);
           Assert.Equal(3, x.Total);
        }
    }
}
