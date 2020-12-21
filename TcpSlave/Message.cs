namespace TcpSlave
{
    public class Message
    {
        public byte[] dataRecv;
        public byte[] dataSend;

        private bool my_sendFlag = false;
        public bool sendFlag
        {
            get { return my_sendFlag; }
            set { my_sendFlag = value; }
        }
        private bool my_RecvFlag = false;
        public bool recvFlag
        {
            get { return my_RecvFlag; }
            set { my_RecvFlag = value; }
        }

    }
}
