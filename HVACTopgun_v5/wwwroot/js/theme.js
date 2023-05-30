export function setTheme(theme) {
    if (theme === 'dark') {
        document.documentElement.classList.add('dark');
        
    } else if (theme === 'light') {
        document.documentElement.classList.remove('dark');
        
    }
}

// Initialization for ES Users
import {
    Carousel,
    initTE,
} from "tw-elements";

initTE({ Carousel });

