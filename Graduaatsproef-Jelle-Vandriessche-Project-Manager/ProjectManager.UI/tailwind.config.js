/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './src/**/*.{vue,js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      colors: {
        customGreen: '#5CFF93',
      },
      width: {
        120: '7.5rem', // 120px
        150: '9.375rem', // 150px
        260: '16.25rem', // 260px
        300: '18.75rem', // 300px
        510: '31.875rem', // 510px
        532: '33.25rem', // 532px
        600: '37.5rem', // 600px
        740: '46.25rem', // 740px
      },
      height: {
        26: '6.5rem', // 104px
        160: '10rem', // 160px
        185: '11.563rem', // 185px
        360: '22.5rem', // 360px
        375: '23.438rem', // 375px
        430: '26.875rem', // 430px
        460: '28.75rem', // 460px
        480: '30rem', // 480px
        490: '30.625rem', // 490px
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

