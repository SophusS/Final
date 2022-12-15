const baseUri = "https://localhost:7294/api/purchases";

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
    },
    methods: {
        async helperGetPosts(uri) {
            try {
                var response = await axios.get(uri);
                this.output = await response.data;
                this.error = null;
            } catch (ex) {
                this.error = ex.message;
            }

        },
        async deleteById(id){
            if(id == null || id == ""){
                this.error = "error";
            }else{
                const uri = baseUri + "/" + id;
                await axios.delete(uri)
                window.location.href = 'index.html';

            }
        }
        
    }
}).mount("#app")