using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;
using System.Data;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
			DataTable dt = new DataTable();
			MySqlConnectionStringBuilder connect = new MySqlConnectionStringBuilder ();	
			connect.Server = "127.0.0.1";
			connect.Database = "test";
			connect.UserID = "root";
			connect.Password = "123";
			String query = @"select * from desciption";

			using (MySqlConnection con = new MySqlConnection())
			{
				con.ConnectionString = connect.ConnectionString;

				MySqlCommand com = new MySqlCommand(query, con);

				try
				{
					con.Open();

					using(MySqlDataReader dr = com.ExecuteReader())
					{
						if (dr.HasRows)
						{
							dt.Load(dr);
						}
					}
				}

				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			var w = dt.Rows;
			foreach (var ww in w) {
				Console.WriteLine (ww);
			}

//			NameValueCollection querystring = new NameValueCollection();
//			querystring ["email_address"] = "aozertsov@gmail.com";
//
//			string[] files = new string[] {"/home/alexander/Изображения/Ubunta.png"};
//			UploadFilesToRemoteUrl("http://netacademy.net/cgi-bin/upload.cgi", files, "", querystring);

			String adress = @"http://netacademy.net/some/Ubunta.png";

			//byte[] barray = Encoding.UTF8.GetBytes(adress);
			//adress = Encoding.UTF8.GetString(barray);

			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();


			string fileName = "/home/alexander/Загрузки/Ubunta.png";
			//barray = Encoding.UTF8.GetBytes(fileName);
			//fileName = Encoding.UTF8.GetString(barray);

			myWebClient.DownloadFile (adress, fileName);

			Console.WriteLine("Uploading {0} to {1} ...",fileName, adress);
			// Upload the file to the URL using the HTTP 1.0 POST. 
			byte[] responseArray = myWebClient.UploadFile(adress, "POST", fileName);

			// Decode and display the response.
			Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
				System.Text.Encoding.ASCII.GetString(responseArray));


			//проверка файла
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://netacademy.net/cgi-bin/perltest.cgi");
			request.Method = "GET";
			WebResponse webResponse2 = request.GetResponse();
			Stream stream2 = webResponse2.GetResponseStream();
			StreamReader reader2 = new StreamReader(stream2);

			String otvet = reader2.ReadToEnd();
			//need to split;
			Console.WriteLine (otvet);
			webResponse2.Close();
			request = null;
			webResponse2 = null;

//			sorter
//            int[] p = new int[3];
//            for (int l = 0; l < p.Length; l++)
//            {
//                p[l] = Int16.Parse(Console.ReadLine());
//            }
//            Console.WriteLine();
//            BaseSort.PasteSort(p);
//            for (int l = 0; l < p.Length; l++)
//            {
//                Console.WriteLine(p[l]);
//            }
        }

		private static void UploadFilesToRemoteUrl(string url, string[] files, string
			logpath, NameValueCollection nvc)
		{
			long length = 0;
			string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
			HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
			httpWebRequest2.Method = "POST";
			httpWebRequest2.KeepAlive = true;
			httpWebRequest2.Credentials = System.Net.CredentialCache.DefaultCredentials;

			Stream memStream = new System.IO.MemoryStream();

			byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
			string formdataTemplate = "\r\n--" + boundary +	"\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

			foreach(string key in nvc.Keys)
			{
				string formitem = string.Format(formdataTemplate, key, nvc[key]);
				byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
				memStream.Write(formitembytes, 0, formitembytes.Length);
			}
			memStream.Write(boundarybytes,0,boundarybytes.Length);

			string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";

			for(int i=0; i<files.Length; i++)
			{
				string header = string.Format(headerTemplate,"file",files[i]);

				byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

				memStream.Write(headerbytes,0,headerbytes.Length);
				FileStream fileStream = new FileStream(files[i], FileMode.Open,
					FileAccess.Read);
				byte[] buffer = new byte[1024];

				int bytesRead = 0;

				while ( (bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0 )
				{
					memStream.Write(buffer, 0, bytesRead);

				}
				memStream.Write(boundarybytes,0,boundarybytes.Length);
				fileStream.Close();
			}

			httpWebRequest2.ContentLength = memStream.Length;

			Stream requestStream = httpWebRequest2.GetRequestStream();

			memStream.Position = 0;
			byte[] tempBuffer = new byte[memStream.Length];
			memStream.Read(tempBuffer,0,tempBuffer.Length);
			memStream.Close();
			requestStream.Write(tempBuffer,0,tempBuffer.Length );
			requestStream.Close();
			WebResponse webResponse2 = httpWebRequest2.GetResponse();

			Stream stream2 = webResponse2.GetResponseStream();
			StreamReader reader2 = new StreamReader(stream2);

			Console.WriteLine(reader2.ReadToEnd());

			webResponse2.Close();
			httpWebRequest2 = null;
			webResponse2 = null;

		}

    }
}
