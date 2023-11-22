<template>
    <nav
      class="navbar navbar-expand-lg"
      :class="[`navbar-${theme}`, `bg-${theme}`, 'navbar', 'navbar-expand-lg']"
    >
      <div class="container-fluid">
        <a href="#" class="navbar-brand">My Vue</a>
        <ul class="navbar-nav me-auto mb-2 mb-lg-0 bg-red">
          <navbar-link
            v-for="(page, index) in publishedPages" class="nav-item" :key="index"
            :page="page"
            :index="index"
          ></navbar-link>

          <li>
            <router-link
              to="/pages/create"
              aria-current="page"
              active-class="active"
              class="nav-link"
            >
                Create Page
            </router-link>
          </li>

        </ul>
        <form class="d-flex">
          <button class="btn btn-primary" @click.prevent="changeTheme()">
            Toggle Navbar
          </button>
        </form>
      </div>
    </nav>
</template>

<script>
import NavbarLink from './NavbarLink.vue';

export default {
    components: {
        NavbarLink
    },
    watch: {
      pages: {
        handler: 'updatePages',
        deep: true,
      },
    },
    created() {
      this.GetThemeSetting();

      this.pages = this.$pages.getAllPages();
    },
    computed: {
      publishedPages() {
        return this.pages.filter(p => p.published);
      }
    },
    data() {
        return {
            theme: "dark",
            pages: []
        };
    },
    methods: {
        changeTheme() {
            let theme = "light";

            if (this.theme == "light") {
                theme = "dark";
            }

            this.theme = theme;
            this.storeThemeSetting();
        },
        storeThemeSetting() {
          localStorage.setItem('theme', this.theme);
        },
        GetThemeSetting() {
          let theme = localStorage.getItem('theme');

          if (theme) {
            this.theme = theme;
          }
        },
        updatePages() {
          console.log('Pages updated in Navbar:', this.pages);
        }
    },
}
</script>