using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Collections;

namespace DashEnt
{
    public class DbMani //: IEnumerable
    {
        private String cadena = "data source=DbDash.db";
        public SQLiteConnection cn;
        private SQLiteCommandBuilder cmb;
        public DataSet ds = new DataSet();
        public SQLiteDataAdapter da;
        public SQLiteCommand comando;
         
        

        private void conectar()
        {
            cn = new SQLiteConnection(cadena);
        }

        public DbMani()
        {
            conectar();
        }

        //Metodo para Consultas

        public void consultar(string sql, string tabla)
        {
            ds.Tables.Clear();
            da = new SQLiteDataAdapter(sql, cn);
            cmb = new SQLiteCommandBuilder(da);
            da.Fill(ds, tabla);
        }

        //Metodo para Eliminar

        public bool eliminar(string tabla, string condicion)
        {
            cn.Open();
            string sql = "delete from " + tabla + " where " + condicion;
            comando = new SQLiteCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo para Actualizar

        public bool actualizar(string tabla, string campos, string condicion)
        {
            cn.Open();
            string sql = "update " + tabla + " set " + campos + " where " + condicion;
            comando = new SQLiteCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Metodo consultas para combos

        public DataTable consucom(string tabla)
        {
            string sql = "select * from " + tabla;
            da = new SQLiteDataAdapter(sql, cn);
            DataSet dts = new DataSet();
            da.Fill(dts, tabla);
            DataTable dt = new DataTable();
            dt = dts.Tables[tabla];
            return dt;
        }

        //Metodo para insertar datos
        
        public bool insertar(string sql)
        {
            cn.Open();
            comando = new SQLiteCommand(sql, cn);
            int i = comando.ExecuteNonQuery();
            cn.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       // public IEnumerator GetEnumerator()
        //{
            //return ds.GetEnumerator();
        //}
    }
}
