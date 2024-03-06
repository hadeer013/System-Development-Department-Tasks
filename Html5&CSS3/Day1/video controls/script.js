window.onload = function () {
    var vid = document.getElementsByTagName("video")[0];


    var btnPlay = document.getElementById("play");
    btnPlay.onclick = function () {
        console.log("play")
        vid.play();
    }

    var btnPause = document.getElementById("pause");
    btnPause.onclick = function () {
        vid.pause();
    }

    var volInput = document.getElementById("volumn");
    volInput.oninput = function () {
        vid.volume = parseInt(volInput.value) / 10;
    }

    var mute = document.getElementById("mute");
    mute.onclick = function () {
        vid.volume = 0;
        volInput.value = 0;
    }

    var speed = document.getElementById("speed");
    speed.oninput = function () {
        vid.playbackRate = speed.value;
    }

    var length = document.getElementById("length");
    var vidDur = document.getElementById("vidDur");
    var vidCur = document.getElementById("vidCur");

    length.setAttribute("max", parseInt(vid.duration));
    vidDur.innerText = parseInt(vid.duration);

    vid.onplay = function () {
        length.value = vidCur.innerText = parseInt(vid.currentTime);
    }

    length.onchange = function () {
        vid.currentTime = vidCur.innerText = length.value;
    }

    var tenPrev = document.getElementById("tenPrev");
    tenPrev.onclick = function () {
        length.value = parseInt(length.value) - 10;
        length.dispatchEvent(new Event('change'));
    }

    var onePrev = document.getElementById("onePrev");
    onePrev.onclick = function () {
        length.value = parseInt(length.value) - 1;
        length.dispatchEvent(new Event('change'));
    }

    var oneNext = document.getElementById("oneNext");
    oneNext.onclick = function () {
        length.value = parseInt(length.value) + 1;
        length.dispatchEvent(new Event('change'));
    }

    var tenNext = document.getElementById("tenNext");
    tenNext.onclick = function () {
        length.value = parseInt(length.value) + 10;
        length.dispatchEvent(new Event('change'));
    }

    vid.onloadedmetadata = function () {
        length.setAttribute("max", vid.duration);
        vidDur.innerText = parseInt(vid.duration);
    }

    vid.addEventListener("timeupdate", function () {
        vidCur.innerText = length.value = parseInt(vid.currentTime);
    })
}