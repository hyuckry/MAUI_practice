using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace ExamNaverOpenAPI
{
    public partial class Form1 : Form
    {
        const string _apiUrl = "https://openapi.naver.com/v1/search/news.json"; 
        const string _clientId = "th9HE15pX9wwEfg0wVLq"; //Application Client ID 입력
        const string _clientSecret = "Y52e_EJeJn"; //Application Client Secret 입력

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string results = getResults();
                results = results.Replace("<b>", "");
                results = results.Replace("</b>", "");
                results = results.Replace("&lt;", "<");
                results = results.Replace("&gt;", ">");

                var parseJson = JObject.Parse(results);
                var countsOfDisplay = Convert.ToInt32(parseJson["display"]);
                var countsOfResults = Convert.ToInt32(parseJson["total"]);

                listViewResults.Items.Clear();
                for (int i=0; i< countsOfDisplay; i++)
                {
                    ListViewItem item = new ListViewItem((i+1).ToString());
                    
                    var title = parseJson["items"][i]["title"].ToString();
                    title = title.Replace("&quot;", "\"");

                    var description = parseJson["items"][i]["description"].ToString();
                    description = description.Replace("&quot;", "\"");

                    var link = parseJson["items"][i]["link"].ToString();

                    item.SubItems.Add(title);
                    item.SubItems.Add(description);
                    item.SubItems.Add(link);

                    listViewResults.Items.Add(item);
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }
        }

        private string getResults()
        {
            string keyword = textBoxKeyword.Text;
            string display = trackBarDisplayCounts.Value.ToString();
            string sort = "sim";
            if (radioButtonDate.Checked == true)
                sort = "date";

            string query = string.Format("?query={0}&display={1}sort={2}", keyword, display, sort);

            WebRequest request = WebRequest.Create(_apiUrl + query);
            request.Headers.Add("X-Naver-Client-Id", _clientId);
            request.Headers.Add("X-Naver-Client-Secret", _clientSecret);

            string requestResult = "";
            using (var response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(dataStream))
                    {
                        requestResult = reader.ReadToEnd();
                    }
                }
            }
                
            return requestResult;
        }

        private void trackBarDisplayCounts_Scroll(object sender, EventArgs e)
        {
            labelDisplayCounts.Text = trackBarDisplayCounts.Value.ToString();
        }
    }
}
