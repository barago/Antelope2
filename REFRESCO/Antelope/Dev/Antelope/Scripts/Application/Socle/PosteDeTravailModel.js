var PosteDeTravailModel = Backbone.Model.extend({
});

var PosteDeTravailCollection = Backbone.Collection.extend({
    model: PosteDeTravailModel,
    url: '/api/action/posteDeTravail/getPosteDeTravailsByZoneId'
});