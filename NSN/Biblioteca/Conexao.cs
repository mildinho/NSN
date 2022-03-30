using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;

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

        public bool AbreConexao(bool lTransacao = false)
        {
            try
            {
                Conn = new OracleConnection(RetornaStringConexao());
                {
                    Conn.Open();
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
                Log.Error(error.ToString());
                return false;
            };

        }

        public IEnumerable<T> SQLSelect<T>(string cSql, object oParam = null,CommandType? oCommandType = null)
        {
            try
            {
                IDbTransaction iTransaction = null;
                if (Transacao != null)
                {
                    iTransaction = Transacao;
                }

                var retorno = Conn.Query<T>(cSql, oParam, iTransaction,true,null,oCommandType);

                return retorno;
            }
            catch (OracleException error)
            {

                Log.Error(error.ToString());
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return null;
            }    
        }

        public OracleDynamicParameters DefineParametros()
        {
            var retorno = new OracleDynamicParameters();
            return retorno;
        }

        public void FechaConexao()
        {
            try
            {
                if (Transacao != null)
                {
                    Transacao = null;
                }
                Conn.Close();
            }
            catch (OracleException error)
            {
                Log.Error(error.ToString());

            }
        }


    }
}


