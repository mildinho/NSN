using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

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

        public bool AbreConexao()
        {
            try
            {
                Conn = new OracleConnection(RetornaStringConexao());
                {
                    Conn.Open();
                    if (Conn.State == ConnectionState.Open)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (InvalidCastException error) { return false; };

        }


        public void FechaConexao()
        {
            Conn.Close();
        }

    }
}


