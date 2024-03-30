using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        //Host ve port ile erişim sağlayacağım.
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        //ilk sırada olan database getirecek.
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
