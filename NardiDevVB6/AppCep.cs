using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using NardiDevVB6.Model;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Npgsql;
using System.Data;

namespace NardiDevVB6
{
    [XmlRoot(ElementName = "xmlcep", Namespace = "")]
    public partial class AppCep : Form
    {
        public AppCep()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Iniciando pesquisa");
            //Exefetuar processamento
            string cep = txtCep.ToString();

            //Adicionado regex para remover caracteres inválidos e/ou letras
            cep = Regex.Replace(cep, @"[^\d]", "");

            Console.WriteLine($"CEP sem caracteres: {cep}");
            try
            {
                if (cep != "")
                {
                    ExecutaProcessamento(cep);
                }
                else
                {
                    MessageBox.Show("Digite um CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CarregaDadosTela();

            }
            catch(Exception)
            {
                throw;
            }
            
            

        }

        private void ExecutaProcessamento(string cep)
        {
            //serão realizadas todas etapas do botão processar, separado por funções

            BuscaDadosAPI(cep);

        }
        private void BuscaDadosAPI(string cep)
        {
            string urlxml = $"http://viacep.com.br/ws/{cep}/xml";

            Console.WriteLine($"Url XML: {urlxml}");

            try
            {
                EnderecoModel enderecoConsulta = new EnderecoModel();

                enderecoConsulta = EfetivaConsultaJSON(cep);
                if (enderecoConsulta.cep != null)
                {
                    InsereDadosBancoDados(enderecoConsulta, "JSON");
                }

                enderecoConsulta = EfetivaConsultaXML(cep);
                if (enderecoConsulta.cep != null)
                {
                    InsereDadosBancoDados(enderecoConsulta, "XML");
                }
                else
                {
                    MessageBox.Show("Consulta não retornou dados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                    

            }
            catch(Exception)
            {
                throw;
            }



        }
        private EnderecoModel EfetivaConsultaJSON(string cep)
        {
            EnderecoModel Endereco = new EnderecoModel();
            string urljson = $"http://viacep.com.br/ws/{cep}/json";
            Console.WriteLine($"Url JSON: {urljson}");

            var handler = new HttpClientHandler
            {
                UseProxy = false
            };

            var httpClient = new HttpClient(handler);
            var request = (HttpWebRequest)WebRequest.Create(urljson);


            request.Method = "GET";
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var encoding = Encoding.GetEncoding("utf-8");

                        using (var reader = new StreamReader(response.GetResponseStream(), encoding))
                        {
                            string json = reader.ReadToEnd();
                            Endereco = JsonConvert.DeserializeObject<EnderecoModel>(json);

                            Console.WriteLine($"JSON Response: {json}");
                            return Endereco;
                        }
                    }
                    else
                    {
                        throw new Exception("Erro ao consultar, Código de status: " + response.StatusCode);
                    }
                }    
            }catch(WebException ex)
            {
                return Endereco;
                throw new Exception("Ocorreu um erro no request. Mensagem: " + ex.Message);
                
            }


        }

        private EnderecoModel EfetivaConsultaXML(string cep)
        {
            string urlxml = $"http://viacep.com.br/ws/{cep}/xml";
            Console.WriteLine($"Url XML: {urlxml}");
            EnderecoModel endereco = new EnderecoModel();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlxml);
                request.Method = "GET";

                // Obtém a resposta do servidor
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Lê o XML retornado do serviço do CEP

                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    string xml = reader.ReadToEnd();

                    XmlSerializer serializer = new XmlSerializer(typeof(EnderecoModel));

                    //Criado para criar uma reader a strig xml e gravar no model
                    StringReader stringReader = new StringReader(xml);
                    endereco = (EnderecoModel)serializer.Deserialize(stringReader);
                    Console.WriteLine(xml);
                    return endereco;
                }
                else
                {
                    throw new Exception("Erro ao consultar, Código de status: " + response.StatusCode);
                }

            }
            catch (WebException ex)
            {
                return endereco;
            }

        }
        private void InsereDadosBancoDados(EnderecoModel endereco, string origem)
        {
            string cepcorrigido = Regex.Replace(endereco.cep, @"[^\d]", "");

            string SQL = $@"INSERT INTO tablecep
            values ('{cepcorrigido}',
                    '{endereco.logradouro}',
                    '{endereco.complemento}',
                    '{endereco.bairro}',
                    '{endereco.localidade}',
                    '{endereco.uf}',
                    '{endereco.ibge}',
                    '{endereco.gia}',
                    '{endereco.ddd}',
                    '{endereco.siafi}',
                    '{origem}'
                   )";

            Console.WriteLine($"Insere banco dados, SQL: {SQL}");
            DataSet dS = ExecutaBancoDados(SQL,"");

        }

        private void RemoveDadosBancoDados(string cep)
        {
            string SQL = $"Delete from tablecep where cep = '{cep}'";
            Console.WriteLine($"Deleta banco dados, SQL: {SQL}");
            DataSet dS = ExecutaBancoDados(SQL,"");

        }
        private DataSet ExecutaBancoDados(string sql, string tipo)
        {
            DataSet dataSet = new DataSet();
            try
            {
                //Conexao com banco de dados local
                string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                if (tipo == "C")
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
                    // Preenche o DataSet com os dados da tabela
                    adapter.Fill(dataSet, "tablecep");

                }
                else
                {
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }

                //Fechar conexão banco de dados
                connection.Close();

                return dataSet;

            }
            catch (Exception)
            {
                return dataSet;
            }
            
        }

        private bool CarregaDadosTela()
        {
            string SQL = "select * from tablecep";
            DataSet dS = ExecutaBancoDados(SQL, "C");
            dgCep.Columns.Clear();

            // Obtém a tabela do DataSet que deseja exibir
            DataTable table = dS.Tables["tablecep"];

            // Define o DataGridView como DataSource da tabela
            dgCep.DataSource = table;

            // Ajusta as colunas do DataGridView de acordo com o conteúdo
            dgCep.AutoResizeColumns();

            return true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string cep = txtCep.ToString();

            //Adicionado regex para remover caracteres inválidos e/ou letras
            cep = Regex.Replace(cep, @"[^\d]", "");

            Console.WriteLine($"CEP sem caracteres: {cep}");
            try
            {
                if (cep != "")
                {
                    RemoveDadosBancoDados(cep);
                }
                else
                {
                    MessageBox.Show("Digite um CEP", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CarregaDadosTela();

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
