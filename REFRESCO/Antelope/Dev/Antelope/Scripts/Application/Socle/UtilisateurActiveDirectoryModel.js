var UtilisateurActiveDirectoryModel = Backbone.Model.extend({
    urlRoot: '/api/UtilisateurActiveDirectory'
});

var UtilisateurActiveDirectoryCollection = Backbone.Collection.extend({
    model: UtilisateurActiveDirectoryModel
});