using Module2_Task5.Models;

namespace Module2_Task5.Services.Contracts
{
    public interface IConfigService
    {
        public Config Read(string path);
    }
}
