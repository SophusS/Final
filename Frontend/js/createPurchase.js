const baseUri = "https://localhost:7294/api/purchases";

Vue.createApp({
    data() {
        return {
            output: "",
            error: null,
            purchaseId: ""

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
            try{
                var response = await axios.get(uri);
                this.output = await response.data;
                this.error = null;
                this.purchaseId = this.output.length + 1;
                this.createPurchase()

        


            } catch (ex) {
                this.error = ex.message;
            }

            
            
            

        },
        async createPurchase(){
            try{
                await axios.post(baseUri, {
                "purchaseId": this.purchaseId,
                "itemList": [],
                "amountList": [],
                "date": "2022-12-15T08:32:13.2700663+01:00",
                "isCurrent": true
            });
            console.log("test");
        } catch(ex){
            this.error = ex.message;

        }
            window.location.href = 'getIndividualPurchase.html?id=' + this.purchaseId;
        }
        
    }
}).mount("#app")