<template>
    <div>
        <h1>{{message}}</h1>
        </div>
</template>

<script>
export default {
    name: 'first-component',
    data() {
        return {
            message: 'Our first component'
        }
    }
}
</script>
<style scoped>
h1 {
    color: blue
}
</style>