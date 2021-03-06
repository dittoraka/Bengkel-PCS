﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bengkel_PCS
{
    public partial class Form1 : Form
    {
        
        public OracleConnection conn = new OracleConnection();
        public Form1()
        {
            conn.ConnectionString = "Data Source=orcl;User ID=project;Password=11;";
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama;
            string jabatan = null;
            try
            {
                conn.Open();
                OracleCommand cmd;
                cmd = new OracleCommand("select jabatan as jabatan from karyawan where id_karyawan = '" + textBox1.Text.ToUpper() + "' and password_karyawan = '" + textBox2.Text + "'", conn);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    jabatan = reader["jabatan"] + "";
                }
                conn.Close();
                panel1.Visible = false;
                if (jabatan.Equals("KASIR"))
                {
                    cASHIERToolStripMenuItem.Enabled = true;
                    iNVENTORYToolStripMenuItem.Enabled = false;
                    aDMINToolStripMenuItem.Enabled = false;
                }
                else if (jabatan.Equals("GUDANG"))
                {
                    cASHIERToolStripMenuItem.Enabled = false;
                    iNVENTORYToolStripMenuItem.Enabled = true;
                    aDMINToolStripMenuItem.Enabled = false;
                }
                else if (jabatan.Equals("MANAGER"))
                {
                    cASHIERToolStripMenuItem.Enabled = true;
                    iNVENTORYToolStripMenuItem.Enabled = true;
                    aDMINToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
           
        }

        private void cASHIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashier fm = new Cashier();
            fm.MdiParent = this;
            fm.Show();
        }

        private void iNVENTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory fm = new Inventory();
            fm.MdiParent = this;
            fm.Show();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin fm = new Admin();
            fm.MdiParent = this;
            fm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
