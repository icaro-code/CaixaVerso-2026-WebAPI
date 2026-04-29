using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace APIGestaoUsuarios.Filters
{
    public class ResponseWrapperFilter : IActionFilter
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Restart();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var tempoResposta = $"{_stopwatch.ElapsedMilliseconds} ms";
            var timestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            object? dadosResposta = null;
            List<string>? erros = null;

            if (context.Exception != null)
            {
                erros = new List<string> { context.Exception.Message };
                context.ExceptionHandled = true;
                context.Result = new ObjectResult(new
                {
                    dados_resposta = dadosResposta,
                    erros,
                    timestamp_resposta = timestamp,
                    tempo_da_resposta = tempoResposta
                })
                {
                    StatusCode = 500
                };
                return;
            }

            if (context.Result is ObjectResult objectResult)
            {
                if (objectResult.StatusCode >= 400)
                {
                    if (objectResult.Value is ValidationProblemDetails validationDetails)
                    {
                        erros = validationDetails.Errors.SelectMany(e => e.Value).ToList();
                    }
                    else
                    {
                        erros = new List<string> { objectResult.Value?.ToString() ?? "Erro desconhecido" };
                    }

                    context.Result = new ObjectResult(new
                    {
                        dados_resposta = dadosResposta,
                        erros,
                        timestamp_resposta = timestamp,
                        tempo_da_resposta = tempoResposta
                    })
                    {
                        StatusCode = objectResult.StatusCode
                    };
                }
                else
                {
                    dadosResposta = objectResult.Value;
                    context.Result = new ObjectResult(new
                    {
                        dados_resposta = dadosResposta,
                        erros,
                        timestamp_resposta = timestamp,
                        tempo_da_resposta = tempoResposta
                    })
                    {
                        StatusCode = objectResult.StatusCode
                    };
                }
            }
        }
    }
}
