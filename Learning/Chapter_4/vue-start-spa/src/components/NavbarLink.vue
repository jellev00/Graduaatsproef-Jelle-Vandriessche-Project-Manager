<template>
    <a
      :href="page.link.url"
      :title="`This link goed to ${page.link.text} page`"
      aria-current="page"
      class="nav-link"
      :class="activeClasses"
      >{{ page.link.text }}</a
    >
</template>

<script>
export default {
    props: ["page", "isActive"],
    computed: {
        activeClasses() {
            return {
                active: this.isActive,
                emphasize: this.isActive
            };
        }
    }
}
</script>

<style scoped>
.emphasize {
    text-decoration: underline !important;
}
</style>