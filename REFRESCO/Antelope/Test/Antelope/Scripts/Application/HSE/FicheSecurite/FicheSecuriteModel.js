var FicheSecuriteModel = Backbone.Model.extend({
    urlRoot: '/api/FicheSecurite',
    idAttribute: "FicheSecuriteID",
    initialize: function(){
        this.PersonneConcernee = new PersonneConcerneeModel();

    },
    validate: function (attrs, options) {


        if (attrs.SiteId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Site";
        };
        if (attrs.FicheSecuriteTypeId == 0 || attrs.FicheSecuriteTypeId == null) {
            return "Il manque un champ obligatoire, merci de choisir un Type de fiche";
        };
        if (attrs.DateEvenement == '0001-01-01T00:00:00') {
            return "Il manque un champ obligatoire, merci de choisir une date et heure";
        };
        // Validate se rejoue après la réponse serveur d'un save() et ne possède pas de fonction "has()" >> Triche
        if (attrs.PersonneConcernee instanceof Backbone.Model) {
            if (!attrs.PersonneConcernee.has('Nom')) {
                return "Il manque un champ obligatoire, merci de saisir un nom de Personne concernée";
            };
            if (!attrs.PersonneConcernee.has('Prenom')) {
                return "Il manque un champ obligatoire, merci de saisir un prénom de Personne concernée";
            };
        }
        if (attrs.ZoneId == null || attrs.ZoneId == 0) {
            return "Il manque un champ obligatoire, merci de choisir une Zone";
        };
        if (attrs.PlageHoraireId == null || attrs.PlageHoraireId == 0) {
            return "Il manque un champ obligatoire, merci de choisir une Plage horaire";
        };
        if (attrs.PosteDeTravailId == null || attrs.PosteDeTravailId == 0) {
            return "Il manque un champ obligatoire, merci de choisir une Poste de travail";
        };
        if (attrs.ServiceId == null || attrs.ServiceId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Service";
        };
        if (attrs.Responsable instanceof Backbone.Model) {
            if (!attrs.Responsable.has('Nom')) {
                return "Il manque un champ obligatoire, merci de saisir un nom de Responsable";
            };
            if (!attrs.Responsable.has('Prenom')) {
                return "Il manque un champ obligatoire, merci de saisir un prénom de Responsable";
            };
        }
        if (attrs.LieuId == null || attrs.LieuId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Lieu";
        };
        if (attrs.DangerId == null || attrs.DangerId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Danger";
        };
        if (attrs.RisqueId == null || attrs.RisqueId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Risque";
        };
        if (attrs.Description == null) {
            return "Il manque un champ obligatoire, merci de saisir une Description";
        };
        if (attrs.CotationGravite == 0) {
            return "Il manque un champ obligatoire, merci de saisir une Gravité";
        };
        if (attrs.CotationFrequence == 0) {
            return "Il manque un champ obligatoire, merci de saisir une Fréquence";
        };
        if (attrs.CorpsHumainZoneId == null || attrs.CorpsHumainZoneId == 0) {
            return "Il manque un champ obligatoire, merci de choisir une partie du corps humain";
        };
    }
});

var FicheSecuriteCollection = Backbone.Collection.extend({
    url: '/api/RechercheFicheSecurite',
    model: FicheSecuriteModel
    //parse: function (response) {
    //    this.trigger("collection:updated", { count: repsonse.count, total: response.total, startAt: response.startAt });
    //    return response.records;
    //}
});