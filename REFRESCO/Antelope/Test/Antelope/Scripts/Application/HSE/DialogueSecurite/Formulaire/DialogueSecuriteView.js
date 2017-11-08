$(function () {
   
    window.DialogueSecuriteView = Backbone.View.extend({

        template: _.template($('#DialogueSecuriteTemplate').html()),
        render: function () {
            this.$el.html(this.template(this.model.toJSON()));
            $('#DateDialogueSecurite').datetimepicker({
                pickTime: false,
                language: 'fr'
            });
            //On écoute les changements sur le DatePicker pour les passer à la fonction Backbone
            $('#DateDialogueSecurite').on("dp.change", $.proxy(this.changeDate, this));
            // TODO : Mettre des dp.hide sur tous les DateTimePickers ! >> Si on ne selectionne rien, il choisit date et heure du jour.
            $('#DateDialogueSecurite').on("dp.hide", $.proxy(this.changeDate, this));
            // TODO : BUG Boostrap, si on n'initialise pas toggle:false, les collapse vont show lorsqu'on fait un hide ...
            // $('.AjoutActionCollapse').collapse({ 'toggle': false });
        },
        fillUtilisateur: function (params) {

            switch (params[0].get('sourceUtilisateurField')) {
                case "Dialogueur1":
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur1': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur1Id': params[0].get('PersonneId') });
                    
                    $('#Dialogueur1Nom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur1').get('Nom'));
                    $('#Dialogueur1Prenom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur1').get('Prenom'));
                          
                    break;
                case "Dialogueur2":
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur2': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur2Id': params[0].get('PersonneId') });

                    $('#Dialogueur2Nom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur2').get('Nom'));
                    $('#Dialogueur2Prenom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur2').get('Prenom'));

                    break;
                case "Dialogueur3":
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur3': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Dialogueur3Id': params[0].get('PersonneId') });

                    $('#Dialogueur3Nom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur3').get('Nom'));
                    $('#Dialogueur3Prenom').val(this.model.get('dialogueSecuriteModel').get('Dialogueur3').get('Prenom'));
                    break;
                case "Entretenu1":
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu1': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu1Id': params[0].get('PersonneId') });

                    $('#Entretenu1Nom').val(this.model.get('dialogueSecuriteModel').get('Entretenu1').get('Nom'));
                    $('#Entretenu1Prenom').val(this.model.get('dialogueSecuriteModel').get('Entretenu1').get('Prenom'));

                    break;
                case "Entretenu2":
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu2': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu2Id': params[0].get('PersonneId') });

                    $('#Entretenu2Nom').val(this.model.get('dialogueSecuriteModel').get('Entretenu2').get('Nom'));
                    $('#Entretenu2Prenom').val(this.model.get('dialogueSecuriteModel').get('Entretenu2').get('Prenom'));

                    break;
                case "Entretenu3":
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu3': params[0] });
                    this.model.get('dialogueSecuriteModel').set({ 'Entretenu3Id': params[0].get('PersonneId') });

                    $('#Entretenu3Nom').val(this.model.get('dialogueSecuriteModel').get('Entretenu3').get('Nom'));
                    $('#Entretenu3Prenom').val(this.model.get('dialogueSecuriteModel').get('Entretenu3').get('Prenom'));

                    break;
            }


        },
        initialize: function () {

            Backbone.applicationEvents.on('selectionUtilisateur', function (params) {
                this.fillUtilisateur(params);
            }, this);

            this.render();
        },
        events: {
            "change #Site": "changeSite",
            "change #Zone": "changeZone",
            "change #Lieu": "changeLieu",
            "change #Thematique": "changeThematique",
            "keyup #Atelier": "changeAtelier",
            "keyup #Contexte": "changeContexte",
            "keyup #Observation": "changeObservation",
            "keyup #Reflexion": "changeReflexion",
            "keyup #Action": "changeAction",
            "click #Enregistrer": "enregistrer",
            "keyup #Dialogueur1Nom": "changeDialogueur1Nom",
            "keyup #Dialogueur1Prenom": "changeDialogueur1Prenom",
            "keyup #Dialogueur2Nom": "changeDialogueur2Nom",
            "keyup #Dialogueur2Prenom": "changeDialogueur2Prenom",
            "keyup #Dialogueur3Nom": "changeDialogueur3Nom",
            "keyup #Dialogueur3Prenom": "changeDialogueur3Prenom",
            "keyup #Entretenu1Nom": "changeEntretenu1Nom",
            "keyup #Entretenu1Prenom": "changeEntretenu1Prenom",
            "keyup #Entretenu2Nom": "changeEntretenu2Nom",
            "keyup #Entretenu2Prenom": "changeEntretenu2Prenom",
            "keyup #Entretenu3Nom": "changeEntretenu3Nom",
            "keyup #Entretenu3Prenom": "changeEntretenu3Prenom",
            "click #ActiveDirectoryDialogueur1Recherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryDialogueur2Recherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryDialogueur3Recherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryEntretenu1Recherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryEntretenu2Recherche": "showActiveDirectoryUtilisateurRecherche",
            "click #ActiveDirectoryEntretenu3Recherche": "showActiveDirectoryUtilisateurRecherche",
            "change #ServiceTypeDialogueur1": "changeServiceTypeDialogueur1",
            "change #ServiceTypeDialogueur2": "changeServiceTypeDialogueur2",
            "change #ServiceTypeDialogueur3": "changeServiceTypeDialogueur3",
            "change #ServiceTypeEntretenu1": "changeServiceTypeEntretenu1",
            "change #ServiceTypeEntretenu2": "changeServiceTypeEntretenu2",
            "change #ServiceTypeEntretenu3": "changeServiceTypeEntretenu3",
            "click #ImprimerFicheSecurite": "imprimerFicheSecurite"
        },
        imprimerFicheSecurite: function () {

            window.print();
        },
        changeAtelier: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Atelier': $('#Atelier').val() });
        },
        changeObservation: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Observation': $('#Observation').val() });
        },
        changeContexte: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Contexte': $('#Contexte').val() });
        },
        changeReflexion: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Reflexion': $('#Reflexion').val() });
        },
        changeAction: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Action': $('#Action').val() });
        },
        changeSite: function () {

            this.model.get('dialogueSecuriteModel').set({ 'SiteId': $('#Site').val() });

            this.model.get('zoneCollection').url = '/api/action/zone/getZonesBySiteId/' + this.model.get('dialogueSecuriteModel').get('SiteId');

            this.model.get('zoneCollection').fetch({ async: false });

            this.model.get('zoneCollection').each(function (zone, index) {
                zone.set({ 'Nom': zone.get('ZoneType').Nom });
            });

            this.render();
        },
        changeZone: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ZoneId': $('#Zone').val() });

            this.model.get('lieuCollection').url = '/api/action/lieu/getLieuxByZoneId/' + this.model.get('dialogueSecuriteModel').get('ZoneId');

            this.model.get('lieuCollection').fetch({ async: false });

            this.render();
        },
        changeLieu: function () {
            this.model.get('dialogueSecuriteModel').set({ 'LieuId': $('#Lieu').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeThematique: function () {

            this.model.get('dialogueSecuriteModel').set({ 'ThematiqueId': $('#Thematique').val() });

            if ($("#Thematique option:selected").text().trim() === 'Audit conduite chariot') {

                this.model.get('dialogueSecuriteModel').set({ 'ObservationBackup': this.model.get('dialogueSecuriteModel').get('Observation')});
                this.model.get('dialogueSecuriteModel').set({ 'Observation': '-Conduite avec fourche basse  \n-Klaxon aux intersections \n-Port de la ceinture de sécurité \n-Fiche de vérif. chariot remplie \n-Feux allumés \n-Ralentissement aux endroits' });

            }
            else{
                this.model.get('dialogueSecuriteModel').set({ 'Observation': this.model.get('dialogueSecuriteModel').get('ObservationBackup') });
            }
            this.render();
        },
        changeDate: function () {
            this.model.get('dialogueSecuriteModel').set({ 'Date': this.dateFormatMVC($('#DateDialogueSecuriteInput').val()) + 'T' + '00:00:00.0' });
            this.model.get('dialogueSecuriteModel').set({ 'DateJavascript': $('#DateDialogueSecuriteInput').val() });
        },
        dateFormatMVC: function (date) {
            // De date FR à DateTime
            var dateFormated = date.substring(6, 10) + '-' + date.substring(3, 5) + '-' + date.substring(0, 2);
            return dateFormated;
        },
        changeDialogueur1Nom: function(){
            this.model.get('dialogueSecuriteModel').get('Dialogueur1').set({ 'Nom': $('#Dialogueur1Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeDialogueur1Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Dialogueur1').set({ 'Prenom': $('#Dialogueur1Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeDialogueur2Nom: function () {
            this.model.get('dialogueSecuriteModel').get('Dialogueur2').set({ 'Nom': $('#Dialogueur2Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeDialogueur2Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Dialogueur2').set({ 'Prenom': $('#Dialogueur2Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeDialogueur3Nom: function () {
            this.model.get('dialogueSecuriteModel').get('Dialogueur3').set({ 'Nom': $('#Dialogueur3Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeDialogueur3Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Dialogueur3').set({ 'Prenom': $('#Dialogueur3Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu1Nom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu1').set({ 'Nom': $('#Entretenu1Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu1Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu1').set({ 'Prenom': $('#Entretenu1Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu2Nom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu2').set({ 'Nom': $('#Entretenu2Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu2Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu2').set({ 'Prenom': $('#Entretenu2Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu3Nom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu3').set({ 'Nom': $('#Entretenu3Nom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeEntretenu3Prenom: function () {
            this.model.get('dialogueSecuriteModel').get('Entretenu3').set({ 'Prenom': $('#Entretenu3Prenom').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeDialogueur1: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeDialogueur1Id': $('#ServiceTypeDialogueur1').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeDialogueur2: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeDialogueur2Id': $('#ServiceTypeDialogueur2').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeDialogueur3: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeDialogueur3Id': $('#ServiceTypeDialogueur3').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeEntretenu1: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeEntretenu1Id': $('#ServiceTypeEntretenu1').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeEntretenu2: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeEntretenu2Id': $('#ServiceTypeEntretenu2').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        changeServiceTypeEntretenu3: function () {
            this.model.get('dialogueSecuriteModel').set({ 'ServiceTypeEntretenu3Id': $('#ServiceTypeEntretenu3').val() });
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        showActiveDirectoryUtilisateurRecherche: function (ev) {

            var rechercheActiveDirectoryView = new window.RechercheActiveDirectoryView({
            });
            rechercheActiveDirectoryView.model.set({ "sourceUtilisateurField": $(ev.currentTarget).attr('data-SourceUtilisateurField') });
            if ($(ev.currentTarget).attr('data-actionid') != null) {
                rechercheActiveDirectoryView.model.set({ "sourceId": $(ev.currentTarget).attr('data-actionid') })
            };
            rechercheActiveDirectoryView.show()

            //switch (ev.currentTarget.id) {
            //    case "ActiveDirectoryDialogueur1Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'DIALOGUEUR1' });
            //        break;
            //    case "ActiveDirectoryDialogueur2Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'DIALOGUEUR2' });
            //        break;
            //    case "ActiveDirectoryDialogueur3Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'DIALOGUEUR3' });
            //        break;
            //    case "ActiveDirectoryEntretenu1Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'ENTRETENU1' });
            //        break;
            //    case "ActiveDirectoryEntretenu2Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'ENTRETENU2' });
            //        break;
            //    case "ActiveDirectoryEntretenu3Recherche":
            //        this.model.set({ 'sourceActiveDirectoryUtilisateurRecherche': 'ENTRETENU3' });
            //        break;
            //}

            //rechercheActiveDirectoryView = new RechercheActiveDirectoryView({
            //    model: this.model
            //});
            //rechercheActiveDirectoryView.show()
            Backbone.applicationEvents.trigger('alerteMessageHide');
        },
        enregistrer: function () {
            this.model.get('dialogueSecuriteModel').on("invalid", function (model, error) {
                Backbone.applicationEvents.trigger('alerteInvalid', error);
            });
            this.model.get('dialogueSecuriteModel').save(null,
                {
                    async: false, wait: true,
                    success: _.bind(function (model, response) {
                        //this.model.set({ 'actionModel': new ActionModel() });
                        //this.model.get('actionModel').set({ 'Responsable': new ResponsableModel() });
                        //this.model.get('actionModel').set({ 'Verificateur': new VerificateurModel() });
                        //this.model.get('actionModel').set({ 'NonConformiteId': this.model.get('nonConformiteModel').get('Id') });

                        this.model.get('dialogueSecuriteModel').set({ 'Dialogueur1': new PersonneModel(response.Dialogueur1) });
                        this.model.get('dialogueSecuriteModel').set({ 'Dialogueur2': new PersonneModel(response.Dialogueur2) });
                        this.model.get('dialogueSecuriteModel').set({ 'Dialogueur3': new PersonneModel(response.Dialogueur3) });
                        this.model.get('dialogueSecuriteModel').set({ 'Entretenu1': new PersonneModel(response.Entretenu1) });
                        this.model.get('dialogueSecuriteModel').set({ 'Entretenu2': new PersonneModel(response.Entretenu2) });
                        this.model.get('dialogueSecuriteModel').set({ 'Entretenu3': new PersonneModel(response.Entretenu3) });

                        Backbone.applicationEvents.trigger('DialogueSecuriteEnregistree');
                        this.render(this.model.get('dialogueSecuriteModel'));
                        Backbone.applicationEvents.trigger('alerteValid', 'Le Dialogue Sécurité \"' + this.model.get('dialogueSecuriteModel').get('Code') + '\" est enregistrée.');
                    }, this),
                    error: _.bind(function (model, response) {
                        Backbone.applicationEvents.trigger('alerteInvalid', 'Une erreur est survenue sur l\'ajout du Dialogue Sécurité');
                    }, this)

                });
        }

    });
   
});