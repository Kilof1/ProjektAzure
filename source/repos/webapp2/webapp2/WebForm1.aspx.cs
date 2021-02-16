using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace webapp2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection stormconn = new SqlConnection("Server=tcp:projektazureserver.database.windows.net,1433;Initial Catalog=projektAzureDB;Persist Security Info=False;User ID=kilof;Password=Malina1256;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            stormconn.Open();
            SqlCommand cmd = new SqlCommand("SELECT note FROM [dbo].[notes]");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = stormconn;

            string temp = "";

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp += reader["note"].ToString();
                temp += "<br/>";
            }

            stormconn.Close();

            lbl_test.Text = temp;
                if(Page.IsPostBack == true)
            {
                Label1.Text = ("Dodano notatkę");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection stormconn = new SqlConnection("Server=tcp:projektazureserver.database.windows.net,1433;Initial Catalog=projektAzureDB;Persist Security Info=False;User ID=kilof;Password=Malina1256;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            {
                SqlCommand insert = new SqlCommand("EXEC dbo.InsertFullnote @Fullnote", stormconn);
                insert.Parameters.AddWithValue("@Fullnote", TextBox1.Text);

                stormconn.Open();
                insert.ExecuteNonQuery();
                stormconn.Close();
                stormconn.Open();
                SqlCommand cmd = new SqlCommand("SELECT note FROM [dbo].[notes]");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = stormconn;

                string temp = "";

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp += reader["note"].ToString();
                    temp += "<br/>";
                }

                stormconn.Close();

                lbl_test.Text = temp;
                if ( IsPostBack)
                {
                    TextBox1.Text = "";
                }
            }
        }
    }
}