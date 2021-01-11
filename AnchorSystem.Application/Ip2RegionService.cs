using IP2Region;

namespace AnchorSystem.Application
{
    /// <summary>
    /// Ip2RegionService
    /// </summary>
    public class Ip2RegionService
    {
        private readonly DbSearcher _searcher;

        public Ip2RegionService()
        {
            _searcher = new DbSearcher(@"ip2region.db");
        }

        /// <summary>
        /// 读取IP地区信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string GetIpArea(string ip)
        {
            if (ip == "::ffff:172.17.0.1" || ip == "::1")
                return "开发调试";
            var result = _searcher.MemorySearch(ip).Region;
            return result;
        }
    }
}
