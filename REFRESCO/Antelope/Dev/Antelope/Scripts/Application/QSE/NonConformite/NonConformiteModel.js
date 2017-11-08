var NonConformiteModel = Backbone.Model.extend({
    urlRoot: '/api/NonConformite',
    idAttribute: 'Id',
    validate: function (attrs, options) {
        console.log('Passage Validate NC');
        if (attrs.SiteId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Site";
        };
        if (attrs.ServiceTypeId == 0 || attrs.ServiceTypeId == null) {
            return "Il manque un champ obligatoire, merci de choisir une Appartenance à un service.";
        };
        if (attrs.NonConformiteOrigineId == 0 || attrs.NonConformiteOrigineId == null) {
            return "Il manque un champ obligatoire, merci de choisir une Origine";
        };
        if (attrs.Date == '0001-01-01T00:00:00') {
            return "Il manque un champ obligatoire, merci de choisir une Date";
        };
        if (attrs.NonConformiteDomaineId == 0 || attrs.NonConformiteDomaineId == null) {
            return "Il manque un champ obligatoire, merci de choisir un Domaine";
        };
        if (attrs.NonConformiteGraviteId == 0 || attrs.NonConformiteGraviteId == null) {
            return "Il manque un champ obligatoire, merci de choisir une Gravité";
        };
        if (attrs.Description == null) {
            return "Il manque un champ obligatoire, merci de saisir une Description";
        };
        if (attrs.Cause == null) {
            return "Il manque un champ obligatoire, merci de saisir une Cause";
        };
    }
});

var NonConformiteCollection = Backbone.Collection.extend({
    url: '/api/NonConformite',
    model: NonConformiteModel
});