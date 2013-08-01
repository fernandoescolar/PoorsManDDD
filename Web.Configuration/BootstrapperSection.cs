using System.Configuration;

namespace PoorsManDDD.Web.Configuration
{
    public class BootstrapperSection : ConfigurationSection
    {
        [ConfigurationProperty("class", IsRequired = true)]
        public string Class
        {
            get
            {
                return this["class"].ToString();
            }
            set
            {
                this["class"] = value;
            }
        }
    }
}
