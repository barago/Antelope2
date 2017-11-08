var FicheSecuriteActionView = Backbone.View.extend({
    template: _.template($('#TemplateInfosCorrectives').html()),
    render: function () {

        // Ces instances Javascript se trouvent dans la View Backbone, nous les initialisons donc dans le render de la View.
        $('#datetimepickerDateButoirInitiale').datetimepicker({
            pickTime: false,
            language: 'fr'
        });
        //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
        //$('#datetimepickerDateButoirInitiale').on("dp.change", $.proxy(this.changeDateHeureEvenement, this));


        this.$el.html(this.template(this.model.toJSON()));

    },
    initialize: function () {
        this.render();
    },
    events: {
        //"click #BtnAjoutCause" : "clickBoutonAjoutCause"
        "keyup #AddCauseDescription": "changeAddCauseDescription",
        "click #BtnSaveAddCause": "addCause",
        "keyup .EditCauseDescription": "changeEditCauseDescription",
        "click .BtnEditCause": "editCause",
        "click .BtnDeleteCause": "deleteCause"

    },
    changeAddCauseDescription: function () {
        this.model.get('causeModel').set({ 'Description': $('#AddCauseDescription').val() });
    },
    addCause: function () {

        this.model.get('ficheSecuriteModel').get('causeCollection').create(
            new CauseModel({
                'FicheSecuriteID': this.model.get('ficheSecuriteModel').get('FicheSecuriteID'),
                'Description': this.model.get('causeModel').get('Description'),
                'actionCollection': new ActionCollection()
            }), { async: false, wait: true, success: function () { console.log('PASSAGE SUCCESSSSS') }, error: function () { 'PASSAGE ERROR' } }
        );

        this.model.get('causeModel').clear();
        this.render();
    },
    changeEditCauseDescription: function (ev) {
        var causeToEditId = $(ev.currentTarget).attr('data-causeId');
        this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }).set({ Description: $(ev.currentTarget).val() });

    },
    editCause: function (ev) {

        var causeToEditId = $(ev.currentTarget).attr('data-causeId');

        //Ajout de l'id de l'enregistrement à la volée
        //Il faudrait soit initialiser les Models dans les Collections avec le bon id, soit côté Serveur MVC appeler "id" la clef primaire, simplifiant toute la chaîne d'enregistrement...
        //this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }).id = parseInt(causeToEditId)  //.   get('CauseId');
        // OU ENCORE : Utiliser IdAttribute de Backbone Model !
        this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }).set({ id: parseInt(causeToEditId) });  //.   get('CauseId');

        console.log(this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }));
        this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }).save(null, { async: false, wait: true });
        this.render();
    },
    deleteCause: function (ev) {
        var causeToDeleteId = $(ev.currentTarget).attr('data-causeId');
        this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToDeleteId) }).set({ id: parseInt(causeToDeleteId) });
        this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToDeleteId) }).destroy({ async: false, wait: true, success: function () { console.log('PASSAGE SUCCESSSSS') }, error: function () { 'PASSAGE ERROR' } });
        this.render();
    }



});