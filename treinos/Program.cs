﻿// See https://aka.ms/new-console-template for more information
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


Console.WriteLine("Hello, World!");

MySql.Data.MySqlClient.MySqlConnection myConnection; // Conexão do MySQL

var _configuration = new ConfigurationBuilder()
    .AddJsonFile("config/appsettings.json") // O arquivo JSON onde está a ConnectionString
    .Build(); // Cria a configuração para o objeto de ConnectionString usando o que está no JSON
string? myConnectionString = ""; // myConnectionString a esse ponto ainda está vazia

if (_configuration != null) // contanto que _configuration (o construtor de configuração) seja diferente de nulo, a string de conexão é igual à presente no JSON
    myConnectionString = _configuration.GetConnectionString("myConnectionString");   //"server=127.0.0.1;uid=root;pwd=Nicholas01**;database=projeto_formulario;";

try
{
    myConnection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString); // A sessão estabelecida com o banco de dados usando os valores de conexão 
    myConnection.Open(); // Cria a conexão com o banco de dados

    
    MySqlCommand myCommand = new MySqlCommand(); // Comando SQL
    myCommand.Connection = myConnection; // Especifica em qual conexão o comando deve ser executado
    myCommand.CommandText = @"SELECT * FROM corretores2;"; // O comando a ser executado

    using var myReader = myCommand.ExecuteReader(); // Executa o comando SQL
    {
        while (myReader.Read()) // Lê os registros
        {
            var ID = myReader.GetInt32("ID");
            var employer_num = myReader.GetString("employer_num");
            var name = myReader.GetString("name");
            var company_name = myReader.GetString("company_name");
            var email = myReader.GetString("email");
            var number = myReader.GetString("number");
            var consultancy = myReader.GetString("consultancy");
            var susep_code = myReader.GetString("susep_code");
            var capitalização = myReader.GetBoolean("capitalização");
            var prev_complementar = myReader.GetBoolean("prev_complementar");
            var pessoas = myReader.GetBoolean("pessoas");
            var bens = myReader.GetBoolean("bens");
            var patrimônio = myReader.GetBoolean("patrimônio");
            var dados = myReader.GetBoolean("dados");
            var microsseguros = myReader.GetBoolean("microsseguros");
            var datacriacao = myReader.GetDateTime("datacriacao");
            var data_atualizacao = myReader.GetDateTime("data_atualizacao");

            Console.WriteLine(employer_num + ',' + name + ',' + company_name + ',' + email + ',' + number + ',' + consultancy + ',' + susep_code + ',' + capitalização + ',' + prev_complementar + ',' + pessoas + ',' + bens + ',' + patrimônio + ',' + dados + ',' + microsseguros);
        }
    }
    myConnection.Close(); // Encerra a conexão com o banco de dados
}

// Caso haja algum erro, é exibido no terminal
catch (MySql.Data.MySqlClient.MySqlException ex)
{
    Console.WriteLine(ex);
}