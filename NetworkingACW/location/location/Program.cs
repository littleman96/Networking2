//Demonstrate Sockets
using System;
using System.Net.Sockets;
using System.IO;
public class Whois
{
    static void Main(string[] args)
    {
        int c;
        TcpClient client = new TcpClient();
        client.Connect("whois.net.dcs.hull.ac.uk", 43);  // connecting to the server being used through port 43
        StreamWriter sw = new StreamWriter(client.GetStream());
        StreamReader sr = new StreamReader(client.GetStream());
        try
        {
            sw.WriteLine(args[0]);
        }
        catch(IndexOutOfRangeException e)
        {
            Console.WriteLine("failure" + e);
        }
        sw.Flush();
        Console.WriteLine(sr.ReadToEnd());
    }
}

public void runServer()  //not sure if in the right place. might need removing
{
    TcpListener listener;
    Socket connection;
    NetworkStream socketStream;
    try
    {
        listener = new TcpListener(43);
        while (true)
        {
            connection = listener.AcceptSocket();
            socketStream = new NetworkStream(connection);
            doRequest(socketStream); //check what correct line is
            socketStream.Close();
            connection.Close();
        }
    }
    catch (Exception e)
    {
        log.log(e.ToString()); //check what correct line is
    }
}
