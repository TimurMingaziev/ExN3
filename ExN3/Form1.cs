using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ExN3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string title = "";
        List<string> titleList = new List<string>(); // Список для хранения шапок стр.
        List<string> links = new List<string>(); // Списаок для хранения ссылок.

        // Поиск тега <title> и запись содержимого тега в переменную title.
        void getTitle(string inputString)
        {
            try
            {
                Match m = Regex.Match(inputString, @"<title>\s*(.+?)\s*</title>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                if (m.Success)
                {
                    title = m.Groups[1].Value;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                statusText.Text = "The matching operation timed out.";
            }
        }

        // Определяет URL в строке
        string defineUrl(string input)
        {
            
            string url = "";
            Match m;
            try
            {
                m = Regex.Match(input, @"(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
                if (m.Success)
                    try
                    {
                        Uri uri = new Uri(m.Groups[1].Value.ToString());
                        if (!uri.IsFile && Uri.IsWellFormedUriString(m.Groups[1].Value.ToString(), UriKind.RelativeOrAbsolute))
                            url = m.Groups[1].Value.ToString();
                    }
                    catch { }
            }
            catch (RegexMatchTimeoutException) { statusText.Text = "The matching operation timed out."; }
            return url;
        }

        // Поиск ссылок в данной странице.
        void searchHrefs(string inputString)
        {
            getTitle(inputString);
            links.Clear();
            Match m;
            try
            {
                m = Regex.Match(inputString, "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled, TimeSpan.FromSeconds(1));
                while (m.Success)
                {
                    try
                    {

                        Uri uri = new Uri(m.Groups[1].Value.ToString());
                        if (!uri.IsFile && Uri.IsWellFormedUriString(m.Groups[1].Value.ToString(), UriKind.RelativeOrAbsolute))
                            links.Add(m.Groups[1].Value.ToString());
                    }
                    catch { }
                    finally { m = m.NextMatch(); }
                }
            }
            catch (RegexMatchTimeoutException)
            {
               statusText.Text = "The matching operation timed out.";
            }
        }

        // Загрузка кода html страницы. Переменная path предназначена для выбора функции
        void loadPage(string url, bool path)
        {
            
            HttpWebResponse resp = null;
            StreamReader reader = null;
            string htmlCode = "";
            try
            {
                Uri uri = new Uri(url);
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                    resp = (HttpWebResponse)req.GetResponse();
                    reader = new StreamReader(resp.GetResponseStream());
                    htmlCode += reader.ReadToEnd();

                }
                catch (WebException ex) { statusText.Text = ex.Message + " " + url; }
                catch (ProtocolViolationException ex) { statusText.Text = ex.Message + " " + url; }
                catch (UriFormatException ex) { statusText.Text = ex.Message + " " + url; }
                catch (IOException ex) { MessageBox.Show(ex.Message, "Ошибка ввода-вывода"); }
                catch (NotSupportedException ex) { statusText.Text = ex.Message + " " + url; ; }
                catch (System.Security.SecurityException ex) { statusText.Text = ex.Message + " " + url; }

                finally
                {
                    if (resp != null)
                        resp.Close();
                    if (reader != null)
                        reader.Close();
                }
                if (path)
                    searchHrefs(htmlCode);
                else getTitle(htmlCode);
                
            }
            catch (Exception e) { statusText.Text = e.Message; }
        }
        private void loadPageButton_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            links.Clear();
            try
            {
                Uri uri = new Uri(pagePathText.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            try
            {
                Convert.ToInt32(searchParamText.Text);
            }
            catch { MessageBox.Show("Не верный формат глубины"); return; }
            TreeNode node = itsTree(pagePathText.Text, Convert.ToInt32(searchParamText.Text), new TreeNode());
            foreach (TreeNode n in node.Nodes)
            {
                treeView1.Nodes.Add(n);
            }
            progressBar.Value = 0;
            ClassSerialiaze.SaveTree(treeView1, "linksTree.xml");
        }
        
        public TreeNode itsTree(string url, int l, TreeNode node){
            loadPage(url,true);
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = links.Count;
            progressBar.Step = 1;

            IEnumerable<string> distinctAges = links.Distinct();
            
            foreach (string a in distinctAges)
            {
                progressBar.PerformStep();
                loadPage(a, false);
                node.Nodes.Add(title + " " + a);
            }
            progressBar.Value = links.Count;
            if (l > 0)
            {
                try
                {
                    foreach (TreeNode n in node.Nodes)
                    {
                        itsTree(defineUrl(n.Text), l - 1, n);
                    }
                }
                catch (ArgumentException e) { statusText.Text = e.Message; }

            }
            
            return node;
        }
        private void loadFromXmlButton_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            ClassSerialiaze.LoadTree(treeView1, "linksTree.xml");
        }
    }
}
