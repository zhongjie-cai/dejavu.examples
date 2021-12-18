using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class DummyConfiguration : IConfiguration
    {
        private readonly IDictionary<string, string> m_configurationStubs = new Dictionary<string, string>();

        public string this[string key]
        {
            get => m_configurationStubs.ContainsKey(key) ? m_configurationStubs[key] : string.Empty;
            set => m_configurationStubs[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new System.NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
