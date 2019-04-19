var btn = document.getElementById("btnLink");
var target = document.getElementById("showOnBtnClick");

btn.onclick = function () {
    if (target.style.display == "none") {
        target.style.display = "flex";
        target.style.alignItems = "center";
        target.style.justifyContent = "center";
        btn.innerHTML = "Hide Form";
    }
    else {
        target.style.display = "none";
        btn.innerHTML = "Show Form";
    }
}
