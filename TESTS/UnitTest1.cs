using CommonLibrary.Messages;
using CommonLibrary.Messages.Groups;
using MessageLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<ChatMessage> list = new List<ChatMessage>() {
                new ChatMessage("adat")
            };
            ArrayMessage<ChatMessage> msg = new ArrayMessage<ChatMessage>(list);
            byte[] arr = msg.ToByteArray();
            Message result = Message.FromByteArray(arr.ToList().GetRange(4,arr.Length-4).ToArray());
        }

        [TestMethod]
        public void TestFileClient()
        {
            TcpFileClientWrap client = new TcpFileClientWrap(IPAddress.Parse("127.0.0.1"), 5001);
        }
    }
}
