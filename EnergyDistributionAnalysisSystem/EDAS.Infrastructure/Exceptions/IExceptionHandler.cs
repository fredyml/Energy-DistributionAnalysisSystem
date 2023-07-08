using Microsoft.AspNetCore.Mvc;

namespace EDAS.Infrastructure.Exceptions
{
    public interface IExceptionHandler
    {
        IActionResult Handle(Exception exception);
    }
}
