using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Quanlydoanvien
{
    class ClassNoiCSDL
    {
           
        OleDbCommand cmd = new OleDbCommand();

        public  OleDbConnection conn()
        {
            return new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0 ;" +
                        "Data Source =" + Application.StartupPath + @"\Dangnhap.mdb;" +
                        "Jet OLEDB:Database Password =222222;" +
                        "User ID = admin");         
        }
       
        public string Checklogin(string name, string pass)
        {
            string quyen = "";
            OleDbConnection kn = conn();
            OleDbCommand cmd = new OleDbCommand("select role from Login where userid='" + name + "'and pass='" + pass + "'", kn);
            kn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                quyen = dr[0].ToString();
                kn.Close();
                return quyen;

            }
            kn.Close();
            return quyen;

        }
        public bool Checklogin2(string name, string pass)
        {
           
            OleDbConnection kn = conn();
            OleDbCommand cmd = new OleDbCommand("select userid, pass from Login where userid='" + name + "'and pass='" + pass + "'", kn);
            kn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                kn.Close();
                return true;

            }
            kn.Close();
            return false;

        }
        public bool update(string namecu, string passcu, string namemoi, string passmoi)
        {
            
                OleDbConnection kn = conn();
                OleDbCommand com = new OleDbCommand("update Login Set userid ='" + namemoi + "', pass ='" + passmoi + "' where userid ='" + namecu + "'and pass ='" + passcu + "'", kn);
                kn.Open();
                OleDbDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    kn.Close();
                    return true;

                }
                kn.Close();
                return false;
            

           
        }

            
        

    }
}
