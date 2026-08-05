using System;
using System.Web.UI;
using SistemsProyect.Model.Classes;
using SistemsProyect.Model.Enums;

namespace SistemsProyect.Components
{
    /// <summary>
    /// Página base que exige autenticación y, opcionalmente, un rol específico
    /// antes de procesar cualquier solicitud (incluidos los postbacks).
    /// </summary>
    public abstract class BasePage : Page
    {
        /// <summary>
        /// Roles con acceso a la página. Vacío = cualquier usuario autenticado y activo.
        /// </summary>
        protected virtual UserRole[] AllowedRoles { get; } = Array.Empty<UserRole>();

        private const string LoginUrl = "~/Components/Pages/Login/Login.aspx";

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // CSRF: ligar el ViewState a la sesión del usuario (defensa principal).
            ViewStateUserKey = Session.SessionID;

            // Defensa en profundidad: validar el origen en los postbacks.
            if (IsPostBack && !IsSameOriginRequest())
            {
                RedirectToLogin();
                return;
            }

            var user = Session["user"] as User;
            if (user == null || user.Active != true)
            {
                RedirectToLogin();
                return;
            }

            var roles = AllowedRoles;
            if (roles.Length > 0 && Array.IndexOf(roles, user.Role) < 0)
            {
                RedirectToLogin();
            }
        }

        private bool IsSameOriginRequest()
        {
            var origin = Request.Headers["Origin"];
            var referer = Request.Headers["Referer"];
            var from = string.IsNullOrEmpty(origin) ? referer : origin;
            if (string.IsNullOrEmpty(from))
                return true;

            if (!Uri.TryCreate(from, UriKind.Absolute, out var uri))
                return false;

            return string.Equals(uri.Scheme, Request.Url.Scheme, StringComparison.OrdinalIgnoreCase)
                   && string.Equals(uri.Host, Request.Url.Host, StringComparison.OrdinalIgnoreCase)
                   && uri.Port == Request.Url.Port;
        }

        private void RedirectToLogin()
        {
            Response.Redirect(ResolveUrl(LoginUrl), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
