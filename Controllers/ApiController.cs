using Microsoft.AspNetCore.Mvc;
using Plugin.Sample.Commerce.ExportCsv.Commands;
using Sitecore.Commerce.Core;
using Sitecore.Framework.Conditions;
using System;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace Plugin.Sample.Commerce.ExportCsv.Controllers
{

    public class ApiController : CommerceController
    {
        public ApiController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
          : base(serviceProvider, globalEnvironment)
        {
        }

        [HttpPut]
        [Route("ExportData()")]
        public async Task<IActionResult> ExportData([FromBody] ODataActionParameters value)
        {
            Condition.Requires(value, nameof(value)).IsNotNull();
            string fileName = value["fileName"].ToString();

            return await Command<ExportDataCommand>().Process(this.CurrentContext, fileName);
        }
    }
}
