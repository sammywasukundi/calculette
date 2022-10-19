using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculette
{
    public partial class Calculatrice : Form
    {
        Double valeur_Result = 0;
        string operation_effectue = "";
        bool isOperationEffectue = false;

        public Calculatrice()
        {
            InitializeComponent();
        }
        //pour les buttons
        private void button_click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationEffectue)) 
                textBox_Result.Clear();

            isOperationEffectue = false;    
            Button button =(Button)sender;
            // a reverifier
            if (button.Text == ".") 
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
                textBox_Result.Text = textBox_Result.Text + button.Text;
            //
        }
        //pour les operations
        private void op_click(object sender, EventArgs e)
        {
            Button button =(Button)sender;


            if (valeur_Result != 0)
            {
                button36.PerformClick();
                operation_effectue = button.Text;
                //valeur_Result = Double.Parse(textBox_Result.Text);
                labelOperation.Text = valeur_Result + " " + operation_effectue;
                isOperationEffectue = true;
            }
            else 
            {
                operation_effectue = button.Text;
                valeur_Result = Double.Parse(textBox_Result.Text);
                labelOperation.Text = valeur_Result + " " + operation_effectue;
                isOperationEffectue = true;
            }
            
        }
        // pour clear ce
        private void button24_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            valeur_Result = 0;
        }
        // pour clear c
        private void button23_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }
        // pour le signe egal
        private void button36_Click(object sender, EventArgs e)
        {
            switch (operation_effectue) 
            {
                case "+":
                    textBox_Result.Text = (valeur_Result + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (valeur_Result - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (valeur_Result * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (valeur_Result / Double.Parse(textBox_Result.Text)).ToString();
                    break;
              //  case "%":
                  //  textBox_Result.Text = (valeur_Result % Double.Parse(textBox_Result.Text)).ToString();
                default :
                    break;
            }
            valeur_Result = Double.Parse(textBox_Result.Text);
            labelOperation.Text = "";
        }
        // pour le button Exit
        private void quitter_click(object sender, EventArgs e)
        {
            DialogResult quitte;
            quitte = MessageBox.Show("Voulez-vous vraiment quitter ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (quitte == DialogResult.Yes)
            {
                Application.Exit();
            }
            else 
            {
                this.Show();
            }
        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
