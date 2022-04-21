using Newtonsoft.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Shared.Helpers
{
    public static class ReadHelper
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static string ReadAsString(this object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, Options);
        }

        public static string ReadAsXML(this object obj)
        {
            var jsonText = System.Text.Json.JsonSerializer.Serialize(obj, Options);
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonText);
            return doc.OuterXml;
        }
    }
}
