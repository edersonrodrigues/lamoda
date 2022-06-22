using LogService;
using System;
using System.Configuration;
using System.ServiceModel;

namespace Rgm.LogHelper
{
	public static class Log
	{

		public static string InserirLog(TipoMensagem tipoMensagem, string origemErro, Exception error, string addressEndpoint)
		{
			LogClient proxyCliente = null;

			try
			{

				proxyCliente = new LogClient();
				proxyCliente.Endpoint.Address = new System.ServiceModel.EndpointAddress(addressEndpoint);

				var logReq = new InclusaoLogReq()
				{
					DsWCFServico = "CMM.Api",
					DsMensagem = error.Message, //string.IsNullOrEmpty(mensagem) ? "": mensagem.Substring(0, mensagem.Length > 400 ? 400 : mensagem.Length),
					IdTipoMensagem = tipoMensagem,
					DsPilhaMensagem = error.StackTrace.Substring(0, error.StackTrace.Length > 4000 ? 4000 : error.StackTrace.Length),
					DsFonte = origemErro,
					DsPlataforma = "CMM.Api",
					DsTipoAtributo = "ERROR ID",
					DsUsuario = ""
				};

				logReq.DsValorAtributo = Guid.NewGuid().ToString().ToUpper();
				var retorno = proxyCliente.IncluirLog(logReq);

				if (retorno.Resultado == StatusInclusaoLog.Erro)
					return logReq.DsValorAtributo;
			}
			catch (Exception)
			{
				if (proxyCliente != null)
					proxyCliente.Abort();
			}
			finally
			{
				if (proxyCliente != null)
					proxyCliente.Close();
			}

			return string.Empty;
		}
	}

}