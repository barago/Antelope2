var ZoneModel = Backbone.Model.extend({
});

var ZoneCollection = Backbone.Collection.extend({
    model: ZoneModel,
    url: '/api/action/zone/getZonesBySiteId'
    //url: '/api/Zone'
});