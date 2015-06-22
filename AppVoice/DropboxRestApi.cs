using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVoice
{
    public class DropboxRestApi
    {
        public const string ApiVersion = "1";

        public const string BaseUri = "https://api.dropbox.com/" + ApiVersion + "/";

        public const string ShareUri = "https://api.dropbox.com/" + ApiVersion + "/shares/auto/";

        public const string AuthorizeBaseUri = "https://www.dropbox.com/" + ApiVersion + "/";

        public const string ApiContentServer = "https://api-content.dropbox.com/" + ApiVersion + "/";
    }
}