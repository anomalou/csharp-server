using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
// using client.Model;
using Server.Model;
using F10Libs.Networkdata;

namespace Server.Core {
    class Connection {
        private TcpClient tcpClient;
        private Thread thread;

        public Connection (TcpClient tcpClient) {
            this.tcpClient = tcpClient;
        }

        public void Run () {
            thread = new Thread(new ThreadStart(Threading));
            thread.Start();
            Logger.Instance.AddMessage($"User connected with ip: {((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString()}");
        }

        public void Stop () {
            tcpClient.Close();
            tcpClient.Dispose();
        }

        private void Threading () {
            while (tcpClient.Connected) {
                try {
                    DTO dto;
                    List<byte> dtoBytes = new List<byte>();
                    MemoryStream streamOut = new MemoryStream();
                    MemoryStream streamIn = new MemoryStream();

                    BinaryFormatter binaryFormatter = new BinaryFormatter();

                    do {
                        byte[] buffer = new byte[1024];
                        int bufferSize = tcpClient.GetStream().Read(buffer, 0, 1024);
                        if (bufferSize < 1024) {
                            byte[] lastBuffer = new byte[bufferSize];
                            Array.Copy(buffer, lastBuffer, bufferSize);
                            dtoBytes.AddRange(lastBuffer);
                            continue;
                        }
                        dtoBytes.AddRange(buffer);
                    } while (tcpClient.GetStream().DataAvailable);

                    streamOut.Write(dtoBytes.ToArray(), 0, dtoBytes.Count);

                    streamOut.Seek(0, SeekOrigin.Begin);

                    dto = binaryFormatter.Deserialize(streamOut) as DTO;

                    // using (MemoryStream memoryStream = new MemoryStream()) {
                    //     memoryStream.Write(dtoBytes.ToArray());
                    //     memoryStream.Position = 0;
                    //     DataContractSerializer deserializer = new DataContractSerializer(typeof(DTO));
                    //     dto = deserializer.ReadObject(memoryStream) as DTO;
                    // }

                    DTO newDTO = Parser.Instance.ParseAndExecute(dto);

                    // using (MemoryStream memoryStream = new MemoryStream()) {
                    //     DataContractSerializer serializer = new DataContractSerializer(typeof(DTO));
                    //     serializer.WriteObject(memoryStream, newDTO);
                    //     memoryStream.Position = 0;
                    //     dtoBytes.Clear();
                    //     dtoBytes.AddRange(memoryStream.ToArray());
                    // }
                    
                    // stream.SetLength(0);
                    
                    binaryFormatter.Serialize(streamIn, newDTO);
                    
                    tcpClient.GetStream().Write(streamIn.ToArray());

                    // tcpClient.GetStream().Write(dtoBytes.ToArray(), 0, dtoBytes.Count);
                }catch (Exception ex) {

                }
            }
            Logger.Instance.AddMessage($"User disconnected with ip: {((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString()}");
        }
    }
}
