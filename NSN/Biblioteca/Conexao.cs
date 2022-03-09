using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace NSN.Biblioteca
{
    public enum ConexaoName
    {
        Furacao = 1,
        Its = 2
    }
    public static class Conexao
    {
        public static string Host { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string ServiceName { get; set; }

        public static string RetornaStringConexao(ConexaoName Name)
        {
            string retornoConexao = "";

            if (Name == ConexaoName.Furacao)
            {
                Conexao.Host = "Sacanr2.furacao.com.br";
                Conexao.UserName = "furacaophp";
                Conexao.Password = "furacao123php";
                Conexao.Database = "ofuracao";
                Conexao.ServiceName = "ofuracaoee";

                retornoConexao = String.Format("Server={0};Port=3306;Database={1};Uid={2};Pwd={3};", Conexao.Host, Conexao.Database, Conexao.UserName, Conexao.Password);
            }
            return retornoConexao;
        }

        public static OracleConnection AbreConexao(ConexaoName Name)
        {
            var conn = new OracleConnection(RetornaStringConexao(Name));
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return conn;
                }
            }
            return null;
        }

        public static void FechaConexao(OracleConnection conn)
        {
            conn.Close();
        }

    }
}


