var page =  require('webpage').create(),
            system = require('system'),
            address, output;

// Récupération des paramètres: 
//      - args[1]: adresse page web en entrée
//      - args[2]: paramètres
//      - args[3]: nom image en sortie

address = system.args[1];
data = system.args[2];
output = system.args[3];

console.log('début programme saveImage.js')

// ID - PassWord

var postBody = {
    user: 'REFRESCO\rvissyrias',
    password: 'Stargate(42)',
    data: data
};

//page.settings.userName = 'rvissyrias';
//page.settings.password = 'Stargate(42)';

// Paramètres images: taille zone capturée - taille image finale

page.viewportSize = {
    width: 1024,
    height: 768
};
page.paperSize = {
    format: 'A4',
    orientation: 'landscape',
    margin: '1cm'
};

// Chargement de la page web et extraction de l'image

page.open(address, postBody, function () {

    page.render(output + '.jpeg');
    phantom.exit();

});