/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: 'jit',
    
    content: ['./**/*.{razor,html}',
        './node_modules/flowbite/**/*.js',
        '../{Pages,Shared}/**/*.{cshtml,razor,cs,css}'
    ],

    theme: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/typography'),
        require('flowbite/plugin'),
    ]
}
