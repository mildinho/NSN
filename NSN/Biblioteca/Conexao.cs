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
        public ConexaoName ConexaoAtiva { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Porta { get; set; }
        public string Database { get; set; }
        public string ServiceName { get; set; }
        public string DataSource { get; set; }
        public OracleConnection Conn { get; set; }

        public Conexao(ConexaoName Name)
        {
            if (Name == ConexaoName.Furacao)
            {
                this.ConexaoAtiva = Name;
                this.Host = "Sacanr2.furacao.com.br";
                this.UserName = "furacaophp";
                this.Password = "furacao123php";
                this.Database = "ofuracao";
                this.ServiceName = "ofuracaoee";
                this.Porta = "1521";
                this.DataSource = String.Format("(DESCRIPTION =  (ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1})) (CONNECT_DATA = (SERVICE_NAME = {2}) (SERVER = DEDICATED) ) ) ", this.Host, this.Porta, this.ServiceName);

            }
        }

        public string RetornaStringConexao()
        {
            string retornoConexao = String.Format("User Id={0};Password={1};Data Source={2};", this.UserName, this.Password, this.DataSource);

            return retornoConexao;
        }

        public OracleConnection AbreConexao()
        {
            Conn = new OracleConnection(RetornaStringConexao());
            {
                Conn.Open();
                if (Conn.State == ConnectionState.Open)
                {
                    return Conn;
                }
            }
            return null;
        }

        public void FechaConexao()
        {
            Conn.Close();
        }

    }
}


