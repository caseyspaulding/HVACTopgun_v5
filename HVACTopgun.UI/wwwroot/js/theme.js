export function setTheme(theme) {
    if (theme === 'dark') {
        document.documentElement.classList.add('dark');
    } else if (theme === 'light') {
        document.documentElement.classList.remove('dark');
    }
}

function toggleMobileMenu() {
    var mobileMenu = document.getElementById('mobile-menu');
    if (mobileMenu.classList.contains('hidden')) {
        mobileMenu.classList.remove('hidden');
    } else {
        mobileMenu.classList.add('hidden');
    }
}

function loadscript () {
    var script = document.createElement('script');
    script.src = '_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js';
    script.type = 'text/javascript';
    document.body.appendChild(script);
}