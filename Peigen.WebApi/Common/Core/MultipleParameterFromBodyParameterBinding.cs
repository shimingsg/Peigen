using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;


namespace Peigen.WebApi
{
    /// <summary>
    /// A Custom HttpParameterBinding to bind multiple parameters from request body
    /// </summary>
    public class MultipleParameterFromBodyParameterBinding : HttpParameterBinding
    {
        private const string MultipleBodyParameters = "MultipleBodyParameters";
        private readonly string reqKey = "reqJson";

        public MultipleParameterFromBodyParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            NameValueCollection col = TryReadBody(actionContext.Request);

            if (col == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            if (Descriptor.ParameterType == typeof(int))
            {
                int i = 0;
                int.TryParse(col[Descriptor.ParameterName], out i);
                SetValue(actionContext,i);
            }
            else if(Descriptor.ParameterType == typeof(bool))
            {
                bool flag = false;
                bool.TryParse(col[Descriptor.ParameterName], out flag);
                SetValue(actionContext, flag);
            }
            else if (Descriptor.ParameterType == typeof(string))
            {
                if (Descriptor.ParameterName == reqKey)
                {
                    string reqValue = col[Descriptor.ParameterName];
                    Dictionary<string, object> dic = new Dictionary<string, object>(0);
                    if (!string.IsNullOrEmpty(reqValue))
                    {
                        try
                        {
                            dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(reqValue);
                        }
                        catch (Exception err)
                        {
                            throw new Exception("在将reqJson信息转换成Json格式数据时出错", err);
                        }
                    }
                    SetValue(actionContext, dic);
                }
                else
                {
                    string result = col[Descriptor.ParameterName];
                    if (string.IsNullOrEmpty(result))
                    {
                        result = "";
                    }
                    SetValue(actionContext, result);
                }
            }
            else
            {
                SetValue(actionContext, col[Descriptor.ParameterName]);
            }
            // Set the binding result here
            

            // now, we can return a completed task with no result
            TaskCompletionSource<AsyncVoid> tcs = new TaskCompletionSource<AsyncVoid>();
            tcs.SetResult(default(AsyncVoid));
            return tcs.Task;
        }

        NameValueCollection TryReadBody(HttpRequestMessage request)
        {
            object result = null;
            if (!request.Properties.TryGetValue(MultipleBodyParameters, out result))
            {
                // parsing the string like firstname=Hongmei&lastname=Ge
                NameValueCollection collection = new NameValueCollection();
                result = request.Content.ReadAsFormDataAsync().Result;
                request.Properties.Add(MultipleBodyParameters, result);
            }

            return result as NameValueCollection;
        }

        private struct AsyncVoid
        {
        }
    }
}
