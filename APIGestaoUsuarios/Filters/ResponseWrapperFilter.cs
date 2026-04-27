using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGestaoUsuarios.Filters
{
    public class ResponseWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as ObjectResult;
            if (result?.Value != null)
            {
                var wrapped = new
                {
                    dados_resposta = result.Value,
                    timestamp_resposta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    tempo_da_resposta = "N/A"
                };
                context.Result = new JsonResult(wrapped);
            }
        }
    }
}
