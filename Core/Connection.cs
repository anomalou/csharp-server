using System;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

using Server.Model;

namespace Server.Core {
    class Connection {
        private TcpClient tcpClient;
        private Thread thread;

        public Connection (TcpClient tcpClient) {
            this.tcpClient = tcpClient;
        }

        public void Run () {
            thread = new Thread(new ThreadStart(Threading));
        }

        private void Threading () {
            //TODO: abort connection if connection lost with timeout
            while (tcpClient.Connected) {
                DTO dto;
                List<byte> dtoBytes = new List<byte>();
                
                do {
                    byte[] buffer = new byte[1024];
                    int bufferSize = tcpClient.GetStream().Read(buffer, 0, 1024);
                    if(bufferSize < 1024) {
                        byte[] lastBuffer = new byte[bufferSize];
                        Array.Copy(buffer, lastBuffer, bufferSize);
                        dtoBytes.AddRange(lastBuffer);
                        continue;
                    }
                    dtoBytes.AddRange(buffer);
                } while (tcpClient.GetStream().DataAvailable);

                using(MemoryStream memoryStream = new MemoryStream()) {
                    memoryStream.Write(dtoBytes.ToArray());
                    memoryStream.Position = 0;
                    DataContractSerializer deserializer = new DataContractSerializer(typeof(DTO));
                    dto = deserializer.ReadObject(memoryStream) as DTO;
                }

                DTO newDTO = Parser.Instance.ParseAndExecute(dto);

                using(MemoryStream memoryStream = new MemoryStream()) {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(DTO));
                    serializer.WriteObject(memoryStream, newDTO);
                    memoryStream.Position = 0;
                    dtoBytes.Clear();
                    dtoBytes.AddRange(memoryStream.ToArray());
                }

                tcpClient.GetStream().Write(dtoBytes.ToArray(), 0, dtoBytes.Count);
            }

            thread.Abort();
        }
    }
}
