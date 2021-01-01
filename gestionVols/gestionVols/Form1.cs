using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace gestionVols
{
    public partial class GestionVol : Form
    {
        public GestionVol()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        BindingSource binsou = new BindingSource();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("Select distinct * from vol;",new SqlConnection(ConfigurationManager.ConnectionStrings["ch1"].ConnectionString));
            da.Fill(ds, "vol");
            cbxvildep.DisplayMember = "vilar";
            cbxvildep.ValueMember = "novol";
            cbxvildep.DataSource = ds.Tables[0];
            cbxvilar.DisplayMember = "vildep";
            cbxvilar.DataSource = ds.Tables[0];
            cbxvilar.ValueMember = "novol";
            binsou.DataSource = ds.Tables[0];
            Numvoltxt.DataBindings.Add("text", binsou, "novol");
            cbxvildep.DataBindings.Add("SelectedItem", binsou, "vildep");
            cbxvilar.DataBindings.Add("SelectedItem", binsou, "vilar");
            hdeptext.DataBindings.Add("text", binsou, "dep_h");
            mindeptxt.DataBindings.Add("text", binsou, "dep_mn");
            hartxt.DataBindings.Add("text", binsou, "ar_h");
            minartxt.DataBindings.Add("text", binsou, "ar_mn");
            dgvVol.DataSource = binsou;

        }

        private void nvbtn_Click(object sender, EventArgs e)
        {
            try
            {
                binsou.AddNew();
                
            }
            catch(Exception exc)
            { MessageBox.Show(exc.Message); }
         }

        private void ajbtn_Click(object sender, EventArgs e)
        {
            try
            {
                binsou.EndEdit();
               
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }

        private void modbtn_Click(object sender, EventArgs e)
        {
            try
            {
                binsou.EndEdit();
               
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }

        private void supbtn_Click(object sender, EventArgs e)
        {
            try
            {
                binsou.RemoveCurrent();
                
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }

         }

        private void firstbtn_Click(object sender, EventArgs e)
        {
            binsou.MoveFirst();
        }

        private void lastbtn_Click(object sender, EventArgs e)
        {
            binsou.MoveLast();
        }

        private void prevbtn_Click(object sender, EventArgs e)
        {
            binsou.MovePrevious();
        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            binsou.MoveNext();
        }

        private void sauvbtn_Click(object sender, EventArgs e)
        {
            try
            { 
                SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                da.SelectCommand.CommandText = "Select * from vol;";
                da.Update(ds.Tables[0]);
                
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }
    }
}
