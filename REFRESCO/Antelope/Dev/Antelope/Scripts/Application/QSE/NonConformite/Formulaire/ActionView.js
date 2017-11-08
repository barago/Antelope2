$(function () {

    window.ActionView = Backbone.View.extend({


        template: _.template($('#ActionTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            $('#AddActionDateButoireInitiale').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateButoireInitiale').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateButoireNouvelle').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionRealiseDate').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            $('.EditActionDateVerification').datetimepicker({
                pickTime: false,
                language: 'fr'
            });

            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#AddActionDateButoireInitiale').on("dp.change", $.proxy(this.changeAddActionDateButoireInitiale, this));
            // Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#AddActionDateButoireInitiale').on("dp.hide", $.proxy(this.changeAddActionDateButoireInitiale, this));
            $('.EditActionDateButoireInitiale').on("dp.change", $.proxy(this.changeEditActionDateButoireInitiale, this));
            $('.EditActionDateButoireInitiale').on("dp.hide", $.proxy(this.changeEditActionDateButoireInitiale, this));
            $('.EditActionDateButoireNouvelle').on("dp.change", $.proxy(this.changeEditActionDateButoireNouvelle, this));
            $('.EditActionDateButoireNouvelle').on("dp.hide", $.proxy(this.changeEditActionDateButoireNouvelle, this));
            $('.EditActionRealiseDate').on("dp.change", $.proxy(this.changeEditActionRealiseDate, this));
            $('.EditActionRealiseDate').on("dp.hide", $.proxy(this.changeEditActionRealiseDate, this));
            $('.EditActionDateVerification').on("dp.change", $.proxy(this.changeEditActionVerificationDate, this));
            $('.EditActionDateVerification').on("dp.hide", $.proxy(this.changeEditActionVerificationDate, this));

        },
        fillUtilisateur: function (params) {
            switch (params[0].get('sourceUtilisateurField')) {
                case "AddActionResponsable":
                    this.model.get('actionModel').set({ 'Responsable': params[0] });
                    this.model.get('actionModel').set({ 'ResponsableId': params[0].get('PersonneId') });
                    
                    $('#AddActionResponsableNom').val(this.model.get('actionModel').get('Responsable').get('Nom'));
                    $('#AddActionResponsablePrenom').val(this.model.get('actionModel').get('Responsable').get('Prenom'));
                          
                    break;
                case "AddActionVerificateur":
                    this.model.get('actionModel').set({ 'Verificateur': params[0] });
                    this.model.get('actionModel').set({ 'VerificateurId': params[0].get('PersonneId') });
                    
                    $('#AddActionVerificateurNom').val(this.model.get('actionModel').get('Verificateur').get('Nom'));
                    $('#AddActionVerificateurPrenom').val(this.model.get('actionModel').get('Verificateur').get('Prenom'));

                    break;
                case "EditActionResponsable":
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).set({ 'Responsable': params[0] });
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).set({ 'ResponsableId': params[0].get('PersonneId') });

                    $('#EditActionResponsableNom' + parseInt(params[1])).val(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).get('Responsable').get('Nom'));
                    $('#EditActionResponsablePrenom' + parseInt(params[1])).val(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).get('Responsable').get('Prenom'));
                    break;
                case "EditActionVerificateur":
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).set({ 'Verificateur': params[0] });
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).set({ 'VerificateurId': params[0].get('PersonneId') });

                    $('#EditActionVerificateurNom' + parseInt(params[1])).val(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).get('Verificateur').get('Nom'));
                    $('#EditActionVerificateurPrenom' + parseInt(params[1])).val(this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(params[1]) }).get('Verificateur').get('Prenom'));
                    break;
            }


        },
        initialize: function () {

            // Ecoute du Popup de selection utilisateur, doit traiter quel est le champ concerné par la demande de sélection
            Backbone.applicationEvents.on('selectionUtilisateur', function (params) {
                this.fillUtilisateur(params);
            }, this);

            Backbone.applicationEvents.on('NonConformiteEnregistree', function () {
                this.render();
            }, this);


            this.render();
        },
        events: {
            "keyup #AddActionTitre": "changeAddActionTitre",
            "click #BtnAddAction": "hideShow",
            "keyup #AddActionDescription": "changeAddActionDescription",
            "keyup #AddActionCritere": "changeAddActionCritere",
            "click #ActiveDirectoryAddActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryAddActionVerificateurRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click .ActiveDirectoryEditActionResponsableRecherche": "showActiveDirectoryUtilisateurRecherche",
            "click .ActiveDirectoryEditActionVerificateurRecherche": "showActiveDirectoryUtilisateurRecherche",
            "keyup #AddActionDateButoireInitiale": "changeAddActionDateButoireInitiale",
            "click #BtnAddActionEnregistrer": "saveAddAction",
            "keyup .EditActionTitre": "changeEditActionTitre",
            "click .BtnEditActionDelete": "deleteEditAction",
            "click .BtnEditActionSave": "saveEditAction",
            "keyup .EditActionDescription": "changeEditActionDescription",
            "keyup .EditActionAvancement": "changeEditActionAvancement",
            "keyup .EditActionCritere": "changeEditActionCritere",
            "keyup .EditActionCommentaire": "changeEditActionCommentaire",
            "keyup .EditActionResponsableNom": "changeEditActionResponsableNom",
            "keyup .EditActionResponsablePrenom": "changeEditActionResponsablePrenom",
            "keyup .EditActionDateButoireInitiale": "changeEditActionDateButoireInitiale",
            "keyup .EditActionDateButoireNouvelle": "changeEditActionDateButoireNouvelle",
            "keyup .InputEditActionRealiseDate": "changeEditActionRealiseDate",
            "keyup .EditActionDateVerificationInput": "changeEditActionVerificationDate",


         

        },
        hideShow: function (ev) {
            $('.AjoutActionCollapse').collapse('toggle');
        },
        changeDateNonConformite: function () {
            this.model.get('actionModel').set({ 'DateButoireInitiale': this.dateFormatMVC($('#AddActionDateButoir').val()) });

        },
        dateFormatMVC: dateTimeUtils.dateTimeFormatMVC,
        changeAddActionTitre: function () {
            this.model.get('actionModel').set({ 'Titre': $('#AddActionTitre').val() });
        },
        changeAddActionDescription: function () {
            this.model.get('actionModel').set({ 'Description': $('#AddActionDescription').val() });
        },
        changeAddActionCritere: function () {
            this.model.get('actionModel').set({ 'CritereEfficaciteVerification': $('#AddActionCritere').val() });
        },
        showActiveDirectoryUtilisateurRecherche: function (ev) {

            //TODO :  Créer un constructeur prenant "sourceUtilisateurField" en param. pour créer ce qui suit
            var rechercheActiveDirectoryView = new window.RechercheActiveDirectoryView({
            });
            rechercheActiveDirectoryView.model.set({ "sourceUtilisateurField": $(ev.currentTarget).attr('data-SourceUtilisateurField') });
            if ($(ev.currentTarget).attr('data-actionid') != null) {
                rechercheActiveDirectoryView.model.set({ "sourceId": $(ev.currentTarget).attr('data-actionid') })
            };
            rechercheActiveDirectoryView.show()
        },
        changeAddActionDateButoireInitiale: function (ev) {
            this.model.get('actionModel').set({ 'DateButoireInitiale': this.dateFormatMVC($('#AddActionDateButoireInitialeInput').val())});
            this.model.get('actionModel').set({ 'DateButoireInitialeJavascript': $('#AddActionDateButoireInitialeInput').val() });
        },
        saveAddAction: function(){

            this.model.get('actionModel').set({ NonConformiteId: this.model.get('nonConformiteModel').get('Id') });
            var actionToAdd = this.model.get('actionModel');
            console.log(actionToAdd);
            var actionAdded = this.model.get('nonConformiteModel').get('actionCollection').create(
                    new ActionModel(actionToAdd.toJSON()), {
                        async: false, wait: true,
                        success: _.bind(function (model, response) {
                            model.set({ 'Responsable': new ResponsableModel(model.get('Responsable')) });
                            model.set({ 'Verificateur': new ResponsableModel(model.get('Verificateur')) });

                            this.model.get('actionModel').clear();
                            this.model.get('actionModel').set({ 'Responsable': new ResponsableModel() });
                            this.model.get('actionModel').set({ 'Verificateur': new ResponsableModel() });

                            this.render();

                            Backbone.applicationEvents.trigger('alerteValid', 'l\' action \"' + model.get('Titre') + '\" a été ajoutée');

                        }, this),
                        error: _.bind(function (model, response) {
                            Backbone.applicationEvents.trigger('alerteInvalid', 'Une erreur est survenue sur l\'ajout de l\'action');
                        }, this)
                    });

            if (actionAdded.validationError != null) {
                Backbone.applicationEvents.trigger('alerteInvalid', actionAdded.validationError);

            } else {

            }

        },
        deleteEditAction: function(ev){
            var confirmation = confirm("Êtes-vous sûr de vouloir supprimer cette action ?");
            if (confirmation == true) {
                var actionToDeleteId = $(ev.currentTarget).attr('data-actionid');
                this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToDeleteId) }).set({ id: parseInt(actionToDeleteId) });
                this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToDeleteId) }).destroy({
                    async: false, wait: true,
                    success: _.bind(function (model, response) {
                        this.render();
                        Backbone.applicationEvents.trigger('alerteValid', 'l\' action \"' + model.get('Titre') + '\" a été supprimée');
                    }, this),
                    error: _.bind(function (model, response) {
                        Backbone.applicationEvents.trigger('alerteInvalid', 'Une erreur est survenue sur la suppression de l\'action');
                    }, this)
                });
                
            };
        },
        saveEditAction: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionId');

            //Ajout de l'id de l'enregistrement à la volée
            //Il faudrait soit initialiser les Models dans les Collections avec le bon id, soit côté Serveur MVC appeler "id" la clef primaire, simplifiant toute la chaîne d'enregistrement...
            //this.model.get('ficheSecuriteModel').get('causeCollection').findWhere({ CauseQSEId: parseInt(causeToEditId) }).id = parseInt(causeToEditId)  //.   get('CauseId');
            // OU ENCORE : Utiliser IdAttribute de Backbone Model !
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ id: parseInt(actionToEditId) });  //.   get('ActionId');

            var actionToEdit = this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) });
            actionToEdit.save(null, { async: false, wait: true, 
                success: _.bind(function (model, response) {
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Responsable': new ResponsableModel(response.Responsable) });
                    this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Verificateur': new VerificateurModel(response.Verificateur) });

                    this.render();
                    Backbone.applicationEvents.trigger('alerteValid', 'l\' action a été mise à jour');
                }, this),
                error: _.bind(function (model, response) {
                    Backbone.applicationEvents.trigger('alerteInvalid', 'Une erreur est survenue sur l\'édition de l\'action');
                }, this)
            });

            if (actionToEdit.validationError != null) {
                Backbone.applicationEvents.trigger('alerteInvalid', actionToEdit.validationError);

            } else {

            }
            
        },
        changeEditActionTitre: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Titre': $(ev.currentTarget).val() });
        },
        changeEditActionDateButoireInitiale: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireInitiale': this.dateFormatMVC($('#InputEditActionDateButoireInitiale' + actionToEditId).val())});
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireInitialeJavascript': $('#InputEditActionDateButoireInitiale' + actionToEditId).val() });
        },
        changeEditActionDateButoireNouvelle: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireNouvelle': this.dateFormatMVC($('#InputEditActionDateButoireNouvelle' + actionToEditId).val())});
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'DateButoireNouvelleJavascript': $('#InputEditActionDateButoireNouvelle' + actionToEditId).val() });
        },
        changeEditActionDescription: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Description': $(ev.currentTarget).val() });
        },
        changeEditActionAvancement: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'Avancement': $(ev.currentTarget).val() });
        },
        changeEditActionRealiseDate: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');

            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'RealiseDate': ($('#InputEditActionRealiseDate'  + actionToEditId).val() == "") ? null : this.dateFormatMVC($('#InputEditActionRealiseDate' + actionToEditId).val())});
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'RealiseDateJavascript': $('#InputEditActionRealiseDate' + actionToEditId).val() });
            
        },
        changeEditActionVerificationDate: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            console.log('tyiryuj');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'VerifieDate': ($('#EditActionDateVerificationInput' + actionToEditId).val() == "") ? null : this.dateFormatMVC($('#EditActionDateVerificationInput' + actionToEditId).val())});
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'VerifieDateJavascript': $('#EditActionDateVerificationInput' + actionToEditId).val() });
        },
        changeEditActionCritere: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'CritereEfficaciteVerification': $(ev.currentTarget).val() });
        },
        changeEditActionCommentaire: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).set({ 'CommentaireEfficaciteVerification': $(ev.currentTarget).val() });
        },
        changeEditActionResponsableNom: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'Nom': $(ev.currentTarget).val() });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'PersonneId': 0 });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'ResponsableId': null });
        },
        changeEditActionResponsablePrenom: function (ev) {
            var actionToEditId = $(ev.currentTarget).attr('data-actionid');
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'Prenom': $(ev.currentTarget).val() });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'PersonneId': 0 });
            this.model.get('nonConformiteModel').get('actionCollection').findWhere({ ActionQSEId: parseInt(actionToEditId) }).get('Responsable').set({ 'ResponsableId': null });
        }
    });

});
