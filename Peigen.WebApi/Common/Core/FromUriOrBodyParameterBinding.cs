using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;


namespace Peigen.WebApi
{
    /// <summary>
    /// A Custom HttpParameterBinding to bind a complex type either from request body or uri
    /// </summary>
    public class FromUriOrBodyParameterBinding : HttpParameterBinding
    {
        HttpParameterBinding _defaultUriBinding;
        HttpParameterBinding _defaultFormatterBinding;

        public FromUriOrBodyParameterBinding(HttpParameterDescriptor desc)
            : base(desc)
        {
            _defaultUriBinding = new FromUriAttribute().GetBinding(desc);
            _defaultFormatterBinding = new FromBodyAttribute().GetBinding(desc);
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.Request.Content != null && actionContext.Request.Content.Headers.ContentLength > 0)
            {
                // [FromBody]读取信息
                return _defaultFormatterBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);
            }
            else
            {
                // [FromUri]读取信息
                return _defaultUriBinding.ExecuteBindingAsync(metadataProvider, actionContext, cancellationToken);
            }
        }

    }
}
