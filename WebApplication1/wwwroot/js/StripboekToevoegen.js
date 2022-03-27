function add(amount) {
    for (let i = 0; i < amount; i++) {
        const voornaam = '<input class="form-control" name="voornaamTekenaar" type="text" min="0" maxlength="50" placeholder="Bas"/>';
        const achternaam = '<input class="form-control" name="achternaamTekenaar" type="text" min="0" maxlength="50" placeholder="Heymans"/>';
        $('#voornaamTekenaar').append(voornaam);
        $('#achternaamTekenaar').append(achternaam);
    }
}

function send() {
    let persoonArray = '';
    let voornaamTekenaar = document.getElementsByName('voornaamTekenaar');
    for (let i = 0; i < voornaamTekenaar.length; i++) {
        persoonArray += voornaamTekenaar[i].value + ',';
    }
    persoonArray += '/';
    let achternaamTekenaar = document.getElementsByName('achternaamTekenaar');
    for (let i = 0; i < achternaamTekenaar.length; i++) {
        persoonArray += achternaamTekenaar[i].value + ',';
    }
    persoonArray += ';';
    for (let i = 0; i < voornaamTekenaar.length; i++) {
        persoonArray += 'Tekenaar' + ',';
    }
    document.getElementById('hiddenTekenaar').value = persoonArray;

}


function  fill(array){
    let voornaamTekenaar = document.getElementsByName('voornaamTekenaar');
    for (let i = 0; i < voornaamTekenaar.length; i++) {
        voornaamTekenaar[i].value = array.split(',', i + 1).pop();
    }
    let achternaamTekenaar = document.getElementsByName('achternaamTekenaar');
    for (let i = 0; i < achternaamTekenaar.length; i++) {
        const newarray = array.split('/').pop();
        achternaamTekenaar[i].value = newarray.split(',', i + 1).pop();
    }
}