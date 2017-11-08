// Les migrations de bases de données ne sont pas connectées avec les configuration de contexte (pour autant que je sache) 
// Ainsi, lors d'un "update-database", la commande va toujours chercher la connexion par défaut du web.config, et non pas les web.config transformées (Web.Debug.config ...)
// On peut surcharger l'appel à la commande avec -ConnectionString et -ConnectionProviderName afin de mettre à jour d'autres Bases que celle de Web.Config.
//
// Ce fichier liste donc les différentes commandes d'update possible avec leurs paramètres de connexion afin de les copier-coller dans le power-shell


//WORK / LOCAL / DEBUG

/*
  
update-database -ConnectionString "Data Source=RFS-PW7M11\SQLEXPRESS;Initial Catalog=Antelope;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"

*/

//WORK / SERVER / RELEASE / PRODUCTION

/*

update-database -ConnectionString "Data Source=DLF-S12VM10;Initial Catalog=Antelope;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"

*/

//WORK / SERVER / RELEASE / ACCEPTANCE

/*

update-database -ConnectionString "Data Source=DLF-S12VM10;Initial Catalog=Antelope_Acceptance;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"

*/

//WORK / SERVER / RELEASE / TEST

/*

update-database -ConnectionString "Data Source=DLF-S12VM10;Initial Catalog=Antelope_Test;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"

*/

//HOME / LOCAL / DEBUG

/*

update-database -ConnectionString "Data Source=ALDEBARAN\SQLEXPRESS;Initial Catalog=Antelope;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"
 
*/

//WORK / LOCAL / DEBUG / Remy

/*
  
update-database -ConnectionString "Data Source=RFS-WW7I20\SQLEXPRESS;Initial Catalog=Antelope;User ID=sa;Password=8rj589oH;" -ConnectionProviderName "System.Data.SqlClient"

*/