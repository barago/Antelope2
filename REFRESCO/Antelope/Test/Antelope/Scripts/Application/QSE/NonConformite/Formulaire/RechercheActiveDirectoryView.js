$(function () {

    // !!! Penser à importer RechercheActiveDirectoryModel.js dans le HTML du programme principal, sinon ne marchera pas !!!
    var rechercheActiveDirectoryModel = new RechercheActiveDirectoryModel();
    rechercheActiveDirectoryModel.set({ 'rechercheActiveDirectoryCollection': new RechercheActiveDirectoryCollection() })
    window.RechercheActiveDirectoryView = Backbone.View.extend({

        model: rechercheActiveDirectoryModel,
        id: 'ActiveDirectoryUtilisateurModal',
        className: 'modal fade',
        template: _.template($('#RechercheActiveDirectory').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));
            return this;
        },
        initialize: function () {
            //this.model.set({ 'Nom': "" });
            //this.model.set({ 'Prenom': "" });
            this.render();
        },
        events: {
            "click #RechercheADUtilisateur": "rechercheADUtilisateur",
            "keyup #NomRecherche": "nomChange",
            "keyup #PrenomRecherche": "prenomChange",
            "click .BoutonChoixUtilisateurActiveDirectory": "choixUtilisateurActiveDirectory",
            'hidden.bs.modal': 'teardown'
        },
        show: function () {
            this.$el.modal('show');
        },
        teardown: function () {
            this.$el.data('modal', null);
            this.remove();
            Backbone.applicationEvents.trigger('rechercheActiveDirectoryViewHidden');
        },
        nomChange: function () {
            var nomToSet = $('#NomRecherche').val() == "" ? "undefined" : $('#NomRecherche').val()
            this.model.set({ 'Nom': nomToSet });

        },
        prenomChange: function () {
            var prenomToSet = $('#PrenomRecherche').val() == "" ? "undefined" : $('#PrenomRecherche').val()
            this.model.set({ 'Prenom': prenomToSet });

        },
        rechercheADUtilisateur: function () {
            this.model.get('rechercheActiveDirectoryCollection').url = '/api/action/ActiveDirectoryUtilisateur/GetActiveDirectoryUtilisateurByNomPrenom/0/' + this.model.get('Nom') + '/' + this.model.get('Prenom')

            // /!\ ASYNC : FALSE >>> Si true, la page se raffraichie sans attendre la mise à jour du model (anciennes données affichées)
            this.model.get('rechercheActiveDirectoryCollection').fetch({ async: false });
            this.render();

        },
        choixUtilisateurActiveDirectory: function (ev) {
            var utilisateurSelectionne = this.model.get('rechercheActiveDirectoryCollection').find(
                function (model) { return model.get('PersonneId') == $(ev.currentTarget).attr('id'); }
            );
            this.model.set({ "utilisateurSelectionne": utilisateurSelectionne });
            this.model.get('utilisateurSelectionne').set({ "sourceUtilisateurField": this.model.get('sourceUtilisateurField') });

            Backbone.applicationEvents.trigger('selectionUtilisateur', [this.model.get('utilisateurSelectionne'), this.model.get('sourceId')]);


            this.$el.modal('hide');

        }

    });

});