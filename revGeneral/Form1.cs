using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revGeneral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        revGeneralEntities db = new revGeneralEntities();
        BindingSource bs = new BindingSource();
        private void afficher()
        {
            var req = from emp in db.employes
                      select new
                      {
                          emp.id,
                          emp.nom,
                          emp.prenom,
                          emp.age,
                          emp.salaire,
                          emp.entreprise.name
                      };
            bs.DataSource = req.ToList();
            dataGridView1.DataSource = bs;
            textBox1.DataBindings.Add("Text", bs, "id");
            textBox2.DataBindings.Add("Text", bs, "nom");
            textBox3.DataBindings.Add("Text", bs, "prenom");
            textBox4.DataBindings.Add("Text", bs, "age");
            textBox5.DataBindings.Add("Text", bs, "salaire");
            comboBox1.DataBindings.Add("Text", bs, "name");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            afficher();
            comboBox1.DataSource = db.entreprises.ToList();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "code";
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            employe e1 = new employe();
            e1.id = int.Parse(textBox1.Text);
            e1.nom = textBox2.Text;
            e1.prenom = textBox3.Text;
            e1.age = int.Parse(textBox4.Text);
            e1.salaire = float.Parse(textBox5.Text);
            e1.code = int.Parse(comboBox1.SelectedValue.ToString());
            db.employes.Add(e1);
            db.SaveChanges();
            MessageBox.Show("bien ajouter ");
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            employe e1 = new employe();
            e1.id = int.Parse(textBox1.Text);
            employe e2 = new employe();
            e2 = (from emp in db.employes
                  where emp.id == e1.id
                  select emp).FirstOrDefault();
            e2.nom = textBox2.Text;
            e2.prenom = textBox3.Text;
            e2.age = int.Parse(textBox4.Text);
            e2.salaire = float.Parse(textBox5.Text);
            e2.code = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            employe e1 = new employe();
            e1.id = int.Parse(textBox1.Text);
            employe e2 = new employe();
             e2 = (from emp in db.employes
                     where emp.id == e1.id
                     select emp).FirstOrDefault();
            textBox2.Text = e2.nom;
            textBox3.Text = e2.prenom;
            textBox4.Text = e2.age.ToString();
            textBox5.Text = e2.salaire.ToString();
            comboBox1.Text = e2.entreprise.name;
            
            
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            employe em1 = new employe();
            em1.id = int.Parse(textBox1.Text);
            employe em = new employe();
            em = (from emp in db.employes
                  where emp.id == em1.id
                  select emp).FirstOrDefault();
            db.employes.Remove(em);
            db.SaveChanges();
            MessageBox.Show("bien supprimer");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var req = from emp in db.employes
                      where emp.entreprise.name == comboBox1.Text
                      select new { emp.nom, emp.prenom };
            dataGridView1.DataSource = req.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
