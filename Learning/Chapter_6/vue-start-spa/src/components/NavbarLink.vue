<template>
    <li>
        <router-link
          :to="`/${index}`"
          :title="`This link goes to ${page.link.text} page`"
          aria-current="page"
          class="nav-link"
          active-class="active"
        >
            {{ page.link.text }}
        </router-link>
    </li>
</template>

<script>
export default {
    props: ["page", "index"],
}
</script>