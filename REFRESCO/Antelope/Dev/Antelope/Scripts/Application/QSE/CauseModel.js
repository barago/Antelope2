var CauseModel = Backbone.Model.extend({
    urlRoot: '/api/CauseQSE',
    validate: function (attrs, options) {
        console.log('VALIDATE CAUSEMODEL');
        if (attrs.Description == null) {
            return "Il manque un champ obligatoire, merci de saisir une Description de la cause";
        };
    }
});

var CauseCollection = Backbone.Collection.extend({
    model: CauseModel
});