<template>
    <div class="row">
        <div class="col-md-6 offset-3">
            <b-form @submit="onSubmit" @reset="onReset" v-if="show">

                <b-form-group id="input-group-2" label="Enter amount:" label-for="input-2">
                    <b-form-input id="input-2"
                                  v-model.number="form.amount"
                                  required
                                  type="number"
                                  placeholder="Enter amount"></b-form-input>
                </b-form-group>

                <b-button type="submit" variant="primary" class="m-1">Submit</b-button>
                <b-button type="reset" variant="danger" class="m-1">Reset</b-button>
            </b-form>
            <b-card class="mt-3" header="Result">
                <pre class="m-0">{{ result }}</pre>
            </b-card>

        </div>
        
    </div>
</template>

<script>
    import axios from "axios"

    export default {
        data() {
            return {
                form: {
                    amount: Number
                    },
                result: {},
                show: true,
                url: "api/atm/"
                }
            },
    methods: {
      onSubmit(evt) {
            evt.preventDefault()
            var me = this;
            
            axios(this.url+this.form.amount).then(function (response) {
                me.result = response.data;
            }).catch(function (error) {
                
                if (error.response) {
                    me.result = error.response.data;
                }
                else {
                    me.result = error;
                }
            });
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.amount = null
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      }
    }
  }
</script>