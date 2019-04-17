document.getElementById('sub').addEventListener('click', preven, false);


function preven(evt) {
    var c = document.getElementById('drop').value;
    if (c == "") {
        evt.preventDefault();
    }
}