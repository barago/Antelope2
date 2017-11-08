using Antelope.Domain.Models;
using Antelope.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Services.Socle.DataBaseHydratation
{
    public class DataBaseTestHydratationService
    {

        private AntelopeEntities context = new AntelopeEntities();

        public void FullDataBaseTestHydrate()
        {

            Site siteRFS = new Site()
     {
         Nom = "Refresco",
         Trigramme = "RFS",
         Arouperr = "RFS-Batiment Administratif"
     };

            Site siteDLF = new Site()
            {
                Nom = "Delifruits",
                Trigramme = "DLF",
                Arouperr = "Site DLF"
            };

            Site siteSTA = new Site()
            {
                Nom = "Saint-Alban",
                Trigramme = "STA",
                Arouperr = "Site STA"
            };

            Site siteNSG = new Site()
            {
                Nom = "Nuits-Saint-Georges",
                Trigramme = "NSG",
                Arouperr = "Site NSG"
            };

            Site siteLQN = new Site()
            {
                Nom = "Le Quesnoys",
                Trigramme = "LQN",
                Arouperr = "Site LQN"
            };

            context.Sites.Add(siteRFS);
            context.Sites.Add(siteDLF);
            context.Sites.Add(siteSTA);
            context.Sites.Add(siteNSG);
            context.Sites.Add(siteLQN);

            ServiceType ServiceType0 = new ServiceType() { Nom = "Tous les services", Rang = 0 };
            ServiceType ServiceType1 = new ServiceType() { Nom = "Production", Rang = 15 };
            ServiceType ServiceType2 = new ServiceType() { Nom = "Maintenance/TN", Rang = 12 };
            ServiceType ServiceType3 = new ServiceType() { Nom = "Qualité R/D", Rang = 16 };
            ServiceType ServiceType4 = new ServiceType() { Nom = "Sécurité/Environnement", Rang = 19 };
            ServiceType ServiceType5 = new ServiceType() { Nom = "Amélioration continue", Rang = 2 };
            ServiceType ServiceType6 = new ServiceType() { Nom = "Ressources humaines", Rang = 18 };
            ServiceType ServiceType7 = new ServiceType() { Nom = "Supply chain", Rang = 22 };
            ServiceType ServiceType8 = new ServiceType() { Nom = "Master data", Rang = 13 };
            ServiceType ServiceType9 = new ServiceType() { Nom = "Logistique", Rang = 11 };
            ServiceType ServiceType10 = new ServiceType() { Nom = "Appro/ordo", Rang = 3 };
            ServiceType ServiceType12 = new ServiceType() { Nom = "Comptabilité", Rang = 6 };
            ServiceType ServiceType13 = new ServiceType() { Nom = "Standard", Rang = 21 };
            ServiceType ServiceType14 = new ServiceType() { Nom = "Recherche et développement", Rang = 17 };
            ServiceType ServiceType15 = new ServiceType() { Nom = "Communication", Rang = 5 };
            ServiceType ServiceType16 = new ServiceType() { Nom = "Service client", Rang = 20 };
            ServiceType ServiceType17 = new ServiceType() { Nom = "Packaging", Rang = 14 };
            ServiceType ServiceType18 = new ServiceType() { Nom = "Informatique", Rang = 10 };
            ServiceType ServiceType19 = new ServiceType() { Nom = "Autre", Rang = 100 };
            ServiceType ServiceType20 = new ServiceType() { Nom = "Administratif", Rang = 1 };
            ServiceType ServiceType21 = new ServiceType() { Nom = "Commercial/Marketing", Rang = 4 };
            ServiceType ServiceType22 = new ServiceType() { Nom = "Industriel", Rang = 9 };
            ServiceType ServiceType23 = new ServiceType() { Nom = "Finances/IT", Rang = 8 };
            ServiceType ServiceType24 = new ServiceType() { Nom = "Direction Générale", Rang = 7 };

            context.ServiceTypes.Add(ServiceType0);
            context.ServiceTypes.Add(ServiceType1);
            context.ServiceTypes.Add(ServiceType2);
            context.ServiceTypes.Add(ServiceType3);
            context.ServiceTypes.Add(ServiceType4);
            context.ServiceTypes.Add(ServiceType5);
            context.ServiceTypes.Add(ServiceType6);
            context.ServiceTypes.Add(ServiceType7);
            context.ServiceTypes.Add(ServiceType8);
            context.ServiceTypes.Add(ServiceType9);
            context.ServiceTypes.Add(ServiceType10);
            context.ServiceTypes.Add(ServiceType12);
            context.ServiceTypes.Add(ServiceType13);
            context.ServiceTypes.Add(ServiceType14);
            context.ServiceTypes.Add(ServiceType15);
            context.ServiceTypes.Add(ServiceType16);
            context.ServiceTypes.Add(ServiceType17);
            context.ServiceTypes.Add(ServiceType18);
            context.ServiceTypes.Add(ServiceType19);
            context.ServiceTypes.Add(ServiceType20);
            context.ServiceTypes.Add(ServiceType21);
            context.ServiceTypes.Add(ServiceType22);
            context.ServiceTypes.Add(ServiceType23);
            context.ServiceTypes.Add(ServiceType24);


            //------------------AJOUT DES SERVICES POUR CHAQUE SITE----------------------------

            // -------------------------RFS---------------------------------------------

            Service ServiceRFS1 = new Service() { Site = siteRFS, ServiceType = ServiceType0 };
            Service ServiceRFS2 = new Service() { Site = siteRFS, ServiceType = ServiceType7 };
            Service ServiceRFS3 = new Service() { Site = siteRFS, ServiceType = ServiceType21 };
            Service ServiceRFS4 = new Service() { Site = siteRFS, ServiceType = ServiceType22 };
            Service ServiceRFS5 = new Service() { Site = siteRFS, ServiceType = ServiceType6 };
            Service ServiceRFS6 = new Service() { Site = siteRFS, ServiceType = ServiceType23 };
            Service ServiceRFS8 = new Service() { Site = siteRFS, ServiceType = ServiceType3 };
            Service ServiceRFS9 = new Service() { Site = siteRFS, ServiceType = ServiceType24 };
            Service ServiceRFS14 = new Service() { Site = siteRFS, ServiceType = ServiceType19 };

            context.Services.Add(ServiceRFS1);
            context.Services.Add(ServiceRFS2);
            context.Services.Add(ServiceRFS3);
            context.Services.Add(ServiceRFS4);
            context.Services.Add(ServiceRFS5);
            context.Services.Add(ServiceRFS6);
            context.Services.Add(ServiceRFS8);
            context.Services.Add(ServiceRFS9);
            context.Services.Add(ServiceRFS14);

            // -------------------------DLF---------------------------------------------

            Service ServiceDLF8 = new Service() { Site = siteDLF, ServiceType = ServiceType0 };
            Service ServiceDLF1 = new Service() { Site = siteDLF, ServiceType = ServiceType1 };
            Service ServiceDLF2 = new Service() { Site = siteDLF, ServiceType = ServiceType2 };
            Service ServiceDLF3 = new Service() { Site = siteDLF, ServiceType = ServiceType3 };
            Service ServiceDLF4 = new Service() { Site = siteDLF, ServiceType = ServiceType4 };
            Service ServiceDLF5 = new Service() { Site = siteDLF, ServiceType = ServiceType5 };
            Service ServiceDLF6 = new Service() { Site = siteDLF, ServiceType = ServiceType6 };
            Service ServiceDLF7 = new Service() { Site = siteDLF, ServiceType = ServiceType7 };
            Service ServiceDLF9 = new Service() { Site = siteDLF, ServiceType = ServiceType19 };

            context.Services.Add(ServiceDLF1);
            context.Services.Add(ServiceDLF2);
            context.Services.Add(ServiceDLF3);
            context.Services.Add(ServiceDLF4);
            context.Services.Add(ServiceDLF5);
            context.Services.Add(ServiceDLF6);
            context.Services.Add(ServiceDLF7);
            context.Services.Add(ServiceDLF8);
            context.Services.Add(ServiceDLF9);


            // -------------------------STA---------------------------------------------

            Service ServiceSTA0 = new Service() { Site = siteSTA, ServiceType = ServiceType0 };
            Service ServiceSTA1 = new Service() { Site = siteSTA, ServiceType = ServiceType1 };
            Service ServiceSTA2 = new Service() { Site = siteSTA, ServiceType = ServiceType2 };
            Service ServiceSTA3 = new Service() { Site = siteSTA, ServiceType = ServiceType3 };
            Service ServiceSTA4 = new Service() { Site = siteSTA, ServiceType = ServiceType4 };
            Service ServiceSTA5 = new Service() { Site = siteSTA, ServiceType = ServiceType5 };
            Service ServiceSTA6 = new Service() { Site = siteSTA, ServiceType = ServiceType6 };
            Service ServiceSTA7 = new Service() { Site = siteSTA, ServiceType = ServiceType7 };
            Service ServiceSTA8 = new Service() { Site = siteSTA, ServiceType = ServiceType19 };

            context.Services.Add(ServiceSTA1);
            context.Services.Add(ServiceSTA2);
            context.Services.Add(ServiceSTA3);
            context.Services.Add(ServiceSTA4);
            context.Services.Add(ServiceSTA5);
            context.Services.Add(ServiceSTA6);
            context.Services.Add(ServiceSTA7);

            // -------------------------NSG---------------------------------------------

            Service ServiceNSG0 = new Service() { Site = siteNSG, ServiceType = ServiceType0 };
            Service ServiceNSG1 = new Service() { Site = siteNSG, ServiceType = ServiceType1 };
            Service ServiceNSG2 = new Service() { Site = siteNSG, ServiceType = ServiceType2 };
            Service ServiceNSG3 = new Service() { Site = siteNSG, ServiceType = ServiceType3 };
            Service ServiceNSG4 = new Service() { Site = siteNSG, ServiceType = ServiceType4 };
            Service ServiceNSG6 = new Service() { Site = siteNSG, ServiceType = ServiceType6 };
            Service ServiceNSG7 = new Service() { Site = siteNSG, ServiceType = ServiceType7 };
            Service ServiceNSG19 = new Service() { Site = siteNSG, ServiceType = ServiceType19 };

            context.Services.Add(ServiceNSG0);
            context.Services.Add(ServiceNSG1);
            context.Services.Add(ServiceNSG2);
            context.Services.Add(ServiceNSG3);
            context.Services.Add(ServiceNSG4);
            context.Services.Add(ServiceNSG6);
            context.Services.Add(ServiceNSG7);
            context.Services.Add(ServiceNSG19);

            // -------------------------LQN---------------------------------------------

            Service ServiceLQN0 = new Service() { Site = siteLQN, ServiceType = ServiceType0 };
            Service ServiceLQN20 = new Service() { Site = siteLQN, ServiceType = ServiceType20 };
            Service ServiceLQN10 = new Service() { Site = siteLQN, ServiceType = ServiceType10 };
            Service ServiceLQN9 = new Service() { Site = siteLQN, ServiceType = ServiceType9 };
            Service ServiceLQN2 = new Service() { Site = siteLQN, ServiceType = ServiceType2 };
            Service ServiceLQN1 = new Service() { Site = siteLQN, ServiceType = ServiceType1 };
            Service ServiceLQN12 = new Service() { Site = siteLQN, ServiceType = ServiceType12 };
            Service ServiceLQN4 = new Service() { Site = siteLQN, ServiceType = ServiceType4 };
            Service ServiceLQN19 = new Service() { Site = siteLQN, ServiceType = ServiceType19 };

            context.Services.Add(ServiceLQN0);
            context.Services.Add(ServiceLQN20);
            context.Services.Add(ServiceLQN10);
            context.Services.Add(ServiceLQN9);
            context.Services.Add(ServiceLQN2);
            context.Services.Add(ServiceLQN1);
            context.Services.Add(ServiceLQN12);
            context.Services.Add(ServiceLQN4);
            context.Services.Add(ServiceLQN19);




            // ------------------------- ZONES ---------------------------------------------

            ZoneType ZoneType1 = new ZoneType() { Nom = "Tout le site", Rang = 1 };
            ZoneType ZoneType2 = new ZoneType() { Nom = "Soufflage", Rang = 21 };
            ZoneType ZoneType3 = new ZoneType() { Nom = "Process", Rang = 14 };
            ZoneType ZoneType4 = new ZoneType() { Nom = "Conditionnement", Rang = 3 };
            ZoneType ZoneType5 = new ZoneType() { Nom = "Dépôts", Rang = 5 };
            ZoneType ZoneType6 = new ZoneType() { Nom = "Maintenance", Rang = 11 };
            ZoneType ZoneType7 = new ZoneType() { Nom = "Qualité", Rang = 15 };
            ZoneType ZoneType8 = new ZoneType() { Nom = "Extérieur", Rang = 9 };
            ZoneType ZoneType9 = new ZoneType() { Nom = "Etage", Rang = 6 };
            ZoneType ZoneType10 = new ZoneType() { Nom = "RDC", Rang = 16 };
            ZoneType ZoneType11 = new ZoneType() { Nom = "Autre", Rang = 100 };
            ZoneType ZoneType12 = new ZoneType() { Nom = "Logistique", Rang = 10 };
            ZoneType ZoneType13 = new ZoneType() { Nom = "Siroperie / TTDE", Rang = 20 };
            ZoneType ZoneType14 = new ZoneType() { Nom = "Préparation dépotage", Rang = 13 }; 
            ZoneType ZoneType15 = new ZoneType() { Nom = "Parking", Rang = 12 };
            ZoneType ZoneType16 = new ZoneType() { Nom = "RDC BA Bureaux", Rang = 18 };
            ZoneType ZoneType17 = new ZoneType() { Nom = "RDC BA Accueil", Rang = 17 };
            ZoneType ZoneType18 = new ZoneType() { Nom = "RDC Communs", Rang = 19 };
            ZoneType ZoneType19 = new ZoneType() { Nom = "Etage BA Bureaux", Rang = 7 };
            ZoneType ZoneType20 = new ZoneType() { Nom = "Etage BA Labo R/D", Rang = 8 };
            ZoneType ZoneType21 = new ZoneType() { Nom = "Algeco", Rang = 2 };
            ZoneType ZoneType22 = new ZoneType() { Nom = "Déplacement", Rang = 4 };

            context.ZoneTypes.Add(ZoneType1);
            context.ZoneTypes.Add(ZoneType2);
            context.ZoneTypes.Add(ZoneType3);
            context.ZoneTypes.Add(ZoneType4);
            context.ZoneTypes.Add(ZoneType5);
            context.ZoneTypes.Add(ZoneType6);
            context.ZoneTypes.Add(ZoneType7);
            context.ZoneTypes.Add(ZoneType8);
            context.ZoneTypes.Add(ZoneType9);
            context.ZoneTypes.Add(ZoneType10);
            context.ZoneTypes.Add(ZoneType11);
            context.ZoneTypes.Add(ZoneType12);
            context.ZoneTypes.Add(ZoneType13);
            context.ZoneTypes.Add(ZoneType14);
            context.ZoneTypes.Add(ZoneType15);
            context.ZoneTypes.Add(ZoneType16);
            context.ZoneTypes.Add(ZoneType17);
            context.ZoneTypes.Add(ZoneType18);
            context.ZoneTypes.Add(ZoneType19);
            context.ZoneTypes.Add(ZoneType20);
            context.ZoneTypes.Add(ZoneType21);
            context.ZoneTypes.Add(ZoneType22);



            //------------------AJOUT DES ZONES POUR CHAQUE SITE----------------------------

            // -------------------------RFS---------------------------------------------

            Zone ZoneRFS1 = new Zone() { Site = siteRFS, ZoneType = ZoneType1 };
            Zone ZoneRFS15 = new Zone() { Site = siteRFS, ZoneType = ZoneType15 };
            Zone ZoneRFS16 = new Zone() { Site = siteRFS, ZoneType = ZoneType16 };
            Zone ZoneRFS17 = new Zone() { Site = siteRFS, ZoneType = ZoneType17 };
            Zone ZoneRFS18 = new Zone() { Site = siteRFS, ZoneType = ZoneType18 };
            Zone ZoneRFS19 = new Zone() { Site = siteRFS, ZoneType = ZoneType19 };
            Zone ZoneRFS20 = new Zone() { Site = siteRFS, ZoneType = ZoneType20 };
            Zone ZoneRFS21 = new Zone() { Site = siteRFS, ZoneType = ZoneType21 };
            Zone ZoneRFS22 = new Zone() { Site = siteRFS, ZoneType = ZoneType22 };
            Zone ZoneRFS11 = new Zone() { Site = siteRFS, ZoneType = ZoneType11 };


            context.Zones.Add(ZoneRFS1);
            context.Zones.Add(ZoneRFS15);
            context.Zones.Add(ZoneRFS16);
            context.Zones.Add(ZoneRFS17);
            context.Zones.Add(ZoneRFS18);
            context.Zones.Add(ZoneRFS19);
            context.Zones.Add(ZoneRFS20);
            context.Zones.Add(ZoneRFS21);
            context.Zones.Add(ZoneRFS22);
            context.Zones.Add(ZoneRFS11);


            // -------------------------DLF---------------------------------------------


            Zone ZoneDLF1 = new Zone() { Site = siteDLF, ZoneType = ZoneType1 };
            Zone ZoneDLF2 = new Zone() { Site = siteDLF, ZoneType = ZoneType2 };
            Zone ZoneDLF3 = new Zone() { Site = siteDLF, ZoneType = ZoneType3 };
            Zone ZoneDLF4 = new Zone() { Site = siteDLF, ZoneType = ZoneType4 };
            Zone ZoneDLF5 = new Zone() { Site = siteDLF, ZoneType = ZoneType5 };
            Zone ZoneDLF6 = new Zone() { Site = siteDLF, ZoneType = ZoneType6 };
            Zone ZoneDLF7 = new Zone() { Site = siteDLF, ZoneType = ZoneType7 };
            Zone ZoneDLF8 = new Zone() { Site = siteDLF, ZoneType = ZoneType8 };
            Zone ZoneDLF11 = new Zone() { Site = siteDLF, ZoneType = ZoneType11 };

            context.Zones.Add(ZoneDLF1);
            context.Zones.Add(ZoneDLF2);
            context.Zones.Add(ZoneDLF3);
            context.Zones.Add(ZoneDLF4);
            context.Zones.Add(ZoneDLF5);
            context.Zones.Add(ZoneDLF6);
            context.Zones.Add(ZoneDLF7);
            context.Zones.Add(ZoneDLF8);
            context.Zones.Add(ZoneDLF11);

            // -------------------------STA---------------------------------------------

            Zone ZoneSTA1 = new Zone() { Site = siteSTA, ZoneType = ZoneType1 };
            Zone ZoneSTA2 = new Zone() { Site = siteSTA, ZoneType = ZoneType2 };
            Zone ZoneSTA3 = new Zone() { Site = siteSTA, ZoneType = ZoneType3 };
            Zone ZoneSTA4 = new Zone() { Site = siteSTA, ZoneType = ZoneType4 };
            Zone ZoneSTA5 = new Zone() { Site = siteSTA, ZoneType = ZoneType5 };
            Zone ZoneSTA6 = new Zone() { Site = siteSTA, ZoneType = ZoneType6 };
            Zone ZoneSTA7 = new Zone() { Site = siteSTA, ZoneType = ZoneType7 };
            Zone ZoneSTA8 = new Zone() { Site = siteSTA, ZoneType = ZoneType8 };
            Zone ZoneSTA11 = new Zone() { Site = siteSTA, ZoneType = ZoneType11 };
            Zone ZoneSTA12 = new Zone() { Site = siteSTA, ZoneType = ZoneType12 };
            Zone ZoneSTA13 = new Zone() { Site = siteSTA, ZoneType = ZoneType13 };

            context.Zones.Add(ZoneSTA1);
            context.Zones.Add(ZoneSTA2);
            context.Zones.Add(ZoneSTA3);
            context.Zones.Add(ZoneSTA4);
            context.Zones.Add(ZoneSTA5);
            context.Zones.Add(ZoneSTA6);
            context.Zones.Add(ZoneSTA7);
            context.Zones.Add(ZoneSTA8);
            context.Zones.Add(ZoneSTA11);
            context.Zones.Add(ZoneSTA12);
            context.Zones.Add(ZoneSTA13);

            // -------------------------NSG---------------------------------------------
            Zone ZoneNSG1 = new Zone() { Site = siteNSG, ZoneType = ZoneType1 };
            Zone ZoneNSG2 = new Zone() { Site = siteNSG, ZoneType = ZoneType14 };
            Zone ZoneNSG3 = new Zone() { Site = siteNSG, ZoneType = ZoneType6 };
            Zone ZoneNSG4 = new Zone() { Site = siteNSG, ZoneType = ZoneType4 };
            Zone ZoneNSG5 = new Zone() { Site = siteNSG, ZoneType = ZoneType3 };
            Zone ZoneNSG7 = new Zone() { Site = siteNSG, ZoneType = ZoneType5 };
            Zone ZoneNSG8 = new Zone() { Site = siteNSG, ZoneType = ZoneType7 };
            Zone ZoneNSG9 = new Zone() { Site = siteNSG, ZoneType = ZoneType8 };
            Zone ZoneNSG11 = new Zone() { Site = siteNSG, ZoneType = ZoneType11 };

            context.Zones.Add(ZoneNSG1);
            context.Zones.Add(ZoneNSG2);
            context.Zones.Add(ZoneNSG3);
            context.Zones.Add(ZoneNSG4);
            context.Zones.Add(ZoneNSG5);
            context.Zones.Add(ZoneNSG7);
            context.Zones.Add(ZoneNSG8);
            context.Zones.Add(ZoneNSG9);
            context.Zones.Add(ZoneNSG11);

            // -------------------------LQN---------------------------------------------
            Zone ZoneLQN1 = new Zone() { Site = siteLQN, ZoneType = ZoneType1 };
            Zone ZoneLQN4 = new Zone() { Site = siteLQN, ZoneType = ZoneType4 };
            Zone ZoneLQN5 = new Zone() { Site = siteLQN, ZoneType = ZoneType5 };
            Zone ZoneLQN8 = new Zone() { Site = siteLQN, ZoneType = ZoneType8 };
            Zone ZoneLQN12 = new Zone() { Site = siteLQN, ZoneType = ZoneType12 };
            Zone ZoneLQN6 = new Zone() { Site = siteLQN, ZoneType = ZoneType6 };
            Zone ZoneLQN3 = new Zone() { Site = siteLQN, ZoneType = ZoneType3 };
            Zone ZoneLQN7 = new Zone() { Site = siteLQN, ZoneType = ZoneType7 };
            Zone ZoneLQN14 = new Zone() { Site = siteLQN, ZoneType = ZoneType14 };
            Zone ZoneLQN11 = new Zone() { Site = siteLQN, ZoneType = ZoneType11 };

            context.Zones.Add(ZoneLQN1);
            context.Zones.Add(ZoneLQN4);
            context.Zones.Add(ZoneLQN5);
            context.Zones.Add(ZoneLQN8);
            context.Zones.Add(ZoneLQN12);
            context.Zones.Add(ZoneLQN6);
            context.Zones.Add(ZoneLQN3);
            context.Zones.Add(ZoneLQN7);
            context.Zones.Add(ZoneLQN14);
            context.Zones.Add(ZoneLQN11);

            //--------------------------------------------------------------

            //------------------------LIEUX-----------------------------

            // LIEUX DLF

            Lieu Lieu1_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF1 };
            Lieu Lieu1_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF1 };

            Lieu Lieu2_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF2 };
            Lieu Lieu2_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF2 };

            Lieu Lieu1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF5 };
            Lieu Lieu2 = new Lieu() { Nom = "DépôtB/P", Rang = 2, Zone = ZoneDLF5 };
            Lieu Lieu3 = new Lieu() { Nom = "DépôtMP", Rang = 2, Zone = ZoneDLF5 };
            Lieu Lieu13 = new Lieu() { Nom = "Dépôt PF", Rang = 2, Zone = ZoneDLF5 };
            Lieu Lieu3_1 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF5 };

            Lieu Lieu4_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF3 };
            Lieu Lieu4 = new Lieu() { Nom = "Préparation / Pré-pesée", Rang = 2, Zone = ZoneDLF3 };
            Lieu Lieu5 = new Lieu() { Nom = "Zone NEP / Dépotage", Rang = 2, Zone = ZoneDLF3 };
            Lieu Lieu6 = new Lieu() { Nom = "SB 1/2", Rang = 2, Zone = ZoneDLF3 };
            Lieu Lieu7 = new Lieu() { Nom = "R 3", Rang = 2, Zone = ZoneDLF3 };
            Lieu Lieu8 = new Lieu() { Nom = "R 4", Rang = 2, Zone = ZoneDLF3 };
            Lieu Lieu4_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF3 };

            Lieu Lieu5_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF4 };
            Lieu Lieu9 = new Lieu() { Nom = "Etiqueteuse", Rang = 2, Zone = ZoneDLF4 };
            Lieu Lieu10 = new Lieu() { Nom = "Fardeleuse", Rang = 2, Zone = ZoneDLF4 };
            Lieu Lieu11 = new Lieu() { Nom = "BdL", Rang = 2, Zone = ZoneDLF4 };
            Lieu Lieu12 = new Lieu() { Nom = "AGV", Rang = 2, Zone = ZoneDLF4 };
            Lieu Lieu5_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF4 };

            Lieu Lieu6_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF6 };
            Lieu Lieu14 = new Lieu() { Nom = "Energies", Rang = 2, Zone = ZoneDLF6 };
            Lieu Lieu15 = new Lieu() { Nom = "Travaux", Rang = 2, Zone = ZoneDLF6 };
            Lieu Lieu18 = new Lieu() { Nom = "Forage", Rang = 2, Zone = ZoneDLF6 };
            Lieu Lieu6_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF6 };

            Lieu Lieu7_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF7 };
            Lieu Lieu16 = new Lieu() { Nom = "Labo microbiologie", Rang = 2, Zone = ZoneDLF7 };
            Lieu Lieu7_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF7 };

            Lieu Lieu8_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF8 };
            Lieu Lieu17 = new Lieu() { Nom = "Zone déchets", Rang = 2, Zone = ZoneDLF8 };
            Lieu Lieu19 = new Lieu() { Nom = "Epandage", Rang = 2, Zone = ZoneDLF8 };
            Lieu Lieu8_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF8 };

            Lieu Lieu9_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneDLF11 };
            Lieu Lieu20 = new Lieu() { Nom = "Bât. Adm", Rang = 2, Zone = ZoneDLF11 };
            Lieu Lieu9_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneDLF11 };

            //LIEUX RFS
            Lieu Lieu10_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS1 };
            Lieu Lieu10_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS1 };

            Lieu Lieu10_1_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS15 };
            Lieu Lieu10_1_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS15 };

            Lieu Lieu10_2_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS16 };
            Lieu Lieu10_2_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS16 };

            Lieu Lieu10_3_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS17 };
            Lieu Lieu10_3_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS17 };

            Lieu Lieu10_4_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS18 };
            Lieu Lieu10_4_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS18 };

            Lieu Lieu10_5_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS19 };
            Lieu Lieu10_5_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS19 };

            Lieu Lieu10_6_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS20 };
            Lieu Lieu10_6_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS20 };

            Lieu Lieu10_7_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS21 };
            Lieu Lieu10_7_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS21 };

            Lieu Lieu10_8_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS22 };
            Lieu Lieu10_8_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS22 };

            Lieu Lieu11_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneRFS11 };
            Lieu Lieu11_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneRFS11 };

            //LIEUX STA
            Lieu Lieu12_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA1 };
            Lieu Lieu12_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA1 };

            Lieu Lieu13_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA11 };
            Lieu Lieu28 = new Lieu() { Nom = "Bureaux, salles de réunion et parties communes (vestiaires, salles de pause, …)", Rang = 2, Zone = ZoneSTA11 };
            Lieu Lieu13_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA11 };

            Lieu Lieu14_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA2 };
            Lieu Lieu29 = new Lieu() { Nom = "Soufflage L2, L3 et L4", Rang = 2, Zone = ZoneSTA2 };
            Lieu Lieu14_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA2 };

            Lieu Lieu15_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA3 };
            Lieu Lieu30 = new Lieu() { Nom = "Soutirage / Pasteurisation Ligne 1", Rang = 2, Zone = ZoneSTA3 };
            Lieu Lieu34 = new Lieu() { Nom = "Soutirage L2 et L4", Rang = 2, Zone = ZoneSTA3 };
            Lieu Lieu35 = new Lieu() { Nom = "Soutirage L3", Rang = 2, Zone = ZoneSTA3 };
            Lieu Lieu38 = new Lieu() { Nom = "Combi L5", Rang = 2, Zone = ZoneSTA3 };
            Lieu Lieu15_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA3 };

            Lieu Lieu16_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA4 };
            Lieu Lieu31 = new Lieu() { Nom = "Barquetteuse L1", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu32 = new Lieu() { Nom = "Banderolleuses / Palettiseur L1, L2, L3 et L4", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu33 = new Lieu() { Nom = "Dépalettiseur L1", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu36 = new Lieu() { Nom = "Etiqueteuse L2, L3, L4 et L5", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu37 = new Lieu() { Nom = "Fardeleuse (toutes lignes) (1,2,3,4,5)", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu39 = new Lieu() { Nom = "Banderolleuse / Palettiseur L5", Rang = 2, Zone = ZoneSTA4 };
            Lieu Lieu16_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA4 };

            Lieu Lieu17_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA12 };
            Lieu Lieu40 = new Lieu() { Nom = "Fonds de lignes (AGV)", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu41 = new Lieu() { Nom = "Repacking", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu56 = new Lieu() { Nom = "Dépôt 1 : Quais, stockage MP, blocage , essais, destruction", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu57 = new Lieu() { Nom = "Dépôt 2 : quais et stockage", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu58 = new Lieu() { Nom = "TK et magasin TK", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu67 = new Lieu() { Nom = "Salle de charge", Rang = 2, Zone = ZoneSTA12 };
            Lieu Lieu17_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA12 };

            Lieu Lieu18_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA7 };
            Lieu Lieu42 = new Lieu() { Nom = "Labo physico", Rang = 2, Zone = ZoneSTA7 };
            Lieu Lieu42_2 = new Lieu() { Nom = "Labo Microbiologie", Rang = 2, Zone = ZoneSTA7 };
            Lieu Lieu54 = new Lieu() { Nom = "DLUOthèque", Rang = 2, Zone = ZoneSTA7 };
            Lieu Lieu18_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA7 };

            Lieu Lieu19_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA13 };
            Lieu Lieu43 = new Lieu() { Nom = "Stockage Ingrédients (ambiant et frigorifique)", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu44 = new Lieu() { Nom = "Atelier préparation", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu45 = new Lieu() { Nom = "Dépotage citernes", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu46 = new Lieu() { Nom = "Eau Minérale, Eau de Source et Eau process (captages, forages  et traitements)", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu47 = new Lieu() { Nom = "Cuves extérieures : CO2, N2, EdS, EM", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu48 = new Lieu() { Nom = "Stations NEP et stations chimiques", Rang = 2, Zone = ZoneSTA13 };
            Lieu Lieu19_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA13 };

            Lieu Lieu20_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA8 };
            Lieu Lieu49 = new Lieu() { Nom = "Stockage PC", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu50 = new Lieu() { Nom = "Zone déchets dont local DID", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu51 = new Lieu() { Nom = "Station de neutralisation + Bassin Orage", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu52 = new Lieu() { Nom = "Chaufferie", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu60 = new Lieu() { Nom = "Eaux Pluviales", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu62 = new Lieu() { Nom = "Parking VL et PL", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu63 = new Lieu() { Nom = "Stockage palettes vides", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu64 = new Lieu() { Nom = "Cuve et station GPL", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu65 = new Lieu() { Nom = "Sprinklage TK  : cuves de stockage, local et installations", Rang = 2, Zone = ZoneSTA8 };
            Lieu Lieu20_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA8 };

            Lieu Lieu21_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA6 };
            Lieu Lieu53 = new Lieu() { Nom = "Locaux électriques (TGBT)", Rang = 2, Zone = ZoneSTA6 };
            Lieu Lieu55 = new Lieu() { Nom = "Local compresseurs", Rang = 2, Zone = ZoneSTA6 };
            Lieu Lieu59 = new Lieu() { Nom = "Gpes froids", Rang = 2, Zone = ZoneSTA6 };
            Lieu Lieu61 = new Lieu() { Nom = "TAR", Rang = 2, Zone = ZoneSTA6 };
            Lieu Lieu66 = new Lieu() { Nom = "Atelier maintenance et magasin", Rang = 2, Zone = ZoneSTA6 };
            Lieu Lieu21_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA6 };

            Lieu Lieu22_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneSTA5 };
            Lieu Lieu22_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneSTA5 };

            //----------LIEUX NSG --------------

            Lieu Lieu23_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG1 };
            Lieu Lieu23_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG1 };

            Lieu Lieu24_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG2 };
            Lieu Lieu68 = new Lieu() { Nom = "Préparation", Rang = 3, Zone = ZoneNSG2 };
            Lieu Lieu69 = new Lieu() { Nom = "Dépotage", Rang = 2, Zone = ZoneNSG2 };
            Lieu Lieu24_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG2 };

            Lieu Lieu25_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG5 };
            Lieu Lieu70 = new Lieu() { Nom = "Combi", Rang = 2, Zone = ZoneNSG5 };
            Lieu Lieu71 = new Lieu() { Nom = "Isolateur", Rang = 3, Zone = ZoneNSG5 };
            Lieu Lieu72 = new Lieu() { Nom = "Local Nep", Rang = 4, Zone = ZoneNSG5 };
            Lieu Lieu25_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG5 };

            Lieu Lieu26_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG7 };
            Lieu Lieu73 = new Lieu() { Nom = "Stockage MP", Rang = 4, Zone = ZoneNSG7 };
            Lieu Lieu74 = new Lieu() { Nom = "Dépôt 1", Rang = 2, Zone = ZoneNSG7 };
            Lieu Lieu75 = new Lieu() { Nom = "Dépôt 2", Rang = 3, Zone = ZoneNSG7 };
            Lieu Lieu26_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG7 };

            Lieu Lieu27_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG4 };
            Lieu Lieu76 = new Lieu() { Nom = "Etiquetage", Rang = 5, Zone = ZoneNSG4 };
            Lieu Lieu77 = new Lieu() { Nom = "BdL1", Rang = 2, Zone = ZoneNSG4 };
            Lieu Lieu78 = new Lieu() { Nom = "BdL2", Rang = 3, Zone = ZoneNSG4 };
            Lieu Lieu79 = new Lieu() { Nom = "BdL3", Rang = 4, Zone = ZoneNSG4 };
            Lieu Lieu27_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG4 };

            Lieu Lieu28_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG11 };
            Lieu Lieu80 = new Lieu() { Nom = "Bureaux / Vestiaires", Rang = 2, Zone = ZoneNSG11 };
            Lieu Lieu81 = new Lieu() { Nom = "Local rejets", Rang = 4, Zone = ZoneNSG11 };
            Lieu Lieu82 = new Lieu() { Nom = "Cantine", Rang = 3, Zone = ZoneNSG11 };
            Lieu Lieu28_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG11 };

            Lieu Lieu29_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG3 };
            Lieu Lieu83 = new Lieu() { Nom = "Maintenance", Rang = 3, Zone = ZoneNSG3 };
            Lieu Lieu84 = new Lieu() { Nom = "Locaux Energies", Rang = 2, Zone = ZoneNSG3 };
            Lieu Lieu29_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG3 };

            Lieu Lieu30_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG8 };
            Lieu Lieu85 = new Lieu() { Nom = "Etuvage", Rang = 2, Zone = ZoneNSG8 };
            Lieu Lieu86 = new Lieu() { Nom = "Laboratoire", Rang = 3, Zone = ZoneNSG8 };
            Lieu Lieu30_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG8 };

            Lieu Lieu31_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneNSG9 };
            Lieu Lieu87 = new Lieu() { Nom = "Extérieur", Rang = 5, Zone = ZoneNSG9 };
            Lieu Lieu88 = new Lieu() { Nom = "Zone déchets/ global", Rang = 2, Zone = ZoneNSG9 };
            Lieu Lieu89 = new Lieu() { Nom = "Parking visiteurs", Rang = 4, Zone = ZoneNSG9 };
            Lieu Lieu90 = new Lieu() { Nom = "Parking personnel", Rang = 3, Zone = ZoneNSG9 };
            Lieu Lieu31_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneNSG9 };

            //----------LIEUX LQN --------------

            Lieu Lieu32_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN1 };
            Lieu Lieu32_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN1 };

            Lieu Lieu33_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN4 };
            Lieu Lieu91 = new Lieu() { Nom = "Filmeuse / Barquetteuse L2, L3, L4, L5, L6", Rang = 5, Zone = ZoneLQN4 };
            Lieu Lieu92 = new Lieu() { Nom = "Palettiseur L2, L3, L4, L5, L6", Rang = 7, Zone = ZoneLQN4 };
            Lieu Lieu93 = new Lieu() { Nom = "Etiqueteuse pal L2/L3, L5", Rang = 4, Zone = ZoneLQN4 };
            Lieu Lieu94 = new Lieu() { Nom = "Housseuse/ Banderoleuse L2/L3, L4, L5, L6", Rang = 6, Zone = ZoneLQN4 };
            Lieu Lieu95 = new Lieu() { Nom = "Banderoleuse", Rang = 3, Zone = ZoneLQN4 };
            Lieu Lieu96 = new Lieu() { Nom = "Accumulateur Fifo L5, L6", Rang = 2, Zone = ZoneLQN4 };
            Lieu Lieu97 = new Lieu() { Nom = "Stockage/réparation palettes", Rang = 8, Zone = ZoneLQN4 };
            Lieu Lieu33_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN4 };

            Lieu Lieu34_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN5 };
            Lieu Lieu98 = new Lieu() { Nom = "Koné", Rang = 6, Zone = ZoneLQN5 };
            Lieu Lieu99 = new Lieu() { Nom = "Batiment eau", Rang = 2, Zone = ZoneLQN5 };
            Lieu Lieu100 = new Lieu() { Nom = "Chapiteau", Rang = 4, Zone = ZoneLQN5 };
            Lieu Lieu101 = new Lieu() { Nom = "Entrepôt sud", Rang = 5, Zone = ZoneLQN5 };
            Lieu Lieu102 = new Lieu() { Nom = "Bâtiment SAMOS", Rang = 3, Zone = ZoneLQN5 };
            Lieu Lieu34_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN5 };

            Lieu Lieu35_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN8 };
            Lieu Lieu103 = new Lieu() { Nom = "Magasin huile /H2O2/", Rang = 4, Zone = ZoneLQN8 };
            Lieu Lieu104 = new Lieu() { Nom = "Zone déchets", Rang = 12, Zone = ZoneLQN8 };
            Lieu Lieu105 = new Lieu() { Nom = "Point bas", Rang = 6, Zone = ZoneLQN8 };
            Lieu Lieu106 = new Lieu() { Nom = "Point haut", Rang = 7, Zone = ZoneLQN8 };
            Lieu Lieu107 = new Lieu() { Nom = "Station d'épuration", Rang = 8, Zone = ZoneLQN8 };
            Lieu Lieu108 = new Lieu() { Nom = "Stockage des boues", Rang = 9, Zone = ZoneLQN8 };
            Lieu Lieu109 = new Lieu() { Nom = "Eaux pluviales", Rang = 3, Zone = ZoneLQN8 };
            Lieu Lieu110 = new Lieu() { Nom = "Parking VL PL", Rang = 5, Zone = ZoneLQN8 };
            Lieu Lieu111 = new Lieu() { Nom = "Stockage des palettes vides", Rang = 11, Zone = ZoneLQN8 };
            Lieu Lieu112 = new Lieu() { Nom = "Cuve acide chlorhydrique", Rang = 2, Zone = ZoneLQN8 };
            Lieu Lieu113 = new Lieu() { Nom = "Stockage des bouteilles de gaz", Rang = 10, Zone = ZoneLQN8 };
            Lieu Lieu35_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN8 };

            Lieu Lieu36_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN12 };
            Lieu Lieu114 = new Lieu() { Nom = "Zone de charge", Rang = 2, Zone = ZoneLQN12 };
            Lieu Lieu36_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN12 };

            Lieu Lieu37_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN6 };
            Lieu Lieu115 = new Lieu() { Nom = "Locaux électriques (TGBT)", Rang = 8, Zone = ZoneLQN6 };
            Lieu Lieu116 = new Lieu() { Nom = "Groupes froids", Rang = 6, Zone = ZoneLQN6 };
            Lieu Lieu117 = new Lieu() { Nom = "Atelier maintenance et magasin", Rang = 2, Zone = ZoneLQN6 };
            Lieu Lieu118 = new Lieu() { Nom = "Local compresseurs", Rang = 7, Zone = ZoneLQN6 };
            Lieu Lieu119 = new Lieu() { Nom = "Chaufferie", Rang = 4, Zone = ZoneLQN6 };
            Lieu Lieu120 = new Lieu() { Nom = "Forages", Rang = 5, Zone = ZoneLQN6 };
            Lieu Lieu121 = new Lieu() { Nom = "Bâtiment entrepôt équipements démontés", Rang = 3, Zone = ZoneLQN6 };
            Lieu Lieu37_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN6 };

            Lieu Lieu38_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN3 };
            Lieu Lieu122 = new Lieu() { Nom = "pastos L2, L3, L4, L5, L6", Rang = 4, Zone = ZoneLQN3 };
            Lieu Lieu123 = new Lieu() { Nom = "Conditionneuse L2, L3, L4, L5, L6", Rang = 3, Zone = ZoneLQN3 };
            Lieu Lieu124 = new Lieu() { Nom = "Bouchonneuse L2, L3, L4, L5, L6", Rang = 2, Zone = ZoneLQN3 };
            Lieu Lieu38_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN3 };

            Lieu Lieu39_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN7 };
            Lieu Lieu125 = new Lieu() { Nom = "Labo physico", Rang = 5, Zone = ZoneLQN7 };
            Lieu Lieu126 = new Lieu() { Nom = "Labo Microbio", Rang = 4, Zone = ZoneLQN7 };
            Lieu Lieu127 = new Lieu() { Nom = "Laverie", Rang = 6, Zone = ZoneLQN7 };
            Lieu Lieu128 = new Lieu() { Nom = "Etuve (échantillons, palettes)", Rang = 3, Zone = ZoneLQN7 };
            Lieu Lieu129 = new Lieu() { Nom = "DLUOthèque", Rang = 2, Zone = ZoneLQN7 };
            Lieu Lieu39_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN7 };

            Lieu Lieu40_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN14 };
            Lieu Lieu130 = new Lieu() { Nom = "Stockage ingrédients (ambiant et frigorifique)", Rang = 6, Zone = ZoneLQN14 };
            Lieu Lieu131 = new Lieu() { Nom = "Atelier de préparation", Rang = 2, Zone = ZoneLQN14 };
            Lieu Lieu132 = new Lieu() { Nom = "Dépotage citernes", Rang = 4, Zone = ZoneLQN14 };
            Lieu Lieu133 = new Lieu() { Nom = "Salle NEP", Rang = 5, Zone = ZoneLQN14 };
            Lieu Lieu134 = new Lieu() { Nom = "Tanks (intérieur, extérieur)", Rang = 7, Zone = ZoneLQN14 };
            Lieu Lieu135 = new Lieu() { Nom = "Dépotage / Stockage soude, acide", Rang = 3, Zone = ZoneLQN14 };
            Lieu Lieu40_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN14 };

            Lieu Lieu41_1 = new Lieu() { Nom = "Toute la zone", Rang = 1, Zone = ZoneLQN11 };
            Lieu Lieu136 = new Lieu() { Nom = "Bureaux, salles de réunion, parties communes (vestiaires, salles de pause…)", Rang = 2, Zone = ZoneLQN11 };
            Lieu Lieu41_2 = new Lieu() { Nom = "Autre", Rang = 100, Zone = ZoneLQN11 };

             context.Lieux.Add(Lieu1_1);
             context.Lieux.Add(Lieu1_2);

             context.Lieux.Add(Lieu2_1);
             context.Lieux.Add(Lieu2_2);

             context.Lieux.Add(Lieu1);
             context.Lieux.Add(Lieu2);
             context.Lieux.Add(Lieu3);
             context.Lieux.Add(Lieu13);
             context.Lieux.Add(Lieu3_1);

             context.Lieux.Add(Lieu4_1); 
             context.Lieux.Add(Lieu4);
             context.Lieux.Add(Lieu5);
             context.Lieux.Add(Lieu6);
             context.Lieux.Add(Lieu7); 
             context.Lieux.Add(Lieu8 );
             context.Lieux.Add(Lieu4_2); 

             context.Lieux.Add(Lieu5_1); 
             context.Lieux.Add(Lieu9); 
             context.Lieux.Add(Lieu10);
             context.Lieux.Add(Lieu11);
             context.Lieux.Add(Lieu12); 
             context.Lieux.Add(Lieu5_2);

             context.Lieux.Add(Lieu6_1);
             context.Lieux.Add(Lieu14);
             context.Lieux.Add(Lieu15);
             context.Lieux.Add(Lieu18);
             context.Lieux.Add(Lieu6_2);

             context.Lieux.Add(Lieu7_1); 
             context.Lieux.Add(Lieu16);
             context.Lieux.Add(Lieu7_2);

             context.Lieux.Add(Lieu8_1);
             context.Lieux.Add(Lieu19); 
             context.Lieux.Add(Lieu8_2); 

             context.Lieux.Add(Lieu9_1);
             context.Lieux.Add(Lieu20);
             context.Lieux.Add(Lieu9_2);

            //context.Lieux.Add(LieuX RFS
             //context.Lieux.Add(Lieu10_1);
             //context.Lieux.Add(Lieu21);
             //context.Lieux.Add(Lieu22);
             //context.Lieux.Add(Lieu10_2); 

             //context.Lieux.Add(Lieu11_1); 
             //context.Lieux.Add(Lieu23);
             //context.Lieux.Add(Lieu24); 
             //context.Lieux.Add(Lieu25);
             //context.Lieux.Add(Lieu26 );
             //context.Lieux.Add(Lieu11_2); 

            //context.Lieux.Add(LieuX STA
             context.Lieux.Add(Lieu12_1);
             context.Lieux.Add(Lieu12_2);

             context.Lieux.Add(Lieu13_1); 
             context.Lieux.Add(Lieu28);
             context.Lieux.Add(Lieu13_2);

             context.Lieux.Add(Lieu14_1); 
             context.Lieux.Add(Lieu29 );
             context.Lieux.Add(Lieu14_2);

             context.Lieux.Add(Lieu15_1); 
             context.Lieux.Add(Lieu30 );
             context.Lieux.Add(Lieu34 );
             context.Lieux.Add(Lieu35 );
             context.Lieux.Add(Lieu38 );
             context.Lieux.Add(Lieu15_2 );

             context.Lieux.Add(Lieu16_1 );
             context.Lieux.Add(Lieu31 );
             context.Lieux.Add(Lieu32);
             context.Lieux.Add(Lieu33 );
             context.Lieux.Add(Lieu36 );
             context.Lieux.Add(Lieu37 );
             context.Lieux.Add(Lieu39);
             context.Lieux.Add(Lieu16_2); 

             context.Lieux.Add(Lieu17_1 );
             context.Lieux.Add(Lieu40);
             context.Lieux.Add(Lieu41 );
             context.Lieux.Add(Lieu56 );
             context.Lieux.Add(Lieu57 );
             context.Lieux.Add(Lieu58 );
             context.Lieux.Add(Lieu67 );
             context.Lieux.Add(Lieu17_2 );

             context.Lieux.Add(Lieu18_1 );
             context.Lieux.Add(Lieu42 );
             context.Lieux.Add(Lieu42_2 );
             context.Lieux.Add(Lieu54);
             context.Lieux.Add(Lieu18_2); 

             context.Lieux.Add(Lieu19_1 );
             context.Lieux.Add(Lieu43);
             context.Lieux.Add(Lieu44 );
             context.Lieux.Add(Lieu45 );
             context.Lieux.Add(Lieu46 );
             context.Lieux.Add(Lieu47 );
             context.Lieux.Add(Lieu48 );
             context.Lieux.Add(Lieu19_2 );

             context.Lieux.Add(Lieu20_1 );
             context.Lieux.Add(Lieu49 );
             context.Lieux.Add(Lieu50 );
             context.Lieux.Add(Lieu51 );
             context.Lieux.Add(Lieu52 );
             context.Lieux.Add(Lieu60 );
             context.Lieux.Add(Lieu62 );
             context.Lieux.Add(Lieu63 );
             context.Lieux.Add(Lieu64);
             context.Lieux.Add(Lieu65 );
             context.Lieux.Add(Lieu20_2);

             context.Lieux.Add(Lieu21_1);
             context.Lieux.Add(Lieu53 );
             context.Lieux.Add(Lieu55);
             context.Lieux.Add(Lieu59);
             context.Lieux.Add(Lieu61 );
             context.Lieux.Add(Lieu66 );
             context.Lieux.Add(Lieu21_2);

             context.Lieux.Add(Lieu22_1);
             context.Lieux.Add(Lieu22_2);


             context.Lieux.Add(Lieu23_1);
             context.Lieux.Add(Lieu23_2);

             context.Lieux.Add(Lieu24_1);
             context.Lieux.Add(Lieu68);
             context.Lieux.Add(Lieu69);
             context.Lieux.Add(Lieu24_2);

             context.Lieux.Add(Lieu25_1);
             context.Lieux.Add(Lieu70);
             context.Lieux.Add(Lieu71);
             context.Lieux.Add(Lieu72);
             context.Lieux.Add(Lieu25_2);

             context.Lieux.Add(Lieu26_1);
             context.Lieux.Add(Lieu73);
             context.Lieux.Add(Lieu74);
             context.Lieux.Add(Lieu75);
             context.Lieux.Add(Lieu26_2);

             context.Lieux.Add(Lieu27_1);
             context.Lieux.Add(Lieu76);
             context.Lieux.Add(Lieu77);
             context.Lieux.Add(Lieu78);
             context.Lieux.Add(Lieu79);
             context.Lieux.Add(Lieu27_2);

             context.Lieux.Add(Lieu28_1);
             context.Lieux.Add(Lieu80);
             context.Lieux.Add(Lieu81);
             context.Lieux.Add(Lieu82);
             context.Lieux.Add(Lieu28_2);

             context.Lieux.Add(Lieu29_1);
             context.Lieux.Add(Lieu83);
             context.Lieux.Add(Lieu84);
             context.Lieux.Add(Lieu29_2);

             context.Lieux.Add(Lieu30_1);
             context.Lieux.Add(Lieu85);
             context.Lieux.Add(Lieu86);
             context.Lieux.Add(Lieu30_2);

             context.Lieux.Add(Lieu31_1);
             context.Lieux.Add(Lieu87);
             context.Lieux.Add(Lieu88);
             context.Lieux.Add(Lieu89);
             context.Lieux.Add(Lieu90);
             context.Lieux.Add(Lieu31_2);


            //LQN

             context.Lieux.Add(Lieu32_1);
             context.Lieux.Add(Lieu32_2);

             context.Lieux.Add(Lieu33_1);
             context.Lieux.Add(Lieu91);
             context.Lieux.Add(Lieu92);
             context.Lieux.Add(Lieu93);
             context.Lieux.Add(Lieu94);
             context.Lieux.Add(Lieu95);
             context.Lieux.Add(Lieu96);
             context.Lieux.Add(Lieu97);
             context.Lieux.Add(Lieu33_2);

             context.Lieux.Add(Lieu34_1);
             context.Lieux.Add(Lieu98);
             context.Lieux.Add(Lieu99);
             context.Lieux.Add(Lieu100);
             context.Lieux.Add(Lieu101);
             context.Lieux.Add(Lieu102);
             context.Lieux.Add(Lieu34_2);

             context.Lieux.Add(Lieu35_1);
             context.Lieux.Add(Lieu103);
             context.Lieux.Add(Lieu104);
             context.Lieux.Add(Lieu105);
             context.Lieux.Add(Lieu106);
             context.Lieux.Add(Lieu107);
             context.Lieux.Add(Lieu108);
             context.Lieux.Add(Lieu109);
             context.Lieux.Add(Lieu110);
             context.Lieux.Add(Lieu111);
             context.Lieux.Add(Lieu112);
             context.Lieux.Add(Lieu113);
             context.Lieux.Add(Lieu35_2);

             context.Lieux.Add(Lieu36_1);
             context.Lieux.Add(Lieu114);
             context.Lieux.Add(Lieu36_2);

             context.Lieux.Add(Lieu37_1);
             context.Lieux.Add(Lieu115);
             context.Lieux.Add(Lieu116);
             context.Lieux.Add(Lieu117);
             context.Lieux.Add(Lieu118);
             context.Lieux.Add(Lieu119);
             context.Lieux.Add(Lieu120);
             context.Lieux.Add(Lieu121);
             context.Lieux.Add(Lieu37_2);

             context.Lieux.Add(Lieu38_1);
             context.Lieux.Add(Lieu122);
             context.Lieux.Add(Lieu123);
             context.Lieux.Add(Lieu124);
             context.Lieux.Add(Lieu38_2);

             context.Lieux.Add(Lieu39_1);
             context.Lieux.Add(Lieu125);
             context.Lieux.Add(Lieu126);
             context.Lieux.Add(Lieu127);
             context.Lieux.Add(Lieu128);
             context.Lieux.Add(Lieu129);
             context.Lieux.Add(Lieu39_2);

             context.Lieux.Add(Lieu40_1);
             context.Lieux.Add(Lieu130);
             context.Lieux.Add(Lieu131);
             context.Lieux.Add(Lieu132);
             context.Lieux.Add(Lieu133);
             context.Lieux.Add(Lieu134);
             context.Lieux.Add(Lieu135);
             context.Lieux.Add(Lieu40_2);

             context.Lieux.Add(Lieu41_1);
             context.Lieux.Add(Lieu136);
             context.Lieux.Add(Lieu41_2);

             context.Lieux.Add(Lieu10_1);
             context.Lieux.Add(Lieu10_2);

             context.Lieux.Add(Lieu10_1_1);
             context.Lieux.Add(Lieu10_1_2);

             context.Lieux.Add(Lieu10_2_1);
             context.Lieux.Add(Lieu10_2_2);

             context.Lieux.Add(Lieu10_3_1);
             context.Lieux.Add(Lieu10_3_2);

             context.Lieux.Add(Lieu10_4_1);
             context.Lieux.Add(Lieu10_4_2);

             context.Lieux.Add(Lieu10_5_1);
             context.Lieux.Add(Lieu10_5_2);

             context.Lieux.Add(Lieu10_6_1);
             context.Lieux.Add(Lieu10_6_2);

             context.Lieux.Add(Lieu10_7_1);
             context.Lieux.Add(Lieu10_7_2);

             context.Lieux.Add(Lieu10_8_1);
             context.Lieux.Add(Lieu10_8_2);

             context.Lieux.Add(Lieu11_1);
             context.Lieux.Add(Lieu11_2);


            //------------------------POSTE DE TRAVAIL -----------------------------

            //POSTES DE TRAVAIL DE DLF
            PosteDeTravail PosteDeTravail1_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF1 };
            PosteDeTravail PosteDeTravail1_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF1 };

            PosteDeTravail PosteDeTravail2_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF2 };
            PosteDeTravail PosteDeTravail2_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF2 };

            PosteDeTravail PosteDeTravail3_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail1 = new PosteDeTravail() { Nom = "Pilote process", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail2 = new PosteDeTravail() { Nom = "Opérateur salle blanche", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail3 = new PosteDeTravail() { Nom = "Souffleur", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail4 = new PosteDeTravail() { Nom = "Polyvalent process", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail5 = new PosteDeTravail() { Nom = "Polyvalent conditionnement", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail6 = new PosteDeTravail() { Nom = "Pilote R3", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail7 = new PosteDeTravail() { Nom = "Pilote R4", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail8 = new PosteDeTravail() { Nom = "Régleur", Rang = 2, Zone = ZoneDLF3 };
            PosteDeTravail PosteDeTravail3_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF3 };

            PosteDeTravail PosteDeTravail4_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail9 = new PosteDeTravail() { Nom = "Etiqueteur 1, 2, 3", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail10 = new PosteDeTravail() { Nom = "Etiqueteur 4", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail11 = new PosteDeTravail() { Nom = "Fardeleur 1, 2, 3", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail12 = new PosteDeTravail() { Nom = "Fardeleur 4", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail13 = new PosteDeTravail() { Nom = "Etiqueteur 5", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail14 = new PosteDeTravail() { Nom = "Pilote combi", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail15 = new PosteDeTravail() { Nom = "Bout de ligne", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail16 = new PosteDeTravail() { Nom = "Polyvalent conditionnement", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail17 = new PosteDeTravail() { Nom = "Responsable d'équipe", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail18 = new PosteDeTravail() { Nom = "Responsable production", Rang = 2, Zone = ZoneDLF4 };
            PosteDeTravail PosteDeTravail4_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF4 };

            PosteDeTravail PosteDeTravail5_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF6 };
            PosteDeTravail PosteDeTravail19 = new PosteDeTravail() { Nom = "Electroposté", Rang = 2, Zone = ZoneDLF6 };
            PosteDeTravail PosteDeTravail20 = new PosteDeTravail() { Nom = "Technicien de maintenance", Rang = 2, Zone = ZoneDLF6 };
            PosteDeTravail PosteDeTravail21 = new PosteDeTravail() { Nom = "Maitrise maintenance", Rang = 2, Zone = ZoneDLF6 };
            PosteDeTravail PosteDeTravail22 = new PosteDeTravail() { Nom = "Responsable maintenance/TN", Rang = 2, Zone = ZoneDLF6 };
            PosteDeTravail PosteDeTravail5_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF6 };

            PosteDeTravail PosteDeTravail6_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail23 = new PosteDeTravail() { Nom = "Laborantin process", Rang = 2, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail24 = new PosteDeTravail() { Nom = "Laborantin microbio", Rang = 2, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail25 = new PosteDeTravail() { Nom = "Responsable labo microbio", Rang = 2, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail26 = new PosteDeTravail() { Nom = "Responsable qualité", Rang = 2, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail27 = new PosteDeTravail() { Nom = "Assistant qualité", Rang = 2, Zone = ZoneDLF7 };
            PosteDeTravail PosteDeTravail6_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF7 };

            PosteDeTravail PosteDeTravail7_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail55 = new PosteDeTravail() { Nom = "Pilote prépa", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail28 = new PosteDeTravail() { Nom = "Préparateur", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail29 = new PosteDeTravail() { Nom = "Aide préparateur", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail30 = new PosteDeTravail() { Nom = "Opérateur crusher", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail31 = new PosteDeTravail() { Nom = "Responsable préparation", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail7_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF5 };

            PosteDeTravail PosteDeTravail8_1 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail32 = new PosteDeTravail() { Nom = "Technicien services généraux", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail33 = new PosteDeTravail() { Nom = "Directeur Site", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail34 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail35 = new PosteDeTravail() { Nom = "Responsable zone process", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail36 = new PosteDeTravail() { Nom = "Responsable zone conditionnement", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail37 = new PosteDeTravail() { Nom = "Animateur S/E", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail38 = new PosteDeTravail() { Nom = "Agriculteur", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail39 = new PosteDeTravail() { Nom = "Chauffeur", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail40 = new PosteDeTravail() { Nom = "CHSCT", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail41 = new PosteDeTravail() { Nom = "Responsable RH", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail42 = new PosteDeTravail() { Nom = "Responsable amélioration continue", Rang = 2, Zone = ZoneDLF11 };
            PosteDeTravail PosteDeTravail8_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneDLF11 };


            PosteDeTravail PosteDeTravail43 = new PosteDeTravail() { Nom = "Cariste de ligne", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail44 = new PosteDeTravail() { Nom = "Cariste expédition", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail45 = new PosteDeTravail() { Nom = "Magasinier MP", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail46 = new PosteDeTravail() { Nom = "Magasinier soufflage", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail47 = new PosteDeTravail() { Nom = "Magasinier soufflerie", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail48 = new PosteDeTravail() { Nom = "Chef d'équipe cariste", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail49 = new PosteDeTravail() { Nom = "Responsable d'exploitation PF", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail50 = new PosteDeTravail() { Nom = "Responsable d'exploitation MP", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail51 = new PosteDeTravail() { Nom = "Gestionnaire de stock", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail52 = new PosteDeTravail() { Nom = "Hôtesse d'accueil PF", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail53 = new PosteDeTravail() { Nom = "Responsable appro/ordo", Rang = 2, Zone = ZoneDLF5 };
            PosteDeTravail PosteDeTravail54 = new PosteDeTravail() { Nom = "Responsable supply Chain", Rang = 2, Zone = ZoneDLF5 };

            // POSTES DE TRAVAIL DE STA

            PosteDeTravail PosteDeTravail56 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail57 = new PosteDeTravail() { Nom = "Agent entretien", Rang = 2, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail58 = new PosteDeTravail() { Nom = "Animateur SE", Rang = 2, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail59 = new PosteDeTravail() { Nom = "Coordinateur AC", Rang = 2, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail60 = new PosteDeTravail() { Nom = "Directeur site", Rang = 2, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail61 = new PosteDeTravail() { Nom = "Responsable production", Rang = 2, Zone = ZoneSTA1 };
            PosteDeTravail PosteDeTravail62 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA1 };

            PosteDeTravail PosteDeTravail63 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail64 = new PosteDeTravail() { Nom = "Animateur repacking", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail65 = new PosteDeTravail() { Nom = "Cariste", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail66 = new PosteDeTravail() { Nom = "Cariste ligne", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail67 = new PosteDeTravail() { Nom = "Cariste MP", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail68 = new PosteDeTravail() { Nom = "Chef d'exploitation D2", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail69 = new PosteDeTravail() { Nom = "Chef magasinier MP", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail70 = new PosteDeTravail() { Nom = "Gestionnaire de stock", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail71 = new PosteDeTravail() { Nom = "Opérateur repacking", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail72 = new PosteDeTravail() { Nom = "Responsable supply", Rang = 2, Zone = ZoneSTA12 };
            PosteDeTravail PosteDeTravail73 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA12 };

            PosteDeTravail PosteDeTravail74 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA7 };
            PosteDeTravail PosteDeTravail75 = new PosteDeTravail() { Nom = "Laborantin", Rang = 2, Zone = ZoneSTA7 };
            PosteDeTravail PosteDeTravail76 = new PosteDeTravail() { Nom = "Responsable Qualité / Labo", Rang = 2, Zone = ZoneSTA7 };
            PosteDeTravail PosteDeTravail76_2 = new PosteDeTravail() { Nom = "Assistant qualité", Rang = 2, Zone = ZoneSTA7 };
            PosteDeTravail PosteDeTravail77 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA7 };

            PosteDeTravail PosteDeTravail78 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail79 = new PosteDeTravail() { Nom = "Chef d'équipe", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail80 = new PosteDeTravail() { Nom = "Opérateur Combi L5", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail81 = new PosteDeTravail() { Nom = "Opérateur Soutireuse L1", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail82 = new PosteDeTravail() { Nom = "Opérateur Soutireuse L2", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail83 = new PosteDeTravail() { Nom = "Opérateur Soutireuse L3", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail84 = new PosteDeTravail() { Nom = "Opérateur Soutireuse L4", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail85 = new PosteDeTravail() { Nom = "Responsable Process", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail86 = new PosteDeTravail() { Nom = "Opérateur Polyvalent ", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail87 = new PosteDeTravail() { Nom = "Régleur", Rang = 2, Zone = ZoneSTA3 };
            PosteDeTravail PosteDeTravail88 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA3 };

            PosteDeTravail PosteDeTravail89 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA6 };
            PosteDeTravail PosteDeTravail90 = new PosteDeTravail() { Nom = "Coordinateur Maintenance", Rang = 2, Zone = ZoneSTA6 };
            PosteDeTravail PosteDeTravail91 = new PosteDeTravail() { Nom = "Responsable maintenance", Rang = 2, Zone = ZoneSTA6 };
            PosteDeTravail PosteDeTravail92 = new PosteDeTravail() { Nom = "Technicien maintenance", Rang = 2, Zone = ZoneSTA6 };
            PosteDeTravail PosteDeTravail93 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA6 };

            PosteDeTravail PosteDeTravail94 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail95 = new PosteDeTravail() { Nom = "Opérateur Barqueteuse L1", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail96 = new PosteDeTravail() { Nom = "Opérateur Etiq L3 / Fard L4", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail97 = new PosteDeTravail() { Nom = "Opérateur Etiqueteuse L5", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail98 = new PosteDeTravail() { Nom = "Opérateur Fardeleuse L1", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail99 = new PosteDeTravail() { Nom = "Opérateur Fardeleuse L2", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail100 = new PosteDeTravail() { Nom = "Opérateur Fardeleuse L3", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail101 = new PosteDeTravail() { Nom = "Opérateur Pal L2", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail102 = new PosteDeTravail() { Nom = "Opérateur Pal L3", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail103 = new PosteDeTravail() { Nom = "Opérateur Pal L4", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail104 = new PosteDeTravail() { Nom = "Opérateur Pal L5", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail105 = new PosteDeTravail() { Nom = "Opérateur Pal/Dépal L1 ", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail106 = new PosteDeTravail() { Nom = "Opérateur Polyvalent ", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail107 = new PosteDeTravail() { Nom = "Régleur", Rang = 2, Zone = ZoneSTA4 };
            PosteDeTravail PosteDeTravail108 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA4 };

            PosteDeTravail PosteDeTravail109 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA13 };
            PosteDeTravail PosteDeTravail110 = new PosteDeTravail() { Nom = "Opérateur TTDE", Rang = 2, Zone = ZoneSTA13 };
            PosteDeTravail PosteDeTravail111 = new PosteDeTravail() { Nom = "Peseur", Rang = 2, Zone = ZoneSTA13 };
            PosteDeTravail PosteDeTravail112 = new PosteDeTravail() { Nom = "Responsable Siroperie / TTDE", Rang = 2, Zone = ZoneSTA13 };
            PosteDeTravail PosteDeTravail113 = new PosteDeTravail() { Nom = "Siropier", Rang = 2, Zone = ZoneSTA13 };
            PosteDeTravail PosteDeTravail114 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA13 };

            PosteDeTravail PosteDeTravail115 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail116 = new PosteDeTravail() { Nom = "Assistant RH", Rang = 2, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail117 = new PosteDeTravail() { Nom = "Coordinateur Appro/Planning", Rang = 2, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail118 = new PosteDeTravail() { Nom = "Personnel Administratif", Rang = 2, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail119 = new PosteDeTravail() { Nom = "Responsable RH", Rang = 2, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail120 = new PosteDeTravail() { Nom = "Superviseur Admin", Rang = 2, Zone = ZoneSTA11 };
            PosteDeTravail PosteDeTravail121 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA11 };

            PosteDeTravail PosteDeTravail122 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA5 };
            PosteDeTravail PosteDeTravail123 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA5 };

            PosteDeTravail PosteDeTravail124 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA8 };
            PosteDeTravail PosteDeTravail125 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA8 };

            PosteDeTravail PosteDeTravail126 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneSTA2 };
            PosteDeTravail PosteDeTravail127 = new PosteDeTravail() { Nom = "Opérateur souffleur", Rang = 1, Zone = ZoneSTA2 };
            PosteDeTravail PosteDeTravail128 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneSTA2 };

            // ------POSTES DE TRAVAIL NSG ----------

            PosteDeTravail PosteDeTravail129 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail130 = new PosteDeTravail() { Nom = "Responsable production", Rang = 13, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail131 = new PosteDeTravail() { Nom = "Régleur", Rang = 10, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail132 = new PosteDeTravail() { Nom = "Polyvalent ", Rang = 9, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail133 = new PosteDeTravail() { Nom = "Directeur Site", Rang = 5, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail134 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 8, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail135 = new PosteDeTravail() { Nom = "Responsable RH", Rang = 12, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail136 = new PosteDeTravail() { Nom = "Responsable Process- Ammélioration", Rang = 14, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail137 = new PosteDeTravail() { Nom = "Animateur S/E", Rang = 2, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail138 = new PosteDeTravail() { Nom = "CHSCT", Rang = 4, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail139 = new PosteDeTravail() { Nom = "Entreprise extérieure/visiteur", Rang = 6, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail140 = new PosteDeTravail() { Nom = "Responsable appro MPC", Rang = 11, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail141 = new PosteDeTravail() { Nom = "Gestionnaire appro planning", Rang = 7, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail142 = new PosteDeTravail() { Nom = "Assistant  Appro MPA", Rang = 3, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail143 = new PosteDeTravail() { Nom = "Responsable supply Chain", Rang = 15, Zone = ZoneNSG11 };
            PosteDeTravail PosteDeTravail144 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG11 };


            PosteDeTravail PosteDeTravail145 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG5 };
            PosteDeTravail PosteDeTravail146 = new PosteDeTravail() { Nom = "Pilote isolateur", Rang = 3, Zone = ZoneNSG5 };
            PosteDeTravail PosteDeTravail147 = new PosteDeTravail() { Nom = "Pilote combi", Rang = 2, Zone = ZoneNSG5 };
            PosteDeTravail PosteDeTravail148 = new PosteDeTravail() { Nom = "Souffleur /appro préformes", Rang = 4, Zone = ZoneNSG5 };
            PosteDeTravail PosteDeTravail149 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG5 };

            PosteDeTravail PosteDeTravail150 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG4 };
            PosteDeTravail PosteDeTravail151 = new PosteDeTravail() { Nom = "Etiqueteur ", Rang = 3, Zone = ZoneNSG4 };
            PosteDeTravail PosteDeTravail152 = new PosteDeTravail() { Nom = "Opérateur Bout de ligne", Rang = 2, Zone = ZoneNSG4 };
            PosteDeTravail PosteDeTravail153 = new PosteDeTravail() { Nom = "Cariste Bout de ligne", Rang = 4, Zone = ZoneNSG4 };
            PosteDeTravail PosteDeTravail154 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG4 };

            PosteDeTravail PosteDeTravail155 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG2 };
            PosteDeTravail PosteDeTravail156 = new PosteDeTravail() { Nom = "Préparateur ", Rang = 4, Zone = ZoneNSG2 };
            PosteDeTravail PosteDeTravail157 = new PosteDeTravail() { Nom = "Aide préparateur", Rang = 2, Zone = ZoneNSG2 };
            PosteDeTravail PosteDeTravail158 = new PosteDeTravail() { Nom = "Chauffeur citernes", Rang = 3, Zone = ZoneNSG2 };
            PosteDeTravail PosteDeTravail159 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG2 };

            PosteDeTravail PosteDeTravail160 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG3 };
            PosteDeTravail PosteDeTravail161 = new PosteDeTravail() { Nom = "Tech posté", Rang = 4, Zone = ZoneNSG3 };
            PosteDeTravail PosteDeTravail162 = new PosteDeTravail() { Nom = "Technicien journée", Rang = 2, Zone = ZoneNSG3 };
            PosteDeTravail PosteDeTravail163 = new PosteDeTravail() { Nom = "Maitrise maintenance", Rang = 3, Zone = ZoneNSG3 };
            PosteDeTravail PosteDeTravail164 = new PosteDeTravail() { Nom = "Responsable maintenance/TN", Rang = 3, Zone = ZoneNSG3 };
            PosteDeTravail PosteDeTravail165 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG3 };

            PosteDeTravail PosteDeTravail166 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail167 = new PosteDeTravail() { Nom = "Assistant contrôle qualité", Rang = 2, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail168 = new PosteDeTravail() { Nom = "Laborantin posté", Rang = 6, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail169 = new PosteDeTravail() { Nom = "Laborantin journée", Rang = 5, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail170 = new PosteDeTravail() { Nom = "Responsable qualité", Rang = 7, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail171 = new PosteDeTravail() { Nom = "Assistant qualité", Rang = 3, Zone = ZoneNSG8 };
            PosteDeTravail PosteDeTravail172 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG8 };

            PosteDeTravail PosteDeTravail173 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail174 = new PosteDeTravail() { Nom = "Chauffeur", Rang = 5, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail175 = new PosteDeTravail() { Nom = "Cariste navettes", Rang = 3, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail176 = new PosteDeTravail() { Nom = "Cariste polyvalent expédition", Rang = 4, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail177 = new PosteDeTravail() { Nom = "Cariste appro MP", Rang = 2, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail178 = new PosteDeTravail() { Nom = "Gestionnaire de stock", Rang = 7, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail179 = new PosteDeTravail() { Nom = "Chef d'équipe cariste", Rang = 6, Zone = ZoneNSG7 };
            PosteDeTravail PosteDeTravail180 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG7 };

            PosteDeTravail PosteDeTravail181 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG1 };
            PosteDeTravail PosteDeTravail182 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG1 };


            PosteDeTravail PosteDeTravail185 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneNSG9 };
            PosteDeTravail PosteDeTravail186 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneNSG9 };

            //LQN

            PosteDeTravail PosteDeTravail187 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN1 };
            PosteDeTravail PosteDeTravail188 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN1 };

            PosteDeTravail PosteDeTravail189 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail190 = new PosteDeTravail() { Nom = "Responsable adm. et du personnel", Rang = 6, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail191 = new PosteDeTravail() { Nom = "Adjointe responsable du personnel", Rang = 2, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail192 = new PosteDeTravail() { Nom = "Assistante comptable et RH", Rang = 3, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail193 = new PosteDeTravail() { Nom = "Directeur général", Rang = 5, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail194 = new PosteDeTravail() { Nom = "coordinateur flux", Rang = 4, Zone = ZoneLQN11 };
            PosteDeTravail PosteDeTravail196 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN11 };

            PosteDeTravail PosteDeTravail197 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail198 = new PosteDeTravail() { Nom = "Magasinier approvisionnement", Rang = 7, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail199 = new PosteDeTravail() { Nom = "Responsable plannif et ordonnancement", Rang = 10, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail200 = new PosteDeTravail() { Nom = "Assistante plannification et production", Rang = 5, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail201 = new PosteDeTravail() { Nom = "Assistante appro comptable matière", Rang = 3, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail202 = new PosteDeTravail() { Nom = "Assistante planification", Rang = 4, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail203 = new PosteDeTravail() { Nom = "Magasinier préparateur", Rang = 8, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail204 = new PosteDeTravail() { Nom = "Responsable logistique interne", Rang = 9, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail205 = new PosteDeTravail() { Nom = "Cariste préparateur", Rang = 6, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail206 = new PosteDeTravail() { Nom = "Assistante administrative logistique", Rang = 2, Zone = ZoneLQN12 };
            PosteDeTravail PosteDeTravail207 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN12 };

            PosteDeTravail PosteDeTravail208 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail209 = new PosteDeTravail() { Nom = "Responsable labo contrôle qualité", Rang = 6, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail210 = new PosteDeTravail() { Nom = "Agent d'entretien", Rang = 2, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail211 = new PosteDeTravail() { Nom = "Laborentine échantillons", Rang = 4, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail212 = new PosteDeTravail() { Nom = "Laborentine polyvalente qualité", Rang = 5, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail213 = new PosteDeTravail() { Nom = "Contrôleur qualité", Rang = 3, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail214 = new PosteDeTravail() { Nom = "Responsable qualité", Rang = 7, Zone = ZoneLQN7 };
            PosteDeTravail PosteDeTravail215 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN7 };

            PosteDeTravail PosteDeTravail216 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail217 = new PosteDeTravail() { Nom = "Coordinateur maintenance production", Rang = 6, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail218 = new PosteDeTravail() { Nom = "Responsable maintenance travaux neufs", Rang = 8, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail219 = new PosteDeTravail() { Nom = "Technicien de maintenance en apprentissage", Rang = 9, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail220 = new PosteDeTravail() { Nom = "Technicien de maintenance SG", Rang = 11, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail221 = new PosteDeTravail() { Nom = "Technicien de maintenance production", Rang = 10, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail222 = new PosteDeTravail() { Nom = "Coordinateur expert maintenance central", Rang = 3, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail223 = new PosteDeTravail() { Nom = "Agent SG usine", Rang = 4, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail224 = new PosteDeTravail() { Nom = "Coordinateur maintenance elec automate", Rang = 5, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail225 = new PosteDeTravail() { Nom = "Reponsable magasin pièces détachées", Rang = 7, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail226 = new PosteDeTravail() { Nom = "Agent maintenance SG", Rang = 2, Zone = ZoneLQN6 };
            PosteDeTravail PosteDeTravail227 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN6 };

            PosteDeTravail PosteDeTravail228 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail229 = new PosteDeTravail() { Nom = "Préparateur", Rang = 6, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail230 = new PosteDeTravail() { Nom = "Coordinateur préparation", Rang = 8, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail231 = new PosteDeTravail() { Nom = "Pilote suremballage", Rang = 9, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail232 = new PosteDeTravail() { Nom = "Pilote conditionneuse aseptique", Rang = 11, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail233 = new PosteDeTravail() { Nom = "Responsable d'équipe", Rang = 10, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail234 = new PosteDeTravail() { Nom = "Cariste polyvalent production", Rang = 3, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail235 = new PosteDeTravail() { Nom = "Expert technique", Rang = 4, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail236 = new PosteDeTravail() { Nom = "Responsable production et planning ordo", Rang = 5, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail237 = new PosteDeTravail() { Nom = "Assistante production", Rang = 7, Zone = ZoneLQN3 };
            PosteDeTravail PosteDeTravail238 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN3 };

            PosteDeTravail PosteDeTravail239 = new PosteDeTravail() { Nom = "Assistant HSE", Rang = 2, Zone = ZoneLQN11 };

            PosteDeTravail PosteDeTravail239_2 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN4 };
            PosteDeTravail PosteDeTravail240_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN4 };

            PosteDeTravail PosteDeTravail241_2 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN5 };
            PosteDeTravail PosteDeTravail242_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN5 };

            PosteDeTravail PosteDeTravail243_2 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN8 };
            PosteDeTravail PosteDeTravail244_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN8 };

            PosteDeTravail PosteDeTravail245_2 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneLQN14 };
            PosteDeTravail PosteDeTravail246_2 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneLQN14 };

            // RFS

            PosteDeTravail PosteDeTravail240 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail241 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail242 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail243 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail244 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail245 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS1 };
            PosteDeTravail PosteDeTravail247 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS1 };

            PosteDeTravail PosteDeTravail248 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail249 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail250 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail251 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail252 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail253 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS15 };
            PosteDeTravail PosteDeTravail254 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS15 };

            PosteDeTravail PosteDeTravail255 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail256 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail257 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail258 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail259 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail260 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS16 };
            PosteDeTravail PosteDeTravail261 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS16 };

            PosteDeTravail PosteDeTravail262 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail263 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail264 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail265 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail266 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail267 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS17 };
            PosteDeTravail PosteDeTravail268 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS17 };

            PosteDeTravail PosteDeTravail269 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail270 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail271 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail272 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail273 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail274 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS18 };
            PosteDeTravail PosteDeTravail275 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS18 };

            PosteDeTravail PosteDeTravail276 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail277 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail278 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail279 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail280 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail281 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS19 };
            PosteDeTravail PosteDeTravail282 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS19 };

            PosteDeTravail PosteDeTravail283 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail284 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail285 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail286 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail287 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail288 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS11 };
            PosteDeTravail PosteDeTravail289 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS11 };

            PosteDeTravail PosteDeTravail290 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail291 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail292 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail293 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail294 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail295 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS20 };
            PosteDeTravail PosteDeTravail296 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS20 };

            PosteDeTravail PosteDeTravail297 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail298 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail299 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail300 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail301 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail302 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS21 };
            PosteDeTravail PosteDeTravail303 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS21 };

            PosteDeTravail PosteDeTravail304 = new PosteDeTravail() { Nom = "Tous les postes de la zone", Rang = 1, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail305 = new PosteDeTravail() { Nom = "Personnel administratif", Rang = 4, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail306 = new PosteDeTravail() { Nom = "Laborantin R&D", Rang = 2, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail307 = new PosteDeTravail() { Nom = "Standardiste", Rang = 5, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail308 = new PosteDeTravail() { Nom = "Technicien informatique", Rang = 6, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail309 = new PosteDeTravail() { Nom = "Manager", Rang = 3, Zone = ZoneRFS22 };
            PosteDeTravail PosteDeTravail310 = new PosteDeTravail() { Nom = "Autre", Rang = 100, Zone = ZoneRFS22 };



            context.PosteDeTravails.Add(PosteDeTravail3_1);
             context.PosteDeTravails.Add(PosteDeTravail1);
             context.PosteDeTravails.Add(PosteDeTravail2);
             context.PosteDeTravails.Add(PosteDeTravail3);
             context.PosteDeTravails.Add(PosteDeTravail4);
             context.PosteDeTravails.Add(PosteDeTravail5);
             context.PosteDeTravails.Add(PosteDeTravail6);
             context.PosteDeTravails.Add(PosteDeTravail7);
             context.PosteDeTravails.Add(PosteDeTravail8);
             context.PosteDeTravails.Add(PosteDeTravail3_2);

             context.PosteDeTravails.Add(PosteDeTravail4_1);
             context.PosteDeTravails.Add(PosteDeTravail9);
             context.PosteDeTravails.Add(PosteDeTravail10);
             context.PosteDeTravails.Add(PosteDeTravail11);
             context.PosteDeTravails.Add(PosteDeTravail12);
             context.PosteDeTravails.Add(PosteDeTravail13);
             context.PosteDeTravails.Add(PosteDeTravail14);
             context.PosteDeTravails.Add(PosteDeTravail15);
             context.PosteDeTravails.Add(PosteDeTravail16);
             context.PosteDeTravails.Add(PosteDeTravail17);
             context.PosteDeTravails.Add(PosteDeTravail18);
             context.PosteDeTravails.Add(PosteDeTravail4_2);

             context.PosteDeTravails.Add(PosteDeTravail5_1);
             context.PosteDeTravails.Add(PosteDeTravail19);
             context.PosteDeTravails.Add(PosteDeTravail20);
             context.PosteDeTravails.Add(PosteDeTravail21);
             context.PosteDeTravails.Add(PosteDeTravail22);
             context.PosteDeTravails.Add(PosteDeTravail5_2);

             context.PosteDeTravails.Add(PosteDeTravail6_1);
             context.PosteDeTravails.Add(PosteDeTravail23);
             context.PosteDeTravails.Add(PosteDeTravail24);
             context.PosteDeTravails.Add(PosteDeTravail25);
             context.PosteDeTravails.Add(PosteDeTravail26);
             context.PosteDeTravails.Add(PosteDeTravail27);
             context.PosteDeTravails.Add(PosteDeTravail6_2);

             context.PosteDeTravails.Add(PosteDeTravail7_1);
             context.PosteDeTravails.Add(PosteDeTravail55);
             context.PosteDeTravails.Add(PosteDeTravail28);
             context.PosteDeTravails.Add(PosteDeTravail29);
             context.PosteDeTravails.Add(PosteDeTravail30);
             context.PosteDeTravails.Add(PosteDeTravail31);
             context.PosteDeTravails.Add(PosteDeTravail7_2);

             context.PosteDeTravails.Add(PosteDeTravail8_1);
             context.PosteDeTravails.Add(PosteDeTravail32);
             context.PosteDeTravails.Add(PosteDeTravail33);
             context.PosteDeTravails.Add(PosteDeTravail34);
             context.PosteDeTravails.Add(PosteDeTravail35);
             context.PosteDeTravails.Add(PosteDeTravail36);
             context.PosteDeTravails.Add(PosteDeTravail37);
             context.PosteDeTravails.Add(PosteDeTravail38);
             context.PosteDeTravails.Add(PosteDeTravail39);
             context.PosteDeTravails.Add(PosteDeTravail40);
             context.PosteDeTravails.Add(PosteDeTravail41);
             context.PosteDeTravails.Add(PosteDeTravail42);
             context.PosteDeTravails.Add(PosteDeTravail8_2);


             context.PosteDeTravails.Add(PosteDeTravail43);
             context.PosteDeTravails.Add(PosteDeTravail44);
             context.PosteDeTravails.Add(PosteDeTravail45);
             context.PosteDeTravails.Add(PosteDeTravail46);
             context.PosteDeTravails.Add(PosteDeTravail47);
             context.PosteDeTravails.Add(PosteDeTravail48);
             context.PosteDeTravails.Add(PosteDeTravail49);
             context.PosteDeTravails.Add(PosteDeTravail50);
             context.PosteDeTravails.Add(PosteDeTravail51);
             context.PosteDeTravails.Add(PosteDeTravail52);
             context.PosteDeTravails.Add(PosteDeTravail53);
             context.PosteDeTravails.Add(PosteDeTravail54);

            // POSTES DE TRAVAIL DE STA

             context.PosteDeTravails.Add(PosteDeTravail56);
             context.PosteDeTravails.Add(PosteDeTravail57);
             context.PosteDeTravails.Add(PosteDeTravail58);
             context.PosteDeTravails.Add(PosteDeTravail59);
             context.PosteDeTravails.Add(PosteDeTravail60);
             context.PosteDeTravails.Add(PosteDeTravail61);
             context.PosteDeTravails.Add(PosteDeTravail62);
            
             context.PosteDeTravails.Add(PosteDeTravail63);
             context.PosteDeTravails.Add(PosteDeTravail64);
             context.PosteDeTravails.Add(PosteDeTravail65);
             context.PosteDeTravails.Add(PosteDeTravail66);
             context.PosteDeTravails.Add(PosteDeTravail67);
             context.PosteDeTravails.Add(PosteDeTravail68);
             context.PosteDeTravails.Add(PosteDeTravail69);
             context.PosteDeTravails.Add(PosteDeTravail70);
             context.PosteDeTravails.Add(PosteDeTravail71);
             context.PosteDeTravails.Add(PosteDeTravail72);
             context.PosteDeTravails.Add(PosteDeTravail73);

             context.PosteDeTravails.Add(PosteDeTravail74);
             context.PosteDeTravails.Add(PosteDeTravail75);
             context.PosteDeTravails.Add(PosteDeTravail76);
             context.PosteDeTravails.Add(PosteDeTravail76_2);
             context.PosteDeTravails.Add(PosteDeTravail77);

             context.PosteDeTravails.Add(PosteDeTravail78);
             context.PosteDeTravails.Add(PosteDeTravail79);
             context.PosteDeTravails.Add(PosteDeTravail80);
             context.PosteDeTravails.Add(PosteDeTravail81);
             context.PosteDeTravails.Add(PosteDeTravail82);
             context.PosteDeTravails.Add(PosteDeTravail83);
             context.PosteDeTravails.Add(PosteDeTravail84);
             context.PosteDeTravails.Add(PosteDeTravail85);
             context.PosteDeTravails.Add(PosteDeTravail86);
             context.PosteDeTravails.Add(PosteDeTravail87);
             context.PosteDeTravails.Add(PosteDeTravail88);
            
             context.PosteDeTravails.Add(PosteDeTravail89);
             context.PosteDeTravails.Add(PosteDeTravail90);
             context.PosteDeTravails.Add(PosteDeTravail91);
             context.PosteDeTravails.Add(PosteDeTravail92);
             context.PosteDeTravails.Add(PosteDeTravail93);

             context.PosteDeTravails.Add(PosteDeTravail94);
             context.PosteDeTravails.Add(PosteDeTravail95);
             context.PosteDeTravails.Add(PosteDeTravail96);
             context.PosteDeTravails.Add(PosteDeTravail97);
             context.PosteDeTravails.Add(PosteDeTravail98);
             context.PosteDeTravails.Add(PosteDeTravail99);
             context.PosteDeTravails.Add(PosteDeTravail100);
             context.PosteDeTravails.Add(PosteDeTravail101);
             context.PosteDeTravails.Add(PosteDeTravail102);
             context.PosteDeTravails.Add(PosteDeTravail103);
             context.PosteDeTravails.Add(PosteDeTravail104);
             context.PosteDeTravails.Add(PosteDeTravail105);
             context.PosteDeTravails.Add(PosteDeTravail106);
             context.PosteDeTravails.Add(PosteDeTravail107);
             context.PosteDeTravails.Add(PosteDeTravail108);

             context.PosteDeTravails.Add(PosteDeTravail109);
             context.PosteDeTravails.Add(PosteDeTravail110);
             context.PosteDeTravails.Add(PosteDeTravail111);
             context.PosteDeTravails.Add(PosteDeTravail112);
             context.PosteDeTravails.Add(PosteDeTravail113);
             context.PosteDeTravails.Add(PosteDeTravail114);
            
             context.PosteDeTravails.Add(PosteDeTravail115);
             context.PosteDeTravails.Add(PosteDeTravail116);
             context.PosteDeTravails.Add(PosteDeTravail117);
             context.PosteDeTravails.Add(PosteDeTravail118);
             context.PosteDeTravails.Add(PosteDeTravail119);
             context.PosteDeTravails.Add(PosteDeTravail120);
             context.PosteDeTravails.Add(PosteDeTravail121);

             context.PosteDeTravails.Add(PosteDeTravail122);
             context.PosteDeTravails.Add(PosteDeTravail123);

             context.PosteDeTravails.Add(PosteDeTravail124);
             context.PosteDeTravails.Add(PosteDeTravail125);

             context.PosteDeTravails.Add(PosteDeTravail126);
             context.PosteDeTravails.Add(PosteDeTravail127);
             context.PosteDeTravails.Add(PosteDeTravail128);
            
            //---NSG-----

             context.PosteDeTravails.Add(PosteDeTravail129);
             context.PosteDeTravails.Add(PosteDeTravail130);
             context.PosteDeTravails.Add(PosteDeTravail131);
             context.PosteDeTravails.Add(PosteDeTravail132);
             context.PosteDeTravails.Add(PosteDeTravail133);
             context.PosteDeTravails.Add(PosteDeTravail134);
             context.PosteDeTravails.Add(PosteDeTravail135);
             context.PosteDeTravails.Add(PosteDeTravail136);
             context.PosteDeTravails.Add(PosteDeTravail137);
             context.PosteDeTravails.Add(PosteDeTravail138);
             context.PosteDeTravails.Add(PosteDeTravail139);
             context.PosteDeTravails.Add(PosteDeTravail140);
             context.PosteDeTravails.Add(PosteDeTravail141);
             context.PosteDeTravails.Add(PosteDeTravail142);
             context.PosteDeTravails.Add(PosteDeTravail143);
             context.PosteDeTravails.Add(PosteDeTravail144);


             context.PosteDeTravails.Add(PosteDeTravail145);
             context.PosteDeTravails.Add(PosteDeTravail146);
             context.PosteDeTravails.Add(PosteDeTravail147);
             context.PosteDeTravails.Add(PosteDeTravail148);
             context.PosteDeTravails.Add(PosteDeTravail149);

             context.PosteDeTravails.Add(PosteDeTravail150);
             context.PosteDeTravails.Add(PosteDeTravail151);
             context.PosteDeTravails.Add(PosteDeTravail152);
             context.PosteDeTravails.Add(PosteDeTravail153);
             context.PosteDeTravails.Add(PosteDeTravail154);

             context.PosteDeTravails.Add(PosteDeTravail155);
             context.PosteDeTravails.Add(PosteDeTravail156);
             context.PosteDeTravails.Add(PosteDeTravail157);
             context.PosteDeTravails.Add(PosteDeTravail158);
             context.PosteDeTravails.Add(PosteDeTravail159);

             context.PosteDeTravails.Add(PosteDeTravail160);
             context.PosteDeTravails.Add(PosteDeTravail161);
             context.PosteDeTravails.Add(PosteDeTravail162);
             context.PosteDeTravails.Add(PosteDeTravail163);
             context.PosteDeTravails.Add(PosteDeTravail164);
             context.PosteDeTravails.Add(PosteDeTravail165);

             context.PosteDeTravails.Add(PosteDeTravail166);
             context.PosteDeTravails.Add(PosteDeTravail167);
             context.PosteDeTravails.Add(PosteDeTravail168);
             context.PosteDeTravails.Add(PosteDeTravail169);
             context.PosteDeTravails.Add(PosteDeTravail170);
             context.PosteDeTravails.Add(PosteDeTravail171);
             context.PosteDeTravails.Add(PosteDeTravail172);

             context.PosteDeTravails.Add(PosteDeTravail173);
             context.PosteDeTravails.Add(PosteDeTravail174);
             context.PosteDeTravails.Add(PosteDeTravail175);
             context.PosteDeTravails.Add(PosteDeTravail176);
             context.PosteDeTravails.Add(PosteDeTravail177);
             context.PosteDeTravails.Add(PosteDeTravail178);
             context.PosteDeTravails.Add(PosteDeTravail179);
             context.PosteDeTravails.Add(PosteDeTravail180);

             context.PosteDeTravails.Add(PosteDeTravail181);
             context.PosteDeTravails.Add(PosteDeTravail182);

             context.PosteDeTravails.Add(PosteDeTravail185);
             context.PosteDeTravails.Add(PosteDeTravail186);

            // LQN

             context.PosteDeTravails.Add(PosteDeTravail187);
             context.PosteDeTravails.Add(PosteDeTravail188);

             context.PosteDeTravails.Add(PosteDeTravail189);
             context.PosteDeTravails.Add(PosteDeTravail190);
             context.PosteDeTravails.Add(PosteDeTravail191);
             context.PosteDeTravails.Add(PosteDeTravail192);
             context.PosteDeTravails.Add(PosteDeTravail193);
             context.PosteDeTravails.Add(PosteDeTravail194);
             context.PosteDeTravails.Add(PosteDeTravail196);

             context.PosteDeTravails.Add(PosteDeTravail197);
             context.PosteDeTravails.Add(PosteDeTravail198);
             context.PosteDeTravails.Add(PosteDeTravail199);
             context.PosteDeTravails.Add(PosteDeTravail200);
             context.PosteDeTravails.Add(PosteDeTravail201);
             context.PosteDeTravails.Add(PosteDeTravail202);
             context.PosteDeTravails.Add(PosteDeTravail203);
             context.PosteDeTravails.Add(PosteDeTravail204);
             context.PosteDeTravails.Add(PosteDeTravail205);
             context.PosteDeTravails.Add(PosteDeTravail206);
             context.PosteDeTravails.Add(PosteDeTravail207);

             context.PosteDeTravails.Add(PosteDeTravail208);
             context.PosteDeTravails.Add(PosteDeTravail209);
             context.PosteDeTravails.Add(PosteDeTravail210);
             context.PosteDeTravails.Add(PosteDeTravail211);
             context.PosteDeTravails.Add(PosteDeTravail212);
             context.PosteDeTravails.Add(PosteDeTravail213);
             context.PosteDeTravails.Add(PosteDeTravail214);
             context.PosteDeTravails.Add(PosteDeTravail215);

             context.PosteDeTravails.Add(PosteDeTravail216);
             context.PosteDeTravails.Add(PosteDeTravail217);
             context.PosteDeTravails.Add(PosteDeTravail218);
             context.PosteDeTravails.Add(PosteDeTravail219);
             context.PosteDeTravails.Add(PosteDeTravail220);
             context.PosteDeTravails.Add(PosteDeTravail221);
             context.PosteDeTravails.Add(PosteDeTravail222);
             context.PosteDeTravails.Add(PosteDeTravail223);
             context.PosteDeTravails.Add(PosteDeTravail224);
             context.PosteDeTravails.Add(PosteDeTravail225);
             context.PosteDeTravails.Add(PosteDeTravail226);
             context.PosteDeTravails.Add(PosteDeTravail227);

             context.PosteDeTravails.Add(PosteDeTravail228);
             context.PosteDeTravails.Add(PosteDeTravail229);
             context.PosteDeTravails.Add(PosteDeTravail230);
             context.PosteDeTravails.Add(PosteDeTravail231);
             context.PosteDeTravails.Add(PosteDeTravail232);
             context.PosteDeTravails.Add(PosteDeTravail233);
             context.PosteDeTravails.Add(PosteDeTravail234);
             context.PosteDeTravails.Add(PosteDeTravail235);
             context.PosteDeTravails.Add(PosteDeTravail236);
             context.PosteDeTravails.Add(PosteDeTravail237);
             context.PosteDeTravails.Add(PosteDeTravail238);

             context.PosteDeTravails.Add(PosteDeTravail239);

             context.PosteDeTravails.Add(PosteDeTravail239_2);
             context.PosteDeTravails.Add(PosteDeTravail240_2);

             context.PosteDeTravails.Add(PosteDeTravail241_2);
             context.PosteDeTravails.Add(PosteDeTravail242_2);

             context.PosteDeTravails.Add(PosteDeTravail243_2);
             context.PosteDeTravails.Add(PosteDeTravail244_2);

             context.PosteDeTravails.Add(PosteDeTravail245_2);
             context.PosteDeTravails.Add(PosteDeTravail246_2);

            // RFS

             context.PosteDeTravails.Add(PosteDeTravail240);
             context.PosteDeTravails.Add(PosteDeTravail241);
             context.PosteDeTravails.Add(PosteDeTravail242);
             context.PosteDeTravails.Add(PosteDeTravail243);
             context.PosteDeTravails.Add(PosteDeTravail244);
             context.PosteDeTravails.Add(PosteDeTravail245);
             context.PosteDeTravails.Add(PosteDeTravail247);

             context.PosteDeTravails.Add(PosteDeTravail248);
             context.PosteDeTravails.Add(PosteDeTravail249);
             context.PosteDeTravails.Add(PosteDeTravail250);
             context.PosteDeTravails.Add(PosteDeTravail251);
             context.PosteDeTravails.Add(PosteDeTravail252);
             context.PosteDeTravails.Add(PosteDeTravail253);
             context.PosteDeTravails.Add(PosteDeTravail254);

             context.PosteDeTravails.Add(PosteDeTravail255);
             context.PosteDeTravails.Add(PosteDeTravail256);
             context.PosteDeTravails.Add(PosteDeTravail257);
             context.PosteDeTravails.Add(PosteDeTravail258);
             context.PosteDeTravails.Add(PosteDeTravail259);
             context.PosteDeTravails.Add(PosteDeTravail260);
             context.PosteDeTravails.Add(PosteDeTravail261);

             context.PosteDeTravails.Add(PosteDeTravail262);
             context.PosteDeTravails.Add(PosteDeTravail263);
             context.PosteDeTravails.Add(PosteDeTravail264);
             context.PosteDeTravails.Add(PosteDeTravail265);
             context.PosteDeTravails.Add(PosteDeTravail266);
             context.PosteDeTravails.Add(PosteDeTravail267);
             context.PosteDeTravails.Add(PosteDeTravail268);

             context.PosteDeTravails.Add(PosteDeTravail269);
             context.PosteDeTravails.Add(PosteDeTravail270);
             context.PosteDeTravails.Add(PosteDeTravail271);
             context.PosteDeTravails.Add(PosteDeTravail272);
             context.PosteDeTravails.Add(PosteDeTravail273);
             context.PosteDeTravails.Add(PosteDeTravail274);
             context.PosteDeTravails.Add(PosteDeTravail275);

             context.PosteDeTravails.Add(PosteDeTravail276);
             context.PosteDeTravails.Add(PosteDeTravail277);
             context.PosteDeTravails.Add(PosteDeTravail278);
             context.PosteDeTravails.Add(PosteDeTravail279);
             context.PosteDeTravails.Add(PosteDeTravail280);
             context.PosteDeTravails.Add(PosteDeTravail281);
             context.PosteDeTravails.Add(PosteDeTravail282);

             context.PosteDeTravails.Add(PosteDeTravail283);
             context.PosteDeTravails.Add(PosteDeTravail284);
             context.PosteDeTravails.Add(PosteDeTravail285);
             context.PosteDeTravails.Add(PosteDeTravail286);
             context.PosteDeTravails.Add(PosteDeTravail287);
             context.PosteDeTravails.Add(PosteDeTravail288);
             context.PosteDeTravails.Add(PosteDeTravail289);

             context.PosteDeTravails.Add(PosteDeTravail290);
             context.PosteDeTravails.Add(PosteDeTravail291);
             context.PosteDeTravails.Add(PosteDeTravail292);
             context.PosteDeTravails.Add(PosteDeTravail293);
             context.PosteDeTravails.Add(PosteDeTravail294);
             context.PosteDeTravails.Add(PosteDeTravail295);
             context.PosteDeTravails.Add(PosteDeTravail296);

             context.PosteDeTravails.Add(PosteDeTravail297);
             context.PosteDeTravails.Add(PosteDeTravail298);
             context.PosteDeTravails.Add(PosteDeTravail299);
             context.PosteDeTravails.Add(PosteDeTravail300);
             context.PosteDeTravails.Add(PosteDeTravail301);
             context.PosteDeTravails.Add(PosteDeTravail302);
             context.PosteDeTravails.Add(PosteDeTravail303);

             context.PosteDeTravails.Add(PosteDeTravail304);
             context.PosteDeTravails.Add(PosteDeTravail305);
             context.PosteDeTravails.Add(PosteDeTravail306);
             context.PosteDeTravails.Add(PosteDeTravail307);
             context.PosteDeTravails.Add(PosteDeTravail308);
             context.PosteDeTravails.Add(PosteDeTravail309);
             context.PosteDeTravails.Add(PosteDeTravail310);





            Personne PersonneConcernee1 = new Personne()
            {
                Nom = "Dupont",
                Prenom = "Jean"
            };

            Personne PersonneConcernee2 = new Personne()
            {
                Nom = "Bodoin",
                Prenom = "Sandra"
            };

            Personne PersonneConcernee3 = new Personne()
            {
                Nom = "Bricard",
                Prenom = "Isabelle"
            };

            Personne PersonneConcernee4 = new Personne()
            {
                Nom = "Giovaneti",
                Prenom = "Carl"
            };

            context.Personnes.Add(PersonneConcernee1);
            context.Personnes.Add(PersonneConcernee2);
            context.Personnes.Add(PersonneConcernee3);
            context.Personnes.Add(PersonneConcernee4);

            Personne Responsable1 = new Personne()
            {
                Nom = "Cokelaere",
                Prenom = "Julien",
                Guid = Guid.Parse("04520963-d3aa-4d5c-bf35-089999c1001b")
            };

            Personne Responsable2 = new Personne()
            {
                Nom = "Danton",
                Prenom = "Sylvie"
            };

            Personne Responsable3 = new Personne()
            {
                Nom = "Clement",
                Prenom = "Robert"
            };

            Personne Responsable4 = new Personne()
            {
                Nom = "Leloup",
                Prenom = "Sandrine"
            };

            context.Personnes.Add(Responsable1);
            context.Personnes.Add(Responsable2);
            context.Personnes.Add(Responsable3);
            context.Personnes.Add(Responsable4);

            FicheSecuriteType FicheSecuriteType1 = new FicheSecuriteType()
            {
                Nom = "ATAA"
            };

            FicheSecuriteType FicheSecuriteType2 = new FicheSecuriteType()
            {
                Nom = "ATSA"
            };

            FicheSecuriteType FicheSecuriteType3 = new FicheSecuriteType()
            {
                Nom = "Soins"
            };

            FicheSecuriteType FicheSecuriteType4 = new FicheSecuriteType()
            {
                Nom = "Presque Accident"
            };

            FicheSecuriteType FicheSecuriteType5 = new FicheSecuriteType()
            {
                Nom = "Situation Dangereuse"
            };

            context.FicheSecuriteTypes.Add(FicheSecuriteType1);
            context.FicheSecuriteTypes.Add(FicheSecuriteType2);
            context.FicheSecuriteTypes.Add(FicheSecuriteType3);
            context.FicheSecuriteTypes.Add(FicheSecuriteType4);
            context.FicheSecuriteTypes.Add(FicheSecuriteType5);

            List<string> AllDangerNom = new List<string>() { "Agents biologiques et infectieux", "Ambiance de travail (thermique, éclairage, aération)", 
                "Bruit", "Chute d'objets", "Circulation de piétons", "Circulation d'engins", "Co activité", "Comportement", "Déplacements extérieurs", 
                "Electricité", "Engins de levage ou mobiles", "Equipement sous pression", "Evènement extérieur (pluie, neige, vent, animaux, malveillance)", 
                "Geste et posture", "Machine ou outil dangereux", "Manutention ou port de charge", "Non Classé", "Produit chimique", "Produit gazeux", 
                "Projection (poussière, copeaux…)", "Psychosocial", "Rayonnement dangereux (laser, magnétique, radiation…)", "Stockage", 
                "Travail en hauteur", "Travail isolé", "Travail par point chaud", "Travail sur écran", "Vibration" };

            List<Danger> AllDanger = new List<Danger>();

            for (var i = 0; i < AllDangerNom.Count; i++)
            {
                Danger Danger = new Danger()
                {
                    Nom = AllDangerNom[i]
                };

                AllDanger.Add(Danger);
                context.Dangers.Add(Danger);
            }

            RisqueType RisqueType1 = new RisqueType() { Nom = "Santé sécurité" };
            RisqueType RisqueType2 = new RisqueType() { Nom = "Sûreté" };
            RisqueType RisqueType3 = new RisqueType() { Nom = "Autre" };

            context.RisqueTypes.Add(RisqueType1);
            context.RisqueTypes.Add(RisqueType2);
            context.RisqueTypes.Add(RisqueType3);

            List<string> AllRisqueNom = new List<string>() { "Asphyxie", "Brûlure/Irritation", "Choc", "Chute de hauteur", "Chute de plain-pied", 
                "Collision d'engins", "Collision engin/piéton", "Coupure", "Electrisation / Electrocution", "Entorse / luxation", 
                "Entrainement / Ecrasement / Coincement", "Fatigue visuelle", "Fatigue, stress, agressivité", "Fracture", 
                "Infection / Intoxication / Allergie / Irradiation", "Lésions oculaires", "Malaise", "Noyade", "Perte d'audition", "Plaie", "TMS / Lombalgie",
                "Explosion", "Foudre", "Incendie", "Inondation", "Intempérie violent", "Intrusion", "Non classé"};

            List<RisqueType> AllRisqueType = new List<RisqueType>() { RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, 
                RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1, RisqueType1,
                RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType2, RisqueType3};

            List<Risque> AllRisque = new List<Risque>();

            for (var i = 0; i < AllRisqueNom.Count; i++)
            {
                Risque Risque = new Risque()
                {
                    Nom = AllRisqueNom[i],
                    RisqueType = AllRisqueType[i]
                };

                AllRisque.Add(Risque);
                context.Risques.Add(Risque);
            }

            List<string> AllCorpsHumainZoneNom = new List<string>() { "Yeux", "Tête", "Bras", "Main", "Tronc", "Jambe", "Pied", "Tout le corps", "Multiples lésions", "Dos" };
            List<string> AllCorpsHumainZoneCode = new List<string>() { "YEUX", "TETE", "BRAS", "MAIN", "TRONC", "JAMBE", "PIED", "TOUTCORPS", "MULTILESIONS", "DOS" };

            List<CorpsHumainZone> AllCorpsHumainZone = new List<CorpsHumainZone>();

            for (var i = 0; i < AllCorpsHumainZoneNom.Count; i++)
            {
                CorpsHumainZone CorpsHumainZone = new CorpsHumainZone()
                {
                    Nom = AllCorpsHumainZoneNom[i],
                    Code = AllCorpsHumainZoneCode[i]
                };

                AllCorpsHumainZone.Add(CorpsHumainZone);
                context.CorpsHumainZones.Add(CorpsHumainZone);
            }



            PlageHoraire plagehoraire1 = new PlageHoraire() { Nom = "Nuit" };
            PlageHoraire plagehoraire2 = new PlageHoraire() { Nom = "Journée" };
            PlageHoraire plagehoraire3 = new PlageHoraire() { Nom = "Matin" };
            PlageHoraire plagehoraire4 = new PlageHoraire() { Nom = "Après-Midi" };
            PlageHoraire plagehoraire5 = new PlageHoraire() { Nom = "Weekend 1" };
            PlageHoraire plagehoraire6 = new PlageHoraire() { Nom = "Weekend 2" };

            context.PlageHoraires.Add(plagehoraire1);
            context.PlageHoraires.Add(plagehoraire2);
            context.PlageHoraires.Add(plagehoraire3);
            context.PlageHoraires.Add(plagehoraire4);
            context.PlageHoraires.Add(plagehoraire5);
            context.PlageHoraires.Add(plagehoraire6);

            FicheSecurite FicheSecurite1 = new FicheSecurite()
            {
                Code = "DLF-2014-1",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail23,
                Service = ServiceDLF1,
                Responsable = Responsable2,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = Lieu13,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 1

            };

            FicheSecurite FicheSecurite2 = new FicheSecurite()
            {
                Code = "DLF-2014-2",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail23,
                Service = ServiceDLF1,
                Responsable = Responsable2,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = Lieu13,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 2

            };

            FicheSecurite FicheSecurite3 = new FicheSecurite()
            {
                Code = "DLF-2014-3",
                Type = "FPA",
                PosteDeTravail = PosteDeTravail38,
                Service = ServiceDLF1,
                Responsable = Responsable2,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF2,
                Lieu = Lieu20,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType3,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire3,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[3],
                PersonneConcernee = PersonneConcernee3,
                Risque = AllRisque[3],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 3

            };

            FicheSecurite FicheSecurite4 = new FicheSecurite()
            {
                Code = "DLF-2014-4",
                Type = "FPA",
                PosteDeTravail = PosteDeTravail38,
                Service = ServiceDLF1,
                Responsable = Responsable2,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF5,
                Lieu = Lieu20,
                PersonnesConcernees = "Jean Dupont",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType4,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire4,
                CorpsHumainZone = AllCorpsHumainZone[4],
                PersonneConcernee = PersonneConcernee4,
                Risque = AllRisque[4],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 4

            };


            FicheSecurite FicheSecurite5 = new FicheSecurite()
            {
                Code = "STA-2014-3",
                Type = "FPA",
                PosteDeTravail = PosteDeTravail72,
                Service = ServiceSTA1,
                Responsable = Responsable3,
                Site = siteSTA,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneSTA2,
                Lieu = Lieu55,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType3,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire3,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[3],
                PersonneConcernee = PersonneConcernee3,
                Risque = AllRisque[3],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 3

            };

            FicheSecurite FicheSecurite6 = new FicheSecurite()
            {
                Code = "STA-2014-4",
                Type = "FPA",
                PosteDeTravail = PosteDeTravail72,
                Service = ServiceSTA1,
                Responsable = Responsable4,
                Site = siteSTA,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneSTA5,
                Lieu = Lieu55,
                PersonnesConcernees = "Jean Dupont",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType4,
                Danger = AllDanger[3],
                PlageHoraire = plagehoraire4,
                CorpsHumainZone = AllCorpsHumainZone[4],
                PersonneConcernee = PersonneConcernee4,
                Risque = AllRisque[4],
                WorkFlowDiffusee = true,
                CompteurAnnuelSite = 4
            };

            //FicheSecurite FicheSecurite7 = new FicheSecurite()
            //{
            //    Code = "RFS-2014-1",
            //    Type = "FAS",
            //    PosteDeTravail = PosteDeTravail72,
            //    Service = ServiceRFS1,
            //    Responsable = Responsable1,
            //    Site = siteRFS,
            //    DateCreation = DateTime.Now,
            //    DateEvenement = DateTime.Now,
            //    Zone = ZoneDLF4,
            //    Lieu = Lieu55,
            //    PersonnesConcernees = "Jean Dupont",
            //    Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
            //    CotationFrequence = 1,
            //    CotationGravite = 2,
            //    FicheSecuriteType = FicheSecuriteType1,
            //    Danger = AllDanger[1],
            //    PlageHoraire = plagehoraire1,
            //    ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
            //    CorpsHumainZone = AllCorpsHumainZone[1],
            //    PersonneConcernee = PersonneConcernee1,
            //    Risque = AllRisque[1],
            //    WorkFlowDiffusee = true,
            //    CompteurAnnuelSite = 1


            //};

            //FicheSecurite FicheSecurite8 = new FicheSecurite()
            //{
            //    Code = "RFS-2014-2",
            //    Type = "FAS",
            //    PosteDeTravail = PosteDeTravailDLFZone3_2,
            //    Service = ServiceDLF1,
            //    Responsable = Responsable1,
            //    Site = siteRFS,
            //    DateCreation = DateTime.Now,
            //    DateEvenement = DateTime.Now,
            //    Zone = ZoneDLF3,
            //    Lieu = LieuDLFZone3_2,
            //    PersonnesConcernees = "David Leloup, Cyril Clot",
            //    Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
            //    CotationFrequence = 1,
            //    CotationGravite = 4,
            //    FicheSecuriteType = FicheSecuriteType2,
            //    Danger = AllDanger[2],
            //    PlageHoraire = plagehoraire2,
            //    CorpsHumainZone = AllCorpsHumainZone[2],
            //    PersonneConcernee = PersonneConcernee2,
            //    Risque = AllRisque[2],
            //    WorkFlowDiffusee = true,
            //    CompteurAnnuelSite = 2

            //};

            //FicheSecurite FicheSecurite9 = new FicheSecurite()
            //{
            //    Code = "RFS-2014-3",
            //    Type = "FPA",
            //    PosteDeTravail = PosteDeTravailDLFZone3_2,
            //    Service = ServiceDLF1,
            //    Responsable = Responsable1,
            //    Site = siteRFS,
            //    DateCreation = DateTime.Now,
            //    DateEvenement = DateTime.Now,
            //    Zone = ZoneDLF2,
            //    Lieu = LieuDLFZone2_2,
            //    PersonnesConcernees = "Jean Dupont",
            //    Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
            //    CotationFrequence = 1,
            //    CotationGravite = 2,
            //    FicheSecuriteType = FicheSecuriteType3,
            //    Danger = AllDanger[3],
            //    PlageHoraire = plagehoraire3,
            //    ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
            //    CorpsHumainZone = AllCorpsHumainZone[3],
            //    PersonneConcernee = PersonneConcernee3,
            //    Risque = AllRisque[3],
            //    WorkFlowDiffusee = true,
            //    CompteurAnnuelSite = 3

            //};

            //FicheSecurite FicheSecurite10 = new FicheSecurite()
            //{
            //    Code = "RFS-2014-4",
            //    Type = "FPA",
            //    PosteDeTravail = PosteDeTravailDLFZone5_2,
            //    Service = ServiceDLF1,
            //    Responsable = Responsable1,
            //    Site = siteRFS,
            //    DateCreation = DateTime.Now,
            //    DateEvenement = DateTime.Now,
            //    Zone = ZoneDLF5,
            //    Lieu = LieuDLFZone5_2,
            //    PersonnesConcernees = "Jean Dupont",
            //    Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
            //    CotationFrequence = 1,
            //    CotationGravite = 4,
            //    FicheSecuriteType = FicheSecuriteType4,
            //    Danger = AllDanger[3],
            //    PlageHoraire = plagehoraire4,
            //    CorpsHumainZone = AllCorpsHumainZone[4],
            //    PersonneConcernee = PersonneConcernee4,
            //    Risque = AllRisque[4],
            //    WorkFlowDiffusee = true,
            //    CompteurAnnuelSite = 4

            //};

            FicheSecurite FicheSecurite11 = new FicheSecurite()
            {
                Code = "DLF-2014-5",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail15,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = Lieu15,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1],
                WorkFlowDiffusee = true,
                WorkFlowAttenteASEValidation = true,
                CompteurAnnuelSite = 5


            };

            FicheSecurite FicheSecurite12 = new FicheSecurite()
            {
                Code = "DLF-2014-6",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail15,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = Lieu15,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2],
                WorkFlowDiffusee = true,
                WorkFlowAttenteASEValidation = true,
                CompteurAnnuelSite = 6

            };

            FicheSecurite FicheSecurite13 = new FicheSecurite()
            {
                Code = "DLF-2014-7",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail15,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = Lieu15,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1],
                WorkFlowDiffusee = true,
                WorkFlowASEValidee = true,
                CompteurAnnuelSite = 7


            };

            FicheSecurite FicheSecurite14 = new FicheSecurite()
            {
                Code = "DLF-2014-8",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail16,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = Lieu16,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2],
                WorkFlowDiffusee = true,
                WorkFlowASEValidee = true,
                CompteurAnnuelSite = 8

            };


            FicheSecurite FicheSecurite15 = new FicheSecurite()
            {
                Code = "DLF-2014-9",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail17,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = Lieu17,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1],
                WorkFlowDiffusee = true,
                WorkFlowASERejetee = true,
                CompteurAnnuelSite = 9


            };

            FicheSecurite FicheSecurite16 = new FicheSecurite()
            {
                Code = "DLF-2014-10",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail18,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = Lieu18,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2],
                WorkFlowDiffusee = true,
                WorkFlowASERejetee = true,
                CompteurAnnuelSite = 10

            };

            FicheSecurite FicheSecurite17 = new FicheSecurite()
            {
                Code = "DLF-2014-11",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail19,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF4,
                Lieu = Lieu19,
                PersonnesConcernees = "Jean Dupont",
                Description = "L'opérateur a pris une charge trop lourde avec son chariot et il s'est renversé",
                CotationFrequence = 1,
                CotationGravite = 2,
                FicheSecuriteType = FicheSecuriteType1,
                Danger = AllDanger[1],
                PlageHoraire = plagehoraire1,
                ActionImmediate1 = "Rappel à tous les caristes de ne prendre les palettes que deux par deux",
                CorpsHumainZone = AllCorpsHumainZone[1],
                PersonneConcernee = PersonneConcernee1,
                Risque = AllRisque[1],
                WorkFlowDiffusee = true,
                WorkFlowCloturee = true,
                CompteurAnnuelSite = 11


            };

            FicheSecurite FicheSecurite18 = new FicheSecurite()
            {
                Code = "DLF-2014-12",
                Type = "FAS",
                PosteDeTravail = PosteDeTravail20,
                Service = ServiceDLF1,
                Responsable = Responsable1,
                Site = siteDLF,
                DateCreation = DateTime.Now,
                DateEvenement = DateTime.Now,
                Zone = ZoneDLF3,
                Lieu = Lieu20,
                PersonnesConcernees = "David Leloup, Cyril Clot",
                Description = "Pour ouvrir les fûts, l'opérateur utilise une pince monseigneur et un outil pointu permettant d'ecarter la vis du fût avec laquelle il s'est coupé",
                CotationFrequence = 1,
                CotationGravite = 4,
                FicheSecuriteType = FicheSecuriteType2,
                Danger = AllDanger[2],
                PlageHoraire = plagehoraire2,
                CorpsHumainZone = AllCorpsHumainZone[2],
                PersonneConcernee = PersonneConcernee2,
                Risque = AllRisque[2],
                WorkFlowDiffusee = true,
                WorkFlowCloturee = true,
                CompteurAnnuelSite = 12

            };


            ActionSecurite action = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "OPQR",
                Description = "Des musolières ont été achetées pour les datacores",
                FaitPar = "Nicolas Bouhet"
            };

            ActionSecurite action2 = new ActionSecurite()
            {
                FicheSecurite = FicheSecurite1,
                Code = "STUV",
                Description = "Les racks serveurs ont été renforcés",
                FaitPar = "Nicolas Bouhet"
            };

            //for (int i = 0; i < 10; i++)
            //{
            context.FicheSecurites.Add(FicheSecurite1);
            context.ActionSecurites.Add(action);
            context.ActionSecurites.Add(action2);
            context.FicheSecurites.Add(FicheSecurite2);
            context.FicheSecurites.Add(FicheSecurite3);
            context.FicheSecurites.Add(FicheSecurite4);
            context.FicheSecurites.Add(FicheSecurite5);
            context.FicheSecurites.Add(FicheSecurite6);
            //context.FicheSecurites.Add(FicheSecurite7);
            //context.FicheSecurites.Add(FicheSecurite8);
            //context.FicheSecurites.Add(FicheSecurite9);
            //context.FicheSecurites.Add(FicheSecurite10);
            context.FicheSecurites.Add(FicheSecurite11);
            context.FicheSecurites.Add(FicheSecurite12);
            context.FicheSecurites.Add(FicheSecurite13);
            context.FicheSecurites.Add(FicheSecurite14);
            context.FicheSecurites.Add(FicheSecurite15);
            context.FicheSecurites.Add(FicheSecurite16);
            context.FicheSecurites.Add(FicheSecurite17);
            context.FicheSecurites.Add(FicheSecurite18);
            //System.Diagnostics.Debug.WriteLine("Passage boucle"); 

            //}

            CauseQSE Cause1 = new CauseQSE()
            {
                Description = "Manque de formation",
                FicheSecurite = FicheSecurite1
            };

            CauseQSE Cause2 = new CauseQSE()
            {
                Description = "Règles non respectées",
                FicheSecurite = FicheSecurite1
            };

            CauseQSE Cause3 = new CauseQSE()
            {
                Description = "Port d'une protection non respecté",
                FicheSecurite = FicheSecurite2
            };

            CauseQSE Cause4 = new CauseQSE()
            {
                Description = "Remplacement de l'opérateur habituel à la volée",
                FicheSecurite = FicheSecurite2
            };

            context.CauseQSEs.Add(Cause1);
            context.CauseQSEs.Add(Cause2);
            context.CauseQSEs.Add(Cause3);
            context.CauseQSEs.Add(Cause4);

            ActionQSE Action1 = new ActionQSE()
            {
                Description = "Prévoir une nouvelle formation cariste",
                DateButoireInitiale = DateTime.Now,
                Responsable = PersonneConcernee4,
                Cloture = false,
                CauseQS = Cause1,
                DateButoireNouvelle = DateTime.Now,
                RealiseDate = DateTime.Now,
                VerifieDate = DateTime.Now,
                ClotureDate = DateTime.Now
            };

            ActionQSE Action2 = new ActionQSE()
            {
                Description = "S'avertir les uns les autres",
                DateButoireInitiale = DateTime.Now,
                Responsable = PersonneConcernee3,
                Cloture = true,
                ClotureDate = DateTime.Now,
                CauseQS = Cause1,
                DateButoireNouvelle = DateTime.Now,
                RealiseDate = DateTime.Now,
                VerifieDate = DateTime.Now
            };

            context.ActionQSEs.Add(Action1);
            context.ActionQSEs.Add(Action2);

            //ROLE A AJOUTER A LA MAIN AU PREMIER LANCEMENT
            //ADRole ADRoleHSESuperAdministrateur = new ADRole()
            //{
            //    Name = "REFRESCO\\\\RFS-Service des Systemes d'Information-Responsable Logicielles",
            //    RoleType = "HSE",
            //    RoleCode = "100"

            //};

            ADRole ADRoleHSEAdministrateur = new ADRole()
            {
                Name = "REFRESCO\\\\RFS-Service securite environnement",
                RoleType = "HSE",
                RoleCode = "200"

            };

            ADRole ADRoleHSEASE = new ADRole()
            {
                Name = "REFRESCO\\\\Groupe Securite Environnement - M",
                RoleType = "HSE",
                RoleCode = "300"

            };

            ParametrageHSE parametrageHSE = new ParametrageHSE()
            {
                EmailDiffusionFS = "SELF",
                EmailValidationRejetPlanActionFS = "SELF",
                EmailDiffusionPlanAction = "SELF"
            };

            context.ADRoles.Add(ADRoleHSEASE);
            //ROLE A AJOUTER A LA MAIN AU PREMIER LANCEMENT
            //context.ADRoles.Add(ADRoleHSESuperAdministrateur);
            context.ADRoles.Add(ADRoleHSEAdministrateur);

            context.ParametrageHSEs.Add(parametrageHSE);

            context.SaveChanges();

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (Exception e)
            //{
            //    var a = 0;
            //}

        }


        public void QSEListsTestHydrate()
        {

            List<string> AllOrigineNom = new List<string>() { 
                "Audit IFS",
                "Audit ISO 9001",
                "Audit FSSC 22000",
                "Audit AIB",
                "Audit KAS",
                "Audit KORE",
                "Audit externe autre",
                "Audit interne",
                "Non-conformités", 
                "Réclamations", 
                "Revue de Direction"
            };

            List<NonConformiteOrigine> AllOrigine = new List<NonConformiteOrigine>();

            foreach(string OrigineNom in AllOrigineNom){
                NonConformiteOrigine Origine = new NonConformiteOrigine() { Nom = OrigineNom};
                AllOrigine.Add(Origine);
                context.NonConformiteOrigines.Add(Origine);
                context.SaveChanges();
            }

            List<string> AllDomaineNom = new List<string>() { 
                "Gestion documentaire",
                "Responsabilité de la direction",
                "Planification",
                "Revue de direction",
                "Ressources Humaines",
                "Infrastructures",
                "Réalisation du produits",
                "Ecoute client",
                "Conception et développement",
                "Achat",
                "Métrologie",
                "Surveillance et mesurage",
                "Maîtrise du produit non-conforme",
                "Amélioration",
                "Biovigilance",
                "Sécurité des Denrée Alimentaires",
                "Dépôts MPA",
                "Dépôts MPC",
                "Dépôts PF",
                "Dépots Extérieurs",
                "Extérieurs",
                "Communs",
                "Bureaux",
                "Soufflage",
                "Préparation",
                "Process",
                "Traitement des eaux",
                "Packaging",
                "Lutte contre les nuisibles",
            };

            List<NonConformiteDomaine> AllDomaine = new List<NonConformiteDomaine>();

            foreach (string DomaineNom in AllDomaineNom)
            {
                NonConformiteDomaine Domaine = new NonConformiteDomaine() { Nom = DomaineNom };
                AllDomaine.Add(Domaine);
                context.NonConformiteDomaines.Add(Domaine);
                context.SaveChanges();
            }


            List<string> AllGraviteNom = new List<string>() { 
                "Mineur",
                "Majeur",
                "OA"
            };

            List<NonConformiteGravite> AllGravite = new List<NonConformiteGravite>();

            foreach (string GraviteNom in AllGraviteNom)
            {
                NonConformiteGravite Gravite = new NonConformiteGravite() { Nom = GraviteNom };
                AllGravite.Add(Gravite);
                context.NonConformiteGravites.Add(Gravite);
                context.SaveChanges();
            }

            //ROLE A AJOUTER A LA MAIN AU PREMIER LANCEMENT
            //ADRole ADRoleHSESuperAdministrateur = new ADRole()
            //{
            //    Name = "REFRESCO\\\\RFS-Service des Systemes d'Information-Responsable Logicielles",
            //    RoleType = "QSE",
            //    RoleCode = "100"

            //};

            //context.ADRoles.Add(ADRoleHSESuperAdministrateur);

            ParametrageQSE parametrageQSE = new ParametrageQSE()
            {

            };

            context.ParametrageQSEs.Add(parametrageQSE);

            context.SaveChanges();

        }

        public void NSGAllListTestHydrate()
        {
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Tous les services").FirstOrDefault() };
            //Service ServiceNSG2 = new Service() { Site = siteNSG, ServiceType = ServiceType2 };
            //Service ServiceNSG3 = new Service() { Site = siteNSG, ServiceType = ServiceType3 };
            //Service ServiceNSG4 = new Service() { Site = siteNSG, ServiceType = ServiceType4 };
            //Service ServiceNSG5 = new Service() { Site = siteNSG, ServiceType = ServiceType5 };
            //Service ServiceNSG6 = new Service() { Site = siteNSG, ServiceType = ServiceType6 };
            //Service ServiceNSG7 = new Service() { Site = siteNSG, ServiceType = ServiceType7 };

            //context.Services.Add(ServiceNSG1);
            //context.Services.Add(ServiceNSG2);
            //context.Services.Add(ServiceNSG3);
            //context.Services.Add(ServiceNSG4);
            //context.Services.Add(ServiceNSG5);
            //context.Services.Add(ServiceNSG6);
            //context.Services.Add(ServiceNSG7);


            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Tous les services").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Production").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Maintenance/TN").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Qualité").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Sécurité/Environnement").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Tous les services").FirstOrDefault() };
            //Service ServiceNSG1 = new Service() { Site = context.Sites.Where(s => s.Trigramme == "NSG").FirstOrDefault(), ServiceType = context.ServiceTypes.Where(st => st.Nom == "Tous les services").FirstOrDefault() };
            //Service ServiceNSG2 = new Service() { Site = siteNSG, ServiceType = ServiceType1 };
            //Service ServiceNSG3 = new Service() { Site = siteNSG, ServiceType = ServiceType2 };
            //Service ServiceNSG4 = new Service() { Site = siteNSG, ServiceType = ServiceType3 };
            //Service ServiceNSG5 = new Service() { Site = siteNSG, ServiceType = ServiceType4 };
            //Service ServiceNSG6 = new Service() { Site = siteNSG, ServiceType = ServiceType6 };
            //Service ServiceNSG7 = new Service() { Site = siteNSG, ServiceType = ServiceType7 };
            //Service ServiceNSG8 = new Service() { Site = siteNSG, ServiceType = ServiceType19 };

            //context.Services.Add(ServiceNSG1);
            //context.Services.Add(ServiceNSG2);
            //context.Services.Add(ServiceNSG3);
            //context.Services.Add(ServiceNSG4);
            //context.Services.Add(ServiceNSG5);
            //context.Services.Add(ServiceNSG6);
            //context.Services.Add(ServiceNSG7);
            //context.Services.Add(ServiceNSG8);

        }

    }
}