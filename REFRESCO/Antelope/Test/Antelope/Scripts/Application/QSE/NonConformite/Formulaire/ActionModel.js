var ActionModel = Backbone.Model.extend({
    urlRoot: '/api/ActionQSE',
    validate: function (attrs, options) {
        console.log('PASSAGE VALIDATE');
        console.log(attrs);
        if (attrs.VerifieDate != null && attrs.RealiseDate == null) {
            return "Une date de vérification existe, impossible de supprimer la date de réalisation.";
        }
        if (attrs.DateButoireInitiale == '0001-01-01T00:00:00' || attrs.DateButoireInitiale == null) {
            return "Il manque un champ obligatoire, merci de choisir une date initiale de l'action";
        };
        if (attrs.DateButoireInitialeJavascript == '' || attrs.DateButoireInitialeJavascript == null) {
            return "Il manque un champ obligatoire, merci de choisir une date initiale de l'action";
        };
        if (attrs.Responsable instanceof Backbone.Model) {
            if (!attrs.Responsable.has('Nom') || attrs.Responsable.get('Nom') === "" ) {
                return "Il manque un champ obligatoire, merci de saisir un nom de Responsable d'action";
            };
            if (!attrs.Responsable.has('Prenom') || attrs.Responsable.get('Prenom') === "") {
                return "Il manque un champ obligatoire, merci de saisir un prénom de Responsable d'action";
            };
        }
        if (attrs.Description == null || attrs.Description == "") {
            return "Il manque un champ obligatoire, merci de saisir une Description de l'action";
        };
        if (attrs.Verificateur instanceof Backbone.Model) {
            if (!attrs.Verificateur.has('Nom') || attrs.Verificateur.get('Nom') === "") {
                return "Il manque un champ obligatoire, merci de saisir un nom de Verificateur d'action";
            };
            if (!attrs.Verificateur.has('Prenom') || attrs.Verificateur.get('Prenom') === "") {
                return "Il manque un champ obligatoire, merci de saisir un prénom de Verificateur d'action";
            };
        };
        if (attrs.CritereEfficaciteVerification == null || attrs.CritereEfficaciteVerification == "") {
            return "Il manque un champ obligatoire, merci de saisir un Critere de vérification de l'action";
        };

    }
});

var ActionCollection = Backbone.Collection.extend({
    model: ActionModel
});