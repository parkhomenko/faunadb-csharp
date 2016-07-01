﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaunaDB.Collections;
using FaunaDB.Errors;
using FaunaDB.Query;
using FaunaDB.Types;

namespace FaunaDB.Client
{
    /// <summary>
    /// Directly communicates with FaunaDB via JSON.
    /// </summary>
    public class Client
    {
        readonly IClientIO clientIO;

        /// <param name="domain">Base URL for the FaunaDB server.</param>
        /// <param name="scheme">Scheme of the FaunaDB server. Should be "http" or "https".</param>
        /// <param name="port">Port of the FaunaDB server.</param>
        /// <param name="timeout">Timeout. Defaults to 1 minute.</param>
        /// <param name="secret">Auth token for the FaunaDB server.</param>
        /// <param name="clientIO">Optional IInnerClient. Used only for testing.</param>"> 
        public Client(
            string domain = "rest.faunadb.com",
            string scheme = "https",
            int? port = null,
            TimeSpan? timeout = null,
            string secret = null,
            IClientIO clientIO = null)
        {
            if (port == null)
                port = scheme == "https" ? 443 : 80;

            this.clientIO = clientIO ??
                new DefaultClientIO(new Uri(scheme + "://" + domain + ":" + port), timeout ?? TimeSpan.FromSeconds(60), secret);
        }

        /// <summary>
        /// Use the FaunaDB query API.
        /// </summary>
        /// <param name="expression">Expression generated by methods of <see cref="Query"/>.</param>
        /// <exception cref="FaunaException"/>
        public Task<Value> Query(Expr expression) =>
            Execute(HttpMethodKind.Post, "", data: expression);

        /// <summary>
        /// Ping FaunaDB.
        /// See the <see href="https://faunadb.com/documentation/rest#other">docs</see>. 
        /// </summary>
        /// <exception cref="FaunaException"/>
        public async Task<string> Ping(string scope = null, int? timeout = null) =>
            (string)await Execute(HttpMethodKind.Get, "ping", query: ImmutableDictionary.Of("scope", scope, "timeout", timeout?.ToString()))
                .ConfigureAwait(false);

        async Task<Value> Execute(HttpMethodKind action, string path, Expr data = null, IDictionary<string, string> query = null)
        {
            /*
            `ConfigureAwait(false)` should be used on on all `await` calls in the FaunaDB package.
            http://stackoverflow.com/questions/13489065/best-practice-to-call-configureawait-for-all-server-side-code
            http://blog.stephencleary.com/2012/02/async-and-await.html
            https://channel9.msdn.com/Series/Three-Essential-Tips-for-Async/Async-library-methods-should-consider-using-Task-ConfigureAwait-false-
            http://www.tugberkugurlu.com/archive/the-perfect-recipe-to-shoot-yourself-in-the-foot-ending-up-with-a-deadlock-using-the-c-sharp-5-0-asynchronous-language-features
            */
            var dataString = data == null ?  null : data.ToJson();
            var responseHttp = await clientIO.DoRequest(action, path, dataString, query);

            RaiseForStatusCode(responseHttp);

            var responseContent = Value.FromJson(responseHttp.ResponseContent);
            return ((ObjectV) responseContent)["resource"];
        }

        internal static void RaiseForStatusCode(RequestResult rr)
        {
            var code = rr.StatusCode;

            if (code >= 200 && code < 300)
                return;

            var responseContent = Value.FromJson(rr.ResponseContent);
            var errors = (from _ in ((ArrayV) ((ObjectV) responseContent)["errors"]) select (ErrorData) _).ToList();

            switch (code)
            {
                case 400:
                    throw new BadRequest(rr, errors);
                case 401:
                    throw new Unauthorized(rr, errors);
                case 403:
                    throw new PermissionDenied(rr, errors);
                case 404:
                    throw new NotFound(rr, errors);
                case 405:
                    throw new MethodNotAllowed(rr, errors);
                case 500:
                    throw new InternalError(rr, errors);
                case 503:
                    throw new UnavailableError(rr, errors);
                default:
                    throw new UnknowException(rr, errors);
            }
        }

    }
}
