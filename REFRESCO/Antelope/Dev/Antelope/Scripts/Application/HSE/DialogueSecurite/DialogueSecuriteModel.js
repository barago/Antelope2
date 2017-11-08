var DialogueSecuriteModel = Backbone.Model.extend({
    urlRoot: '/api/DialogueSecurite',
    idAttribute: 'Id',
    validate: function (attrs, options) {
        console.log('Passage Validate DS');
        if (attrs.SiteId == 0) {
            return "Il manque un champ obligatoire, merci de choisir un Site";
        };
        //if (attrs.NonConformiteOrigineId == 0 || attrs.NonConformiteOrigineId == null) {
        //    return "Il manque un champ obligatoire, merci de choisir une Origine";
        //};
        if (attrs.Date == '0001-01-01T00:00:00') {
            return "Il manque un champ obligatoire, merci de choisir une Date";
        };

        if (attrs.Contexte == null) {
            return "Il manque un champ obligatoire, merci de saisir une Contexte";
        };
        if (attrs.Observation == null) {
            return "Il manque un champ obligatoire, merci de saisir une Observation";
        };
        if (attrs.Reflexion == null) {
            return "Il manque un champ obligatoire, merci de saisir une Reflexion";
        };
        if (attrs.Action == null) {
            return "Il manque un champ obligatoire, merci de saisir une Action";
        };
        if(attrs.Dialogueur1 == null){
            return "Il manque un champ obligatoire, merci de saisir un Dialogueur";
        };
        if (attrs.Entretenu1 == null) {
            return "Il manque un champ obligatoire, merci de saisir un Dialogué";
        };
        if (attrs.ServiceTypeDialogueur1Id == 0) {
            return "Il manque un champ obligatoire, merci de saisir un service de dialogueur";
        };
        if (attrs.ServiceTypeEntretenu1Id == 0) {
            return "Il manque un champ obligatoire, merci de saisir un service de dialogué";
        };
        if (attrs.Dialogueur2.Nom != null) {
            if (attrs.ServiceTypeDialogueur2Id == 0) {
                return "Il manque un champ obligatoire, merci de saisir un service pour le dialogueur 2";
            };
        }
        if (attrs.Dialogueur3.Nom != null) {
            if (attrs.ServiceTypeDialogueur3Id == 0) {
                return "Il manque un champ obligatoire, merci de saisir un service pour le dialogueur 3";
            };
        }
        if (attrs.Entretenu2.Nom != null) {
            if (attrs.ServiceTypeEntretenu2Id == 0) {
                console.log(attrs);
                return "Il manque un champ obligatoire, merci de saisir un service pour le dialogué 2";
            };
        }
        if (attrs.Entretenu3.Nom != null) {
            if (attrs.ServiceTypeEntretenu3Id == 0) {
                return "Il manque un champ obligatoire, merci de saisir un service pour le dialogué 3";
            };
        }
    }
});

var NonConformiteCollection = Backbone.Collection.extend({
    url: '/api/DialogueSecurite',
    model: DialogueSecuriteModel
});