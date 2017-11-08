var LieuModel = Backbone.Model.extend({
});

var LieuCollection = Backbone.Collection.extend({
    model: LieuModel,
    url: '/api/action/lieu/getLieuxByZoneId'
});