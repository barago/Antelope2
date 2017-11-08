using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Antelope.Configurations
{
    /// <summary>
    /// Configuration de l'active directory.
    /// </summary>
    public class ActiveDirectoryConfig : ConfigurationSection
    {
        private const string SECTION_NAME = "activeDirectory";

        /// <summary>
        /// Configuration.
        /// </summary>
        private static readonly ActiveDirectoryConfig _currentConfig = ConfigurationManager.GetSection(SECTION_NAME) as ActiveDirectoryConfig;

        /// <summary>
        /// Obtient la configuration du context de l'application en cours.
        /// </summary>
        /// <returns>La configuration du contexte de l'application en cours ou null si elle n'est pas définit dans le fichier de configuration.</returns>
        public static ActiveDirectoryConfig CurrentConfig
        {
            get
            {
                return _currentConfig;
            }
        }

        /// <summary>
        /// Nom du domaine ou serveur.
        /// </summary>
        [ConfigurationProperty("domainName", IsRequired = true)]
        public string DomainName
        {
            get
            {
                return this["domainName"].ToString();
            }
            set
            {
                this["domainName"] = value;
            }
        }

        /// <summary>
        /// Chemin au serveur active directory.
        /// </summary>
        public string ActiveDirectoryPath => $"LDAP://{DomainName}";
    }
}
