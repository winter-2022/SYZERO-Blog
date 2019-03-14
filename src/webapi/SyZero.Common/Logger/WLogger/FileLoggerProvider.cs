using Microsoft.Extensions.Logging;

namespace SyZero.Common
{
    public class FileLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// 默认构造函数，根据Provider进此构造函数
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }
}
