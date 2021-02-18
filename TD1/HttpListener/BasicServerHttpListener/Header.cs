using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BasicServerHTTPlistener
{
    class Header
    {
        string accept { get; }
        public void display_Accept() { Console.WriteLine(accept); }
        string acceptEncoding { get; }
        public void display_AcceptEncoding() { Console.WriteLine(acceptEncoding); }
        string acceptLanguage { get; }
        public void display_AcceptLanguage() { Console.WriteLine(acceptLanguage); }
        string allow { get; }
        public void display_Allow() { Console.WriteLine(allow); }
        string authorization { get; }
        public void display_Authorization() { Console.WriteLine(authorization); }
        string cookie { get; }
        public void display_Cookie() { Console.WriteLine(cookie); }
        string from { get; }
        public void display_From() { Console.WriteLine(from); }
        string userAgent { get; }
        public void display_UserAgent() { Console.WriteLine(userAgent); }

        public static string TranslateToHttpHeaderName(HttpRequestHeader enumToTranslate)
        {
            const string httpHeaderNameSeparator = "-";
            string enumName = enumToTranslate.ToString();
            var stringBuilder = new StringBuilder();

            // skip first letter
            stringBuilder.Append(enumName[0]);
            for (int i = 1; i < enumName.Length; i++)
            {
                if (char.IsUpper(enumName[i])) stringBuilder.Append(httpHeaderNameSeparator);
                stringBuilder.Append(enumName[i]);
            }
            // Cover special case for 2 character enum name "Te" to "TE" header case.
            string headerName = stringBuilder.ToString();
            if (headerName.Length == 2) headerName = headerName.ToUpper();
            return headerName;
        }

        public Header(HttpListenerRequest request)
        {
            accept = request.Headers.Get(HttpRequestHeader.Accept.ToString());
            acceptEncoding = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.AcceptEncoding));
            acceptLanguage = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.AcceptLanguage));
            allow = request.Headers.Get(HttpRequestHeader.Allow.ToString());
            authorization = request.Headers.Get(HttpRequestHeader.Authorization.ToString());
            cookie = request.Headers.Get(HttpRequestHeader.Cookie.ToString());
            from = request.Headers.Get(HttpRequestHeader.From.ToString());
            userAgent = request.Headers.Get(TranslateToHttpHeaderName(HttpRequestHeader.UserAgent));
        }
    }
}
