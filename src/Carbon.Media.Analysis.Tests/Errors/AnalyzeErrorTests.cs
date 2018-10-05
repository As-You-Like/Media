using Carbon.Json;
using Xunit;

namespace Carbon.Media.Analysis
{
    public class AnalyzeErrorTests
    {
        [Fact]
        public void Parse()
        {
            var text = @"{    ""error"": {        ""code"": -858797304,        ""string"": ""Server returned 403 Forbidden(access denied)""    }}";

            var error = JsonObject.Parse(text)["error"].As<AnalyzeError>();

            Assert.Equal(-858797304, error.Code);
            Assert.Equal("Server returned 403 Forbidden(access denied)", error.String);
        }

    }
}

// '[{    "error": {        "code": -858797304,        "string": "Server returned 403 Forbidden (access denied)"    }}]'