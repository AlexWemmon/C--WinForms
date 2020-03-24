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
using System.Drawing.Printing;
namespace AnotherCalculat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            recentDropDown = new ToolStripDropDown();
            выходToolStripMenuItem.DropDown = recentDropDown;
            recentDropDown.OwnerItem = выходToolStripMenuItem;
            выходToolStripMenuItem.ShowDropDown();
            if (openFileDialog1.FileName == "") {
                File.WriteAllText("C:\\Users\\truen\\Desktop\\recent.txt", openFileDialog1.FileName + "/");
                recentstr = File.ReadAllText("C:\\Users\\truen\\Desktop\\recent.txt");

                paths = recentstr.Split(new Char[] { '/' });
                recent = new ToolStripMenuItem();
                foreach (string path in paths) { recentDropDown.Items.Add(path); }
                
            }
        }
        ToolStripMenuItem recent;
        ToolStripDropDown recentDropDown;
        string recentstr;
        string[] paths;
        List<string> list = new List<string>();
        
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.TXT";
           
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
                string content = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = content;
            list.Add(textBox1.Text);
            File.WriteAllText("C:\\Users\\truen\\Desktop\\recent1.txt", openFileDialog1.FileName+"/");
            recentstr = File.ReadAllText("C:\\Users\\truen\\Desktop\\recent1.txt");
            
             paths = recentstr.Split(new Char[]{'/'});
            recent = new ToolStripMenuItem();
          foreach(string path in paths) { recentDropDown.Items.Add(path); }
            

  
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(openFileDialog1.FileName, textBox1.Text);
                MessageBox.Show(" Файл успешно сохранён !");
            }
            catch (Exception ex) { MessageBox.Show("Файла не существует.Откройте файл!"); }
        }

        private void оРехнутыхСоздателяхПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Создатель: Смирнов А.С.|ЭИС-25");
             
        }

       

        private void смыслСейПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана для курса\"Технологии программирования\"");
        }

        private void цветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
                textBox1.BackColor = colorDialog1.Color;
                MessageBox.Show("Цвет фона задан");
            
   
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
                textBox1.ForeColor = colorDialog1.Color;
                MessageBox.Show("Цвет текста задан");
            
        }
        

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                if (fontDialog1.ShowDialog() == DialogResult.Cancel) return;
                textBox1.Font = fontDialog1.Font;
                MessageBox.Show("Шрифт установлен");
            
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            saveFileDialog1.Filter="Text Files(*.txt)|*.TXT|All files (*.*)|*.*";
            string file = saveFileDialog1.FileName;
            File.WriteAllText(file, textBox1.Text);
            
            MessageBox.Show(" Файл успешно сохранён !");
        }


        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void строкаСостоянияToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (statusStrip1.Items.Count != 0) { list.Add(textBox1.Text); statusStrip1.Items.RemoveAt(0); statusStrip1.Items.Add(textBox1.TextLength.ToString()); }
            else{
                statusStrip1.Items.Add(Convert.ToString(textBox1.Text.Length));

            }
            
        }

        private void hfgcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                printDialog1.AllowSomePages = true;
                printDialog1.ShowHelp = true;
                PrintDocument print = new PrintDocument();
                print.DocumentName = openFileDialog1.FileName;
                print.PrinterSettings = printDialog1.PrinterSettings;
                if (printDialog1.ShowDialog() == DialogResult.Cancel) return;
                printDialog1.PrintToFile = true;
                print = printDialog1.Document;
                print.Print();
                MessageBox.Show("Запущен процесс печати");
                
            
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {   if (textBox1.WordWrap == true)
                textBox1.WordWrap = false;
            else textBox1.WordWrap = true;
        }

        private void строкаСостоянияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == false) { statusStrip1.Visible = true;} else statusStrip1.Visible = false;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void недавниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
              if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                saveFileDialog1.Filter = "Text Files(*.txt)|*.TXT|All files (*.*)|*.*";
                string file2 = saveFileDialog1.FileName;
                File.WriteAllText(file2, textBox1.Text);

                MessageBox.Show(" Файл успешно создан !");
            
        }

        private void выходToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        { foreach (var i in paths)
            {
                string help = i;
                string content = File.ReadAllText(help);
                textBox1.Text = content;
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            textBox1.Copy();
        }

        private void вставитьCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void отменаCTRLZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void повторитьCTRLYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Count != 0) { textBox1.Text = list.LastOrDefault(); list.RemoveAt(list.Count - 1); }
        }

        private void новыйДокументCTRLNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.TXT|All files (*.*)|*.*";
            string file = saveFileDialog1.FileName;
            File.WriteAllText(file, textBox1.Text);
        }

        private void сохранитьCTRLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines(openFileDialog1.FileName, textBox1.Lines);
                MessageBox.Show(" Файл успешно сохранён !");
            }
            catch (Exception ex) { MessageBox.Show("Файла не существует.Откройте файл!"); }
        }

        private void сохранитьКакCTRLSHIFTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.TXT|All files (*.*)|*.*";
            string file = saveFileDialog1.FileName;
            File.WriteAllText(file, textBox1.Text);
        }

        private void открытьCTRLOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files(*.txt)|*.TXT";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            string content = File.ReadAllText(openFileDialog1.FileName);
            textBox1.Text = content;
            File.WriteAllText("C:\\Users\\truen\\Desktop\\recent1.txt", openFileDialog1.FileName + "/");
            recentstr = File.ReadAllText("C:\\Users\\truen\\Desktop\\recent1.txt");

            paths = recentstr.Split(new Char[] { '/' });
            recent = new ToolStripMenuItem();
            foreach (string path in paths) { recentDropDown.Items.Add(path); }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.O&&e.Control)) { открытьCTRLOToolStripMenuItem_Click(sender as object,EventArgs.Empty); }
            if ((e.KeyCode == Keys.Z && e.Control)) { textBox1.Undo(); }
            if ((e.KeyCode == Keys.Y && e.Control)) { if (list.Count != 0) { textBox1.Text = list.LastOrDefault(); list.RemoveAt(list.Count - 1); } }
            if ((e.KeyCode == Keys.S && e.Control&&e.Shift)) { сохранитьКакCTRLSHIFTSToolStripMenuItem_Click(sender as object, EventArgs.Empty); }
            if ((e.KeyCode == Keys.N&& e.Control)) { новыйДокументCTRLNToolStripMenuItem_Click(sender as object, EventArgs.Empty); }
            if ((e.KeyCode == Keys.S && e.Control)) {сохранитьCTRLSToolStripMenuItem_Click(sender as object, EventArgs.Empty); }
        }
    }
    
}
