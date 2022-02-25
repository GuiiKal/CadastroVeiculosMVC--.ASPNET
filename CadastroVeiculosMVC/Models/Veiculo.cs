using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroVeiculosMVC.Models
{
    public class Veiculo
    {
        const string conexaoBD = "Server=localhost; Database='AQUI VAI O NOME DO BD'; User id = root; Password='AQUI VAI A SENHA DO BD' ";
        string modelo, placa, msg;
        //criando propriedades
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public  static List<Veiculo> listarVeiculos()
        {
            
            List<Veiculo> lista = new List<Veiculo>();
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("select * from carro;", con);
                MySqlDataReader leitor = query.ExecuteReader();
                //percorre o resultado
                while (leitor.Read())
                {
                    //cria o item da lista
                    Veiculo item = new Veiculo();
                    item.Placa = leitor["placa"].ToString();
                    item.Modelo = leitor["modelo"].ToString();
                    lista.Add(item);
                }
                
            }
            catch (Exception e2)
            {
                lista = null;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public string ExcluirM()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query= new MySqlCommand("delete from carro where placa = @placa;", con);
                query.Parameters.AddWithValue("@placa", Placa);
                query.ExecuteNonQuery();
                msg = "Deletado com sucesso!";
            }
            catch (Exception ex1)
            {
                msg = "ERRO " + ex1.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }

        public string SalvarM()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("insert into carro(placa, modelo) values(@placa, @modelo);", con);
                query.Parameters.AddWithValue("@placa", Placa);
                query.Parameters.AddWithValue("@modelo", Modelo);
                query.ExecuteNonQuery();
                msg = "Dados salvos com sucesso!";

            }
            catch (Exception ex2)
            {
                msg = "Falha ao salvar!" + ex2.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
    }
}