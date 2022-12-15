const baseUri = "https://localhost:7294/api/products";

Vue.createApp({
    data() {
        return {
            output: "",
            error: null,

        }
    },
    async created() {
        // created() is a life cycle method, not an ordinary method
        // created() is called automatically when the page is loaded
        console.log("created method called")
        this.helperGetPosts(baseUri)
        console.log(this.$route.query.id)
    },
    methods: {
        async helperGetPosts(uri) {
            try {
                let urlParams = new URLSearchParams(window.location.search);
                var response = await axios.get(uri + '/' + urlParams.get('id'));
                this.output = await response.data;
                this.error = null;
            } catch (ex) {
                this.error = ex.message;
            }

        },
        
    }
}).mount("#app")