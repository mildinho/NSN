using System;
using System.Data;
using System.Collections.Generic;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NSN.Biblioteca
{
    public enum ConexaoName
    {
        Furacao,
        Its,
        Sav
    }

    public class Conexao
    {

        private readonly ILogger _logger;
        private ConexaoName ConexaoAtiva { get; set; }
        private string Host { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        private string Porta { get; set; }
        private string Database { get; set; }
        private string ServiceName { get; set; }
        private string DataSource { get; set; }
        public OracleConnection Conn { get; set; }
        public OracleTransaction Transacao { get; set; }

        public Conexao(ConexaoName Name)
        {
            if (Name == ConexaoName.Furacao)
            {
                ConexaoAtiva = Name;
                Host = "scanr2.furacao.com.br";
                UserName = "furacaophp";
                Password = "furacaoadmphp";
                Database = "ofuracao";
                ServiceName = "ofuracaoee";
                Porta = "1521";
                DataSource = String.Format("(DESCRIPTION =  (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1})) (CONNECT_DATA = (SERVICE_NAME = {2}) (SERVER = DEDICATED) ) ) ", this.Host, this.Porta, this.ServiceName);

            }
        }

        public string RetornaStringConexao()
        {
            string retornoConexao = String.Format("User Id={0};Password={1};Data Source={2};", this.UserName, this.Password, this.DataSource);

            return retornoConexao;
        }

        public async Task<bool> AbreConexao(bool lTransacao = false)
        {
            try
            {
                Conn = new OracleConnection(RetornaStringConexao());
                {
                    await Conn.OpenAsync();
                    if (Conn.State == ConnectionState.Open)
                    {
                        if (lTransacao)
                        {
                            Transacao = Conn.BeginTransaction();
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (OracleException error)
            {
                _logger.LogError(error.Message);
                return false;
            };

        }

        public async Task<IEnumerable<T>> SQLSelect<T>(string cSql, object oParam = null)
        {
            try
            {
                IDbTransaction iTransaction = null;
                if (Transacao != null)
                {
                    iTransaction = Transacao;
                }

                var retorno = await Conn.QueryAsync<T>(cSql, oParam, iTransaction);

                return retorno;
            }
            catch (OracleException error)
            {
                
                _logger.LogError(error.Message);
                return null;
            };

        }

        public DynamicParameters DefineParametros()
        {
            var retorno = new DynamicParameters();
            return retorno;
        }

        public async Task FechaConexao()
        {
            try
            {
                if (Transacao != null)
                {
                    Transacao = null;
                }
                await Conn.CloseAsync();
            }
            catch (OracleException error)
            {
                _logger.LogError(error.Message);
            }
        }


    }
}


