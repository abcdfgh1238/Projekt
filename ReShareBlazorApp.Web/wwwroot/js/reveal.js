// Efekt "wyłaniania z dołu": elementy z klasą .reveal dostają klasę .is-visible,
// gdy pojawią się w oknie przeglądarki podczas przewijania strony.
(function () {
    // Obserwator sprawdza, czy element jest już widoczny na ekranie
    const observer = new IntersectionObserver(function (entries) {
        entries.forEach(function (entry) {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-visible');   // odpala animację w CSS
                observer.unobserve(entry.target);           // raz wystarczy – przestajemy obserwować
            }
        });
    }, { threshold: 0.12, rootMargin: '0px 0px -40px 0px' });

    // Znajduje nowe elementy .reveal i zaczyna je obserwować
    function scan() {
        document.querySelectorAll('.reveal:not(.is-visible):not([data-reveal-watched])').forEach(function (el) {
            el.setAttribute('data-reveal-watched', '1');
            observer.observe(el);
        });
    }

    // Blazor dorysowuje elementy już po załadowaniu strony – więc patrzymy na zmiany w DOM
    new MutationObserver(scan).observe(document.documentElement, { childList: true, subtree: true });

    document.addEventListener('DOMContentLoaded', scan);
    scan();
})();
