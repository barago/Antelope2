var ServiceModel = Backbone.Model.extend({
});

var ServiceCollection = Backbone.Collection.extend({
    model: ServiceModel,
    url: '/api/action/service/getServicesBySiteId'
    //url: '/api/Zone'
});