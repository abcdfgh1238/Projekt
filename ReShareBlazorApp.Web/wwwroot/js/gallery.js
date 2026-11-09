// Galeria na stronie ogłoszenia: klik w miniaturę podmienia duże zdjęcie.
// Nasłuchujemy na całym dokumencie, więc działa też po nawigacji Blazora.
document.addEventListener('click', function (e) {
    var thumb = e.target.closest('[data-gallery-thumb]');
    if (!thumb) return;

    var main = document.getElementById('rs-gallery-main');
    if (!main) return;

    main.src = thumb.getAttribute('data-src');
    document.querySelectorAll('[data-gallery-thumb]').forEach(function (el) {
        el.classList.toggle('active', el === thumb);
    });
});
