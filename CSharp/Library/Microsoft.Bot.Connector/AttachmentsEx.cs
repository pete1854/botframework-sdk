// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Bot.Connector
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json.Linq;
    using System.Net.Http;
    using System.Configuration;
    using System.Threading.Tasks;
    using System.IO;

    public partial class Attachments
    {
        /// <summary>
        /// Get the URI of an attachment view
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <param name="viewId">default is "original"</param>
        /// <returns>uri</returns>
        public string GetAttachmentUri(string attachmentId, string viewId = "original")
        {
            if (attachmentId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "attachmentId");
            }

            // Construct URL
            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v3/attachments/{attachmentId}/views/{viewId}").ToString();
            url = url.Replace("{attachmentId}", Uri.EscapeDataString(attachmentId));
            url = url.Replace("{viewId}", Uri.EscapeDataString(viewId));
            return url;
        }

        /// <summary>
        /// Get the given attachmentid view as a stream
        /// </summary>
        /// <param name="attachmentId">attachmentid</param>
        /// <param name="viewId">view to get (default:original)</param>
        /// <returns>stream of attachment</returns>
        public Task<Stream> GetAttachmentStreamAsync(string attachmentId, string viewId = "original")
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStreamAsync(GetAttachmentUri(attachmentId, viewId));
            }
        }
    }
}
