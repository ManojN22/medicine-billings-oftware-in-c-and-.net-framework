using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public int mank;
        public int il = new int();
        public int ik = new int();
        public int opn = new int();
        public int i = new int();
        public Int64 un = new Int64();
        public int maind = new int();

        public int total = new int();
        public int[] idd = new int[100];
        public int[] qtt = new int[100];
        public int op = new int();
        public struct manu
        {
            public int mrfn;
            public string mrname;


        }
        public struct med
        {

            public int id;
            public int mfrno;
            public string me;
            public int mrp;
            public int qty;
            public int[] bqt;
            public string[] batch;
            public DateTime datee;
            public string mfr;

            public int[] yer;
            public int[] da;
            public int bno;
            public int tobn;
            public void man()
            {

                yer = new int[1000];
                da = new int[1000];
                bqt = new int[1000];
                batch = new string[1000];
                bno = 0;
                tobn = 0;
            }

        }

        public struct medic
        {
            public int id;
            public int mfrno;
            public string me;
            public int mrp;
            public int qty;

            public string batch;
            public DateTime datee;
            public string mfr;

            public int yer;
            public int da;

        }
        manu[] ba = new manu[200];

        med[] a = new med[30000];
        public medic[] rec = new medic[300000];
        public medic[] totrec = new medic[30000];
        med[] or = new med[100];


        public Form1()
        {

            InitializeComponent();
            ik = 0;
            ok = 0;
            i = 0;
            un = 0;
            op = 0;
            maind = 0;
            for (int i = 0; i < 30000; i++)
            {
                a[i].man();
            }
            int n = new int();
            panel7.Visible = false;
            FileStream m = new FileStream("medi.bin", FileMode.OpenOrCreate);
            FileStream l = new FileStream("index.bin", FileMode.OpenOrCreate);
            FileStream lk = new FileStream("value.bin", FileMode.OpenOrCreate);
            FileStream mk = new FileStream("order.bin", FileMode.OpenOrCreate);
            FileStream manufac = new FileStream("manu.bin", FileMode.OpenOrCreate);
            FileStream manuin = new FileStream("manuindex.bin", FileMode.OpenOrCreate);
            BinaryReader mu = new BinaryReader(manufac);
            BinaryReader min = new BinaryReader(manuin);
            BinaryReader k = new BinaryReader(m);
            BinaryReader p = new BinaryReader(l);
            BinaryReader pk = new BinaryReader(lk);
            BinaryReader kk = new BinaryReader(mk);
            i = p.Read();
            un = pk.Read();
            maind = min.Read();
            
            for (n = 0; n < i; n++)
            {
                a[n].id = k.ReadInt32();
                a[n].mfr = k.ReadString();
                a[n].mfrno = k.ReadInt32();
                a[n].me = k.ReadString().ToUpper();
                a[n].mrp = k.ReadInt32();
                a[n].qty = k.ReadInt32();
                a[n].tobn = k.ReadInt32();
                a[n].bno = k.ReadInt32();

                for (int kl = 0; kl <=a[n].tobn; kl++)
                    a[n].batch[kl] = k.ReadString();
                for (int kl = 0; kl <=a[n].tobn; kl++)
                    a[n].da[kl] = k.ReadInt32();
                for (int kl = 0; kl <=a[n].tobn; kl++)
                    a[n].yer[kl] = k.ReadInt32();
                for (int kl = 0; kl <=a[n].tobn; kl++)
                    a[n].bqt[kl] = k.ReadInt32();



            }

            for (n = 0; n < un; n++)
            {
                rec[n].id = kk.ReadInt32();
                rec[n].mfr = kk.ReadString();
                rec[n].mfrno = kk.ReadInt32();
                rec[n].me = kk.ReadString();
                rec[n].mrp = kk.ReadInt32();
                rec[n].qty = kk.ReadInt32();
                rec[n].batch = kk.ReadString();
                rec[n].da = kk.ReadInt32();
                rec[n].yer = kk.ReadInt32();
              


                string kj = kk.ReadString();
                DateTime.TryParse(kj, out rec[n].datee);


            }

            for (n = 0; n < maind; n++)
            {
                ba[n].mrfn = mu.ReadInt32();

                ba[n].mrname = mu.ReadString();
            }

            pk.Close();
            kk.Close();
            k.Close();
            l.Close();
            m.Close();
            mk.Close();
            lk.Close();
            mu.Close();
            min.Close();
            manufac.Close();
            manuin.Close();
      
            if (un == 200000)
            {   
            medic trpv = new medic();
                for (int kj = 0;kj<100000;kj++)
               {
                    trpv = rec[kj + 100000];
                    rec[kj] = trpv;

                }
                un = 100000;
            }
            panel9.Visible = false;
            listBox1.Visible = false;
            add.BringToFront();
            button1.PerformClick();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       public bool agh = new bool();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox6.Select();
            agh = false;
            ro = 0;
            panel9.Visible = false;
            total = 0;
            add.BringToFront();
            button1.BackColor = Color.White;
            button4.BackColor = Color.DarkGreen;
            button8.BackColor = Color.DarkGreen;
            button9.BackColor = Color.DarkGreen;
            button3.BackColor = Color.DarkGreen;
            listBox1.Visible = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            ser.BringToFront();
            button1.BackColor = Color.DarkGreen;
            button3.BackColor = Color.White;
            button4.BackColor = Color.DarkGreen;
            button8.BackColor = Color.DarkGreen;
            button9.BackColor = Color.DarkGreen;
            textBox1.Select();
        }

        private void ser_Paint(object sender, PaintEventArgs e)
        {

        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            int n = new int();

            FileStream m = new FileStream("medi.bin", FileMode.OpenOrCreate);
            m.SetLength(0);
            FileStream h = new FileStream("index.bin", FileMode.OpenOrCreate);

            FileStream mk = new FileStream("order.bin", FileMode.OpenOrCreate);
            mk.SetLength(0);
            FileStream lk = new FileStream("value.bin", FileMode.OpenOrCreate);
            FileStream qw = new FileStream("manu.bin", FileMode.OpenOrCreate);
            FileStream we = new FileStream("manuindex.bin", FileMode.OpenOrCreate);
            BinaryWriter er = new BinaryWriter(we);
            BinaryWriter mu = new BinaryWriter(qw);
            BinaryWriter u = new BinaryWriter(h);

            BinaryWriter k = new BinaryWriter(m);
            BinaryWriter uk = new BinaryWriter(mk);

            BinaryWriter kk = new BinaryWriter(lk);

            u.Write(i);
            kk.Write(un);
            er.Write(maind);


            for (n = 0; n < i; n++)
            {
                k.Write(a[n].id);
                k.Write(a[n].mfr);
                k.Write(a[n].mfrno);
                k.Write(a[n].me);
                k.Write(a[n].mrp);
                k.Write(a[n].qty);
                k.Write(a[n].tobn);
                k.Write(a[n].bno);


                for (int kl = 0; kl <=a[n].tobn; kl++)
                    k.Write(a[n].batch[kl]);
                for (int kl = 0; kl <= a[n].tobn; kl++)
                    k.Write(a[n].da[kl]);
                for (int kl = 0; kl <= a[n].tobn; kl++)
                    k.Write(a[n].yer[kl]);
                for (int kl = 0; kl <= a[n].tobn; kl++)
                    k.Write(a[n].bqt[kl]);

            }
            for (n = 0; n < un; n++)
            {
                uk.Write(rec[n].id);
                uk.Write(rec[n].mfr);
                uk.Write(rec[n].mfrno);
                uk.Write(rec[n].me);
                uk.Write(rec[n].mrp);
                uk.Write(rec[n].qty);
                uk.Write(rec[n].batch);
                uk.Write(rec[n].da);
                uk.Write(rec[n].yer);

                uk.Write(rec[n].datee.ToString());


            }
            for (n = 0; n < maind; n++)
            {
                mu.Write(ba[n].mrfn);

                mu.Write(ba[n].mrname);
            }
            mu.Close();
            er.Close();
            u.Close();
            k.Close();
            uk.Close();
            kk.Close();
            h.Close();
            m.Close();
            mk.Close();
            lk.Close();
            we.Close();

            qw.Close();

        }

        public int ro = new int();
        private void button5_Click(object sender, EventArgs e)
        {
           
            ok = 0;
            try
            {

                int r;

                decimal gh = new decimal();

                {
                    textBox6.Text = listBox1.GetItemText(listBox1.SelectedItem);
                   
                        {
                            for (r = 0; r < i; r++)
                            {
                                if (textBox6.Text == a[r].me)
                                {


                                    listBox1.Items.Clear();
                                    listBox1.Visible = false;




                                    gh = numericUpDown1.Value;
                                    total += a[r].mrp * decimal.ToInt32(gh);



                                    if (decimal.ToInt32(gh) < a[r].qty)
                                    {
                                        ro = dataGridView1.Rows.Add();
                                    agh = true;
                                        dataGridView1.Rows[ro].Cells[0].Value = a[r].id;
                                        dataGridView1.Rows[ro].Cells[1].Value = a[r].me;

                                        dataGridView1.Rows[ro].Cells[2].Value = gh;
                                        dataGridView1.Rows[ro].Cells[3].Value = a[r].mrp;
                                        dataGridView1.Rows[ro].Cells[4].Value = a[r].mrp * decimal.ToInt32(gh);
                                        dataGridView1.Rows[ro].Cells[5].Value = a[r].da[a[r].bno].ToString() + "/" + a[r].yer[a[r].bno].ToString();
                                        dataGridView1.Rows[ro].Cells[6].Value = a[r].batch[a[r].bno];
                                        textBox9.Text = total.ToString();
                                    }
                                    else
                                    {
                                    agh = true;
                                    MessageBox.Show("there is only :" + a[r].qty.ToString());
                                        ro = dataGridView1.Rows.Add();
                                        dataGridView1.Rows[ro].Cells[0].Value = a[r].id;
                                        dataGridView1.Rows[ro].Cells[1].Value = a[r].me;

                                        dataGridView1.Rows[ro].Cells[2].Value = a[r].qty;
                                        dataGridView1.Rows[ro].Cells[3].Value = a[r].mrp;
                                        dataGridView1.Rows[ro].Cells[4].Value = a[r].mrp * a[r].qty;
                                        dataGridView1.Rows[ro].Cells[5].Value = a[r].da[a[r].bno] + "/" + a[r].yer[a[r].bno];
                                        dataGridView1.Rows[ro].Cells[6].Value = a[r].batch[a[r].bno];
                                        textBox9.Text = total.ToString();
                                    }

                                
                            }
                        }
                    }
                    textBox6.Clear();

                }

            }
            catch { MessageBox.Show("me"); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();


            //this add dsearching items to the object


            int ok = new int();
            bool j;


            try
            {
                for (ok = 0; ok < i; ok++)
                {
                    j = a[ok].me.Contains(textBox6.Text);

                    if (j) { listBox1.Items.Add(a[ok].me); }
                }
            }

            catch { MessageBox.Show("call me"); }
            listBox1.Visible = true;
            if (textBox11.Text == null) { listBox2.Visible = false; }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int oi = new int();
            for (oi = 0; oi < i; oi++)
            {
                if (string.Compare(textBox1.Text.ToUpper(), a[i].me) == 0)
                {
                    label8.Text = "medicine is already available";
                    textBox1.Clear();

                }
            }


        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            int oip;
            char ch = e.KeyChar;
            if (ch == 13)
            {
                for (oip = 0; oip < maind; oip++)
                    if (ba[oip].mrfn == int.Parse(textBox5.Text))
                    {
                        label11.Text = ba[oip].mrname;
                    }
            }
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGreen;
            button3.BackColor = Color.DarkGreen;
            button4.BackColor = Color.White;
            button8.BackColor = Color.DarkGreen;
            button9.BackColor = Color.DarkGreen;
          
            listView2.Items.Clear();
            listView4.Items.Clear();
            medic tep = new medic();
            int oli = 0;
            int olp = 0;
            int r = new int();
            int ru = new int();

            int tot = new int();
            listView2.Visible = true;


            panel2.BringToFront();
            tot = 0;

            ListViewItem i2;

            for (ru = 0; ru < un; ru++)
            {


                i2 = listView2.Items.Add(rec[ru].id.ToString());
                i2.SubItems.Add(rec[ru].me);
                i2.SubItems.Add(rec[ru].qty.ToString());
                i2.SubItems.Add(rec[ru].mrp.ToString());
                tot = rec[ru].qty * rec[ru].mrp;
                i2.SubItems.Add(tot.ToString());
                i2.SubItems.Add(rec[ru].da.ToString() + "/" + rec[ru].yer.ToString());
                i2.SubItems.Add(rec[ru].datee.ToShortDateString());
                i2.SubItems.Add(rec[ru].batch);





            }


            tot = 0;
            bool ke = false;
            for (r = 0; r < un; r++)
            {
                if (olp == 0)
                {
                    tep = rec[r];
                    totrec[olp] = tep;

                    olp += 1;
                }
                else
                {

                    for (oli = 0; oli < olp; oli++)
                    {
                        if (totrec[oli].id == rec[r].id)
                        {
                            ke = false;
                            break;
                        }
                        else
                        { ke = true; }
                    }

                    if (ke)
                    {
                        tep = rec[r];
                        totrec[olp] = tep;

                        olp += 1;
                    }
                    else
                    {
                        totrec[oli].qty += rec[r].qty;
                        totrec[oli].datee = rec[r].datee;
                    }
                }

            }

            ListViewItem i4;
            for (r = 0; r < olp; r++)
            {


                i4 = listView4.Items.Add(totrec[r].id.ToString());
                i4.SubItems.Add(totrec[r].me);
                i4.SubItems.Add(totrec[r].qty.ToString());
                i4.SubItems.Add(totrec[r].mrp.ToString());
                tot = totrec[r].qty * totrec[r].mrp;
                i4.SubItems.Add(tot.ToString());
                i4.SubItems.Add(totrec[r].da.ToString() + "/" + totrec[r].yer.ToString());
                i4.SubItems.Add(totrec[r].datee.ToShortDateString());
                i4.SubItems.Add(totrec[r].batch.ToString());
                i4.SubItems.Add(totrec[r].mfr);






            }
            listBox2.Visible = true;
            listView4.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void maskedTextBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool kj = false;
            int ui;
            int[] q = new int[6];
            int yu;

            for (yu = 0; yu < i; yu++)
            {
                if (string.Compare(a[yu].me, textBox1.Text) == 0)
                { kj = true; }
            }
            if (kj == false)
            {



                if (int.TryParse(textBox2.Text, out q[0]) && int.TryParse(textBox3.Text, out q[1]) && int.TryParse(textBox5.Text, out q[3]) && int.TryParse(textBox7.Text, out q[4]) && int.TryParse(textBox8.Text, out q[5]))
                {
                    a[i].id = i + 1;
                    a[i].me = textBox1.Text;
                    a[i].mrp = q[0];
                    a[i].qty = q[1];
                    a[i].bqt[0] = q[1];
                    a[i].bno = 0;
                    a[i].tobn = 0;
                    a[i].batch[0] = textBox4.Text;
                    a[i].mfrno = q[3];
                    a[i].da[0] = q[4];
                    a[i].yer[0] = q[5];
                    for (ui = 0; ui < maind; ui++)
                    {
                        if (a[i].mfrno == ba[ui].mrfn)
                        {
                            a[i].mfr = ba[ui].mrname;
                        }
                    }



                    i += 1;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox1.Select();
                }


            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch;
            ch = e.KeyChar;
            if (textBox7.Text.Length == 1) textBox8.Select();
            if ((!char.IsDigit(ch) || (textBox7.Text.Length > 1)) && ch != 8)
            {
                e.Handled = true;

            }
        }
        public int ok = new int();
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch;
            ch = e.KeyChar;
            if ((!char.IsDigit(ch) || (textBox8.Text.Length > 3)) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGreen;
            button3.BackColor = Color.DarkGreen;
            button4.BackColor = Color.DarkGreen;
            button8.BackColor = Color.White;
            button9.BackColor = Color.DarkGreen;
            panel3.BringToFront();
            int r = new int();


            ListViewItem i3;
            listView3.Items.Clear();
            for (r = maind - 1; r >= 0; r--)
            {

                i3 = listView3.Items.Add(ba[r].mrfn.ToString());
                i3.SubItems.Add(ba[r].mrname);






            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int ou;
            int jk;
            int k;
            int jkl = 0;
      
            for (ou = 0; ou <= ro; ou++)
            {
              
                


                for (k = 0; k < i; k++)
                {
                    if (string.Compare(dataGridView1.Rows[ou].Cells[1].Value.ToString(), a[k].me) == 0)
                    { break; }
                }
                if (agh == true)
                {
                    if (int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString()) != 0)
                    {
                        a[k].qty -= int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString());
                        if (jkl == 0)
                        {
                            printPreviewDialog1.Document = printDocument1;

                            printPreviewDialog1.ShowDialog();

                            jkl = 1;
                        }
                        jk = int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString());

                        while (jk != 0)
                        {
                            if (a[k].bqt[a[k].bno] == 0) { a[k].bno += 1; }

                            if (a[k].bqt[a[k].bno] >= jk)
                            {
                                if (a[k].qty == int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString())) { a[k].qty = 0; }
                                rec[un].me = dataGridView1.Rows[ou].Cells[1].Value.ToString();
                                rec[un].id = a[k].id;
                                a[k].bqt[a[k].bno] -= int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString());
                                rec[un].batch = a[k].batch[a[k].bno];
                                rec[un].da = a[k].da[a[k].bno];
                                rec[un].mfrno = a[k].mfrno;
                                rec[un].yer = a[k].yer[a[k].bno];

                                rec[un].mrp = a[k].id;
                                rec[un].mfr = a[k].mfr;

                                rec[un].qty = int.Parse(dataGridView1.Rows[ou].Cells[2].Value.ToString());
                                rec[un].datee = DateTime.Today;

                                un += 1;
                                break;
                            }
                            else
                            {
                                rec[un].me = dataGridView1.Rows[ou].Cells[1].Value.ToString();
                                rec[un].id = a[k].id;

                                rec[un].batch = a[k].batch[a[k].bno];
                                rec[un].da = a[k].da[a[k].bno];
                                rec[un].mfrno = a[k].mfrno;
                                rec[un].yer = a[k].yer[a[k].bno];
                                jk -= a[k].bqt[a[k].bno];
                                rec[un].mrp = a[k].id;
                                rec[un].mfr = a[k].mfr;

                                rec[un].qty = a[k].bqt[a[k].bno];
                                rec[un].datee = DateTime.Today;
                                a[k].bqt[a[k].bno] = 0;
                                a[k].bno += 1;
                                un += 1;

                            }

                        }



                    }
                }
            }
            ro = 0;
            dataGridView1.Rows.Clear();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int r = new int();

            bool kj = false;


            ListViewItem i3;

            for (r = maind - 1; r >= 0; r--)
            {
                if (string.Compare(textBox10.Text, ba[r].mrname) == 0)
                {
                    kj = true;
                    MessageBox.Show("already there");
                    textBox10.Clear();
                }

            }
            if (kj == false)
            {
                ba[maind].mrfn = maind;
                ba[maind].mrname = textBox10.Text;
                maind += 1;
            }
            listView3.Items.Clear();
            for (r = maind - 1; r >= 0; r--)
            {



                i3 = listView3.Items.Add(ba[r].mrfn.ToString());
                i3.SubItems.Add(ba[r].mrname);





            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            int yui;
            char ch;
            ch = e.KeyChar;
            if (ch == 13)
            {
                for (yui = 0; yui < maind; yui++)
                {
                    if (string.Compare(textBox10.Text, ba[yui].mrname) == 0)
                    {
                        MessageBox.Show("already there");
                        textBox10.Clear();
                    }
                }
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            button11.Visible = false ;
            dataGridView2.Visible = false;
            button18.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            panel8.Visible = false;
            listBox2.Visible = false;
            panel8.Visible = false;
            listBox2.Visible = false;

            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            MRP.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            textBox11.Clear();
            label15.Visible = false;
            button1.BackColor = Color.DarkGreen;
            button3.BackColor = Color.DarkGreen;
            button4.BackColor = Color.DarkGreen;
            button8.BackColor = Color.DarkGreen;
            button9.BackColor = Color.White;
            panel4.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listView2.Visible = true;
            listView4.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listView2.Visible = false;

            listView4.Visible = true;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            listBox1.Select();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int hjk;
        int kank;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (agh == true||ro!=0)
                {
                    panel7.Visible = true;
                    for (hjk = 0; hjk < i; hjk++)
                    {
                        if (string.Compare(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), a[hjk].me) == 0)
                        { break; }
                    }
                    label20.Visible = true;
                    label21.Visible = true;
                    label22.Visible = true;
                    label23.Visible = true;
                    label25.Visible = true;
                    label18.Text = a[hjk].id.ToString();
                    label19.Text = a[hjk].me;
                    label20.Text = a[hjk].qty.ToString();
                    label21.Text = a[hjk].mrp.ToString();
                    label22.Text = a[hjk].da[a[hjg].bno].ToString() + "/" + a[hjk].yer[a[hjg].bno].ToString(); ;
                    label23.Text = a[hjk].batch[a[hjg].bno];
                    label25.Text = a[hjk].mfr;




                }

            }
            else if (e.ColumnIndex == 2) {
                if (agh == true || ro != 0)
                {
                    panel9.Visible = true;
                    mank = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    kank = e.RowIndex;
                }
            }


        }

        private void button11_Click_1(object sender, EventArgs e)
        {

            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label25.Visible = false;



        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {



            {
                listBox1.Items.Clear();

                if (textBox6.Text.Length != 0)
                {
                    //this add searching items to the object

                    int ok = new int();
                    bool j;



                    for (ok = 0; ok < i; ok++)
                    {
                        j = a[ok].me.ToUpper().Contains(textBox6.Text.ToUpper());

                        if (j) { listBox1.Items.Add(a[ok].me); listBox1.Visible = true; }
                    }


                }



                else { listBox1.Visible = false; }
            }
            textBox6.Select();
        }
        string t23;
        int hjg;
        int ter;
        int oua;
        int[] td;
        int[] ty;
        private void button19_Click(object sender, EventArgs e)
        {


            panel8.Visible = false;
            opn = 0;

            for (hjg = 0; hjg < i; hjg++)
                if (string.Compare(textBox11.Text, a[hjg].me) == 0)
                {
                    t23 = a[hjg].me;
                    listBox2.Visible = false;
                    dataGridView2.Rows.Clear();
                    td = new int[100];
                    ty = new int[100];
                    dataGridView2.Visible = true;

                    button20.Visible = true;
                    button21.Visible = true;
                    button22.Visible = true;


                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label26.Visible = true;
                    label27.Visible = true;
                    label28.Visible = true;
                    MRP.Visible = true;
                    label30.Visible = true;
                    label31.Visible = true;
                    label32.Visible = true;
                    listBox2.Visible = false;
                    label15.Visible = true;
                    label15.Text = a[hjg].id.ToString();
                    label16.Text = a[hjg].me.ToUpper();
                    label17.Text = a[hjg].mrp.ToString();
                    label26.Text = a[hjg].qty.ToString();
                    label32.Text = a[hjg].mfr.ToUpper();

                    for (int zx = 0; zx <= (a[hjg].tobn - a[hjg].bno); zx++)
                    {
                        oua = dataGridView2.Rows.Add();
                        td[zx] = a[hjg].da[a[hjg].bno + zx];
                        ty[zx] = a[hjg].yer[a[hjg].bno + zx];
                        dataGridView2.Rows[oua].Cells[0].Value = a[hjg].batch[a[hjg].bno + zx];
                        dataGridView2.Rows[oua].Cells[1].Value = td[zx] + "/" + ty[zx];
                        dataGridView2.Rows[oua].Cells[2].Value = a[hjg].bqt[a[hjg].bno + zx];
                    }
                  
                    break;

                }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            int ok = new int();
            bool j;
            listBox2.Items.Clear();


            for (ok = 0; ok < i; ok++)
            {
                j = a[ok].me.Contains(textBox11.Text);

                if (j) { listBox2.Items.Add(a[ok].me); listBox2.Visible = true; }
            }




            if (textBox11.TextLength == 0) { listBox2.Visible = false; }
        }

        private void listBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
            {
                textBox11.Text = listBox2.GetItemText(listBox2.SelectedIndex);
                listBox2.Visible = false;
            }
            e.Handled = true;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (opn != 2&&opn!=1)
            {
                oua = dataGridView2.Rows.Add();
                panel8.Visible = true;
                opn = 1;
                button18.Visible = true;
                button11.Visible = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (opn == 1)
            { a[hjg].tobn -= a[hjg].bno;
                a[hjg].bno = 0;
               
                a[hjg].tobn += 1;
                a[hjg].qty = 0;
                for (int ad = 0; ad <= (a[hjg].tobn - a[hjg].bno); ad++)
                {

                    a[hjg].qty += int.Parse(dataGridView2.Rows[ad].Cells[2].Value.ToString());
                    a[hjg].da[ad] = td[ad];
                    a[hjg].yer[ad] = ty[ad];
                    a[hjg].batch[ad] = dataGridView2.Rows[ad].Cells[0].Value.ToString();
                    a[hjg].bqt[ad] = int.Parse(dataGridView2.Rows[ad].Cells[2].Value.ToString());
                    opn = 0;
                }


                MessageBox.Show("SUCCEFULLY SAVED");


                dataGridView2.Visible = false;
                button18.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                panel8.Visible = false;
                listBox2.Visible = false;

                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                MRP.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                textBox11.Clear();
                label15.Visible = false;




            }
            else if (opn == 2)
            {
                a[hjg].tobn -= a[hjg].bno;
                a[hjg].qty = 0;
                a[hjg].bno = 0;
                for (int ad = 0; ad <= (a[hjg].tobn); ad++)
                {
                    a[hjg].qty += int.Parse(dataGridView2.Rows[ad].Cells[2].Value.ToString());
                    a[hjg].da[ad] = td[ad];
                    a[hjg].yer[ad] = ty[ad];
                    a[hjg].batch[ad] = dataGridView2.Rows[ad].Cells[0].Value.ToString();
                    a[hjg].da[ad] = td[ad];
                    a[hjg].bqt[ad] = int.Parse(dataGridView2.Rows[ad].Cells[2].Value.ToString());
                    opn = 0;
                }
                MessageBox.Show("SUCCEFULLY SAVED");


                dataGridView2.Visible = false;
                button18.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                panel8.Visible = false;
                listBox2.Visible = false;

                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                MRP.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                textBox11.Clear();
                label15.Visible = false;



            }

            int q1, d1, y1;
            string b1;
            for (int vb = 0; vb < i; vb++)
            {
                for (int nm = 0;nm<= a[vb].tobn-1 ; nm++)
                    for (int hx = a[vb].bno; hx <=a[vb].tobn - nm -1; hx++)
                    {
                        if (a[vb].yer[hx] > a[vb].yer[hx + 1])
                        {
                            y1 = a[vb].yer[hx];
                            a[vb].yer[hx] = a[vb].yer[hx + 1];
                            a[vb].yer[hx + 1] = y1;
                            d1 = a[vb].da[hx];
                            a[vb].da[hx] = a[vb].da[hx + 1];
                            a[vb].da[hx + 1] = d1;
                            q1 = a[vb].bqt[hx];
                            a[vb].bqt[hx] = a[vb].bqt[hx + 1];
                            a[vb].bqt[hx + 1] = q1;
                            b1 = a[vb].batch[hx];
                            a[vb].batch[hx] = a[vb].batch[hx + 1];
                            a[vb].batch[hx + 1] = b1;
                        }
                        else if (a[vb].yer[hx] == a[vb].yer[hx + 1])
                        {
                            if (a[vb].da[hx] > a[vb].da[hx + 1])
                            {
                                y1 = a[vb].yer[hx];
                                a[vb].yer[hx] = a[vb].yer[hx + 1];
                                a[vb].yer[hx + 1] = y1;
                                d1 = a[vb].da[hx];
                                a[vb].da[hx] = a[vb].da[hx + 1];
                                a[vb].da[hx + 1] = d1;
                                q1 = a[vb].bqt[hx];
                                a[vb].bqt[hx] = a[vb].bqt[hx + 1];
                                a[vb].bqt[hx + 1] = q1;
                                b1 = a[vb].batch[hx];
                                a[vb].batch[hx] = string.Copy(a[vb].batch[hx + 1]);
                                a[vb].batch[hx + 1] = b1;
                            }
                        }
                    }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            for (int zx = 0; zx <= (a[hjg].tobn - a[hjg].bno); zx++)
            {
                oua = dataGridView2.Rows.Add();
                td[zx] = a[hjg].da[a[hjg].bno + zx];
                ty[zx] = a[hjg].yer[a[hjg].bno + zx];
                dataGridView2.Rows[oua].Cells[0].Value = a[hjg].batch[a[hjg].bno + zx];
                dataGridView2.Rows[oua].Cells[1].Value = td[zx] + "/" + ty[zx];
                dataGridView2.Rows[oua].Cells[2].Value = a[hjg].bqt[a[hjg].bno + zx];
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            {
                opn = 2;
                button18.Visible = true;
                button11.Visible = true;
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Text = listBox2.SelectedItem.ToString();
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            listBox2.Select();

        }

        private void button24_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= (a[hjg].tobn - a[hjg].bno))
            {
             
                
                    ter = e.RowIndex;
                    panel8.Visible = true;
                    textBox12.Text = a[hjg].batch[a[hjg].bno + e.RowIndex];
                    textBox13.Text = (a[hjg].da[a[hjg].bno + e.RowIndex]).ToString();
                    textBox14.Text = (a[hjg].yer[a[hjg].bno + e.RowIndex]).ToString();
                    textBox15.Text = (a[hjg].bqt[a[hjg].bno + e.RowIndex]).ToString();
                

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (opn == 1)
            {
                if (textBox12.TextLength != 0 || textBox13.TextLength != 0 || textBox14.TextLength != 0 || textBox15.TextLength != 0)
                {
                    td[oua] = int.Parse(textBox13.Text);
                    ty[oua] = int.Parse(textBox14.Text);

                    dataGridView2.Rows[oua].Cells[0].Value = textBox12.Text;
                    dataGridView2.Rows[oua].Cells[1].Value = td[oua] + "/" + ty[oua];
                    dataGridView2.Rows[oua].Cells[2].Value = textBox15.Text;
                    panel8.Visible = false;
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                }
            }
            else if (opn == 2)
            {
                td[ter] = int.Parse(textBox13.Text);
                ty[ter] = int.Parse(textBox14.Text);

                dataGridView2.Rows[ter].Cells[0].Value = textBox12.Text;
                dataGridView2.Rows[ter].Cells[1].Value = td[ter] + "/" + ty[ter];
                dataGridView2.Rows[ter].Cells[2].Value = textBox15.Text;

                panel8.Visible = false;
                 textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();

            }

           
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
                textBox13.Select();



        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
                textBox14.Select();

            else
            if (!char.IsDigit(c) && c != 8)
            {
                if (textBox13.TextLength >= 1)
                    e.Handled = true;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
                textBox13.Select();

            else
            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 13)
                textBox13.Select();

            else
            if (!char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox11_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (listBox2.Visible == true)
            { listBox2.Select(); }
        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for(int kl=0;kl<i;kl++)
            {
                if(a[kl].me.ToUpper().Contains(textBox11.Text.ToUpper()))
                {
                    listBox2.Items.Add(a[kl].me);
                    listBox2.Visible = true;
                }
                else if(textBox11.TextLength==0)
                { listBox2.Visible = false; }
            }
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            button18.PerformClick();
            textBox11.Text = t23;
            button19.PerformClick();
            button11.Visible = false;
          
     
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            decimal d = numericUpDown2.Value;
            if (a[mank-1].qty >= d)
            {
                dataGridView1.Rows[kank].Cells[2].Value = d;
                dataGridView1.Rows[kank].Cells[4].Value = d * int.Parse(dataGridView1.Rows[kank].Cells[3].Value.ToString());
                panel9.Visible = false;
                numericUpDown2.Value = 0;
                mank = 0;
                kank = 0;
                
            }
            else { MessageBox.Show("there only"+a[mank-1].qty.ToString());
                dataGridView1.Rows[kank].Cells[2].Value = a[mank-1].qty;
                dataGridView1.Rows[kank].Cells[4].Value = a[mank-1].qty * int.Parse(dataGridView1.Rows[kank].Cells[3].Value.ToString());
                panel9.Visible = false;
                numericUpDown2.Value = 0;
                mank = 0;
                kank = 0;
            }
            int totoq;
            totoq = 0;
            for(int hkn=0;hkn<=ro;hkn++)
            {
                totoq += int .Parse(dataGridView1.Rows[hkn].Cells[4].Value.ToString());
              

            }
            textBox9.Text = totoq.ToString();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            panel9.Visible = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {
           

        }

        private void button26_Click(object sender, EventArgs e)
        {
            

        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if( e.KeyChar==13)
            { e.Handled = true;
                textBox6.Text = listBox1.GetItemText(listBox1.SelectedItem);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            panel10.BringToFront();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.PageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4",800,1200);
            e.Graphics.DrawString("SRI ARUNACHALAM MEDICALS", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(300, 50));
            e.Graphics.DrawString(System.DateTime.Today.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600,62));
            e.Graphics.DrawString(System.DateTime.Now.ToShortTimeString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 75));
            e.Graphics.DrawString("ID", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 110));
            e.Graphics.DrawString("MEDICINE NAME", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 110));
            e.Graphics.DrawString("QTY", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, 110));
            e.Graphics.DrawString("MRP", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325,110 ));
            e.Graphics.DrawString("COST", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 110));
            e.Graphics.DrawString("EXP DATE", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 110));
            e.Graphics.DrawString("BATCH", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 110));
            for (int mnk=0;mnk<=ro;mnk++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[0].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 150+  (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[1].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 150 + (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[2].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(250, 150 + (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[3].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325, 150 + (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[4].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 150 + (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[5].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 150 + (mnk * 20)));
                e.Graphics.DrawString(dataGridView1.Rows[mnk].Cells[6].Value.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 150 + (mnk * 20)));
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
          int nj=  int.Parse(label18.Text);
            textBox16.Visible = true;
            textBox17.Visible = true;

        }
    }
}


