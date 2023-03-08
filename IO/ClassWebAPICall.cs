using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Newtonsoft.Json;

namespace IO
{
    public class ClassWebAPICall
    {
        public ClassWebAPICall()
        {

        }

        /// <summary>
        /// Denne asynkone metode kan komunikere med alle former for WEB Api'er
        /// Den skal blot modtage en komplet Url
        /// </summary>
        /// <param name="inURL">string</param>
        /// <returns>string</returns>
        public async Task<ClassCurrency> GetDataFromWebApiAsync()
        {
            var content = new MemoryStream();
            var webReq = WebRequest.Create("https://openexchangerates.org/api/latest.json?app_id=ac5d2ecd34a44f688a4060555af1773e");
            
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    await responseStream.CopyToAsync(content);
                }
            }

            return JsonConvert.DeserializeObject<ClassCurrency>(Encoding.UTF8.GetString(content.ToArray()));
        }
    }
}
