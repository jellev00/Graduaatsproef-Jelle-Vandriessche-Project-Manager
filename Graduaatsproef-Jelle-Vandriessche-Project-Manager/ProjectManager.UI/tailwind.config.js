/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './src/App.vue',
    './src/pages/Home.vue',
    './src/pages/Projects.vue',
    './src/pages/Tasks.vue',
  ],
  theme: {
    extend: {
      colors: {
        customGreen: '#5CFF93',
      },
      width: {
        510: '31.875rem', // 510px
        532: '33.25rem', // 532px
        740: '46.25rem', // 740px
      },
      height: {
        26: '6.5rem', // 104px
        160: '10rem', // 150px
        375: '23.438rem', // 375px
        460: '28.75rem', // 460px
        480: '30rem', // 480px
      },
      borderRadius: {
        50: '3.125rem', // 50px
      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}

