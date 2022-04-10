
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public class MultiIPEchoServer
{

	private static void ProcessClientRequests(object argument)
	{

		TcpClient client = (TcpClient)argument;
		try
		{

			StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
			string s = String.Empty;

			while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
			{

				Console.WriteLine("From client -> " + s);
				writer.WriteLine("From server ->");


				writer.Flush();
                // Giving System Commands
				if (s.Equals("dir"))
				{

					try
					{
						using (Process p = new Process()) // Provides access to local and remote processes
						{
							// set start info
							p.StartInfo = new ProcessStartInfo("cmd.exe") //Specifies application name
							{
								RedirectStandardInput = true,
								RedirectStandardOutput = true,
								UseShellExecute = false,
								WorkingDirectory = @"C:\Users\Test\Documents\Test" // Where files are stored
							};


							// start process
							p.Start();
							// send command to its input
							p.StandardInput.Write("dir" + p.StandardInput.NewLine);
							p.StandardInput.Write("exit" + p.StandardInput.NewLine);
							string output = String.Empty;
							output = p.StandardOutput.ReadToEnd();

							writer.Write(output); // Print on client terminal
							Console.Write(output);// Print on server terminal
							//wait
							p.WaitForExit();

						}
					}

					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
				}




				else if (s.Equals("Open Pershendetje.txt") || s.Equals("open Pershendetje.txt"))
				{

					try
					{
						using (Process p = new Process())
						{
							// set start info
							p.StartInfo = new ProcessStartInfo("cmd.exe")
							{
								RedirectStandardInput = true,
								UseShellExecute = false,
								WorkingDirectory = @"C:\Users\Test\Documents\Test"
							};


							// start process
							p.Start();

							// send command to its input
							p.StandardInput.Write("Pershendetje.txt" + p.StandardInput.NewLine);
							p.StandardInput.Write("exit" + p.StandardInput.NewLine);

							//wait

							p.WaitForExit();
						}
					}


					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}


				}

				else if (s.Equals("Open Test.txt") || s.Equals("open Test.txt"))
				{

					try
					{
						using (Process p = new Process())
						{
							// set start info
							p.StartInfo = new ProcessStartInfo("cmd.exe")
							{
								RedirectStandardInput = true,
								UseShellExecute = false,
								WorkingDirectory = @"C:\Users\Test\Documents\Test"
							};


							// start process
							p.Start();

							// send command to its input
							p.StandardInput.Write("Test.txt" + p.StandardInput.NewLine);
							p.StandardInput.Write("exit" + p.StandardInput.NewLine);

							//wait
							p.WaitForExit();
						}
					}


					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}


				}
				else if (s.Equals("mkdir New") || s.Equals("mkdir new"))
				{


					try
					{
						using (Process p = new Process())
						{
							// set start info
							p.StartInfo = new ProcessStartInfo("cmd.exe")
							{
								RedirectStandardInput = true,
								UseShellExecute = false,
								WorkingDirectory = @"C:\Users\Test\Documents\Test"
							};


							// start process
							p.Start();

							// send command to its input


							p.StandardInput.Write("mkdir New" + p.StandardInput.NewLine);
							p.StandardInput.Write("exit" + p.StandardInput.NewLine);

							//wait
							p.WaitForExit();
						}
					}


					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}


				}


				else if (s.Equals("mkdir New1") || s.Equals("mkdir new1"))
				{


					try
					{
						using (Process p = new Process())
						{
							// set start info
							p.StartInfo = new ProcessStartInfo("cmd.exe")
							{
								RedirectStandardInput = true,
								UseShellExecute = false,
								WorkingDirectory = @"C:\Users\Test\Documents\Test"
							};

