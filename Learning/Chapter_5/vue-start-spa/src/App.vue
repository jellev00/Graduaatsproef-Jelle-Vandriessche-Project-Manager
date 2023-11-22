<template>
    <Navbar
      :pages="pages"
      :active-page="activePage"
    >
    </Navbar>
    <div v-show="false">
        hide this content
    </div>
    <PageViewer
        v-if="pages.length > 0"
        :page="pages[activePage]"
    > 
    </PageViewer>
    <create-page
        :page-created="pageCreated"
    ></create-page>
</template>

<script>
import PageViewer from './components/PageViewer.vue';
import Navbar from './components/Navbar.vue';
import CreatePage from './components/CreatePage.vue';

export default {
    components: {
        Navbar,
        PageViewer,
        CreatePage,
    },
    created() {
        this.getPages()

        this.$bus.$on('navbarLinkActived', (index) => {
            this.activePage = index
        });
    },
    data() {
        return {
            activePage: 0,
            pages: []
        };
    },
    methods: {
        async getPages() {
            let res = await fetch("pages.json");
            let data = await res.json();

            this.pages = data
        },
        pageCreated(pageObj) {
            this.pages.push(pageObj);
        },
    }
}
</script>