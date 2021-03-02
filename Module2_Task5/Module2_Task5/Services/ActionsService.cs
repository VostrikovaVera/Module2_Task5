using System;
using Module2_Task5.Common.Enums;
using Module2_Task5.Models.Contracts;
using Module2_Task5.Services.Contracts;

namespace Module2_Task5.Services
{
    public class ActionsService : IActionsService
    {
        private readonly ILoggerService _logger;
        private readonly IConfigService _configService;

        public ActionsService()
        {
            _logger = LoggerService.Instance;
            _configService = new ConfigService();
        }

        public bool ActionOne()
        {
            var config = _configService.Read("config.json");
            var logMessage = $"Start method: {nameof(ActionOne)}";
            _logger.LogEvent(LogTypes.Info, logMessage, config.LogPath);

            return true;
        }

        public bool ActionTwo()
        {
            try
            {
                return false;
            }
            finally
            {
                throw new BusinessException();
            }
        }

        public bool ActionThree()
        {
            try
            {
                return false;
            }
            finally
            {
                throw new Exception("I broke a logic");
            }
        }
    }
}
