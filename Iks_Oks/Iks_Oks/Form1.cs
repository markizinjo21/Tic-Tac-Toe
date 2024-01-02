using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iks_Oks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            this.Size = new System.Drawing.Size(600,600);

        }
        bool x;
        bool o;
        bool[] tabla;
        int[,] tabla_koordinate;
      
        bool[,] tabla_x;
        bool[,] tabla_o;
       
       
        public struct Parametri
        {
            public int x;
            public int y;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
      
            x = true;
            o=false;
            tabla = new bool[9];
            tabla_koordinate= new int[3,3];
           
            tabla_x= new bool[3, 3];
            tabla_o=new bool[3,3];
    ;

            int b = 0;
            for (int j = 0; j < tabla_koordinate.GetLength(1); j++)
            {
                for (int i = 0; i < tabla_koordinate.GetLength(0); i++)
                {
                    tabla_koordinate[i, j] = b;
                    b++;
                }
            }
            Refresh();

        }
        private void NacrtajGrid(Graphics g,Pen olovka)
        {
         
            g.DrawLine(olovka, ClientRectangle.Width / 3, 0, ClientRectangle.Width / 3, ClientRectangle.Height);
            g.DrawLine(olovka, 2 * ClientRectangle.Width / 3, 0, 2 * ClientRectangle.Width / 3, ClientRectangle.Height);
            g.DrawLine(olovka, 0, ClientRectangle.Height / 3, ClientRectangle.Width, ClientRectangle.Height / 3);
            g.DrawLine(olovka, 0, 2 * ClientRectangle.Height / 3, ClientRectangle.Width, 2 * (ClientRectangle.Height / 3));
        }
        private bool Provera_Pobede1(bool[,]tablapolja)
        {
            int b = 0;
            List<Parametri> l=new List<Parametri>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablapolja[i, j])
                    {
                        b++;
                        Parametri p = new Parametri();
                        p.x = i;
                        p.y = j;
                        l.Add(p);
                    }

                }
            }
            if(b>=3)
            {
                    int b1 = 0;
                    int b2 = 0;
                    int b3 = 0;
                    foreach (var x in l)
                    {
                        if (x.x == 0)
                            b1++;
                        if(x.x==1)
                            b2++;
                        if(x.x==2)
                            b3++;
                    }    
                    if (b1 == 3 || b2 == 3 || b3 == 3)
                    { return true; }
                    b1=b2=b3 = 0;
                    foreach (var x in l)
                    {
                        if (x.y == 0)
                            b1++;
                        if (x.y == 1)
                            b2++;
                        if (x.y == 2)
                            b3++;
                    }
                    if (b1 == 3 || b2 == 3 || b3 == 3)
                    { return true; }
                    b1 = b2 = b3 = 0;
                    foreach (var x in l)
                    {
                        if (x.x-x.y==0)
                        {
                            b1++;
                        }
                    }
                    if (b1 == 3)
                        return true;
                    foreach (var x in l)
                    {
                        if (x.x + x.y == 2)
                            b2++;
                    }
                    if (b2 == 3)
                        return true;
            }
            return false;
        }
      // private bool Provera_Pobede(List<int> polja_znaka)
        //{
        //    int z = 0;
        //    foreach (var x in polja_znaka)
        //    {
        //        z += x;

        //    }
        //    if(polja_znaka.Count==3)
        //    {
        //        if (z == 12)
        //            return true;
        //    }
        //    if (polja_znaka.Count == 4)
        //    {
        //        foreach (var x in polja_znaka)
        //        {
        //            if (z - x == 12)
        //            {
        //                return true;
        //            }
        //        }

        //    }
        //    if (polja_znaka.Count == 5)
        //    {
        //        foreach (var x in polja_znaka)
        //        {
        //            foreach (var y in polja_znaka)
        //            {
        //                if (y == x)
        //                    continue;
        //                else
        //                {
        //                    if (z - x - y == 12)
        //                    {
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen olovka = new Pen(Color.Black, 20);
            NacrtajGrid(g, olovka);

        }
       
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Graphics g = CreateGraphics();
            bool kraj = true;
            bool pobeda_x=false;
            bool pobeda_o = false;
            int x1 = ClientRectangle.Width / 3;

            int x2=ClientRectangle.Width / 30;
            int x3 = ClientRectangle.Width / 15;
            int y1=ClientRectangle.Height / 3;
            int y2=ClientRectangle.Height / 30;
           
            int y3=ClientRectangle.Height / 15;
            for (int i = 0; i < tabla_koordinate.GetLength(0); i++)
            {
                for (int j = 0; j < tabla_koordinate.GetLength(1); j++)
                {
                  if(e.X>=i * x1 &&
                        e.X < (i + 1) * x1 &&
                        e.Y>=j*y1&&
                        e.Y < (j + 1) * y1&&
                        tabla[tabla_koordinate[i, j]] == false)
                    {
                        if(x)
                        {
                            Pen olovka = new Pen(Color.Red, 15);
                            g.DrawLine(olovka,i * x1+x2, j * y1+y2, (i + 1) *x1-x2, (j + 1) * y1-y2);
                            g.DrawLine(olovka, (i + 1) * x1-x2, j * y1+y2, i * x1+x2, (j + 1) * y1-y2);
                            o = true;
                            x = false;
                          
                            tabla_x[i, j] = true;
                           pobeda_x= Provera_Pobede1(tabla_x);

                        }
                        else
                        {
                            Pen olovka = new Pen(Color.Blue, 15);
                            g.DrawEllipse(olovka, (i * x1) + x2, (j *y1) + y2, x1 - x3, y1 - y3);
                            o = false;
                            x = true;
                           
                            tabla_o[i, j] = true;
                            pobeda_o = Provera_Pobede1(tabla_o);
                        }
                        tabla[tabla_koordinate[i,j]] = true;
                    }

                }
            }
            if (pobeda_x)
            {
               KrajIgre pbx = new KrajIgre('x',this);
                pbx.Show();
              
            }
            else if (pobeda_o)
            {

                KrajIgre pbx = new KrajIgre('o',this);
                pbx.Show();
            
            }
            else
            {
                foreach (bool x in tabla)
                {
                    if (!x)
                        kraj = false;
                }
                if (kraj)
                {
                   
                    KrajIgre pbx = new KrajIgre('=',this);
                    pbx.Show();
                    

                }
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
