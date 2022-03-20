using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumToStr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> lsResult = new List<string>();
        string[] single = { "صفر", "واحد", "اثنين", "ثلاثة", "اربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة" };
        string[] et = {"", "احدا عشر", "اثنا عشر" };
        string[] tens = { "", "عشرة", "عشرين", "ثلاثين", "اربعين", "خمسين", "ستين", "سبعين", "ثمانين", "تسعين" };
        string[] hundred = { "", "مئة", "مئتان" };
        public string num2str(int num, int len)
        {
            string temp = " ";
            int x0, x1, x2;
            switch (len)
            {
                case 1:
                    {
                        temp = single[num];
                        break;
                    }
                case 2:
                    {
                        x0 = num % 10;
                        num=num/10;
                        x1 = num % 10;
                        temp = tens_str(x1, x0);
                        break;
                    }
                case 3:
                    {
                        x0 = num % 10;
                        num = num / 10;
                        x1 = num % 10;
                        num = num / 10;
                        x2 = num % 10;
                        if(x2<=2)
                        {
                            if (x0 == 0 && x1 == 0)
                            {
                                temp = hundred[x2];
                            }
                            else
                            {
                                temp = hundred[x2] + " و " + tens_str(x1, x0);
                            }
                        }
                         else if(x2>2)
                        {
                             if(x0==0 && x1==0)
                             {
                                 temp =single[x2]+ hundred[1];
                             }
                             else
                             {
                                 temp = single[x2] +" "+ hundred[1] + " و " + tens_str(x1, x0);
                             }
                         }
                        break;
                    }
            }
            return temp;
        }
        public string tens_str(int x1,int x0)
        {
            string temp = "";
            if (x0 == 1 && x1 == 1)
            {
                temp = et[x0];
            }
            else if (x0 == 2 && x1 == 1)
            {
                temp = et[x0];
            }
            else if (x0 == 0 && x1 >0)
            {
                temp = tens[x1];
            }
            else if(x0>=1 && x1==0)
            {
                temp = single[x0];
            }
            else
            {
                if (x1 > 1)
                    temp = single[x0] + " و " + tens[x1];
                else
                {
                    temp = single[x0] + " " + tens[x1];
                }
            }     
            return temp;
        }
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            int x, len = 0;
            x = Int32.Parse(nudNumber.Value.ToString());
            while (x != 0)
            {
                x /= 10;
                len++;
            }// end while
            lblMsg.Text = num2str(Int32.Parse(nudNumber.Value.ToString()), len);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
