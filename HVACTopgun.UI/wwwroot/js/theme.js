window.openModal = (id) => document.getElementById(id).showModal();
window.closeModal = (id) => document.getElementById(id).close();

export function setTheme(theme) {
    if (theme === 'dark') {
        document.documentElement.classList.add('dark');
    } else if (theme === 'light') {
        document.documentElement.classList.remove('dark');
    }
}
function scrollEventArgsCreator(event) {
    return {
        scrollPosition: window.scrollY || document.documentElement.scrollTop
    };
}
function toggleBanner() {
    var scrollPosition = window.scrollY;
    var banner = document.querySelector('.bg-blue-700');
    if (scrollPosition > 50) { // You can adjust this value
        banner.style.display = 'none';
    } else {
        banner.style.display = 'block';
    }
}

window.scrollFunctions = {
    registerScroll: function (dotNetObject) {
        window.addEventListener("scroll", function () {
            var scrollY = window.scrollY || document.documentElement.scrollTop;
            dotNetObject.invokeMethodAsync("HandleScrollEvent", scrollY);
        });
    }
};
function toggleMobileMenu() {
    var mobileMenu = document.getElementById('mobile-menu');
    if (mobileMenu.classList.contains('hidden')) {
        mobileMenu.classList.remove('hidden');
    } else {
        mobileMenu.classList.add('hidden');
    }
}

function loadscript() {
    var script = document.createElement('script');
    script.src = '_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js';
    script.type = 'text/javascript';
    document.body.appendChild(script);
}

window.toggleDrawer = () => {
    const drawer = document.querySelector('.relative.bg-white.h-full.transform.transition-transform.duration-300.ease-in-out');
    drawer.style.transform = drawer.style.transform === 'translateX(0)' ? 'translateX(-100%)' : 'translateX(0)';
}