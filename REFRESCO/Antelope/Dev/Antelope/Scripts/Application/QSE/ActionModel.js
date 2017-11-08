var ActionModel = Backbone.Model.extend({
    urlRoot: '/api/ActionQSE',
    validate: function (attrs, options) {

        if (attrs.Description == null) {
            return "Il manque un champ obligatoire, merci de saisir une Description de l'action";
        };
        if (attrs.DateButoireInitiale == '0001-01-01T00:00:00' || attrs.DateButoireInitiale == null) {
            return "Il manque un champ obligatoire, merci de choisir une date initiale de l'action";
        };
        if (attrs.Responsable instanceof Backbone.Model) {
            if (!attrs.Responsable.has('Nom')) {
                return "Il manque un champ obligatoire, merci de saisir un nom de Responsable d'action";
            };
            if (!attrs.Responsable.has('Prenom')) {
                return "Il manque un champ obligatoire, merci de saisir un prénom de Responsable d'action";
            };
        }
    }
});

var ActionCollection = Backbone.Collection.extend({
    model: ActionModel
});