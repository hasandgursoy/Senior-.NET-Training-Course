using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
 
    public class BaseController : ControllerBase
    {
        // Mediatr varsa onu kullan yoksa IOC den çöz onu getir anlamına geliyor aşşağıdaki kod.
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
    }
}
