using System;
using Module2_Task5.Common.Enums;
using Module2_Task5.Models.Contracts;
using Module2_Task5.Services;
using Module2_Task5.Services.Contracts;

namespace Module2_Task5
{
    public class Starter
    {
        private readonly int _minRandomAction = 0;
        private readonly int _maxRandomAction = 3;
        private readonly Random _random = new Random();
        private readonly IActionsService _actionsService;
        private readonly ILoggerService _loggerService;
        private readonly IConfigService _configService;

        public Starter()
        {
            _actionsService = new ActionsService();
            _loggerService = LoggerService.Instance;
            _configService = new ConfigService();
        }

        public void Run()
        {
            var config = _configService.Read("config.json");

            for (var i = 0; i < 100; i++)
            {
                var actionFlag = true;
                var actionNumber = _random.Next(_minRandomAction, _maxRandomAction);

                try
                {
                    switch (actionNumber)
                    {
                        case 0:
                            actionFlag = _actionsService.ActionOne();
                            break;
                        case 1:
                            actionFlag = _actionsService.ActionTwo();
                            break;
                        case 2:
                            actionFlag = _actionsService.ActionThree();
                            break;
                    }
                }
                catch (BusinessException exception)
                {
                    var logMessage = $"Action got this custom Exception: {exception.Message}";
                    _loggerService.LogEvent(LogTypes.Warning, logMessage, config.LogPath);
                }
                catch (Exception exception)
                {
                    var logMessage = $"Action failed by a reason: {exception.Message}";
                    _loggerService.LogEvent(LogTypes.Error, logMessage, config.LogPath);
                }
            }
        }
    }
}
