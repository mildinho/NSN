using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace NSN.Biblioteca
{
    public class Cookie
    {


        private readonly IHttpContextAccessor _contexto;
        public Cookie(IHttpContextAccessor context)
        {
            _contexto = context;
        }

        public void Cadastrar(string Key, string Valor)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);

            try
            {
                _contexto.HttpContext.Response.Cookies.Append(Key, Valor, options);
            }
            catch (Exception x)
            {
                
            }

        }

        public void Atualizar(string Key, string Valor)
        {
            if (Existe(Key))
            {
                Remover(Key);
            }

            Cadastrar(Key, Valor);


        }

        public void Remover(string Key)
        {
            _contexto.HttpContext.Response.Cookies.Delete(Key);
        }

        public string Consultar(string Key)
        {
            return _contexto.HttpContext.Request.Cookies[Key];
        }

        public bool Existe(string Key)
        {

            if (Consultar(Key) == null)
            {
                return false;
            }

            return true;
        }

        public void RemoverTodos()
        {
            var ListaCookie = _contexto.HttpContext.Request.Cookies.ToList();
            foreach (var item in ListaCookie)
            {

                Remover(item.Key);

            }
        }

    }
}
