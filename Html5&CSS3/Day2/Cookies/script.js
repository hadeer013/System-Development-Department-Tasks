(function (root, CookieFactory) {
    root.CookiePolyfill = CookieFactory();
})(this, function () {

    var Cookie = {}
    Cookie.CreateCookie = function CreateCook(key, value, date) {
        if (date) {
            localStorage.setItem(key, value)
        } else {
            sessionStorage.setItem(key, value)
        }
    }

    Cookie.GetCookie = function GetCook(key) {
        if (localStorage.getItem(key))
            return localStorage.getItem(key)
        else if (sessionStorage.getItem(key))
            return sessionStorage.getItem(key)
        else
            console.log("No such key found")
    }

    Cookie.RemoveCookie = function RemoveCook(key) {
        if (localStorage.getItem(key))
            return localStorage.removeItem(key)
        else if (sessionStorage.getItem(key))
            return sessionStorage.removeItem(key)
        else
            console.log("No such key found")
    }

    Cookie.GetCookies = function getAllStorage() {
        var allStorage = {};

        for (var i = 0; i < localStorage.length; i++) {
            var key = localStorage.key(i);
            allStorage[key] = localStorage.getItem(key);
        }

        for (var i = 0; i < sessionStorage.length; i++) {
            var key = sessionStorage.key(i);
            allStorage[key] = sessionStorage.getItem(key);
        }

        return allStorage;
    }


    Cookie.ClearCookies = function ClearCook() {
        localStorage.clear();
        sessionStorage.clear();
    }

    return Cookie;
})