var SiteModel = Backbone.Model.extend({
});

var SiteCollection = Backbone.Collection.extend({
    model: SiteModel,
    url: '/api/sites'
});