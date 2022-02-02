using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace GamesCatalog.Security
{
    public class Impersonation
    {
        IConfiguration _config;

        public Impersonation(IConfiguration config)
        {
            _config = config;

        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);
        public async Task<string> SaveFiles(IFormFile file, string filePath)
        {
            // Get the user token for the specified user, domain, and password using the   
            // unmanaged LogonUser method.   
            // The local machine name can be used for the domain name to impersonate a user on this machine.
            string domainName = _config.GetSection("domain").Value;

            string userName = _config.GetSection("user").Value;

            string pass = _config.GetSection("password").Value;

            const int LOGON32_PROVIDER_DEFAULT = 0;
            //Este parametro causa que LogonUser cree un token primario 
            const int LOGON32_LOGON_INTERACTIVE = 2;
            // Llama a LogonUser para obtener un manejador para un token de acceso.   
            SafeAccessTokenHandle safeAccessTokenHandle;
            bool returnValue = LogonUser(userName, domainName, pass,
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeAccessTokenHandle);

            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                throw new System.ComponentModel.Win32Exception(ret);
            }

#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
            await WindowsIdentity.RunImpersonated(
              safeAccessTokenHandle,
              // User action
              async () =>
              {
                  try
                  {
                      if (file.Length > 0)
                      {
                          using (var strm = new FileStream(filePath, mode: FileMode.Create))
                          {

                              await file.CopyToAsync(strm);
                          }
                      }
                  }

                  catch (Exception ex)
                  {

                      throw (ex);
                  }

              }
              );
#pragma warning restore CA1416 // Validar la compatibilidad de la plataforma

            return filePath;

        }
        public async Task<byte[]> DescargarArchivo(string rutaDocumento)
        {
            byte[] fileBytes = new byte[byte.MaxValue];

            // Get the user token for the specified user, domain, and password using the   
            // unmanaged LogonUser method.   
            // The local machine name can be used for the domain name to impersonate a user on this machine.
            string domainName = _config.GetSection("domain").Value;

            string userName = _config.GetSection("user").Value;

            string pass = _config.GetSection("password").Value;

            const int LOGON32_PROVIDER_DEFAULT = 0;
            //Este parametro causa que LogonUser cree un token primario 
            const int LOGON32_LOGON_INTERACTIVE = 2;
            // Llama a LogonUser para obtener un manejador para un token de acceso.   

            SafeAccessTokenHandle safeAccessTokenHandle;
            bool returnValue = LogonUser(userName, domainName, pass,
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeAccessTokenHandle);

            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                throw new System.ComponentModel.Win32Exception(ret);
            }
#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
            await WindowsIdentity.RunImpersonated(
               safeAccessTokenHandle,
               // User action
               async () =>
               {
                   try
                   {
                       if (File.Exists(rutaDocumento))
                       {
                           fileBytes = await File.ReadAllBytesAsync(rutaDocumento);
                       }
                       else
                       {
                           throw new Exception("Este Arhivo no existe 404");
                       }

                   }
                   catch (Exception ex)
                   {
                       throw ex;
                   }
               }
               );
#pragma warning restore CA1416 // Validar la compatibilidad de la plataforma

            return fileBytes;

        }

        public async Task<string> RenombrarArhvivos(string filePath)
        {
            var res = "";
            // Get the user token for the specified user, domain, and password using the   
            // unmanaged LogonUser method.   
            // The local machine name can be used for the domain name to impersonate a user on this machine.
            string domainName = _config.GetSection("domain").Value;

            string userName = _config.GetSection("user").Value;

            string pass = _config.GetSection("password").Value;

            const int LOGON32_PROVIDER_DEFAULT = 0;
            //Este parametro causa que LogonUser cree un token primario 
            const int LOGON32_LOGON_INTERACTIVE = 2;
            // Llama a LogonUser para obtener un manejador para un token de acceso.   
            SafeAccessTokenHandle safeAccessTokenHandle;
            bool returnValue = LogonUser(userName, domainName, pass,
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeAccessTokenHandle);

            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                throw new System.ComponentModel.Win32Exception(ret);
            }

#pragma warning disable CA1416 // Validar la compatibilidad de la plataforma
            await WindowsIdentity.RunImpersonated(
              safeAccessTokenHandle,
              // User action
              async () =>
              {
                  try
                  {
                      var rutaDividida = filePath.Split('.');
                      var rutaNueva = rutaDividida[0] + DateTime.Now.Ticks + '.' + rutaDividida[1];
                      res = rutaNueva.Split('\\')[rutaNueva.Split('\\').Length - 1];
                      File.Move(filePath, rutaNueva);




                  }

                  catch (Exception ex)
                  {

                      throw (ex);
                  }

              }
              );
#pragma warning restore CA1416 // Validar la compatibilidad de la plataforma

            return res;

        }
    }
}
