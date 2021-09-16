using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiCatalogoJogosRafa.Middleware
{
    public class ExceptionMiddleware
    {
        //RequestDelegate é um tipo do proprio aspNet Core, o Middleware sempre vai tentar chamar o next
        //depois o proximo next esse é o padrao que ele vai fazer quando ele bate na controller ele vai
        //tentar fazer o caminho de volta. Pra plugar um Middleware no meio temos que plugar Middleware que receba e chame o proximo passo nescessario.
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //HttpContext é a requisição e o aspNet Core que cuida de que Middleware chama quem.
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //se der erro um erro na controller cai no catch
                await next(context);
            }
            catch
            {
                await HandleExceptionAsync(context);
            }
        }

        //aqui trato o erro de forma personalizada, nesse caso mudados o status de retorno pra 500, poderia ser o que quiser e a mensagem também.
        //é muito usado para tratar erros gerais que não foram previsto na aplicação, e usar para gravar no Kibana, MongoDB ou outro banco de dados,etc.
        private static async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new { Message = "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde" });
        }
    }
}
