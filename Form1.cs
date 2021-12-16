using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_4_2
{
    public partial class Form1 : Form
    {
        Model modelA;
        Model modelB;
        Model modelC;

        public Form1()
        {
            InitializeComponent();
            modelA = new Model();
            modelB = new Model();
            modelC = new Model();
            modelA.observers += new System.EventHandler(this.UpdateFromModel);
            modelB.observers += new System.EventHandler(this.UpdateFromModel2);
            modelC.observers += new System.EventHandler(this.UpdateFromModel3);
        }


      


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            modelA.setValue(Decimal.ToInt32(numericUpDown1.Value));
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelA.setValue(Int32.Parse(textBox1.Text));
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            modelA.setValue(trackBar1.Value);
        }
        private void UpdateFromModel(object sender,EventArgs e)
        {
            textBox1.Text = modelA.getValue().ToString();
            numericUpDown1.Value = modelA.getValue();
            trackBar1.Value = modelA.getValue();
            modelB.setMin(modelA.getValue());

        }
        // вторые обекты
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            modelB.setValue(Decimal.ToInt32(numericUpDown2.Value));
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelB.setValue(Int32.Parse(textBox2.Text));
            }

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            modelB.setValue(trackBar2.Value);
        }
        private void UpdateFromModel2(object sender, EventArgs e)
        {
            textBox2.Text = modelB.getValue().ToString();
            numericUpDown2.Value = modelB.getValue();
            trackBar2.Value = modelB.getValue();
            modelC.setMin(modelB.getValue());
            modelA.setMax(modelB.getValue());

        }
        // третьи обекты
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            modelC.setValue(Decimal.ToInt32(numericUpDown3.Value));
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modelC.setValue(Int32.Parse(textBox3.Text));
            }

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            modelC.setValue(trackBar3.Value);
        }
        private void UpdateFromModel3(object sender, EventArgs e)
        {
            textBox3.Text = modelC.getValue().ToString();
            numericUpDown3.Value = modelC.getValue();
            trackBar3.Value = modelC.getValue();            
            modelB.setMax(modelC.getValue());            

        }
    }
}

public class Model
{
    private int Value, Max, Min;
        
    public System.EventHandler observers;  
     public Model()
    {
        Value = 0;
        Max = 100;
        Min = 0;
    }
    public void setValue(int V)
    {
        if(V <= Max && V >= Min)
        {
            Value = V;       
        }        
        observers.Invoke(this, null);
    }    
    public int  getValue()
    {
        return Value;
    }
    public void setMax(int Mx)
    {
        Max = Mx;
    }
    public void setMin(int Mn)
    {
        Min = Mn;
    }
   
}
