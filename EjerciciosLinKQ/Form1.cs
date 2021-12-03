using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjerciciosLinKQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //metodo privado que devuelva un datatable
        private DataTable CreaGrilla(string[] titulos)// define titulos de grilla
        {
            DataTable dt = new DataTable();
            foreach(string titulo in titulos)
            {
                dt.Columns.Add(titulo,System.Type.GetType("System.String"));
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////1.alumnos con sus respectivas notas 
            //using(var db= new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Alumno", "Nota" });
            //    //--
            //    var query = from a in db.alumnos select a;

            //    foreach(var a in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(a.nombre, "");

            //        foreach(var n in a.notas)
            //        {
            //            dt.Rows.Add("",n.nota);
            //        }
            //    }
            //--
            //    dataGridView1.DataSource = dt;
            //    dataGridView1.Columns["Nota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// 2.- Departamento con sus respectivas Provincias
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Departamento", "Provincia" });
            //    //--
            //    var query = from dep in db.departamentos select dep;

            //    foreach (var dep in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(dep.departamento, "");

            //        foreach (var pro in dep.provincias)
            //        {
            //            dt.Rows.Add("", pro.provincia);
            //        }
            //    }
            //    dataGridView1.DataSource = dt;               
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// 3.- Departamento con sus respectivas Provincias y estas Distritos
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Departamento", "Provincia", "Distrito" });
            //    //--
            //    var query = from dep in db.departamentos select dep;

            //    foreach (var dep in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(dep.departamento, "","");

            //        foreach (var pro in dep.provincias)
            //        {
            //            dt.Rows.Add("", pro.provincia,"");

            //            foreach(var dis in pro.distritos)
            //            {
            //                dt.Rows.Add("","", dis.distrito);
            //            }
            //        }
            //    }
            //    dataGridView1.DataSource = dt;                
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 4.- Alumno con su respectiva nota
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "alumno", "Nota" });
            //    //--
            //    var query = from n in db.notas select n;

            //    foreach (var n in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(n.alumnos.nombre,n.nota);
            //    }
            //    dataGridView1.DataSource = dt;
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 5.- Departamentos con su respectiva provincia 
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Departamento", "Provincia" });
            //    //--
            //    var query = from prov in db.provincias select prov;

            //    foreach (var prov in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(prov.departamentos.departamento, prov.provincia);
            //    }
            //    dataGridView1.DataSource = dt;
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// 6.- Departamentos, provincia y distrito desde consulta distrito 
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Departamento", "Provincia","Distrito" });
            //    //--
            //    var query = from dist in db.distritos select dist;

            //    foreach (var dist in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(dist.provincias.departamentos.departamento,dist.provincias.provincia,dist.distrito);
            //    }
            //    dataGridView1.DataSource = dt;
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// 7.- Nombre y Nota usando join 
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Alumno", "Nota"});
            //    //--
            //    var query = from a in db.alumnos 
            //                join n in db.notas on a.idalumno equals n.idalumno
            //                select new {alumno = a.nombre, nota = n.nota};

            //    foreach (var a in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(a.alumno, a.nota);
            //    }
            //    dataGridView1.DataSource = dt;
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// 8.- departamento y provincia usando join 
            //using (var db = new ModelEjercicio())
            //{
            //    DataTable dt = CreaGrilla(new string[] { "Departmaento", "Provincia" });
            //    //--
            //    var query = from dep in db.departamentos
            //                join pro in db.provincias on dep.iddepartamento equals pro.iddepartamento
            //                select new { departamento = dep.departamento, provincia = pro.provincia };

            //    foreach (var dep in query)
            //    {
            //        // que me adiciones un fila "Rows"
            //        dt.Rows.Add(dep.departamento, dep.provincia);
            //    }
            //    dataGridView1.DataSource = dt;
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 9.- departamento y provincia y distrito usando join 
            using (var db = new ModelEjercicio())
            {
                DataTable dt = CreaGrilla(new string[] { "Departmaento", "Provincia", "Distrito" });
                //--
                var query = from dep in db.departamentos
                            join pro in db.provincias on dep.iddepartamento equals pro.iddepartamento
                            join dis in db.distritos on pro.idprovincia equals dis.idprovincia
                            select new { departamento = dep.departamento,
                                provincia = pro.provincia,
                                distrito = dis.distrito };

                foreach (var dep in query)
                {
                    // que me adiciones un fila "Rows"
                    dt.Rows.Add(dep.departamento, dep.provincia, dep.distrito);
                }
                dataGridView1.DataSource = dt;
            }

        }
    }
}
