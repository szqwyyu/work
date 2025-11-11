function openLoginPopup() {
    const overlay = document.getElementById("authPopup");
    overlay.classList.remove("d-none");
    document.getElementById("loginPopup").classList.add("active");
    document.getElementById("registerPopup").classList.remove("active");
}

function openRegisterPopup() {
    const overlay = document.getElementById("authPopup");
    overlay.classList.remove("d-none");
    document.getElementById("registerPopup").classList.add("active");
    document.getElementById("loginPopup").classList.remove("active");
}

function closePopup() {
    const overlay = document.getElementById("authPopup");
    overlay.classList.add("d-none");
}

function switchToRegister(e) {
    e.preventDefault();
    document.getElementById("loginPopup").classList.remove("active");
    document.getElementById("registerPopup").classList.add("active");
}

function switchToLogin(e) {
    e.preventDefault();
    document.getElementById("registerPopup").classList.remove("active");
    document.getElementById("loginPopup").classList.add("active");
}
