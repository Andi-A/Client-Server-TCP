using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class EchoClient
{
	public static  void Main(String[] args)
	{
		ShowClientNetworkConfig();
		IPAddress ip_address = IPAddress.Parse("127.0.0.1"); //default
		int port = 8080;
		try
		{
			if (args.Length >= 1)
			{
				ip_address = IPAddress.Parse(args[0]);
			}
		}
		catch (FormatException)
		{
			Console.WriteLine("Invalid IP address entered. Using default IP of: "
												+ ip_address.ToString());
		}
		try
		{
			Console.WriteLine("Attempting to connect to server at IP address: {0} port: {1}",
												ip_address.ToString(), port);
			TcpClient client = new TcpClient(ip_address.ToString(), port);
			Console.WriteLine("Connection successful!");
			StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
			string s = String.Empty;
			
			Console.WriteLine("[+] Enter dir to list directories[+]: ");
			Console.WriteLine("[+] Enter Open <filename> to open file[+]: ");
			Console.WriteLine("[+] Enter mkdir new or new1 to create new directory[+]: ");
			Console.WriteLine("[+] Enter a string to send to the server[+]: ");

			string t = String.Empty;

			
			while (!s.Equals("Exit"))
			{
				
				
				s = Console.ReadLine(); // Excepts input
				Console.WriteLine(":>");
				
				writer.WriteLine(s); // Writes on Server Terminal

				writer.Flush();
				if (s.Equals("Help") || s.Equals("help"))
				{
					Console.WriteLine("[+] Enter dir to list directories");
					Console.WriteLine("[+] Enter Open <filename> to open file ");
					Console.WriteLine("[+] Enter mkdir new or new1 to create new directory[+]: ");

					Console.WriteLine("[+] Enter a string to send to the server : ");
				}
				
				if (!s.Equals("Exit"))
				{
					string server_string = reader.ReadLine();
					Console.WriteLine(server_string); //Writes on client
				}

				//}
			}

			reader.Close();
			writer.Close();
			client.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	} // end Main()

	

