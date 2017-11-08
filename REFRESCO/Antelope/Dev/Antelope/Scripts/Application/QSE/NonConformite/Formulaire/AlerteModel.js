var AlerteModel = Backbone.Model.extend({
    defaults: {
        alerteHidden: true,
        alerteClass: "alert alert-danger",
        alerteMessage: "Test d'alerte",
        messages: [{ '0': 'Vous devez saisir tous les champs obligatoires, merci de compléter votre saisie.' }]
    },

});

