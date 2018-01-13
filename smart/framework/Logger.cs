using System;
using log4net;

namespace demo.framework
{
    public class Logger
    {
        private ILog logger;

        public Logger(ILog logger)
        {
            this.logger = logger;
        }

        public void Step(int step, string action)
        {
            logger.Info("== Step " + step + " :" + action + " ==");
        }
        public void Info(string info)
        {
            logger.Info(info);
        }

        public void Fatal(string fatal)
        {
            logger.Fatal(fatal);
        }
    }
}
