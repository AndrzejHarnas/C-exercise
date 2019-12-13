using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SQLtest
{
    public partial class AplikacjaSQL : Form
    {

        string conectionString = "Data Source=KZ-119GOLABEK2\\SQLEXPRESS;Initial Catalog = Test; Integrated Security = True";




        public List<Person> People { get; set; }
        public AplikacjaSQL()
        {
            People = GetPeople();
            InitializeComponent();

        }


        private List<Person> GetPeople()
        {
           var list = new List<Person>();

                list.Add(new Person(){
                    name="Andrzej", 
                    surname="Gołąbek",
                    city="Krosno"
               });

                list.Add(new Person(){
                name = "Andrzej",
                surname = "Gołąbek",
                city = "Krosno"
            });
            list.Add(new Person()
            {
                name = "Andrzej",
                surname = "Gołąbek",
                city = "Krosno"
            });
            list.Add(new Person()
            {
                name = "Andrzej",
                surname = "Gołąbek",
                city = "Krosno"
            });

            return list;
        }


        public void button3_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(conectionString))
            {
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "EXEC dbo.insertUsers @name='Roman', @surname='Buba', @city='Kraków'  ";
                    // SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sglDa = new SqlDataAdapter(query, con);
                    DataTable dtbl = new DataTable();
                    sglDa.Fill(dtbl);

                    SQLview.DataSource = dtbl;



                }
            }

        }

        public void button1_Click(object sender, EventArgs e)
        {

            var people = this.People;

            SQLview.DataSource = people;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(conectionString)) {
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string query = "Exec dbo.showusers";
                    // SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sglDa = new SqlDataAdapter(query,con);
                    DataTable dtbl = new DataTable();
                    sglDa.Fill(dtbl);

                    SQLview.DataSource = dtbl;



            }
            }

        }

        private void SQLview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Wywołana procedura");
        }
    }
}
