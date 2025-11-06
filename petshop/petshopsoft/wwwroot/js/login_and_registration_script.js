function openLoginPopup() {
    document.getElementById("loginPopup").classList.remove("d-none");
}

function openRegisterPopup() {
    document.getElementById("registerPopup").classList.remove("d-none");
}

function closePopup() {
    document.getElementById("loginPopup").classList.add("d-none");
    document.getElementById("registerPopup").classList.add("d-none");
}

function switchToRegister(e) {
    e.preventDefault();
    document.getElementById("loginPopup").classList.add("d-none");
    document.getElementById("registerPopup").classList.remove("d-none");
}

function switchToLogin(e) {
    e.preventDefault();
    document.getElementById("registerPopup").classList.add("d-none");
    document.getElementById("loginPopup").classList.remove("d-none");
}
