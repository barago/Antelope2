AlerteView = Backbone.View.extend({
    id: 'alerteInnerDiv',
    template: _.template($('#alerteTemplate').html()),
    render: function () {
        this.$el.html(this.template(this.model.toJSON()));
        return this;
    },
    initialize: function () {

        Backbone.applicationEvents.on('alerteInvalid', function (error) {
            this.model.set({ 'alerteHidden': false })
            this.model.set({ 'alerteClass': 'alert alert-danger' })
            this.model.set({ 'alerteMessage': error })

            this.render();
        }, this);

        Backbone.applicationEvents.on('alerteMessageHide', function () {
            this.model.set({ 'alerteHidden': true })
            this.model.set({ 'alerteMessage': '' })

            this.render();
        }, this);

        Backbone.applicationEvents.on('alerteValid', function (message) {
            this.model.set({ 'alerteHidden': false })
            this.model.set({ 'alerteClass': 'alert alert-success' })
            this.model.set({ 'alerteMessage': message })

            this.render();
        }, this);

        this.render();
    },
    events: {


    }
});