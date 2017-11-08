var RechercheActiveDirectoryModel = Backbone.Model.extend({
    urlRoot: '/api/RechercheActiveDirectory'
});

var RechercheActiveDirectoryCollection = Backbone.Collection.extend({
    model: RechercheActiveDirectoryModel
});