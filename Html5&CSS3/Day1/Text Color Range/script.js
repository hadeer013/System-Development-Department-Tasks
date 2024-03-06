function ChangeColor() {
    var red = document.getElementById("red").value;
    var green = document.getElementById("green").value;
    var blue = document.getElementById("blue").value;

    var p = document.getElementsByTagName("p")[0];
    p.style.color = "rgb(" + red + ", " + green + ", " + blue + ")";
}
