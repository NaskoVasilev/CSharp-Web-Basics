using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
	public class Program
	{
		private const string NewLine = "\r\n";

		static void Main(string[] args)
		{
			const int port = 8000;

			TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
			tcpListener.Start();
			Console.WriteLine("Server is listening on port: " + port);

			while (true)
			{
				TcpClient tcpClient = tcpListener.AcceptTcpClient();

				using (NetworkStream stream = tcpClient.GetStream())
				{
					string requestContent = ReadRequest(stream);
					PrintRequest(requestContent);
					string responseBody = GetResponseBody();
					byte[] response = GetResponse(responseBody);

					stream.Write(response, 0, response.Length);
				}
			}

		}

		private static byte[] GetResponse(string responseBody)
		{

			string resposne = "HTTP/1.1 200 OK" + NewLine +
				"Content-Type: text/html" + NewLine +
				"Server: Nasko's Custom Server" + NewLine +
				$"Content-Length: {Encoding.UTF8.GetBytes(responseBody).Length}" + NewLine + NewLine +
				responseBody;

			return Encoding.UTF8.GetBytes(resposne);
		}

		private static string GetResponseBody()
		{
			string body = @"<form method='post'>
				<input type='text' name='title' placeholder='Enter post title'/>
				<input type='text' name='content' placeholder='Enter post content'/>
				<input type='submit'/>
			</form>";
			return body;
		}

		private static void PrintRequest(string requestContent)
		{
			Console.WriteLine(requestContent);
			Console.WriteLine(new string('=', 80));
		}

		private static string ReadRequest(NetworkStream stream)
		{
			StringBuilder requestStringBuilder = new StringBuilder();
			byte[] buffer = new byte[1024];
			int readBytes = 0;

			do
			{
				readBytes = stream.Read(buffer, 0, buffer.Length);
				string requestLine = Encoding.UTF8.GetString(buffer, 0, readBytes);
				requestStringBuilder.Append(requestLine);
			}
			while (stream.DataAvailable);

			return requestStringBuilder.ToString().TrimEnd();
		}
	}
}
