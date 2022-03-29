let voornaamTekenaar = document.getElementsByName('voornaamTekenaar');
let achternaamTekenaar = document.getElementsByName('achternaamTekenaar');
let voornaamAuteur = document.getElementsByName('voornaamAuteur');
let achternaamAuteur = document.getElementsByName('achternaamAuteur');

function addTekenaar(amount) {
    for (let i = 0; i < amount; i++) {
        const voornaamTekenaar = '<input class="form-control" name="voornaamTekenaar" type="text" min="0" maxlength="25" placeholder="Bas"/>';
        const achternaamTekenaar = '<input class="form-control" name="achternaamTekenaar" type="text" min="0" maxlength="25" placeholder="Heymans"/>';
        $('#voornaamTekenaar').append(voornaamTekenaar);
        $('#achternaamTekenaar').append(achternaamTekenaar);
    }
}
function addAuteur(amount){
    for (let i = 0; i < amount; i++) {
        const voornaamAuteur = '<input class="form-control" name="voornaamAuteur" type="text" min="0" maxlength="25" placeholder="Carl"/>';
        const achternaamAuteur = '<input class="form-control" name="achternaamAuteur" type="text" min="0" maxlength="25" placeholder="Barks"/>';
        $('#voornaamAuteur').append(voornaamAuteur);
        $('#achternaamAuteur').append(achternaamAuteur);
    }
}
function verwijderTekenaar(){
document.getElementById("voornaamTekenaar").lastElementChild.remove()
    document.getElementById("achternaamTekenaar").lastElementChild.remove()
}
function verwijderAuteur(){
    document.getElementById("voornaamAuteur").lastElementChild.remove()
    document.getElementById("achternaamAuteur").lastElementChild.remove()
}

function send() {
    let persoonArray = '';
    let auteurArray = '';
    let rolArray = '';
    for (let i = 0; i < voornaamTekenaar.length; i++) {
        persoonArray += voornaamTekenaar[i].value + ',';
        rolArray += 'Tekenaar' + ',';
    }
    for (let i = 0; i < voornaamAuteur.length; i++) {
        auteurArray += voornaamAuteur[i].value + ',';
        rolArray += 'Auteur' + ',';
    }
    persoonArray += '/';
    auteurArray += '/';
    for (let i = 0; i < achternaamTekenaar.length; i++) {
        persoonArray += achternaamTekenaar[i].value + ',';
    }
    for (let i = 0; i < achternaamAuteur.length; i++) {
        auteurArray += achternaamAuteur[i].value + ',';
    }
    document.getElementById('hiddenAuteur').value = auteurArray;
    document.getElementById('hiddenTekenaar').value = persoonArray;
    document.getElementById('hiddenRol').value = rolArray;

}


function  fill(array, auteurarray) {
    const newarray = array.split('/').pop();
    for (let i = 0; i < voornaamTekenaar.length; i++) {
        voornaamTekenaar[i].value = array.split(',', i + 1).pop();
        achternaamTekenaar[i].value = newarray.split(',', i + 1).pop();
    }

    const newarrayAuteur = auteurarray.split('/').pop();
    for (let i = 0; i < voornaamAuteur.length; i++) {
        voornaamAuteur[i].value = auteurarray.split(',', i + 1).pop();
        achternaamAuteur[i].value = newarrayAuteur.split(',', i + 1).pop();
    }
}
